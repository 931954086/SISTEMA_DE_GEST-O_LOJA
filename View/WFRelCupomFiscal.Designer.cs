namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFRelCupomFiscal
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.uspNtVendaEmitirNotaFiscalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.estoqueDataSet = new SISTEMA_DE_GESTÃO_LOJA.EstoqueDataSet();
            this.RptRelatorio = new Microsoft.Reporting.WinForms.ReportViewer();
            this.estoqueDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BtnPesquisar = new System.Windows.Forms.Button();
            this.TxtPesquisarNumeroFatura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.uspNtVendaEmitirNotaFiscalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uspNtVendaEmitirNotaFiscalBindingSource
            // 
            this.uspNtVendaEmitirNotaFiscalBindingSource.DataMember = "uspNtVendaEmitirNotaFiscal";
            this.uspNtVendaEmitirNotaFiscalBindingSource.DataSource = this.estoqueDataSet;
            // 
            // estoqueDataSet
            // 
            this.estoqueDataSet.DataSetName = "EstoqueDataSet";
            this.estoqueDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RptRelatorio
            // 
            this.RptRelatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetRelatorio";
            reportDataSource2.Value = this.uspNtVendaEmitirNotaFiscalBindingSource;
            this.RptRelatorio.LocalReport.DataSources.Add(reportDataSource2);
            this.RptRelatorio.LocalReport.ReportEmbeddedResource = "SISTEMA_DE_GESTÃO_LOJA.Relatorios.RptCupomFiscal.rdlc";
            this.RptRelatorio.Location = new System.Drawing.Point(20, 60);
            this.RptRelatorio.Name = "RptRelatorio";
            this.RptRelatorio.ServerReport.BearerToken = null;
            this.RptRelatorio.Size = new System.Drawing.Size(491, 589);
            this.RptRelatorio.TabIndex = 0;
            // 
            // estoqueDataSetBindingSource
            // 
            this.estoqueDataSetBindingSource.DataSource = this.estoqueDataSet;
            this.estoqueDataSetBindingSource.Position = 0;
            // 
            // BtnPesquisar
            // 
            this.BtnPesquisar.FlatAppearance.BorderSize = 0;
            this.BtnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPesquisar.ForeColor = System.Drawing.Color.Black;
            this.BtnPesquisar.Location = new System.Drawing.Point(409, 25);
            this.BtnPesquisar.Name = "BtnPesquisar";
            this.BtnPesquisar.Size = new System.Drawing.Size(98, 29);
            this.BtnPesquisar.TabIndex = 1;
            this.BtnPesquisar.Text = "Pesquisar";
            this.BtnPesquisar.UseVisualStyleBackColor = true;
            this.BtnPesquisar.Click += new System.EventHandler(this.BtnPesquisar_Click);
            // 
            // TxtPesquisarNumeroFatura
            // 
            this.TxtPesquisarNumeroFatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisarNumeroFatura.Location = new System.Drawing.Point(184, 23);
            this.TxtPesquisarNumeroFatura.Multiline = true;
            this.TxtPesquisarNumeroFatura.Name = "TxtPesquisarNumeroFatura";
            this.TxtPesquisarNumeroFatura.Size = new System.Drawing.Size(219, 31);
            this.TxtPesquisarNumeroFatura.TabIndex = 112;
            // 
            // WFRelCupomFiscal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 669);
            this.Controls.Add(this.TxtPesquisarNumeroFatura);
            this.Controls.Add(this.BtnPesquisar);
            this.Controls.Add(this.RptRelatorio);
            this.Name = "WFRelCupomFiscal";
            this.Text = "Relatório Fiscal";
            this.Load += new System.EventHandler(this.WFRelCupomFiscal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uspNtVendaEmitirNotaFiscalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.estoqueDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RptRelatorio;
        private System.Windows.Forms.BindingSource estoqueDataSetBindingSource;
        private EstoqueDataSet estoqueDataSet;
        private System.Windows.Forms.BindingSource uspNtVendaEmitirNotaFiscalBindingSource;
        private System.Windows.Forms.Button BtnPesquisar;
        private System.Windows.Forms.TextBox TxtPesquisarNumeroFatura;
    }
}