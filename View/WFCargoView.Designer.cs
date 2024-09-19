namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFCargoView
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
            this.DtgCargo = new System.Windows.Forms.DataGridView();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TxtNomeCargo = new System.Windows.Forms.TextBox();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblNumCodigo = new System.Windows.Forms.Label();
            this.Pesquisa = new System.Windows.Forms.Label();
            this.LblNomeCidade = new System.Windows.Forms.Label();
            this.LblSiglaCargo = new System.Windows.Forms.Label();
            this.TxtSiglaCargo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnIncluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgCargo)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgCargo
            // 
            this.DtgCargo.AllowUserToAddRows = false;
            this.DtgCargo.AllowUserToDeleteRows = false;
            this.DtgCargo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgCargo.BackgroundColor = System.Drawing.Color.White;
            this.DtgCargo.ColumnHeadersHeight = 40;
            this.DtgCargo.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgCargo.Location = new System.Drawing.Point(494, 124);
            this.DtgCargo.Name = "DtgCargo";
            this.DtgCargo.RowTemplate.Height = 35;
            this.DtgCargo.Size = new System.Drawing.Size(689, 389);
            this.DtgCargo.TabIndex = 23;
            this.DtgCargo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgCargo_CellClick);
            this.DtgCargo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgCargo_KeyUp);
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(503, 529);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(141, 20);
            this.LblTotalRegistros.TabIndex = 22;
            this.LblTotalRegistros.Text = "Total de Registos: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.TxtNomeCargo);
            this.panel2.Controls.Add(this.TxtPesquisar);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LblNumCodigo);
            this.panel2.Controls.Add(this.Pesquisa);
            this.panel2.Controls.Add(this.LblNomeCidade);
            this.panel2.Controls.Add(this.LblSiglaCargo);
            this.panel2.Controls.Add(this.TxtSiglaCargo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(10, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 425);
            this.panel2.TabIndex = 21;
            // 
            // TxtNomeCargo
            // 
            this.TxtNomeCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeCargo.Location = new System.Drawing.Point(149, 86);
            this.TxtNomeCargo.Multiline = true;
            this.TxtNomeCargo.Name = "TxtNomeCargo";
            this.TxtNomeCargo.Size = new System.Drawing.Size(301, 28);
            this.TxtNomeCargo.TabIndex = 11;
            this.TxtNomeCargo.Enter += new System.EventHandler(this.TxtNomeCargo_Enter);
            this.TxtNomeCargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNomeCargo_KeyPress);
            this.TxtNomeCargo.Leave += new System.EventHandler(this.TxtNomeCargo_Leave);
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(160, 388);
            this.TxtPesquisar.MaxLength = 20;
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(301, 28);
            this.TxtPesquisar.TabIndex = 10;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
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
            this.LblNumCodigo.Location = new System.Drawing.Point(145, 29);
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
            this.LblNomeCidade.Location = new System.Drawing.Point(29, 86);
            this.LblNomeCidade.Name = "LblNomeCidade";
            this.LblNomeCidade.Size = new System.Drawing.Size(102, 20);
            this.LblNomeCidade.TabIndex = 2;
            this.LblNomeCidade.Text = "Título Cargo :";
            // 
            // LblSiglaCargo
            // 
            this.LblSiglaCargo.AutoSize = true;
            this.LblSiglaCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSiglaCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSiglaCargo.Location = new System.Drawing.Point(29, 160);
            this.LblSiglaCargo.Name = "LblSiglaCargo";
            this.LblSiglaCargo.Size = new System.Drawing.Size(99, 20);
            this.LblSiglaCargo.TabIndex = 1;
            this.LblSiglaCargo.Text = "Sigla Cargo :";
            // 
            // TxtSiglaCargo
            // 
            this.TxtSiglaCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSiglaCargo.Location = new System.Drawing.Point(149, 160);
            this.TxtSiglaCargo.Multiline = true;
            this.TxtSiglaCargo.Name = "TxtSiglaCargo";
            this.TxtSiglaCargo.Size = new System.Drawing.Size(301, 28);
            this.TxtSiglaCargo.TabIndex = 5;
            this.TxtSiglaCargo.Enter += new System.EventHandler(this.TxtSiglaCargo_Enter);
            this.TxtSiglaCargo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSiglaCargo_KeyPress);
            this.TxtSiglaCargo.Leave += new System.EventHandler(this.TxtSiglaCargo_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(29, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo :";
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
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1195, 46);
            this.panelBar.TabIndex = 20;
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
            // WFCargoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 780);
            this.Controls.Add(this.DtgCargo);
            this.Controls.Add(this.LblTotalRegistros);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBar);
            this.Name = "WFCargoView";
            this.Text = "WFCargoView";
            this.Load += new System.EventHandler(this.WFCargoView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgCargo)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgCargo;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblNumCodigo;
        private System.Windows.Forms.Label Pesquisa;
        private System.Windows.Forms.Label LblNomeCidade;
        private System.Windows.Forms.Label LblSiglaCargo;
        private System.Windows.Forms.TextBox TxtSiglaCargo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.TextBox TxtNomeCargo;
    }
}