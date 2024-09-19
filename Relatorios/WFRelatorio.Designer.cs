namespace SISTEMA_DE_GESTÃO_LOJA.Relatorios
{
    partial class WFRelatorio
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.TxtNumeroFatura = new System.Windows.Forms.TextBox();
            this.BtnFatPesquisa = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISTEMA_DE_GESTÃO_LOJA.Relatorios.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(402, 568);
            this.reportViewer1.TabIndex = 0;
            // 
            // TxtNumeroFatura
            // 
            this.TxtNumeroFatura.Location = new System.Drawing.Point(133, 28);
            this.TxtNumeroFatura.Multiline = true;
            this.TxtNumeroFatura.Name = "TxtNumeroFatura";
            this.TxtNumeroFatura.ReadOnly = true;
            this.TxtNumeroFatura.Size = new System.Drawing.Size(95, 26);
            this.TxtNumeroFatura.TabIndex = 3;
            // 
            // BtnFatPesquisa
            // 
            this.BtnFatPesquisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BtnFatPesquisa.FlatAppearance.BorderSize = 0;
            this.BtnFatPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFatPesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFatPesquisa.ForeColor = System.Drawing.Color.Black;
            this.BtnFatPesquisa.Location = new System.Drawing.Point(303, 28);
            this.BtnFatPesquisa.Name = "BtnFatPesquisa";
            this.BtnFatPesquisa.Size = new System.Drawing.Size(116, 26);
            this.BtnFatPesquisa.TabIndex = 4;
            this.BtnFatPesquisa.Text = "Entrar com Id";
            this.BtnFatPesquisa.UseVisualStyleBackColor = false;
            this.BtnFatPesquisa.Click += new System.EventHandler(this.BtnFatPesquisa_Click);
            // 
            // WFRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 648);
            this.Controls.Add(this.BtnFatPesquisa);
            this.Controls.Add(this.TxtNumeroFatura);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "WFRelatorio";
            this.Text = "Fatura nº";
            this.Load += new System.EventHandler(this.ImprimirFaturaRel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox TxtNumeroFatura;
        private System.Windows.Forms.Button BtnFatPesquisa;
    }
}