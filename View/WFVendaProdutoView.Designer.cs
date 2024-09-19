namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFVendaProdutoView
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
            this.BtnFaturamento = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnFaturaPDF = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LblCliente = new System.Windows.Forms.Label();
            this.CboCliente = new System.Windows.Forms.ComboBox();
            this.TxtNumFatura = new System.Windows.Forms.TextBox();
            this.LblNumFatura = new System.Windows.Forms.Label();
            this.LblNomeCliente = new System.Windows.Forms.Label();
            this.LblDescProduto = new System.Windows.Forms.Label();
            this.TxtNomeProduto = new System.Windows.Forms.TextBox();
            this.LblQtdEstoque = new System.Windows.Forms.Label();
            this.TxtQtdEstoque = new System.Windows.Forms.TextBox();
            this.LblPrecoProduto = new System.Windows.Forms.Label();
            this.TxtPrecoProduto = new System.Windows.Forms.TextBox();
            this.LblQtdMinEstoque = new System.Windows.Forms.Label();
            this.TxtQtdMinEstoque = new System.Windows.Forms.TextBox();
            this.LblSituacao = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtQtdVendaProduto = new System.Windows.Forms.TextBox();
            this.BtnRemoverItem = new System.Windows.Forms.Button();
            this.DtgProduto = new System.Windows.Forms.DataGridView();
            this.LvwVenda = new System.Windows.Forms.ListView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.LblPesquisarProduto = new System.Windows.Forms.Label();
            this.RdbProduto = new System.Windows.Forms.RadioButton();
            this.RdbCodBarra = new System.Windows.Forms.RadioButton();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtSubTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtImpostos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDesconto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDinheiro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtTroco = new System.Windows.Forms.TextBox();
            this.TxtResultadoDesconto = new System.Windows.Forms.TextBox();
            this.TxtResultadoImposto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnRelacaoProduto = new System.Windows.Forms.Button();
            this.TxtSituacao = new System.Windows.Forms.TextBox();
            this.LblDataVenda = new System.Windows.Forms.Label();
            this.LblHoraVenda = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnLocalizarCliente = new FontAwesome.Sharp.IconPictureBox();
            this.BtnAtulizarCboCliente = new FontAwesome.Sharp.IconPictureBox();
            this.LblNumCodigo = new System.Windows.Forms.TextBox();
            this.LblCod = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblValorCodBarra = new System.Windows.Forms.TextBox();
            this.BtnAdicionarLista = new System.Windows.Forms.Button();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProduto)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BtnLocalizarCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAtulizarCboCliente)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnFaturamento
            // 
            this.BtnFaturamento.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnFaturamento.FlatAppearance.BorderSize = 0;
            this.BtnFaturamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFaturamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFaturamento.ForeColor = System.Drawing.Color.White;
            this.BtnFaturamento.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Plus_36px;
            this.BtnFaturamento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFaturamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnFaturamento.Location = new System.Drawing.Point(2, 3);
            this.BtnFaturamento.Name = "BtnFaturamento";
            this.BtnFaturamento.Size = new System.Drawing.Size(164, 40);
            this.BtnFaturamento.TabIndex = 9;
            this.BtnFaturamento.Text = "&Faturamento";
            this.BtnFaturamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnFaturamento.UseVisualStyleBackColor = true;
            this.BtnFaturamento.Click += new System.EventHandler(this.BtnFaturamento_Click);
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
            this.BtnCancelar.Location = new System.Drawing.Point(214, 3);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(130, 37);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "&Cancelar";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
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
            this.BtnSalvar.Location = new System.Drawing.Point(413, 3);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(112, 40);
            this.BtnSalvar.TabIndex = 7;
            this.BtnSalvar.Text = "&Salvar";
            this.BtnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalvar.UseVisualStyleBackColor = true;
            this.BtnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // panelBar
            // 
            this.panelBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(207)))), ((int)(((byte)(223)))));
            this.panelBar.Controls.Add(this.BtnFaturaPDF);
            this.panelBar.Controls.Add(this.BtnSalvar);
            this.panelBar.Controls.Add(this.BtnCancelar);
            this.panelBar.Controls.Add(this.BtnFaturamento);
            this.panelBar.Controls.Add(this.LblDataVenda);
            this.panelBar.Controls.Add(this.LblHoraVenda);
            this.panelBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBar.Location = new System.Drawing.Point(0, 0);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(1195, 46);
            this.panelBar.TabIndex = 21;
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
            this.BtnFaturaPDF.Location = new System.Drawing.Point(594, 4);
            this.BtnFaturaPDF.Name = "BtnFaturaPDF";
            this.BtnFaturaPDF.Size = new System.Drawing.Size(109, 38);
            this.BtnFaturaPDF.TabIndex = 10;
            this.BtnFaturaPDF.Text = "&Fatura";
            this.BtnFaturaPDF.UseVisualStyleBackColor = true;
            this.BtnFaturaPDF.Click += new System.EventHandler(this.BtnFaturaPDF_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCliente.Location = new System.Drawing.Point(85, 53);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(62, 20);
            this.LblCliente.TabIndex = 29;
            this.LblCliente.Text = "Cliente:";
            // 
            // CboCliente
            // 
            this.CboCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.CboCliente.FormattingEnabled = true;
            this.CboCliente.Location = new System.Drawing.Point(151, 53);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Size = new System.Drawing.Size(252, 28);
            this.CboCliente.TabIndex = 30;
            this.CboCliente.Enter += new System.EventHandler(this.CboCliente_Enter);
            this.CboCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboCliente_KeyDown);
            // 
            // TxtNumFatura
            // 
            this.TxtNumFatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumFatura.Location = new System.Drawing.Point(150, 18);
            this.TxtNumFatura.Multiline = true;
            this.TxtNumFatura.Name = "TxtNumFatura";
            this.TxtNumFatura.ReadOnly = true;
            this.TxtNumFatura.Size = new System.Drawing.Size(324, 30);
            this.TxtNumFatura.TabIndex = 31;
            this.TxtNumFatura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumFatura_KeyPress);
            // 
            // LblNumFatura
            // 
            this.LblNumFatura.AutoSize = true;
            this.LblNumFatura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumFatura.ForeColor = System.Drawing.Color.Red;
            this.LblNumFatura.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumFatura.Location = new System.Drawing.Point(66, 21);
            this.LblNumFatura.Name = "LblNumFatura";
            this.LblNumFatura.Size = new System.Drawing.Size(81, 20);
            this.LblNumFatura.TabIndex = 32;
            this.LblNumFatura.Text = "Nº Fatura:";
            // 
            // LblNomeCliente
            // 
            this.LblNomeCliente.AutoSize = true;
            this.LblNomeCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomeCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LblNomeCliente.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNomeCliente.Location = new System.Drawing.Point(32, 89);
            this.LblNomeCliente.Name = "LblNomeCliente";
            this.LblNomeCliente.Size = new System.Drawing.Size(111, 21);
            this.LblNomeCliente.TabIndex = 58;
            this.LblNomeCliente.Text = "Código Barras:";
            // 
            // LblDescProduto
            // 
            this.LblDescProduto.AutoSize = true;
            this.LblDescProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDescProduto.Location = new System.Drawing.Point(17, 122);
            this.LblDescProduto.Name = "LblDescProduto";
            this.LblDescProduto.Size = new System.Drawing.Size(119, 20);
            this.LblDescProduto.TabIndex = 59;
            this.LblDescProduto.Text = "Nome  Produto:";
            // 
            // TxtNomeProduto
            // 
            this.TxtNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeProduto.Location = new System.Drawing.Point(151, 122);
            this.TxtNomeProduto.Multiline = true;
            this.TxtNomeProduto.Name = "TxtNomeProduto";
            this.TxtNomeProduto.ReadOnly = true;
            this.TxtNomeProduto.Size = new System.Drawing.Size(323, 30);
            this.TxtNomeProduto.TabIndex = 60;
            // 
            // LblQtdEstoque
            // 
            this.LblQtdEstoque.AutoSize = true;
            this.LblQtdEstoque.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtdEstoque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblQtdEstoque.Location = new System.Drawing.Point(38, 189);
            this.LblQtdEstoque.Name = "LblQtdEstoque";
            this.LblQtdEstoque.Size = new System.Drawing.Size(98, 21);
            this.LblQtdEstoque.TabIndex = 61;
            this.LblQtdEstoque.Text = "Qtd Estoque:";
            // 
            // TxtQtdEstoque
            // 
            this.TxtQtdEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQtdEstoque.Location = new System.Drawing.Point(151, 187);
            this.TxtQtdEstoque.Multiline = true;
            this.TxtQtdEstoque.Name = "TxtQtdEstoque";
            this.TxtQtdEstoque.ReadOnly = true;
            this.TxtQtdEstoque.Size = new System.Drawing.Size(142, 30);
            this.TxtQtdEstoque.TabIndex = 62;
            this.TxtQtdEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblPrecoProduto
            // 
            this.LblPrecoProduto.AutoSize = true;
            this.LblPrecoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPrecoProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPrecoProduto.Location = new System.Drawing.Point(22, 155);
            this.LblPrecoProduto.Name = "LblPrecoProduto";
            this.LblPrecoProduto.Size = new System.Drawing.Size(114, 20);
            this.LblPrecoProduto.TabIndex = 63;
            this.LblPrecoProduto.Text = "Preço Produto:";
            // 
            // TxtPrecoProduto
            // 
            this.TxtPrecoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPrecoProduto.Location = new System.Drawing.Point(151, 155);
            this.TxtPrecoProduto.Multiline = true;
            this.TxtPrecoProduto.Name = "TxtPrecoProduto";
            this.TxtPrecoProduto.ReadOnly = true;
            this.TxtPrecoProduto.Size = new System.Drawing.Size(142, 30);
            this.TxtPrecoProduto.TabIndex = 64;
            this.TxtPrecoProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblQtdMinEstoque
            // 
            this.LblQtdMinEstoque.AutoSize = true;
            this.LblQtdMinEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblQtdMinEstoque.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblQtdMinEstoque.Location = new System.Drawing.Point(4, 224);
            this.LblQtdMinEstoque.Name = "LblQtdMinEstoque";
            this.LblQtdMinEstoque.Size = new System.Drawing.Size(136, 20);
            this.LblQtdMinEstoque.TabIndex = 65;
            this.LblQtdMinEstoque.Text = "Qtd Min. Estoque:";
            // 
            // TxtQtdMinEstoque
            // 
            this.TxtQtdMinEstoque.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQtdMinEstoque.Location = new System.Drawing.Point(151, 219);
            this.TxtQtdMinEstoque.Multiline = true;
            this.TxtQtdMinEstoque.Name = "TxtQtdMinEstoque";
            this.TxtQtdMinEstoque.ReadOnly = true;
            this.TxtQtdMinEstoque.Size = new System.Drawing.Size(142, 30);
            this.TxtQtdMinEstoque.TabIndex = 66;
            this.TxtQtdMinEstoque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblSituacao
            // 
            this.LblSituacao.AutoSize = true;
            this.LblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSituacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSituacao.Location = new System.Drawing.Point(60, 255);
            this.LblSituacao.Name = "LblSituacao";
            this.LblSituacao.Size = new System.Drawing.Size(76, 20);
            this.LblSituacao.TabIndex = 67;
            this.LblSituacao.Text = "Situação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(50, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 69;
            this.label1.Text = "Qtd Venda:";
            // 
            // TxtQtdVendaProduto
            // 
            this.TxtQtdVendaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtQtdVendaProduto.Location = new System.Drawing.Point(151, 283);
            this.TxtQtdVendaProduto.Multiline = true;
            this.TxtQtdVendaProduto.Name = "TxtQtdVendaProduto";
            this.TxtQtdVendaProduto.Size = new System.Drawing.Size(142, 30);
            this.TxtQtdVendaProduto.TabIndex = 70;
            this.TxtQtdVendaProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtQtdVendaProduto.TextChanged += new System.EventHandler(this.TxtQtdVendaProduto_TextChanged);
            this.TxtQtdVendaProduto.Enter += new System.EventHandler(this.TxtQtdVendaProduto_Enter);
            this.TxtQtdVendaProduto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtQtdVendaProduto_KeyPress);
            this.TxtQtdVendaProduto.Leave += new System.EventHandler(this.TxtQtdVendaProduto_Leave);
            // 
            // BtnRemoverItem
            // 
            this.BtnRemoverItem.BackColor = System.Drawing.Color.Tomato;
            this.BtnRemoverItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoverItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemoverItem.ForeColor = System.Drawing.Color.White;
            this.BtnRemoverItem.Location = new System.Drawing.Point(150, 370);
            this.BtnRemoverItem.Name = "BtnRemoverItem";
            this.BtnRemoverItem.Size = new System.Drawing.Size(134, 31);
            this.BtnRemoverItem.TabIndex = 72;
            this.BtnRemoverItem.Text = "Remover Item";
            this.BtnRemoverItem.UseVisualStyleBackColor = false;
            this.BtnRemoverItem.Click += new System.EventHandler(this.BtnRemoverItem_Click);
            // 
            // DtgProduto
            // 
            this.DtgProduto.AllowUserToAddRows = false;
            this.DtgProduto.AllowUserToDeleteRows = false;
            this.DtgProduto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgProduto.BackgroundColor = System.Drawing.Color.White;
            this.DtgProduto.ColumnHeadersHeight = 40;
            this.DtgProduto.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgProduto.Location = new System.Drawing.Point(480, 46);
            this.DtgProduto.Name = "DtgProduto";
            this.DtgProduto.RowTemplate.Height = 35;
            this.DtgProduto.Size = new System.Drawing.Size(701, 289);
            this.DtgProduto.TabIndex = 73;
            this.DtgProduto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgProduto_CellClick);
            this.DtgProduto.Enter += new System.EventHandler(this.DtgProduto_Enter);
            this.DtgProduto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DtgProduto_KeyDown);
            this.DtgProduto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgProduto_KeyUp);
            // 
            // LvwVenda
            // 
            this.LvwVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwVenda.HideSelection = false;
            this.LvwVenda.Location = new System.Drawing.Point(3, 406);
            this.LvwVenda.Name = "LvwVenda";
            this.LvwVenda.Size = new System.Drawing.Size(577, 216);
            this.LvwVenda.TabIndex = 76;
            this.LvwVenda.UseCompatibleStateImageBehavior = false;
            this.LvwVenda.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LvwVenda_ItemSelectionChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 403);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1178, 1);
            this.panel5.TabIndex = 74;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(0, 42);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(500, 1);
            this.panel6.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DimGray;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(4, 624);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(576, 1);
            this.panel7.TabIndex = 75;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.Black;
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(0, 42);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(500, 1);
            this.panel8.TabIndex = 14;
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(836, 369);
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(345, 30);
            this.TxtPesquisar.TabIndex = 77;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            // 
            // LblPesquisarProduto
            // 
            this.LblPesquisarProduto.AutoSize = true;
            this.LblPesquisarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesquisarProduto.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPesquisarProduto.Location = new System.Drawing.Point(449, 372);
            this.LblPesquisarProduto.Name = "LblPesquisarProduto";
            this.LblPesquisarProduto.Size = new System.Drawing.Size(147, 20);
            this.LblPesquisarProduto.TabIndex = 78;
            this.LblPesquisarProduto.Text = "Pesquisar Produto: ";
            // 
            // RdbProduto
            // 
            this.RdbProduto.AutoSize = true;
            this.RdbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbProduto.Location = new System.Drawing.Point(613, 371);
            this.RdbProduto.Name = "RdbProduto";
            this.RdbProduto.Size = new System.Drawing.Size(83, 24);
            this.RdbProduto.TabIndex = 79;
            this.RdbProduto.TabStop = true;
            this.RdbProduto.Text = "Produto";
            this.RdbProduto.UseVisualStyleBackColor = true;
            this.RdbProduto.Click += new System.EventHandler(this.RdbProduto_Click);
            // 
            // RdbCodBarra
            // 
            this.RdbCodBarra.AutoSize = true;
            this.RdbCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RdbCodBarra.Location = new System.Drawing.Point(702, 371);
            this.RdbCodBarra.Name = "RdbCodBarra";
            this.RdbCodBarra.Size = new System.Drawing.Size(128, 24);
            this.RdbCodBarra.TabIndex = 80;
            this.RdbCodBarra.TabStop = true;
            this.RdbCodBarra.Text = "Codigo Barras";
            this.RdbCodBarra.UseVisualStyleBackColor = true;
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(475, 338);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(137, 20);
            this.LblTotalRegistros.TabIndex = 81;
            this.LblTotalRegistros.Text = "Total de Registos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(586, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 85;
            this.label5.Text = "Sub Total AOA:";
            // 
            // TxtSubTotal
            // 
            this.TxtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSubTotal.Location = new System.Drawing.Point(717, 410);
            this.TxtSubTotal.Multiline = true;
            this.TxtSubTotal.Name = "TxtSubTotal";
            this.TxtSubTotal.ReadOnly = true;
            this.TxtSubTotal.Size = new System.Drawing.Size(201, 30);
            this.TxtSubTotal.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(624, 445);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 87;
            this.label2.Text = "Impostos:";
            // 
            // TxtImpostos
            // 
            this.TxtImpostos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtImpostos.Location = new System.Drawing.Point(717, 445);
            this.TxtImpostos.Multiline = true;
            this.TxtImpostos.Name = "TxtImpostos";
            this.TxtImpostos.Size = new System.Drawing.Size(201, 30);
            this.TxtImpostos.TabIndex = 88;
            this.TxtImpostos.TextChanged += new System.EventHandler(this.TxtImpostos_TextChanged);
            this.TxtImpostos.Enter += new System.EventHandler(this.TxtImpostos_Enter);
            this.TxtImpostos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtImpostos_KeyPress);
            this.TxtImpostos.Leave += new System.EventHandler(this.TxtImpostos_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(621, 481);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 89;
            this.label3.Text = "Desconto:";
            // 
            // TxtDesconto
            // 
            this.TxtDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDesconto.Location = new System.Drawing.Point(717, 481);
            this.TxtDesconto.Multiline = true;
            this.TxtDesconto.Name = "TxtDesconto";
            this.TxtDesconto.Size = new System.Drawing.Size(201, 30);
            this.TxtDesconto.TabIndex = 90;
            this.TxtDesconto.TextChanged += new System.EventHandler(this.TxtDesconto_TextChanged);
            this.TxtDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDesconto_KeyPress);
            this.TxtDesconto.Leave += new System.EventHandler(this.TxtDesconto_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(617, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 91;
            this.label4.Text = "Total AOA:";
            // 
            // TxtTotal
            // 
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(717, 524);
            this.TxtTotal.Multiline = true;
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(201, 30);
            this.TxtTotal.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(631, 561);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 93;
            this.label6.Text = "Dinheiro:";
            // 
            // TxtDinheiro
            // 
            this.TxtDinheiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDinheiro.Location = new System.Drawing.Point(717, 558);
            this.TxtDinheiro.Multiline = true;
            this.TxtDinheiro.Name = "TxtDinheiro";
            this.TxtDinheiro.Size = new System.Drawing.Size(201, 30);
            this.TxtDinheiro.TabIndex = 94;
            this.TxtDinheiro.TextChanged += new System.EventHandler(this.TxtDinheiro_TextChanged);
            this.TxtDinheiro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDinheiro_KeyPress);
            this.TxtDinheiro.Leave += new System.EventHandler(this.TxtDinheiro_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(650, 595);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 95;
            this.label7.Text = "Troco:";
            // 
            // TxtTroco
            // 
            this.TxtTroco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTroco.Location = new System.Drawing.Point(717, 592);
            this.TxtTroco.Multiline = true;
            this.TxtTroco.Name = "TxtTroco";
            this.TxtTroco.ReadOnly = true;
            this.TxtTroco.Size = new System.Drawing.Size(201, 30);
            this.TxtTroco.TabIndex = 96;
            this.TxtTroco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtTroco_KeyPress);
            // 
            // TxtResultadoDesconto
            // 
            this.TxtResultadoDesconto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtResultadoDesconto.Location = new System.Drawing.Point(1001, 478);
            this.TxtResultadoDesconto.Multiline = true;
            this.TxtResultadoDesconto.Name = "TxtResultadoDesconto";
            this.TxtResultadoDesconto.ReadOnly = true;
            this.TxtResultadoDesconto.Size = new System.Drawing.Size(180, 30);
            this.TxtResultadoDesconto.TabIndex = 98;
            // 
            // TxtResultadoImposto
            // 
            this.TxtResultadoImposto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtResultadoImposto.Location = new System.Drawing.Point(1001, 442);
            this.TxtResultadoImposto.Multiline = true;
            this.TxtResultadoImposto.Name = "TxtResultadoImposto";
            this.TxtResultadoImposto.ReadOnly = true;
            this.TxtResultadoImposto.Size = new System.Drawing.Size(180, 30);
            this.TxtResultadoImposto.TabIndex = 99;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(938, 475);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 24);
            this.label10.TabIndex = 101;
            this.label10.Text = "%  =";
            // 
            // BtnRelacaoProduto
            // 
            this.BtnRelacaoProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRelacaoProduto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BtnRelacaoProduto.Location = new System.Drawing.Point(480, 18);
            this.BtnRelacaoProduto.Name = "BtnRelacaoProduto";
            this.BtnRelacaoProduto.Size = new System.Drawing.Size(701, 28);
            this.BtnRelacaoProduto.TabIndex = 102;
            this.BtnRelacaoProduto.Text = "Relação de Produto";
            this.BtnRelacaoProduto.UseVisualStyleBackColor = true;
            // 
            // TxtSituacao
            // 
            this.TxtSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSituacao.Location = new System.Drawing.Point(151, 251);
            this.TxtSituacao.Multiline = true;
            this.TxtSituacao.Name = "TxtSituacao";
            this.TxtSituacao.ReadOnly = true;
            this.TxtSituacao.Size = new System.Drawing.Size(142, 30);
            this.TxtSituacao.TabIndex = 104;
            this.TxtSituacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblDataVenda
            // 
            this.LblDataVenda.AutoSize = true;
            this.LblDataVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDataVenda.ForeColor = System.Drawing.Color.White;
            this.LblDataVenda.Location = new System.Drawing.Point(976, 4);
            this.LblDataVenda.Name = "LblDataVenda";
            this.LblDataVenda.Size = new System.Drawing.Size(95, 20);
            this.LblDataVenda.TabIndex = 105;
            this.LblDataVenda.Text = "Dt. Venda:";
            // 
            // LblHoraVenda
            // 
            this.LblHoraVenda.AutoSize = true;
            this.LblHoraVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHoraVenda.ForeColor = System.Drawing.Color.White;
            this.LblHoraVenda.Location = new System.Drawing.Point(1010, 24);
            this.LblHoraVenda.Name = "LblHoraVenda";
            this.LblHoraVenda.Size = new System.Drawing.Size(58, 20);
            this.LblHoraVenda.TabIndex = 106;
            this.LblHoraVenda.Text = "Hora: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(940, 445);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 24);
            this.label9.TabIndex = 107;
            this.label9.Text = "%  =";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(618, 516);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 1);
            this.panel3.TabIndex = 76;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 42);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(500, 1);
            this.panel4.TabIndex = 14;
            // 
            // BtnLocalizarCliente
            // 
            this.BtnLocalizarCliente.BackColor = System.Drawing.SystemColors.Window;
            this.BtnLocalizarCliente.ForeColor = System.Drawing.Color.DimGray;
            this.BtnLocalizarCliente.IconChar = FontAwesome.Sharp.IconChar.Searchengin;
            this.BtnLocalizarCliente.IconColor = System.Drawing.Color.DimGray;
            this.BtnLocalizarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnLocalizarCliente.Location = new System.Drawing.Point(403, 50);
            this.BtnLocalizarCliente.Name = "BtnLocalizarCliente";
            this.BtnLocalizarCliente.Size = new System.Drawing.Size(37, 32);
            this.BtnLocalizarCliente.TabIndex = 109;
            this.BtnLocalizarCliente.TabStop = false;
            this.BtnLocalizarCliente.Click += new System.EventHandler(this.BtnLocalizarCliente_Click_1);
            this.BtnLocalizarCliente.MouseLeave += new System.EventHandler(this.BtnLocalizarCliente_MouseLeave);
            this.BtnLocalizarCliente.MouseHover += new System.EventHandler(this.BtnLocalizarCliente_MouseHover);
            // 
            // BtnAtulizarCboCliente
            // 
            this.BtnAtulizarCboCliente.BackColor = System.Drawing.Color.White;
            this.BtnAtulizarCboCliente.ForeColor = System.Drawing.Color.DimGray;
            this.BtnAtulizarCboCliente.IconChar = FontAwesome.Sharp.IconChar.Repeat;
            this.BtnAtulizarCboCliente.IconColor = System.Drawing.Color.DimGray;
            this.BtnAtulizarCboCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnAtulizarCboCliente.Location = new System.Drawing.Point(442, 50);
            this.BtnAtulizarCboCliente.Name = "BtnAtulizarCboCliente";
            this.BtnAtulizarCboCliente.Size = new System.Drawing.Size(32, 32);
            this.BtnAtulizarCboCliente.TabIndex = 110;
            this.BtnAtulizarCboCliente.TabStop = false;
            this.BtnAtulizarCboCliente.Click += new System.EventHandler(this.BtnAtulizarCboCliente_Click);
            this.BtnAtulizarCboCliente.MouseLeave += new System.EventHandler(this.BtnAtulizarCboCliente_MouseLeave);
            this.BtnAtulizarCboCliente.MouseHover += new System.EventHandler(this.BtnAtulizarCboCliente_MouseHover);
            // 
            // LblNumCodigo
            // 
            this.LblNumCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumCodigo.Location = new System.Drawing.Point(336, 155);
            this.LblNumCodigo.Multiline = true;
            this.LblNumCodigo.Name = "LblNumCodigo";
            this.LblNumCodigo.ReadOnly = true;
            this.LblNumCodigo.Size = new System.Drawing.Size(138, 30);
            this.LblNumCodigo.TabIndex = 111;
            // 
            // LblCod
            // 
            this.LblCod.AutoSize = true;
            this.LblCod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCod.Location = new System.Drawing.Point(295, 159);
            this.LblCod.Name = "LblCod";
            this.LblCod.Size = new System.Drawing.Size(41, 21);
            this.LblCod.TabIndex = 112;
            this.LblCod.Text = "Cod:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblValorCodBarra);
            this.panel1.Controls.Add(this.LblCod);
            this.panel1.Controls.Add(this.LblNumCodigo);
            this.panel1.Controls.Add(this.BtnAtulizarCboCliente);
            this.panel1.Controls.Add(this.BtnLocalizarCliente);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.TxtSituacao);
            this.panel1.Controls.Add(this.BtnRelacaoProduto);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.TxtResultadoImposto);
            this.panel1.Controls.Add(this.TxtResultadoDesconto);
            this.panel1.Controls.Add(this.TxtTroco);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.TxtDinheiro);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TxtTotal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TxtDesconto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TxtImpostos);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtSubTotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.LblTotalRegistros);
            this.panel1.Controls.Add(this.RdbCodBarra);
            this.panel1.Controls.Add(this.RdbProduto);
            this.panel1.Controls.Add(this.LblPesquisarProduto);
            this.panel1.Controls.Add(this.TxtPesquisar);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.LvwVenda);
            this.panel1.Controls.Add(this.DtgProduto);
            this.panel1.Controls.Add(this.BtnRemoverItem);
            this.panel1.Controls.Add(this.BtnAdicionarLista);
            this.panel1.Controls.Add(this.TxtQtdVendaProduto);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblSituacao);
            this.panel1.Controls.Add(this.TxtQtdMinEstoque);
            this.panel1.Controls.Add(this.LblQtdMinEstoque);
            this.panel1.Controls.Add(this.TxtPrecoProduto);
            this.panel1.Controls.Add(this.LblPrecoProduto);
            this.panel1.Controls.Add(this.TxtQtdEstoque);
            this.panel1.Controls.Add(this.LblQtdEstoque);
            this.panel1.Controls.Add(this.TxtNomeProduto);
            this.panel1.Controls.Add(this.LblDescProduto);
            this.panel1.Controls.Add(this.LblNomeCliente);
            this.panel1.Controls.Add(this.LblNumFatura);
            this.panel1.Controls.Add(this.TxtNumFatura);
            this.panel1.Controls.Add(this.CboCliente);
            this.panel1.Controls.Add(this.LblCliente);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 734);
            this.panel1.TabIndex = 22;
            // 
            // LblValorCodBarra
            // 
            this.LblValorCodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValorCodBarra.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.LblValorCodBarra.Location = new System.Drawing.Point(151, 86);
            this.LblValorCodBarra.Multiline = true;
            this.LblValorCodBarra.Name = "LblValorCodBarra";
            this.LblValorCodBarra.ReadOnly = true;
            this.LblValorCodBarra.Size = new System.Drawing.Size(322, 32);
            this.LblValorCodBarra.TabIndex = 113;
            // 
            // BtnAdicionarLista
            // 
            this.BtnAdicionarLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(207)))), ((int)(((byte)(223)))));
            this.BtnAdicionarLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdicionarLista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdicionarLista.ForeColor = System.Drawing.Color.White;
            this.BtnAdicionarLista.Location = new System.Drawing.Point(4, 370);
            this.BtnAdicionarLista.Name = "BtnAdicionarLista";
            this.BtnAdicionarLista.Size = new System.Drawing.Size(136, 31);
            this.BtnAdicionarLista.TabIndex = 71;
            this.BtnAdicionarLista.Text = "Adicionar Item";
            this.BtnAdicionarLista.UseVisualStyleBackColor = false;
            this.BtnAdicionarLista.Click += new System.EventHandler(this.BtnAdicionarLista_Click);
            // 
            // WFVendaProdutoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 780);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBar);
            this.Name = "WFVendaProdutoView";
            this.Text = "Venda de Produtos";
            this.Load += new System.EventHandler(this.WFVendaProdutoView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFVendaProdutoView_KeyDown);
            this.panelBar.ResumeLayout(false);
            this.panelBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgProduto)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BtnLocalizarCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnAtulizarCboCliente)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnFaturamento;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BtnFaturaPDF;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.ComboBox CboCliente;
        private System.Windows.Forms.TextBox TxtNumFatura;
        private System.Windows.Forms.Label LblNumFatura;
        private System.Windows.Forms.Label LblNomeCliente;
        private System.Windows.Forms.Label LblDescProduto;
        private System.Windows.Forms.TextBox TxtNomeProduto;
        private System.Windows.Forms.Label LblQtdEstoque;
        private System.Windows.Forms.TextBox TxtQtdEstoque;
        private System.Windows.Forms.Label LblPrecoProduto;
        private System.Windows.Forms.TextBox TxtPrecoProduto;
        private System.Windows.Forms.Label LblQtdMinEstoque;
        private System.Windows.Forms.TextBox TxtQtdMinEstoque;
        private System.Windows.Forms.Label LblSituacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtQtdVendaProduto;
        private System.Windows.Forms.Button BtnRemoverItem;
        private System.Windows.Forms.DataGridView DtgProduto;
        private System.Windows.Forms.ListView LvwVenda;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.Label LblPesquisarProduto;
        private System.Windows.Forms.RadioButton RdbProduto;
        private System.Windows.Forms.RadioButton RdbCodBarra;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtSubTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtImpostos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDesconto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDinheiro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtTroco;
        private System.Windows.Forms.TextBox TxtResultadoDesconto;
        private System.Windows.Forms.TextBox TxtResultadoImposto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button BtnRelacaoProduto;
        private System.Windows.Forms.TextBox TxtSituacao;
        private System.Windows.Forms.Label LblDataVenda;
        private System.Windows.Forms.Label LblHoraVenda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private FontAwesome.Sharp.IconPictureBox BtnLocalizarCliente;
        private FontAwesome.Sharp.IconPictureBox BtnAtulizarCboCliente;
        private System.Windows.Forms.TextBox LblNumCodigo;
        private System.Windows.Forms.Label LblCod;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox LblValorCodBarra;
        private System.Windows.Forms.Button BtnAdicionarLista;
    }
}