namespace Cliente
{
    partial class Frm_Cliente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_Mensaje = new System.Windows.Forms.TextBox();
            this.Bnt_Enviar = new System.Windows.Forms.Button();
            this.Btn_Conectar = new System.Windows.Forms.Button();
            this.Txt_Servidor = new System.Windows.Forms.TextBox();
            this.Btn_Desconectar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Txt_Mensaje
            // 
            this.Txt_Mensaje.Location = new System.Drawing.Point(4, 54);
            this.Txt_Mensaje.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Mensaje.Multiline = true;
            this.Txt_Mensaje.Name = "Txt_Mensaje";
            this.Txt_Mensaje.Size = new System.Drawing.Size(686, 197);
            this.Txt_Mensaje.TabIndex = 0;
            // 
            // Bnt_Enviar
            // 
            this.Bnt_Enviar.Location = new System.Drawing.Point(580, 264);
            this.Bnt_Enviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Bnt_Enviar.Name = "Bnt_Enviar";
            this.Bnt_Enviar.Size = new System.Drawing.Size(110, 28);
            this.Bnt_Enviar.TabIndex = 1;
            this.Bnt_Enviar.Text = "&Enviar";
            this.Bnt_Enviar.UseVisualStyleBackColor = true;
            this.Bnt_Enviar.Click += new System.EventHandler(this.Bnt_Enviar_Click);
            // 
            // Btn_Conectar
            // 
            this.Btn_Conectar.Location = new System.Drawing.Point(512, 11);
            this.Btn_Conectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Conectar.Name = "Btn_Conectar";
            this.Btn_Conectar.Size = new System.Drawing.Size(82, 31);
            this.Btn_Conectar.TabIndex = 2;
            this.Btn_Conectar.Text = "&Conectar";
            this.Btn_Conectar.UseVisualStyleBackColor = true;
            this.Btn_Conectar.Click += new System.EventHandler(this.Btn_Conectar_Click);
            // 
            // Txt_Servidor
            // 
            this.Txt_Servidor.Location = new System.Drawing.Point(4, 14);
            this.Txt_Servidor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Servidor.Name = "Txt_Servidor";
            this.Txt_Servidor.Size = new System.Drawing.Size(502, 23);
            this.Txt_Servidor.TabIndex = 3;
            // 
            // Btn_Desconectar
            // 
            this.Btn_Desconectar.Location = new System.Drawing.Point(599, 11);
            this.Btn_Desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Desconectar.Name = "Btn_Desconectar";
            this.Btn_Desconectar.Size = new System.Drawing.Size(91, 31);
            this.Btn_Desconectar.TabIndex = 4;
            this.Btn_Desconectar.Text = "&Desconectar";
            this.Btn_Desconectar.UseVisualStyleBackColor = true;
            this.Btn_Desconectar.Click += new System.EventHandler(this.Btn_Desconectar_Click);
            // 
            // Frm_Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 314);
            this.Controls.Add(this.Btn_Desconectar);
            this.Controls.Add(this.Txt_Servidor);
            this.Controls.Add(this.Btn_Conectar);
            this.Controls.Add(this.Bnt_Enviar);
            this.Controls.Add(this.Txt_Mensaje);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Frm_Cliente";
            this.Text = "Peticiones de Cliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Txt_Mensaje;
        private Button Bnt_Enviar;
        private Button Btn_Conectar;
        private TextBox Txt_Servidor;
        private Button Btn_Desconectar;
    }
}