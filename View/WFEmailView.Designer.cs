namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFEmailView
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
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.LblRemetente = new System.Windows.Forms.Label();
            this.TxtRemetente = new System.Windows.Forms.TextBox();
            this.LblDestinatario = new System.Windows.Forms.Label();
            this.TxtDestinatario = new System.Windows.Forms.TextBox();
            this.LblAssunto = new System.Windows.Forms.Label();
            this.TxtAssunto = new System.Windows.Forms.TextBox();
            this.LblMensagem = new System.Windows.Forms.Label();
            this.TxtMensagem = new System.Windows.Forms.TextBox();
            this.LblAnexo = new System.Windows.Forms.Label();
            this.TxtAnexo = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.BtnEnviar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 50);
            this.panel2.TabIndex = 98;
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
            this.BtnCancelar.Location = new System.Drawing.Point(142, 5);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(125, 40);
            this.BtnCancelar.TabIndex = 100;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnviar.FlatAppearance.BorderSize = 0;
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEnviar.ForeColor = System.Drawing.Color.White;
            this.BtnEnviar.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.icons8_Plus_48px;
            this.BtnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEnviar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnEnviar.Location = new System.Drawing.Point(3, 3);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(108, 44);
            this.BtnEnviar.TabIndex = 98;
            this.BtnEnviar.Text = "&Enviar";
            this.BtnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // LblRemetente
            // 
            this.LblRemetente.AutoSize = true;
            this.LblRemetente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRemetente.ForeColor = System.Drawing.Color.DimGray;
            this.LblRemetente.Location = new System.Drawing.Point(19, 154);
            this.LblRemetente.Name = "LblRemetente";
            this.LblRemetente.Size = new System.Drawing.Size(107, 24);
            this.LblRemetente.TabIndex = 100;
            this.LblRemetente.Text = "Remetente:";
            // 
            // TxtRemetente
            // 
            this.TxtRemetente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRemetente.Location = new System.Drawing.Point(23, 181);
            this.TxtRemetente.Multiline = true;
            this.TxtRemetente.Name = "TxtRemetente";
            this.TxtRemetente.Size = new System.Drawing.Size(378, 35);
            this.TxtRemetente.TabIndex = 99;
            // 
            // LblDestinatario
            // 
            this.LblDestinatario.AutoSize = true;
            this.LblDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDestinatario.ForeColor = System.Drawing.Color.DimGray;
            this.LblDestinatario.Location = new System.Drawing.Point(19, 230);
            this.LblDestinatario.Name = "LblDestinatario";
            this.LblDestinatario.Size = new System.Drawing.Size(112, 24);
            this.LblDestinatario.TabIndex = 102;
            this.LblDestinatario.Text = "Destinatário:";
            // 
            // TxtDestinatario
            // 
            this.TxtDestinatario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDestinatario.Location = new System.Drawing.Point(23, 257);
            this.TxtDestinatario.Multiline = true;
            this.TxtDestinatario.Name = "TxtDestinatario";
            this.TxtDestinatario.Size = new System.Drawing.Size(378, 35);
            this.TxtDestinatario.TabIndex = 101;
            // 
            // LblAssunto
            // 
            this.LblAssunto.AutoSize = true;
            this.LblAssunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAssunto.ForeColor = System.Drawing.Color.DimGray;
            this.LblAssunto.Location = new System.Drawing.Point(19, 305);
            this.LblAssunto.Name = "LblAssunto";
            this.LblAssunto.Size = new System.Drawing.Size(83, 24);
            this.LblAssunto.TabIndex = 104;
            this.LblAssunto.Text = "Assunto:";
            // 
            // TxtAssunto
            // 
            this.TxtAssunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAssunto.Location = new System.Drawing.Point(23, 332);
            this.TxtAssunto.Multiline = true;
            this.TxtAssunto.Name = "TxtAssunto";
            this.TxtAssunto.Size = new System.Drawing.Size(378, 35);
            this.TxtAssunto.TabIndex = 103;
            // 
            // LblMensagem
            // 
            this.LblMensagem.AutoSize = true;
            this.LblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensagem.ForeColor = System.Drawing.Color.DimGray;
            this.LblMensagem.Location = new System.Drawing.Point(407, 154);
            this.LblMensagem.Name = "LblMensagem";
            this.LblMensagem.Size = new System.Drawing.Size(195, 24);
            this.LblMensagem.TabIndex = 106;
            this.LblMensagem.Text = "Mensagem de Texto: ";
            // 
            // TxtMensagem
            // 
            this.TxtMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtMensagem.Location = new System.Drawing.Point(411, 181);
            this.TxtMensagem.Multiline = true;
            this.TxtMensagem.Name = "TxtMensagem";
            this.TxtMensagem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtMensagem.Size = new System.Drawing.Size(507, 306);
            this.TxtMensagem.TabIndex = 105;
            // 
            // LblAnexo
            // 
            this.LblAnexo.AutoSize = true;
            this.LblAnexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAnexo.ForeColor = System.Drawing.Color.DimGray;
            this.LblAnexo.Location = new System.Drawing.Point(19, 425);
            this.LblAnexo.Name = "LblAnexo";
            this.LblAnexo.Size = new System.Drawing.Size(71, 24);
            this.LblAnexo.TabIndex = 108;
            this.LblAnexo.Text = "Anexo:";
            // 
            // TxtAnexo
            // 
            this.TxtAnexo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TxtAnexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAnexo.Location = new System.Drawing.Point(23, 452);
            this.TxtAnexo.Multiline = true;
            this.TxtAnexo.Name = "TxtAnexo";
            this.TxtAnexo.Size = new System.Drawing.Size(378, 35);
            this.TxtAnexo.TabIndex = 107;
            // 
            // WFEmailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 546);
            this.Controls.Add(this.LblAnexo);
            this.Controls.Add(this.TxtAnexo);
            this.Controls.Add(this.LblMensagem);
            this.Controls.Add(this.TxtMensagem);
            this.Controls.Add(this.LblAssunto);
            this.Controls.Add(this.TxtAssunto);
            this.Controls.Add(this.LblDestinatario);
            this.Controls.Add(this.TxtDestinatario);
            this.Controls.Add(this.LblRemetente);
            this.Controls.Add(this.TxtRemetente);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "WFEmailView";
            this.Text = "Compor Email";
            this.Load += new System.EventHandler(this.WFEmailView_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Label LblRemetente;
        private System.Windows.Forms.TextBox TxtRemetente;
        private System.Windows.Forms.Label LblDestinatario;
        private System.Windows.Forms.TextBox TxtDestinatario;
        private System.Windows.Forms.Label LblAssunto;
        private System.Windows.Forms.TextBox TxtAssunto;
        private System.Windows.Forms.Label LblMensagem;
        private System.Windows.Forms.TextBox TxtMensagem;
        private System.Windows.Forms.Label LblAnexo;
        private System.Windows.Forms.TextBox TxtAnexo;
    }
}