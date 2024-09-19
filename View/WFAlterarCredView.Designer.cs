namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFCredView
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
            this.LblConfirmarSenha = new System.Windows.Forms.Label();
            this.LblSenha = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.LblSenhadecod = new System.Windows.Forms.Label();
            this.checkBoxVerSenha = new System.Windows.Forms.CheckBox();
            this.TxtSenha = new System.Windows.Forms.MaskedTextBox();
            this.TxtConfirmarSenha = new System.Windows.Forms.MaskedTextBox();
            this.LblMensagem = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.LblUsuario = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblConfirmarSenha
            // 
            this.LblConfirmarSenha.AutoSize = true;
            this.LblConfirmarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConfirmarSenha.ForeColor = System.Drawing.Color.DimGray;
            this.LblConfirmarSenha.Location = new System.Drawing.Point(53, 369);
            this.LblConfirmarSenha.Name = "LblConfirmarSenha";
            this.LblConfirmarSenha.Size = new System.Drawing.Size(158, 24);
            this.LblConfirmarSenha.TabIndex = 2;
            this.LblConfirmarSenha.Text = "Confirme a senha";
            // 
            // LblSenha
            // 
            this.LblSenha.AutoSize = true;
            this.LblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenha.ForeColor = System.Drawing.Color.DimGray;
            this.LblSenha.Location = new System.Drawing.Point(53, 266);
            this.LblSenha.Name = "LblSenha";
            this.LblSenha.Size = new System.Drawing.Size(65, 24);
            this.LblSenha.TabIndex = 3;
            this.LblSenha.Text = "Senha";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel2.Controls.Add(this.BtnCancelar);
            this.panel2.Controls.Add(this.BtnSalvar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(20, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 50);
            this.panel2.TabIndex = 97;
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
            this.BtnCancelar.Location = new System.Drawing.Point(174, 5);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(125, 40);
            this.BtnCancelar.TabIndex = 100;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            // 
            // BtnSalvar
            // 
            this.BtnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSalvar.FlatAppearance.BorderSize = 0;
            this.BtnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalvar.ForeColor = System.Drawing.Color.White;
            this.BtnSalvar.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.icons8_Plus_48px;
            this.BtnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnSalvar.Location = new System.Drawing.Point(3, 3);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(108, 44);
            this.BtnSalvar.TabIndex = 98;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // LblSenhadecod
            // 
            this.LblSenhadecod.AutoSize = true;
            this.LblSenhadecod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenhadecod.ForeColor = System.Drawing.Color.Firebrick;
            this.LblSenhadecod.Location = new System.Drawing.Point(164, 335);
            this.LblSenhadecod.Name = "LblSenhadecod";
            this.LblSenhadecod.Size = new System.Drawing.Size(0, 20);
            this.LblSenhadecod.TabIndex = 120;
            // 
            // checkBoxVerSenha
            // 
            this.checkBoxVerSenha.AutoSize = true;
            this.checkBoxVerSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVerSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.checkBoxVerSenha.Location = new System.Drawing.Point(57, 335);
            this.checkBoxVerSenha.Name = "checkBoxVerSenha";
            this.checkBoxVerSenha.Size = new System.Drawing.Size(96, 22);
            this.checkBoxVerSenha.TabIndex = 119;
            this.checkBoxVerSenha.Text = "Ver senha!";
            this.checkBoxVerSenha.UseVisualStyleBackColor = true;
            this.checkBoxVerSenha.CheckedChanged += new System.EventHandler(this.checkBoxVerSenha_CheckedChanged);
            // 
            // TxtSenha
            // 
            this.TxtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSenha.Location = new System.Drawing.Point(57, 294);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(349, 35);
            this.TxtSenha.TabIndex = 118;
            this.TxtSenha.UseSystemPasswordChar = true;
            // 
            // TxtConfirmarSenha
            // 
            this.TxtConfirmarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfirmarSenha.Location = new System.Drawing.Point(57, 396);
            this.TxtConfirmarSenha.Name = "TxtConfirmarSenha";
            this.TxtConfirmarSenha.Size = new System.Drawing.Size(349, 35);
            this.TxtConfirmarSenha.TabIndex = 121;
            this.TxtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // LblMensagem
            // 
            this.LblMensagem.AutoSize = true;
            this.LblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMensagem.ForeColor = System.Drawing.Color.Blue;
            this.LblMensagem.Location = new System.Drawing.Point(53, 440);
            this.LblMensagem.Name = "LblMensagem";
            this.LblMensagem.Size = new System.Drawing.Size(0, 24);
            this.LblMensagem.TabIndex = 122;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(57, 220);
            this.TxtUsuario.Multiline = true;
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(349, 35);
            this.TxtUsuario.TabIndex = 124;
            // 
            // LblUsuario
            // 
            this.LblUsuario.AutoSize = true;
            this.LblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.LblUsuario.Location = new System.Drawing.Point(53, 193);
            this.LblUsuario.Name = "LblUsuario";
            this.LblUsuario.Size = new System.Drawing.Size(74, 24);
            this.LblUsuario.TabIndex = 125;
            this.LblUsuario.Text = "Usuário";
            // 
            // WFCredView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 546);
            this.Controls.Add(this.LblUsuario);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.LblMensagem);
            this.Controls.Add(this.TxtConfirmarSenha);
            this.Controls.Add(this.LblSenhadecod);
            this.Controls.Add(this.checkBoxVerSenha);
            this.Controls.Add(this.TxtSenha);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LblSenha);
            this.Controls.Add(this.LblConfirmarSenha);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WFCredView";
            this.Text = "Minhas Credências";
            this.Load += new System.EventHandler(this.WFCredView_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LblConfirmarSenha;
        private System.Windows.Forms.Label LblSenha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Label LblSenhadecod;
        private System.Windows.Forms.CheckBox checkBoxVerSenha;
        private System.Windows.Forms.MaskedTextBox TxtSenha;
        private System.Windows.Forms.MaskedTextBox TxtConfirmarSenha;
        private System.Windows.Forms.Label LblMensagem;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label LblUsuario;
    }
}