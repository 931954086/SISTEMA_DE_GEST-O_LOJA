namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFDepartamentoView
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
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnIncluir = new System.Windows.Forms.Button();
            this.DtgDepartamento = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RichTextDescricao = new System.Windows.Forms.RichTextBox();
            this.LblDescricao = new System.Windows.Forms.Label();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.CboEmpresa = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblNumCodigo = new System.Windows.Forms.Label();
            this.Pesquisa = new System.Windows.Forms.Label();
            this.LblNomeCidade = new System.Windows.Forms.Label();
            this.LblCboEmpresa = new System.Windows.Forms.Label();
            this.TxtDepartamento = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepartamento)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(207)))), ((int)(((byte)(223)))));
            this.panelBar.Controls.Add(this.BtnSalvar);
            this.panelBar.Controls.Add(this.BtnExcluir);
            this.panelBar.Controls.Add(this.BtnAlterar);
            this.panelBar.Controls.Add(this.BtnCancelar);
            this.panelBar.Controls.Add(this.BtnIncluir);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelBar.Location = new System.Drawing.Point(20, 60);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1039, 46);
            this.panelBar.TabIndex = 21;
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
            this.BtnSalvar.Location = new System.Drawing.Point(552, 3);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(109, 40);
            this.BtnSalvar.TabIndex = 7;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // BtnExcluir
            // 
            this.BtnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExcluir.FlatAppearance.BorderSize = 0;
            this.BtnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExcluir.ForeColor = System.Drawing.Color.White;
            this.BtnExcluir.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Delete_36px;
            this.BtnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnExcluir.Location = new System.Drawing.Point(421, 3);
            this.BtnExcluir.Name = "BtnExcluir";
            this.BtnExcluir.Size = new System.Drawing.Size(107, 40);
            this.BtnExcluir.TabIndex = 5;
            this.BtnExcluir.Text = "&Excluir";
            this.BtnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExcluir.UseVisualStyleBackColor = true;
            this.BtnExcluir.Click += new System.EventHandler(this.BtnExcluir_Click);
            // 
            // BtnAlterar
            // 
            this.BtnAlterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAlterar.FlatAppearance.BorderSize = 0;
            this.BtnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAlterar.ForeColor = System.Drawing.Color.White;
            this.BtnAlterar.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Edit_36px;
            this.BtnAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAlterar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnAlterar.Location = new System.Drawing.Point(281, 3);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(107, 40);
            this.BtnAlterar.TabIndex = 4;
            this.BtnAlterar.Text = "&Alterar";
            this.BtnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAlterar.UseVisualStyleBackColor = true;
            this.BtnAlterar.Click += new System.EventHandler(this.BtnAlterar_Click);
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
            this.BtnCancelar.Location = new System.Drawing.Point(140, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(124, 40);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnIncluir
            // 
            this.BtnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnIncluir.FlatAppearance.BorderSize = 0;
            this.BtnIncluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnIncluir.ForeColor = System.Drawing.Color.White;
            this.BtnIncluir.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Plus_36px;
            this.BtnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnIncluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnIncluir.Location = new System.Drawing.Point(2, 3);
            this.BtnIncluir.Name = "BtnIncluir";
            this.BtnIncluir.Size = new System.Drawing.Size(104, 40);
            this.BtnIncluir.TabIndex = 9;
            this.BtnIncluir.Text = "&Incluir";
            this.BtnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIncluir.UseVisualStyleBackColor = true;
            this.BtnIncluir.Click += new System.EventHandler(this.BtnIncluir_Click);
            // 
            // DtgDepartamento
            // 
            this.DtgDepartamento.AllowUserToAddRows = false;
            this.DtgDepartamento.AllowUserToDeleteRows = false;
            this.DtgDepartamento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgDepartamento.BackgroundColor = System.Drawing.Color.White;
            this.DtgDepartamento.ColumnHeadersHeight = 40;
            this.DtgDepartamento.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgDepartamento.Location = new System.Drawing.Point(524, 128);
            this.DtgDepartamento.Name = "DtgDepartamento";
            this.DtgDepartamento.RowTemplate.Height = 35;
            this.DtgDepartamento.Size = new System.Drawing.Size(535, 389);
            this.DtgDepartamento.TabIndex = 22;
            this.DtgDepartamento.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDepartamento_CellClick);
            this.DtgDepartamento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgDepartamento_KeyUp);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RichTextDescricao);
            this.panel2.Controls.Add(this.LblDescricao);
            this.panel2.Controls.Add(this.TxtPesquisar);
            this.panel2.Controls.Add(this.CboEmpresa);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LblNumCodigo);
            this.panel2.Controls.Add(this.Pesquisa);
            this.panel2.Controls.Add(this.LblNomeCidade);
            this.panel2.Controls.Add(this.LblCboEmpresa);
            this.panel2.Controls.Add(this.TxtDepartamento);
            this.panel2.Controls.Add(this.LblCodigo);
            this.panel2.Location = new System.Drawing.Point(20, 128);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(498, 425);
            this.panel2.TabIndex = 23;
            // 
            // RichTextDescricao
            // 
            this.RichTextDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextDescricao.Location = new System.Drawing.Point(152, 201);
            this.RichTextDescricao.Name = "RichTextDescricao";
            this.RichTextDescricao.Size = new System.Drawing.Size(326, 140);
            this.RichTextDescricao.TabIndex = 13;
            this.RichTextDescricao.Text = "";
            this.RichTextDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RichTextDescricao_KeyDown);
            // 
            // LblDescricao
            // 
            this.LblDescricao.AutoSize = true;
            this.LblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDescricao.Location = new System.Drawing.Point(23, 201);
            this.LblDescricao.Name = "LblDescricao";
            this.LblDescricao.Size = new System.Drawing.Size(88, 20);
            this.LblDescricao.TabIndex = 12;
            this.LblDescricao.Text = "Descrição :";
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(160, 388);
            this.TxtPesquisar.MaxLength = 20;
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(318, 28);
            this.TxtPesquisar.TabIndex = 10;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            this.TxtPesquisar.Enter += new System.EventHandler(this.TxtPesquisar_Enter);
            this.TxtPesquisar.Leave += new System.EventHandler(this.TxtPesquisar_Leave);
            // 
            // CboEmpresa
            // 
            this.CboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboEmpresa.FormattingEnabled = true;
            this.CboEmpresa.Location = new System.Drawing.Point(152, 148);
            this.CboEmpresa.Name = "CboEmpresa";
            this.CboEmpresa.Size = new System.Drawing.Size(326, 28);
            this.CboEmpresa.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(6, 371);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 1);
            this.panel3.TabIndex = 8;
            // 
            // LblNumCodigo
            // 
            this.LblNumCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumCodigo.Location = new System.Drawing.Point(148, 29);
            this.LblNumCodigo.Name = "LblNumCodigo";
            this.LblNumCodigo.Size = new System.Drawing.Size(119, 26);
            this.LblNumCodigo.TabIndex = 4;
            this.LblNumCodigo.Text = "LblNumCodigo";
            // 
            // Pesquisa
            // 
            this.Pesquisa.AutoSize = true;
            this.Pesquisa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pesquisa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Pesquisa.Location = new System.Drawing.Point(28, 396);
            this.Pesquisa.Name = "Pesquisa";
            this.Pesquisa.Size = new System.Drawing.Size(83, 20);
            this.Pesquisa.TabIndex = 3;
            this.Pesquisa.Text = "Pesquisar:";
            // 
            // LblNomeCidade
            // 
            this.LblNomeCidade.AutoSize = true;
            this.LblNomeCidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomeCidade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNomeCidade.Location = new System.Drawing.Point(19, 86);
            this.LblNomeCidade.Name = "LblNomeCidade";
            this.LblNomeCidade.Size = new System.Drawing.Size(120, 20);
            this.LblNomeCidade.TabIndex = 2;
            this.LblNomeCidade.Text = "Departamento :";
            // 
            // LblCboEmpresa
            // 
            this.LblCboEmpresa.AutoSize = true;
            this.LblCboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCboEmpresa.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCboEmpresa.Location = new System.Drawing.Point(19, 151);
            this.LblCboEmpresa.Name = "LblCboEmpresa";
            this.LblCboEmpresa.Size = new System.Drawing.Size(77, 20);
            this.LblCboEmpresa.TabIndex = 1;
            this.LblCboEmpresa.Text = "Empresa:";
            // 
            // TxtDepartamento
            // 
            this.TxtDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDepartamento.Location = new System.Drawing.Point(152, 83);
            this.TxtDepartamento.Multiline = true;
            this.TxtDepartamento.Name = "TxtDepartamento";
            this.TxtDepartamento.Size = new System.Drawing.Size(326, 28);
            this.TxtDepartamento.TabIndex = 5;
            this.TxtDepartamento.Enter += new System.EventHandler(this.TxtDepartamento_Enter);
            this.TxtDepartamento.Leave += new System.EventHandler(this.TxtDepartamento_Leave);
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCodigo.Location = new System.Drawing.Point(19, 29);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(99, 20);
            this.LblCodigo.TabIndex = 0;
            this.LblCodigo.Text = "Cod Depart :";
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(524, 533);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(141, 20);
            this.LblTotalRegistros.TabIndex = 24;
            this.LblTotalRegistros.Text = "Total de Registos: ";
            // 
            // WFDepartamentoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 574);
            this.Controls.Add(this.LblTotalRegistros);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DtgDepartamento);
            this.Controls.Add(this.panelBar);
            this.Name = "WFDepartamentoView";
            this.Text = "Cadastro de Departamento";
            this.Load += new System.EventHandler(this.WFDepartamentoView_Load);
            this.panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDepartamento)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.DataGridView DtgDepartamento;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.ComboBox CboEmpresa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblNumCodigo;
        private System.Windows.Forms.Label Pesquisa;
        private System.Windows.Forms.Label LblNomeCidade;
        private System.Windows.Forms.Label LblCboEmpresa;
        private System.Windows.Forms.TextBox TxtDepartamento;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.Label LblDescricao;
        private System.Windows.Forms.RichTextBox RichTextDescricao;
    }
}