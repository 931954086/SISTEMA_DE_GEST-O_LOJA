namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFRecuperarSenhaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSolicitar = new System.Windows.Forms.Button();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblSenha = new System.Windows.Forms.Label();
            this.TxtResultadoSenha = new System.Windows.Forms.TextBox();
            this.LblMensagemTexto = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.BtnSolicitar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 50);
            this.panel2.TabIndex = 99;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Cancel_36px;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnCancelar.Location = new System.Drawing.Point(218, 5);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(131, 40);
            this.BtnCancelar.TabIndex = 100;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnSolicitar
            // 
            this.BtnSolicitar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSolicitar.FlatAppearance.BorderSize = 0;
            this.BtnSolicitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSolicitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSolicitar.ForeColor = System.Drawing.Color.White;
            this.BtnSolicitar.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.icons8_Plus_48px;
            this.BtnSolicitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSolicitar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnSolicitar.Location = new System.Drawing.Point(3, 3);
            this.BtnSolicitar.Name = "BtnSolicitar";
            this.BtnSolicitar.Size = new System.Drawing.Size(131, 44);
            this.BtnSolicitar.TabIndex = 98;
            this.BtnSolicitar.Text = "&Solicitar ";
            this.BtnSolicitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSolicitar.UseVisualStyleBackColor = true;
            this.BtnSolicitar.Click += new System.EventHandler(this.BtnSolicitar_Click);
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.ForeColor = System.Drawing.Color.DimGray;
            this.LblEmail.Location = new System.Drawing.Point(74, 174);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(67, 24);
            this.LblEmail.TabIndex = 102;
            this.LblEmail.Text = "Email: ";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(181, 174);
            this.TxtEmail.Multiline = true;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(379, 35);
            this.TxtEmail.TabIndex = 101;
            // 
            // LblSenha
            // 
            this.LblSenha.AutoSize = true;
            this.LblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenha.ForeColor = System.Drawing.Color.DimGray;
            this.LblSenha.Location = new System.Drawing.Point(74, 258);
            this.LblSenha.Name = "LblSenha";
            this.LblSenha.Size = new System.Drawing.Size(104, 24);
            this.LblSenha.TabIndex = 104;
            this.LblSenha.Text = "Resultado: ";
            // 
            // TxtResultadoSenha
            // 
            this.TxtResultadoSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtResultadoSenha.Location = new System.Drawing.Point(181, 251);
            this.TxtResultadoSenha.Multiline = true;
            this.TxtResultadoSenha.Name = "TxtResultadoSenha";
            this.TxtResultadoSenha.Size = new System.Drawing.Size(379, 35);
            this.TxtResultadoSenha.TabIndex = 103;
            // 
            // LblMensagemTexto
            // 
            this.LblMensagemTexto.AutoSize = true;
            this.LblMensagemTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensagemTexto.ForeColor = System.Drawing.Color.Blue;
            this.LblMensagemTexto.Location = new System.Drawing.Point(88, 324);
            this.LblMensagemTexto.Name = "LblMensagemTexto";
            this.LblMensagemTexto.Size = new System.Drawing.Size(10, 24);
            this.LblMensagemTexto.TabIndex = 107;
            this.LblMensagemTexto.Text = "\r\n";
            // 
            // WFRecuperarSenhaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 546);
            this.Controls.Add(this.LblMensagemTexto);
            this.Controls.Add(this.LblSenha);
            this.Controls.Add(this.TxtResultadoSenha);
            this.Controls.Add(this.LblEmail);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "WFRecuperarSenhaView";
            this.Text = "Recuperar Senha";
            this.Load += new System.EventHandler(this.WFRecuperarSenhaView_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnSolicitar;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblSenha;
        private System.Windows.Forms.TextBox TxtResultadoSenha;
        private System.Windows.Forms.Label LblMensagemTexto;
    }
}