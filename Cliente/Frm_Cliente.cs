using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Threading;
using System.Net;


namespace Cliente
{

    public partial class Frm_Cliente : Form
    {
        TcpClient client = new TcpClient();
        ASCIIEncoding encoder = new ASCIIEncoding();
        NetworkStream stream = null;
        byte[] buffer;
        string message = "";


        public Frm_Cliente()
        {
            InitializeComponent();
        }

        private void Btn_Conectar_Click(object sender, EventArgs e)
        {
            Btn_Conectar.Enabled = false;
           

            if (Txt_Servidor.Text == "")
                {
                    MessageBox.Show("Por favor ingrese una dirección IP para el servidor", "Error al conectar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
            {
                if (!client.Connected)
                {
                    try
                    {
                        client = new TcpClient();
                        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(Txt_Servidor.Text),30000);
                        client.Connect(serverEndPoint);
                        NetworkStream clientStream = client.GetStream();
                        buffer = encoder.GetBytes("Hello Server!");
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();

                        byte[] message2 = new byte[4096];
                        int bytesRead = clientStream.Read(message2, 0, 4096);

                        MessageBox.Show("Conexión Realizada con Exito");

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        client.Close();
                        
   
                    }
                    catch (Exception Exc)
                    {
                        MessageBox.Show(Exc.ToString());
                    }
                }
            }
        }

        private void Btn_Desconectar_Click(object sender, EventArgs e)
        {
            Btn_Conectar.Enabled = true;
            if (client.Connected)
                try
                {
                    client.Close();
                    MessageBox.Show("Desconexión Realizada con Exito");

                }
                catch (Exception Exc)
                {
                    MessageBox.Show(Exc.ToString());
                }
            
        }

        private void Bnt_Enviar_Click(object sender, EventArgs e)
        {
            NetworkStream clientStream = client.GetStream();
            buffer = encoder.GetBytes(Txt_Mensaje.Text.Trim());
            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();


            byte[] message2 = new byte[4096];
            int bytesRead = clientStream.Read(message2, 0, 4096);

            encoder.GetString(message2, 0, bytesRead);
            Txt_Mensaje.Text = encoder.GetString(message2, 0, bytesRead).ToString();
        }
    }
}