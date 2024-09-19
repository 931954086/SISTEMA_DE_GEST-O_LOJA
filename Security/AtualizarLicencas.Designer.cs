namespace SISTEMA_DE_GESTÃO_LOJA.Security
{
    partial class WFAtualizarLicencas
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
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblMensagem = new System.Windows.Forms.Label();
            this.TxtParte4Chave = new System.Windows.Forms.TextBox();
            this.TxtParte3Chave = new System.Windows.Forms.TextBox();
            this.TxtParte2Chave = new System.Windows.Forms.TextBox();
            this.TxtParte1Chave = new System.Windows.Forms.TextBox();
            this.panelBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(207)))), ((int)(((byte)(223)))));
            this.panelBar.Controls.Add(this.BtnSalvar);
            this.panelBar.Controls.Add(this.BtnCancelar);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelBar.Location = new System.Drawing.Point(20, 60);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(762, 46);
            this.panelBar.TabIndex = 3;
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.FlatAppearance.BorderSize = 0;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.ForeColor = System.Drawing.Color.White;
            this.BtnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnSalvar.Location = new System.Drawing.Point(3, 3);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(104, 40);
            this.BtnSalvar.TabIndex = 7;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancelar.FlatAppearance.BorderSize = 0;
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.ForeColor = System.Drawing.Color.White;
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnCancelar.Location = new System.Drawing.Point(157, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 40);
            this.BtnCancelar.TabIndex = 8;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblMensagem);
            this.panel1.Controls.Add(this.TxtParte4Chave);
            this.panel1.Controls.Add(this.TxtParte3Chave);
            this.panel1.Controls.Add(this.TxtParte2Chave);
            this.panel1.Controls.Add(this.TxtParte1Chave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(20, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 298);
            this.panel1.TabIndex = 19;
            // 
            // LblMensagem
            // 
            this.LblMensagem.AutoSize = true;
            this.LblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensagem.ForeColor = System.Drawing.Color.Gray;
            this.LblMensagem.Location = new System.Drawing.Point(14, 14);
            this.LblMensagem.Name = "LblMensagem";
            this.LblMensagem.Size = new System.Drawing.Size(537, 100);
            this.LblMensagem.TabIndex = 30;
            this.LblMensagem.Text = "Caro usuário, notamos que a sua licença expirou \r\nentão se pretende continuar, de" +
    "ves atualizar a licença \r\npara desfrutar dos nossos serviços...\r\n\r\n";
            // 
            // TxtParte4Chave
            // 
            this.TxtParte4Chave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParte4Chave.Location = new System.Drawing.Point(501, 177);
            this.TxtParte4Chave.MaxLength = 5;
            this.TxtParte4Chave.Multiline = true;
            this.TxtParte4Chave.Name = "TxtParte4Chave";
            this.TxtParte4Chave.Size = new System.Drawing.Size(109, 37);
            this.TxtParte4Chave.TabIndex = 28;
            this.TxtParte4Chave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtParte3Chave
            // 
            this.TxtParte3Chave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParte3Chave.Location = new System.Drawing.Point(391, 177);
            this.TxtParte3Chave.MaxLength = 5;
            this.TxtParte3Chave.Multiline = true;
            this.TxtParte3Chave.Name = "TxtParte3Chave";
            this.TxtParte3Chave.Size = new System.Drawing.Size(109, 37);
            this.TxtParte3Chave.TabIndex = 27;
            this.TxtParte3Chave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtParte2Chave
            // 
            this.TxtParte2Chave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParte2Chave.Location = new System.Drawing.Point(281, 177);
            this.TxtParte2Chave.MaxLength = 5;
            this.TxtParte2Chave.Multiline = true;
            this.TxtParte2Chave.Name = "TxtParte2Chave";
            this.TxtParte2Chave.Size = new System.Drawing.Size(109, 37);
            this.TxtParte2Chave.TabIndex = 26;
            this.TxtParte2Chave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtParte1Chave
            // 
            this.TxtParte1Chave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtParte1Chave.Location = new System.Drawing.Point(171, 177);
            this.TxtParte1Chave.MaxLength = 5;
            this.TxtParte1Chave.Multiline = true;
            this.TxtParte1Chave.Name = "TxtParte1Chave";
            this.TxtParte1Chave.Size = new System.Drawing.Size(109, 37);
            this.TxtParte1Chave.TabIndex = 25;
            this.TxtParte1Chave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // WFAtualizarLicencas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 424);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBar);
            this.MaximizeBox = false;
            this.Name = "WFAtualizarLicencas";
            this.Text = "Atualizar Licença";
            this.Load += new System.EventHandler(this.RegistarLicencas_Load);
            this.panelBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblMensagem;
        private System.Windows.Forms.TextBox TxtParte4Chave;
        private System.Windows.Forms.TextBox TxtParte3Chave;
        private System.Windows.Forms.TextBox TxtParte2Chave;
        private System.Windows.Forms.TextBox TxtParte1Chave;
    }
}