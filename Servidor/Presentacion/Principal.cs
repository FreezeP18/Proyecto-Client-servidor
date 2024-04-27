using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace Servidor
{
    public partial class Principal : Form
    {
        #region Atributos
        private TcpListener tcpListener;
        private Thread listenThread;
        private String lastMessage;
        private int clientesConectados;
        #endregion

        // Arreglos para representar la disponibilidad de los asientos para cada tipo de viaje
        private bool[,] asientosDisponiblesAB = new bool[15, 5];
        private bool[,] asientosDisponiblesBA = new bool[15, 5];
        private int costo;


        // Cantidad máxima de boletos que se pueden comprar por conexión
        private const int MaxBoletosPorConexion = 5;

        public Principal()
        {
            InitializeComponent();
            InicializarAsientosDisponibles();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            Txt_Mensajes.Text = "Servidor Iniciado. Esperando por clientes...\n";
            this.tcpListener = new TcpListener(IPAddress.Any, 30000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();
            while (true)
            {
                TcpClient client = this.tcpListener.AcceptTcpClient();
                clientesConectados++;

                if (InvokeRequired)
                    Invoke(new Action(() => Txt_Clientes.Text = clientesConectados.ToString()));
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;
                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    // Error de socket
                }

                if (bytesRead == 0)
                {
                    clientesConectados--;

                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => Txt_Clientes.Text = clientesConectados.ToString()));
                    }
                    break;
                }

                string mensajeRecibido = encoder.GetString(message, 0, bytesRead);
                System.Diagnostics.Debug.WriteLine(mensajeRecibido);

                if (mensajeRecibido.Length == 3 && mensajeRecibido.All(char.IsDigit))
                {
                    string codigoViaje = mensajeRecibido.Substring(0, 2);
                    int cantidadAsientos = Convert.ToInt32(mensajeRecibido.Substring(2));

                    string respuesta = GenerarRespuesta(codigoViaje, cantidadAsientos);
                    byte[] buffer = encoder.GetBytes(respuesta);
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                }
                else
                {
                    byte[] buffer = encoder.GetBytes("Formato de mensaje incorrecto");
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                }
            }
        }

        private void InicializarAsientosDisponibles()
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    asientosDisponiblesAB[i, j] = true;
                    asientosDisponiblesBA[i, j] = true;
                }

            }
        }

        private void ImprimirMatriz(bool[,] asientosDisponibles)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    sb.Append(asientosDisponibles[i, j] ? "O " : "X ");
                }
                sb.AppendLine();
            }
            MessageBox.Show(sb.ToString(), "Estado de los asientos");
        }

        private string GenerarRespuesta(string codigoViaje, int cantidadAsientos)
        {
            
            int costo = 0;

            if (cantidadAsientos <= 0)
            {
                return "0"; 
            }
            else if (cantidadAsientos > MaxBoletosPorConexion)
            {
                return "3"; 
            }

            bool[,] asientosDisponibles;
            if (codigoViaje == "01")
            {
                asientosDisponibles = asientosDisponiblesAB; 
                costo = 3500 * cantidadAsientos; 
            }
            else if (codigoViaje == "02")
            {
                asientosDisponibles = asientosDisponiblesBA; 
                costo = 4000 * cantidadAsientos; 
            }
            else
            {
                return "0"; 
            }

       
            List<string> asientosReservados = new List<string>();

            int fila = -1;
            int columna = -1;

      
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (asientosDisponibles[i, j])
                    {
                
                        asientosDisponibles[i, j] = false;

                        fila = i + 1; 
                        columna = j + 1; 

                        
                        asientosReservados.Add(string.Format("{0}{1}", fila, columna));

                        
                        if (asientosReservados.Count == cantidadAsientos)
                        {
                            
                            string respuestaServidor = string.Format("1-{0}-{1}-{2}-{3}", codigoViaje, fila, cantidadAsientos == 1 ? "1" : new string('1', cantidadAsientos), costo);

                            
                            string respuestaCliente = string.Format("1{0}{1}{2}{3}", codigoViaje, fila, cantidadAsientos == 1 ? "1" : new string('1', cantidadAsientos), costo);

                            
                            Txt_Mensajes.Invoke((MethodInvoker)delegate
                            {
                                Txt_Mensajes.AppendText(Environment.NewLine + respuestaServidor + Environment.NewLine);
                            });
                           
                            ImprimirMatriz(asientosDisponiblesAB);
                            ImprimirMatriz(asientosDisponiblesBA);
                            return respuestaCliente; 
                        }
                    }
                }
            }

          
            return "0";
        }








    }
}
