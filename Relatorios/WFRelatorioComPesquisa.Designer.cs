namespace SISTEMA_DE_GESTÃO_LOJA.Relatorios
{
    partial class WFRelatorioComPesquisa
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
            this.TxtPesquisaNum = new System.Windows.Forms.TextBox();
            this.IconBtnPesquisar = new FontAwesome.Sharp.IconButton();
            this.IconBtnLimpar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SISTEMA_DE_GESTÃO_LOJA.Relatorios.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(20, 60);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(402, 601);
            this.reportViewer1.TabIndex = 0;
            // 
            // TxtPesquisaNum
            // 
            this.TxtPesquisaNum.Location = new System.Drawing.Point(124, 28);
            this.TxtPesquisaNum.Multiline = true;
            this.TxtPesquisaNum.Name = "TxtPesquisaNum";
            this.TxtPesquisaNum.Size = new System.Drawing.Size(198, 26);
            this.TxtPesquisaNum.TabIndex = 2;
            // 
            // IconBtnPesquisar
            // 
            this.IconBtnPesquisar.FlatAppearance.BorderSize = 0;
            this.IconBtnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconBtnPesquisar.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.IconBtnPesquisar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.IconBtnPesquisar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconBtnPesquisar.IconSize = 32;
            this.IconBtnPesquisar.Location = new System.Drawing.Point(328, 30);
            this.IconBtnPesquisar.Name = "IconBtnPesquisar";
            this.IconBtnPesquisar.Size = new System.Drawing.Size(41, 26);
            this.IconBtnPesquisar.TabIndex = 4;
            this.IconBtnPesquisar.UseVisualStyleBackColor = true;
            this.IconBtnPesquisar.Click += new System.EventHandler(this.IconBtnPesquisar_Click);
            // 
            // IconBtnLimpar
            // 
            this.IconBtnLimpar.FlatAppearance.BorderSize = 0;
            this.IconBtnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IconBtnLimpar.IconChar = FontAwesome.Sharp.IconChar.Backspace;
            this.IconBtnLimpar.IconColor = System.Drawing.Color.Red;
            this.IconBtnLimpar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.IconBtnLimpar.IconSize = 32;
            this.IconBtnLimpar.Location = new System.Drawing.Point(377, 30);
            this.IconBtnLimpar.Name = "IconBtnLimpar";
            this.IconBtnLimpar.Size = new System.Drawing.Size(42, 25);
            this.IconBtnLimpar.TabIndex = 5;
            this.IconBtnLimpar.UseVisualStyleBackColor = true;
            this.IconBtnLimpar.Click += new System.EventHandler(this.IconBtnLimpar_Click);
            // 
            // WFRelatorioComPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 681);
            this.Controls.Add(this.IconBtnLimpar);
            this.Controls.Add(this.IconBtnPesquisar);
            this.Controls.Add(this.TxtPesquisaNum);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "WFRelatorioComPesquisa";
            this.Text = "Fatura nº";
            this.Load += new System.EventHandler(this.RelatorioComPesquisa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox TxtPesquisaNum;
        private FontAwesome.Sharp.IconButton IconBtnPesquisar;
        private FontAwesome.Sharp.IconButton IconBtnLimpar;
    }
}