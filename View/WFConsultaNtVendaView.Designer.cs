namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFConsultaNtVendaView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblClienteBorda = new System.Windows.Forms.Label();
            this.CboCliente = new System.Windows.Forms.ComboBox();
            this.DtgTelefoneCli = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnCancelarNota = new System.Windows.Forms.Button();
            this.LblPesquisarNota = new System.Windows.Forms.Label();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtgNtVenda = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblItemVenda = new System.Windows.Forms.Label();
            this.DtgItemVenda = new System.Windows.Forms.DataGridView();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnFaturaPDF = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.BtnBalanco = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTelefoneCli)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgNtVenda)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgItemVenda)).BeginInit();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblClienteBorda);
            this.panel1.Controls.Add(this.CboCliente);
            this.panel1.Controls.Add(this.DtgTelefoneCli);
            this.panel1.Location = new System.Drawing.Point(30, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 152);
            this.panel1.TabIndex = 0;
            // 
            // LblClienteBorda
            // 
            this.LblClienteBorda.AutoSize = true;
            this.LblClienteBorda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClienteBorda.Location = new System.Drawing.Point(3, 5);
            this.LblClienteBorda.Name = "LblClienteBorda";
            this.LblClienteBorda.Size = new System.Drawing.Size(79, 25);
            this.LblClienteBorda.TabIndex = 33;
            this.LblClienteBorda.Text = "Cliente";
            // 
            // CboCliente
            // 
            this.CboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CboCliente.FormattingEnabled = true;
            this.CboCliente.Location = new System.Drawing.Point(31, 39);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Size = new System.Drawing.Size(311, 32);
            this.CboCliente.TabIndex = 32;
            this.CboCliente.Enter += new System.EventHandler(this.CboCliente_Enter);
            // 
            // DtgTelefoneCli
            // 
            this.DtgTelefoneCli.AllowUserToAddRows = false;
            this.DtgTelefoneCli.AllowUserToDeleteRows = false;
            this.DtgTelefoneCli.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTelefoneCli.BackgroundColor = System.Drawing.Color.White;
            this.DtgTelefoneCli.ColumnHeadersHeight = 40;
            this.DtgTelefoneCli.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgTelefoneCli.Location = new System.Drawing.Point(348, 5);
            this.DtgTelefoneCli.Name = "DtgTelefoneCli";
            this.DtgTelefoneCli.RowTemplate.Height = 35;
            this.DtgTelefoneCli.Size = new System.Drawing.Size(813, 140);
            this.DtgTelefoneCli.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnCancelarNota);
            this.panel2.Controls.Add(this.LblPesquisarNota);
            this.panel2.Controls.Add(this.TxtPesquisar);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.DtgNtVenda);
            this.panel2.Location = new System.Drawing.Point(30, 265);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1164, 232);
            this.panel2.TabIndex = 34;
            // 
            // BtnCancelarNota
            // 
            this.BtnCancelarNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelarNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BtnCancelarNota.Location = new System.Drawing.Point(455, 194);
            this.BtnCancelarNota.Name = "BtnCancelarNota";
            this.BtnCancelarNota.Size = new System.Drawing.Size(146, 30);
            this.BtnCancelarNota.TabIndex = 103;
            this.BtnCancelarNota.Text = "Cancelar  Nota";
            this.BtnCancelarNota.UseVisualStyleBackColor = true;
            this.BtnCancelarNota.Click += new System.EventHandler(this.BtnCancelarNota_Click);
            // 
            // LblPesquisarNota
            // 
            this.LblPesquisarNota.AutoSize = true;
            this.LblPesquisarNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesquisarNota.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPesquisarNota.Location = new System.Drawing.Point(7, 198);
            this.LblPesquisarNota.Name = "LblPesquisarNota";
            this.LblPesquisarNota.Size = new System.Drawing.Size(146, 20);
            this.LblPesquisarNota.TabIndex = 79;
            this.LblPesquisarNota.Text = "Pesquisar Nº Nota: ";
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(160, 194);
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(271, 30);
            this.TxtPesquisar.TabIndex = 78;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Venda";
            // 
            // DtgNtVenda
            // 
            this.DtgNtVenda.AllowUserToAddRows = false;
            this.DtgNtVenda.AllowUserToDeleteRows = false;
            this.DtgNtVenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgNtVenda.BackgroundColor = System.Drawing.Color.White;
            this.DtgNtVenda.ColumnHeadersHeight = 40;
            this.DtgNtVenda.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgNtVenda.Location = new System.Drawing.Point(10, 26);
            this.DtgNtVenda.Name = "DtgNtVenda";
            this.DtgNtVenda.RowTemplate.Height = 35;
            this.DtgNtVenda.Size = new System.Drawing.Size(1151, 162);
            this.DtgNtVenda.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LblItemVenda);
            this.panel3.Controls.Add(this.DtgItemVenda);
            this.panel3.Location = new System.Drawing.Point(30, 519);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1164, 206);
            this.panel3.TabIndex = 104;
            // 
            // LblItemVenda
            // 
            this.LblItemVenda.AutoSize = true;
            this.LblItemVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblItemVenda.Location = new System.Drawing.Point(8, 2);
            this.LblItemVenda.Name = "LblItemVenda";
            this.LblItemVenda.Size = new System.Drawing.Size(120, 25);
            this.LblItemVenda.TabIndex = 33;
            this.LblItemVenda.Text = "Item Venda";
            // 
            // DtgItemVenda
            // 
            this.DtgItemVenda.AllowUserToAddRows = false;
            this.DtgItemVenda.AllowUserToDeleteRows = false;
            this.DtgItemVenda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgItemVenda.BackgroundColor = System.Drawing.Color.White;
            this.DtgItemVenda.ColumnHeadersHeight = 40;
            this.DtgItemVenda.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgItemVenda.Location = new System.Drawing.Point(11, 32);
            this.DtgItemVenda.Name = "DtgItemVenda";
            this.DtgItemVenda.RowTemplate.Height = 35;
            this.DtgItemVenda.Size = new System.Drawing.Size(1150, 172);
            this.DtgItemVenda.TabIndex = 20;
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(207)))), ((int)(((byte)(223)))));
            this.panelBar.Controls.Add(this.BtnFaturaPDF);
            this.panelBar.Controls.Add(this.BtnSalvar);
            this.panelBar.Controls.Add(this.BtnCancelar);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1203, 49);
            this.panelBar.TabIndex = 105;
            // 
            // BtnFaturaPDF
            // 
            this.BtnFaturaPDF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFaturaPDF.FlatAppearance.BorderSize = 0;
            this.BtnFaturaPDF.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnFaturaPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFaturaPDF.ForeColor = System.Drawing.Color.White;
            this.BtnFaturaPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFaturaPDF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnFaturaPDF.Location = new System.Drawing.Point(352, 5);
            this.BtnFaturaPDF.Name = "BtnFaturaPDF";
            this.BtnFaturaPDF.Size = new System.Drawing.Size(109, 38);
            this.BtnFaturaPDF.TabIndex = 11;
            this.BtnFaturaPDF.Text = "&Fatura";
            this.BtnFaturaPDF.UseVisualStyleBackColor = true;
            this.BtnFaturaPDF.Click += new System.EventHandler(this.BtnFaturaPDF_Click);
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
            this.BtnSalvar.Location = new System.Drawing.Point(203, 3);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(112, 40);
            this.BtnSalvar.TabIndex = 7;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalvar.UseVisualStyleBackColor = true;
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
            this.BtnCancelar.Location = new System.Drawing.Point(4, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(130, 37);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Diário",
            "Semanal",
            "Mensal",
            "Anual"});
            this.comboBox1.Location = new System.Drawing.Point(1012, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 32);
            this.comboBox1.TabIndex = 107;
            // 
            // BtnBalanco
            // 
            this.BtnBalanco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBalanco.FlatAppearance.BorderSize = 0;
            this.BtnBalanco.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBalanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBalanco.ForeColor = System.Drawing.Color.Black;
            this.BtnBalanco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBalanco.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnBalanco.Location = new System.Drawing.Point(922, 56);
            this.BtnBalanco.Name = "BtnBalanco";
            this.BtnBalanco.Size = new System.Drawing.Size(88, 32);
            this.BtnBalanco.TabIndex = 108;
            this.BtnBalanco.Text = "&Balanço";
            this.BtnBalanco.UseVisualStyleBackColor = true;
            this.BtnBalanco.Click += new System.EventHandler(this.BtnBalanco_Click);
            // 
            // WFConsultaNtVendaView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1203, 780);
            this.Controls.Add(this.BtnBalanco);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "WFConsultaNtVendaView";
            this.Text = "Consulta Venda";
            this.Load += new System.EventHandler(this.WFConsultaNtVendaView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFConsultaNtVendaView_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTelefoneCli)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgNtVenda)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgItemVenda)).EndInit();
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DtgTelefoneCli;
        private System.Windows.Forms.ComboBox CboCliente;
        private System.Windows.Forms.Label LblClienteBorda;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DtgNtVenda;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.Label LblPesquisarNota;
        private System.Windows.Forms.Button BtnCancelarNota;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblItemVenda;
        private System.Windows.Forms.DataGridView DtgItemVenda;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnFaturaPDF;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button BtnBalanco;
    }
}