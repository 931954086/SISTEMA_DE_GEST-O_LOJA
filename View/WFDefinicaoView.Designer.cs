namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFDefinicaoView
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
            this.BtnMetas = new FontAwesome.Sharp.IconButton();
            this.BtnSenha = new FontAwesome.Sharp.IconButton();
            this.BtnEmail = new FontAwesome.Sharp.IconButton();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panelBar.Controls.Add(this.BtnMetas);
            this.panelBar.Controls.Add(this.BtnSenha);
            this.panelBar.Controls.Add(this.BtnEmail);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelBar.Location = new System.Drawing.Point(20, 60);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(387, 40);
            this.panelBar.TabIndex = 98;
            // 
            // BtnMetas
            // 
            this.BtnMetas.FlatAppearance.BorderSize = 0;
            this.BtnMetas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMetas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMetas.ForeColor = System.Drawing.Color.White;
            this.BtnMetas.IconChar = FontAwesome.Sharp.IconChar.M;
            this.BtnMetas.IconColor = System.Drawing.Color.White;
            this.BtnMetas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnMetas.IconSize = 32;
            this.BtnMetas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMetas.Location = new System.Drawing.Point(117, 4);
            this.BtnMetas.Name = "BtnMetas";
            this.BtnMetas.Size = new System.Drawing.Size(83, 32);
            this.BtnMetas.TabIndex = 102;
            this.BtnMetas.Text = "ETAS";
            this.BtnMetas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMetas.UseVisualStyleBackColor = true;
            // 
            // BtnSenha
            // 
            this.BtnSenha.FlatAppearance.BorderSize = 0;
            this.BtnSenha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSenha.ForeColor = System.Drawing.Color.White;
            this.BtnSenha.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.BtnSenha.IconColor = System.Drawing.Color.White;
            this.BtnSenha.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnSenha.IconSize = 32;
            this.BtnSenha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSenha.Location = new System.Drawing.Point(4, 4);
            this.BtnSenha.Name = "BtnSenha";
            this.BtnSenha.Size = new System.Drawing.Size(88, 33);
            this.BtnSenha.TabIndex = 101;
            this.BtnSenha.Text = "Senha";
            this.BtnSenha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSenha.UseVisualStyleBackColor = true;
            this.BtnSenha.Click += new System.EventHandler(this.BtnSenha_Click);
            // 
            // BtnEmail
            // 
            this.BtnEmail.FlatAppearance.BorderSize = 0;
            this.BtnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEmail.ForeColor = System.Drawing.Color.White;
            this.BtnEmail.IconChar = FontAwesome.Sharp.IconChar.Envelope;
            this.BtnEmail.IconColor = System.Drawing.Color.White;
            this.BtnEmail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnEmail.IconSize = 32;
            this.BtnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEmail.Location = new System.Drawing.Point(217, 4);
            this.BtnEmail.Name = "BtnEmail";
            this.BtnEmail.Size = new System.Drawing.Size(85, 33);
            this.BtnEmail.TabIndex = 100;
            this.BtnEmail.Text = "Email";
            this.BtnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEmail.UseVisualStyleBackColor = true;
            this.BtnEmail.Click += new System.EventHandler(this.BtnEmail_Click);
            // 
            // WFDefinicaoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 200);
            this.Controls.Add(this.panelBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WFDefinicaoView";
            this.Text = "Definições";
            this.Load += new System.EventHandler(this.WFDefinicaoView_Load);
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
        private FontAwesome.Sharp.IconButton BtnEmail;
        private FontAwesome.Sharp.IconButton BtnSenha;
        private FontAwesome.Sharp.IconButton BtnMetas;
    }
}