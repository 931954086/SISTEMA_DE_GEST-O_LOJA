namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFMaterialView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelDados = new System.Windows.Forms.Panel();
            this.LblQtdMin = new System.Windows.Forms.Label();
            this.TxtQtdMin = new System.Windows.Forms.TextBox();
            this.TxtCodigoBarra = new System.Windows.Forms.TextBox();
            this.LblCodigoBarra = new System.Windows.Forms.Label();
            this.LblNumCodigo = new System.Windows.Forms.TextBox();
            this.LblCodigo = new System.Windows.Forms.Label();
            this.BtnProcurar = new System.Windows.Forms.Button();
            this.picBoxMaterail = new System.Windows.Forms.PictureBox();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.TxtModeloMaterial = new System.Windows.Forms.TextBox();
            this.TxtPrecoMaterial = new System.Windows.Forms.TextBox();
            this.DtgMaterial = new System.Windows.Forms.DataGridView();
            this.RTxtDescricaoMaterial = new System.Windows.Forms.RichTextBox();
            this.LblQtdDisponivel = new System.Windows.Forms.Label();
            this.LblCor = new System.Windows.Forms.Label();
            this.LblDescricao = new System.Windows.Forms.Label();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.TxtCorMaterial = new System.Windows.Forms.TextBox();
            this.TxtNomeMaterial = new System.Windows.Forms.TextBox();
            this.TxtQtdDisponivel = new System.Windows.Forms.TextBox();
            this.LblPesquisaCli = new System.Windows.Forms.Label();
            this.LblQtdTotal = new System.Windows.Forms.Label();
            this.TxtQdtTotal = new System.Windows.Forms.TextBox();
            this.LblModelo = new System.Windows.Forms.Label();
            this.LblPreço = new System.Windows.Forms.Label();
            this.LblNomeMaterial = new System.Windows.Forms.Label();
            this.panelBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMaterail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMaterial)).BeginInit();
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
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1195, 46);
            this.panelBar.TabIndex = 15;
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
            this.BtnSalvar.Size = new System.Drawing.Size(107, 40);
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
            this.BtnExcluir.Size = new System.Drawing.Size(114, 40);
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
            this.BtnAlterar.Location = new System.Drawing.Point(301, 3);
            this.BtnAlterar.Name = "BtnAlterar";
            this.BtnAlterar.Size = new System.Drawing.Size(105, 40);
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
            this.BtnCancelar.Size = new System.Drawing.Size(135, 40);
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
            this.BtnIncluir.Size = new System.Drawing.Size(103, 40);
            this.BtnIncluir.TabIndex = 9;
            this.BtnIncluir.Text = "&Incluir";
            this.BtnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnIncluir.UseVisualStyleBackColor = true;
            this.BtnIncluir.Click += new System.EventHandler(this.BtnIncluir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelDados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 734);
            this.panel1.TabIndex = 16;
            // 
            // panelDados
            // 
            this.panelDados.Controls.Add(this.LblQtdMin);
            this.panelDados.Controls.Add(this.TxtQtdMin);
            this.panelDados.Controls.Add(this.TxtCodigoBarra);
            this.panelDados.Controls.Add(this.LblCodigoBarra);
            this.panelDados.Controls.Add(this.LblNumCodigo);
            this.panelDados.Controls.Add(this.LblCodigo);
            this.panelDados.Controls.Add(this.BtnProcurar);
            this.panelDados.Controls.Add(this.picBoxMaterail);
            this.panelDados.Controls.Add(this.LblTotalRegistros);
            this.panelDados.Controls.Add(this.TxtModeloMaterial);
            this.panelDados.Controls.Add(this.TxtPrecoMaterial);
            this.panelDados.Controls.Add(this.DtgMaterial);
            this.panelDados.Controls.Add(this.RTxtDescricaoMaterial);
            this.panelDados.Controls.Add(this.LblQtdDisponivel);
            this.panelDados.Controls.Add(this.LblCor);
            this.panelDados.Controls.Add(this.LblDescricao);
            this.panelDados.Controls.Add(this.TxtPesquisar);
            this.panelDados.Controls.Add(this.TxtCorMaterial);
            this.panelDados.Controls.Add(this.TxtNomeMaterial);
            this.panelDados.Controls.Add(this.TxtQtdDisponivel);
            this.panelDados.Controls.Add(this.LblPesquisaCli);
            this.panelDados.Controls.Add(this.LblQtdTotal);
            this.panelDados.Controls.Add(this.TxtQdtTotal);
            this.panelDados.Controls.Add(this.LblModelo);
            this.panelDados.Controls.Add(this.LblPreço);
            this.panelDados.Controls.Add(this.LblNomeMaterial);
            this.panelDados.ForeColor = System.Drawing.Color.Black;
            this.panelDados.Location = new System.Drawing.Point(3, 21);
            this.panelDados.Name = "panelDados";
            this.panelDados.Size = new System.Drawing.Size(1180, 685);
            this.panelDados.TabIndex = 21;
            this.panelDados.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDados_Paint);
            // 
            // LblQtdMin
            // 
            this.LblQtdMin.AutoSize = true;
            this.LblQtdMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtdMin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblQtdMin.Location = new System.Drawing.Point(344, 133);
            this.LblQtdMin.Name = "LblQtdMin";
            this.LblQtdMin.Size = new System.Drawing.Size(93, 20);
            this.LblQtdMin.TabIndex = 62;
            this.LblQtdMin.Text = "Qtd Mínima:";
            // 
            // TxtQtdMin
            // 
            this.TxtQtdMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQtdMin.Location = new System.Drawing.Point(443, 130);
            this.TxtQtdMin.MaxLength = 100;
            this.TxtQtdMin.Multiline = true;
            this.TxtQtdMin.Name = "TxtQtdMin";
            this.TxtQtdMin.Size = new System.Drawing.Size(194, 32);
            this.TxtQtdMin.TabIndex = 61;
            this.TxtQtdMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtQtdMin.TextChanged += new System.EventHandler(this.TxtQtdMin_TextChanged);
            // 
            // TxtCodigoBarra
            // 
            this.TxtCodigoBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCodigoBarra.Location = new System.Drawing.Point(332, 16);
            this.TxtCodigoBarra.MaxLength = 30;
            this.TxtCodigoBarra.Multiline = true;
            this.TxtCodigoBarra.Name = "TxtCodigoBarra";
            this.TxtCodigoBarra.Size = new System.Drawing.Size(305, 32);
            this.TxtCodigoBarra.TabIndex = 60;
            // 
            // LblCodigoBarra
            // 
            this.LblCodigoBarra.AutoSize = true;
            this.LblCodigoBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigoBarra.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCodigoBarra.Location = new System.Drawing.Point(276, 22);
            this.LblCodigoBarra.Name = "LblCodigoBarra";
            this.LblCodigoBarra.Size = new System.Drawing.Size(52, 20);
            this.LblCodigoBarra.TabIndex = 59;
            this.LblCodigoBarra.Text = "Barra:";
            // 
            // LblNumCodigo
            // 
            this.LblNumCodigo.Enabled = false;
            this.LblNumCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumCodigo.Location = new System.Drawing.Point(151, 16);
            this.LblNumCodigo.MaxLength = 30;
            this.LblNumCodigo.Multiline = true;
            this.LblNumCodigo.Name = "LblNumCodigo";
            this.LblNumCodigo.Size = new System.Drawing.Size(125, 32);
            this.LblNumCodigo.TabIndex = 58;
            // 
            // LblCodigo
            // 
            this.LblCodigo.AutoSize = true;
            this.LblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCodigo.Location = new System.Drawing.Point(82, 19);
            this.LblCodigo.Name = "LblCodigo";
            this.LblCodigo.Size = new System.Drawing.Size(63, 20);
            this.LblCodigo.TabIndex = 57;
            this.LblCodigo.Text = "Código:";
            // 
            // BtnProcurar
            // 
            this.BtnProcurar.BackColor = System.Drawing.Color.Silver;
            this.BtnProcurar.FlatAppearance.BorderSize = 0;
            this.BtnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProcurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProcurar.Location = new System.Drawing.Point(666, 310);
            this.BtnProcurar.Name = "BtnProcurar";
            this.BtnProcurar.Size = new System.Drawing.Size(510, 36);
            this.BtnProcurar.TabIndex = 56;
            this.BtnProcurar.Text = "Adicionar Foto";
            this.BtnProcurar.UseVisualStyleBackColor = false;
            // 
            // picBoxMaterail
            // 
            this.picBoxMaterail.Location = new System.Drawing.Point(666, 16);
            this.picBoxMaterail.Name = "picBoxMaterail";
            this.picBoxMaterail.Size = new System.Drawing.Size(510, 288);
            this.picBoxMaterail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxMaterail.TabIndex = 55;
            this.picBoxMaterail.TabStop = false;
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(4, 598);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(141, 20);
            this.LblTotalRegistros.TabIndex = 22;
            this.LblTotalRegistros.Text = "Total de Registos: ";
            // 
            // TxtModeloMaterial
            // 
            this.TxtModeloMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtModeloMaterial.Location = new System.Drawing.Point(151, 92);
            this.TxtModeloMaterial.MaxLength = 50;
            this.TxtModeloMaterial.Multiline = true;
            this.TxtModeloMaterial.Name = "TxtModeloMaterial";
            this.TxtModeloMaterial.Size = new System.Drawing.Size(486, 32);
            this.TxtModeloMaterial.TabIndex = 47;
            this.TxtModeloMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtModeloMaterial_KeyPress);
            this.TxtModeloMaterial.Leave += new System.EventHandler(this.TxtModeloMaterial_Leave);
            // 
            // TxtPrecoMaterial
            // 
            this.TxtPrecoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecoMaterial.Location = new System.Drawing.Point(151, 210);
            this.TxtPrecoMaterial.Multiline = true;
            this.TxtPrecoMaterial.Name = "TxtPrecoMaterial";
            this.TxtPrecoMaterial.Size = new System.Drawing.Size(193, 32);
            this.TxtPrecoMaterial.TabIndex = 46;
            this.TxtPrecoMaterial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPrecoMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecoMaterial_KeyPress);
            this.TxtPrecoMaterial.Leave += new System.EventHandler(this.TxtPrecoMaterial_Leave);
            // 
            // DtgMaterial
            // 
            this.DtgMaterial.AllowUserToAddRows = false;
            this.DtgMaterial.AllowUserToDeleteRows = false;
            this.DtgMaterial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgMaterial.BackgroundColor = System.Drawing.Color.White;
            this.DtgMaterial.ColumnHeadersHeight = 40;
            this.DtgMaterial.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgMaterial.Location = new System.Drawing.Point(3, 352);
            this.DtgMaterial.Name = "DtgMaterial";
            this.DtgMaterial.RowTemplate.Height = 35;
            this.DtgMaterial.ShowEditingIcon = false;
            this.DtgMaterial.Size = new System.Drawing.Size(1174, 243);
            this.DtgMaterial.TabIndex = 20;
            this.DtgMaterial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgMaterial_CellClick);
            this.DtgMaterial.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgMaterial_KeyUp);
            // 
            // RTxtDescricaoMaterial
            // 
            this.RTxtDescricaoMaterial.Cursor = System.Windows.Forms.Cursors.Default;
            this.RTxtDescricaoMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTxtDescricaoMaterial.Location = new System.Drawing.Point(151, 253);
            this.RTxtDescricaoMaterial.Name = "RTxtDescricaoMaterial";
            this.RTxtDescricaoMaterial.Size = new System.Drawing.Size(486, 93);
            this.RTxtDescricaoMaterial.TabIndex = 45;
            this.RTxtDescricaoMaterial.Text = "";
            this.RTxtDescricaoMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RTxtDescricaoMaterial_KeyPress);
            this.RTxtDescricaoMaterial.Leave += new System.EventHandler(this.RTxtDescricaoMaterial_Leave);
            // 
            // LblQtdDisponivel
            // 
            this.LblQtdDisponivel.AutoSize = true;
            this.LblQtdDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtdDisponivel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblQtdDisponivel.Location = new System.Drawing.Point(26, 178);
            this.LblQtdDisponivel.Name = "LblQtdDisponivel";
            this.LblQtdDisponivel.Size = new System.Drawing.Size(115, 20);
            this.LblQtdDisponivel.TabIndex = 44;
            this.LblQtdDisponivel.Text = "Qtd Disponível:";
            // 
            // LblCor
            // 
            this.LblCor.AutoSize = true;
            this.LblCor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCor.Location = new System.Drawing.Point(103, 133);
            this.LblCor.Name = "LblCor";
            this.LblCor.Size = new System.Drawing.Size(38, 20);
            this.LblCor.TabIndex = 43;
            this.LblCor.Text = "Cor:";
            // 
            // LblDescricao
            // 
            this.LblDescricao.AutoSize = true;
            this.LblDescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescricao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDescricao.Location = new System.Drawing.Point(56, 253);
            this.LblDescricao.Name = "LblDescricao";
            this.LblDescricao.Size = new System.Drawing.Size(84, 20);
            this.LblDescricao.TabIndex = 41;
            this.LblDescricao.Text = "Descrição:";
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(858, 601);
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(319, 26);
            this.TxtPesquisar.TabIndex = 38;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            this.TxtPesquisar.Leave += new System.EventHandler(this.TxtPesquisar_Leave);
            // 
            // TxtCorMaterial
            // 
            this.TxtCorMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCorMaterial.Location = new System.Drawing.Point(151, 130);
            this.TxtCorMaterial.MaxLength = 100;
            this.TxtCorMaterial.Multiline = true;
            this.TxtCorMaterial.Name = "TxtCorMaterial";
            this.TxtCorMaterial.Size = new System.Drawing.Size(193, 32);
            this.TxtCorMaterial.TabIndex = 5;
            this.TxtCorMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCorMaterial_KeyPress);
            this.TxtCorMaterial.Leave += new System.EventHandler(this.TxtCorMaterial_Leave);
            // 
            // TxtNomeMaterial
            // 
            this.TxtNomeMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeMaterial.Location = new System.Drawing.Point(151, 54);
            this.TxtNomeMaterial.MaxLength = 30;
            this.TxtNomeMaterial.Multiline = true;
            this.TxtNomeMaterial.Name = "TxtNomeMaterial";
            this.TxtNomeMaterial.Size = new System.Drawing.Size(486, 32);
            this.TxtNomeMaterial.TabIndex = 17;
            this.TxtNomeMaterial.Enter += new System.EventHandler(this.TxtNomeMaterial_Enter);
            this.TxtNomeMaterial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNomeMaterial_KeyPress);
            this.TxtNomeMaterial.Leave += new System.EventHandler(this.TxtNomeMaterial_Leave);
            // 
            // TxtQtdDisponivel
            // 
            this.TxtQtdDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQtdDisponivel.Location = new System.Drawing.Point(151, 172);
            this.TxtQtdDisponivel.Multiline = true;
            this.TxtQtdDisponivel.Name = "TxtQtdDisponivel";
            this.TxtQtdDisponivel.Size = new System.Drawing.Size(193, 29);
            this.TxtQtdDisponivel.TabIndex = 29;
            this.TxtQtdDisponivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtQtdDisponivel.TextChanged += new System.EventHandler(this.TxtQtdDisponivel_TextChanged);
            this.TxtQtdDisponivel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQtdDisponivel_KeyPress);
            this.TxtQtdDisponivel.Leave += new System.EventHandler(this.TxtQtdDisponivel_Leave);
            // 
            // LblPesquisaCli
            // 
            this.LblPesquisaCli.AutoSize = true;
            this.LblPesquisaCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesquisaCli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPesquisaCli.Location = new System.Drawing.Point(723, 604);
            this.LblPesquisaCli.Name = "LblPesquisaCli";
            this.LblPesquisaCli.Size = new System.Drawing.Size(129, 20);
            this.LblPesquisaCli.TabIndex = 25;
            this.LblPesquisaCli.Text = "Pesquisar Nome:";
            // 
            // LblQtdTotal
            // 
            this.LblQtdTotal.AutoSize = true;
            this.LblQtdTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtdTotal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblQtdTotal.Location = new System.Drawing.Point(359, 172);
            this.LblQtdTotal.Name = "LblQtdTotal";
            this.LblQtdTotal.Size = new System.Drawing.Size(78, 20);
            this.LblQtdTotal.TabIndex = 19;
            this.LblQtdTotal.Text = "Qtd Total:";
            // 
            // TxtQdtTotal
            // 
            this.TxtQdtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQdtTotal.Location = new System.Drawing.Point(443, 170);
            this.TxtQdtTotal.Multiline = true;
            this.TxtQdtTotal.Name = "TxtQdtTotal";
            this.TxtQdtTotal.Size = new System.Drawing.Size(194, 32);
            this.TxtQdtTotal.TabIndex = 18;
            this.TxtQdtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtQdtTotal.TextChanged += new System.EventHandler(this.TxtQdtTotal_TextChanged);
            this.TxtQdtTotal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQdtTotal_KeyPress);
            this.TxtQdtTotal.Leave += new System.EventHandler(this.TxtQdtTotal_Leave);
            // 
            // LblModelo
            // 
            this.LblModelo.AutoSize = true;
            this.LblModelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblModelo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblModelo.Location = new System.Drawing.Point(76, 95);
            this.LblModelo.Name = "LblModelo";
            this.LblModelo.Size = new System.Drawing.Size(65, 20);
            this.LblModelo.TabIndex = 16;
            this.LblModelo.Text = "Modelo:";
            // 
            // LblPreço
            // 
            this.LblPreço.AutoSize = true;
            this.LblPreço.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPreço.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPreço.Location = new System.Drawing.Point(86, 213);
            this.LblPreço.Name = "LblPreço";
            this.LblPreço.Size = new System.Drawing.Size(54, 20);
            this.LblPreço.TabIndex = 15;
            this.LblPreço.Text = "Preço:";
            // 
            // LblNomeMaterial
            // 
            this.LblNomeMaterial.AutoSize = true;
            this.LblNomeMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomeMaterial.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNomeMaterial.Location = new System.Drawing.Point(86, 54);
            this.LblNomeMaterial.Name = "LblNomeMaterial";
            this.LblNomeMaterial.Size = new System.Drawing.Size(55, 20);
            this.LblNomeMaterial.TabIndex = 14;
            this.LblNomeMaterial.Text = "Nome:";
            // 
            // WFMaterialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 780);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBar);
            this.Name = "WFMaterialView";
            this.Text = "Cadastro de Materias";
            this.Load += new System.EventHandler(this.WFMaterialView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFMaterialView_KeyDown);
            this.panelBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelDados.ResumeLayout(false);
            this.panelDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxMaterail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMaterial)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DtgMaterial;
        private System.Windows.Forms.Panel panelDados;
        private System.Windows.Forms.Label LblDescricao;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.TextBox TxtCorMaterial;
        private System.Windows.Forms.TextBox TxtNomeMaterial;
        private System.Windows.Forms.TextBox TxtQtdDisponivel;
        private System.Windows.Forms.Label LblPesquisaCli;
        private System.Windows.Forms.Label LblQtdTotal;
        private System.Windows.Forms.TextBox TxtQdtTotal;
        private System.Windows.Forms.Label LblModelo;
        private System.Windows.Forms.Label LblPreço;
        private System.Windows.Forms.Label LblNomeMaterial;
        private System.Windows.Forms.Label LblCor;
        private System.Windows.Forms.Label LblQtdDisponivel;
        private System.Windows.Forms.RichTextBox RTxtDescricaoMaterial;
        private System.Windows.Forms.TextBox TxtPrecoMaterial;
        private System.Windows.Forms.TextBox TxtModeloMaterial;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.Button BtnProcurar;
        private System.Windows.Forms.PictureBox picBoxMaterail;
        private System.Windows.Forms.Label LblCodigo;
        private System.Windows.Forms.TextBox LblNumCodigo;
        private System.Windows.Forms.TextBox TxtCodigoBarra;
        private System.Windows.Forms.Label LblCodigoBarra;
        private System.Windows.Forms.Label LblQtdMin;
        private System.Windows.Forms.TextBox TxtQtdMin;
    }
}