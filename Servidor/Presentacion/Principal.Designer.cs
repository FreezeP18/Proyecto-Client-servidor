namespace Servidor
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Txt_Mensajes = new System.Windows.Forms.TextBox();
            this.Lbl_Clientes = new System.Windows.Forms.Label();
            this.Txt_Clientes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Txt_Mensajes
            // 
            this.Txt_Mensajes.Location = new System.Drawing.Point(12, 106);
            this.Txt_Mensajes.Multiline = true;
            this.Txt_Mensajes.Name = "Txt_Mensajes";
            this.Txt_Mensajes.Size = new System.Drawing.Size(755, 335);
            this.Txt_Mensajes.TabIndex = 0;
            // 
            // Lbl_Clientes
            // 
            this.Lbl_Clientes.AutoSize = true;
            this.Lbl_Clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Clientes.Location = new System.Drawing.Point(171, 47);
            this.Lbl_Clientes.Name = "Lbl_Clientes";
            this.Lbl_Clientes.Size = new System.Drawing.Size(236, 29);
            this.Lbl_Clientes.TabIndex = 1;
            this.Lbl_Clientes.Text = "Clientes Conectados";
            // 
            // Txt_Clientes
            // 
            this.Txt_Clientes.Enabled = false;
            this.Txt_Clientes.Location = new System.Drawing.Point(427, 53);
            this.Txt_Clientes.Name = "Txt_Clientes";
            this.Txt_Clientes.Size = new System.Drawing.Size(185, 22);
            this.Txt_Clientes.TabIndex = 2;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 463);
            this.Controls.Add(this.Txt_Clientes);
            this.Controls.Add(this.Lbl_Clientes);
            this.Controls.Add(this.Txt_Mensajes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Principal";
            this.Text = "Servidor";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Mensajes;
        private System.Windows.Forms.Label Lbl_Clientes;
        private System.Windows.Forms.TextBox Txt_Clientes;
    }
}

