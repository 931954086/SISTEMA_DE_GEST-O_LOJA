namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFTipoUsuarioView
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
            this.DtgTipoUsuario = new System.Windows.Forms.DataGridView();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblSiglaTipoUsuario = new System.Windows.Forms.Label();
            this.TxtSiglaTipoUsuario = new System.Windows.Forms.TextBox();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblNumCodigo = new System.Windows.Forms.Label();
            this.Pesquisa = new System.Windows.Forms.Label();
            this.LblTipoUsuario = new System.Windows.Forms.Label();
            this.TxtNomeTipoUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnIncluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DtgTipoUsuario)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgTipoUsuario
            // 
            this.DtgTipoUsuario.AllowUserToAddRows = false;
            this.DtgTipoUsuario.AllowUserToDeleteRows = false;
            this.DtgTipoUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgTipoUsuario.BackgroundColor = System.Drawing.Color.White;
            this.DtgTipoUsuario.ColumnHeadersHeight = 40;
            this.DtgTipoUsuario.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgTipoUsuario.Location = new System.Drawing.Point(498, 116);
            this.DtgTipoUsuario.Name = "DtgTipoUsuario";
            this.DtgTipoUsuario.RowTemplate.Height = 35;
            this.DtgTipoUsuario.Size = new System.Drawing.Size(685, 389);
            this.DtgTipoUsuario.TabIndex = 23;
            this.DtgTipoUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgTipoUsuario_CellClick);
            this.DtgTipoUsuario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgTipoUsuario_KeyUp);
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(507, 521);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(141, 20);
            this.LblTotalRegistros.TabIndex = 22;
            this.LblTotalRegistros.Text = "Total de Registos: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblSiglaTipoUsuario);
            this.panel2.Controls.Add(this.TxtSiglaTipoUsuario);
            this.panel2.Controls.Add(this.TxtPesquisar);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.LblNumCodigo);
            this.panel2.Controls.Add(this.Pesquisa);
            this.panel2.Controls.Add(this.LblTipoUsuario);
            this.panel2.Controls.Add(this.TxtNomeTipoUsuario);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(14, 116);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 425);
            this.panel2.TabIndex = 21;
            // 
            // LblSiglaTipoUsuario
            // 
            this.LblSiglaTipoUsuario.AutoSize = true;
            this.LblSiglaTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSiglaTipoUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSiglaTipoUsuario.Location = new System.Drawing.Point(28, 168);
            this.LblSiglaTipoUsuario.Name = "LblSiglaTipoUsuario";
            this.LblSiglaTipoUsuario.Size = new System.Drawing.Size(86, 20);
            this.LblSiglaTipoUsuario.TabIndex = 11;
            this.LblSiglaTipoUsuario.Text = "Sigla Tipo: ";
            // 
            // TxtSiglaTipoUsuario
            // 
            this.TxtSiglaTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSiglaTipoUsuario.Location = new System.Drawing.Point(160, 168);
            this.TxtSiglaTipoUsuario.Multiline = true;
            this.TxtSiglaTipoUsuario.Name = "TxtSiglaTipoUsuario";
            this.TxtSiglaTipoUsuario.Size = new System.Drawing.Size(301, 28);
            this.TxtSiglaTipoUsuario.TabIndex = 12;
            this.TxtSiglaTipoUsuario.Enter += new System.EventHandler(this.TxtSiglaTipoUsuario_Enter);
            this.TxtSiglaTipoUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSiglaTipoUsuario_KeyPress);
            this.TxtSiglaTipoUsuario.Leave += new System.EventHandler(this.TxtSiglaTipoUsuario_Leave);
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
            this.LblNumCodigo.Location = new System.Drawing.Point(156, 29);
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
            // LblTipoUsuario
            // 
            this.LblTipoUsuario.AutoSize = true;
            this.LblTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTipoUsuario.Location = new System.Drawing.Point(28, 83);
            this.LblTipoUsuario.Name = "LblTipoUsuario";
            this.LblTipoUsuario.Size = new System.Drawing.Size(102, 20);
            this.LblTipoUsuario.TabIndex = 2;
            this.LblTipoUsuario.Text = "Tipo Usuário:";
            // 
            // TxtNomeTipoUsuario
            // 
            this.TxtNomeTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeTipoUsuario.Location = new System.Drawing.Point(160, 83);
            this.TxtNomeTipoUsuario.Multiline = true;
            this.TxtNomeTipoUsuario.Name = "TxtNomeTipoUsuario";
            this.TxtNomeTipoUsuario.Size = new System.Drawing.Size(301, 28);
            this.TxtNomeTipoUsuario.TabIndex = 5;
            this.TxtNomeTipoUsuario.Enter += new System.EventHandler(this.TxtNomeTipoUsuario_Enter);
            this.TxtNomeTipoUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNomeTipoUsuario_KeyPress);
            this.TxtNomeTipoUsuario.Leave += new System.EventHandler(this.TxtNomeTipoUsuario_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(28, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código";
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
            // WFTipoUsuarioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 780);
            this.Controls.Add(this.DtgTipoUsuario);
            this.Controls.Add(this.LblTotalRegistros);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelBar);
            this.Name = "WFTipoUsuarioView";
            this.Text = "TipoUsuarioView";
            this.Load += new System.EventHandler(this.TipoUsuarioView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgTipoUsuario)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgTipoUsuario;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblSiglaTipoUsuario;
        private System.Windows.Forms.TextBox TxtSiglaTipoUsuario;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblNumCodigo;
        private System.Windows.Forms.Label Pesquisa;
        private System.Windows.Forms.Label LblTipoUsuario;
        private System.Windows.Forms.TextBox TxtNomeTipoUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnIncluir;
    }
}