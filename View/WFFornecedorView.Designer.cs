namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFFornecedorView
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
            this.DtgFornecedor = new System.Windows.Forms.DataGridView();
            this.panelDados = new System.Windows.Forms.Panel();
            this.TxtCnpj = new System.Windows.Forms.TextBox();
            this.LblCnpj = new System.Windows.Forms.Label();
            this.LblDescForn = new System.Windows.Forms.Label();
            this.TxtDescForn = new System.Windows.Forms.TextBox();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.TxtNomeFornecedor = new System.Windows.Forms.TextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.BtnListaExcluirTel = new System.Windows.Forms.Button();
            this.BtnListaIncluirTel = new System.Windows.Forms.Button();
            this.BtnListaCancelarTel = new System.Windows.Forms.Button();
            this.MskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.MskDDD = new System.Windows.Forms.MaskedTextBox();
            this.CboTipoTel = new System.Windows.Forms.ComboBox();
            this.MskCep = new System.Windows.Forms.MaskedTextBox();
            this.CboBairro = new System.Windows.Forms.ComboBox();
            this.TxtNumLogradouro = new System.Windows.Forms.TextBox();
            this.CboSituacao = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.LblPesquisaCli = new System.Windows.Forms.Label();
            this.LblNumTel = new System.Windows.Forms.Label();
            this.LblBairro = new System.Windows.Forms.Label();
            this.LblCep = new System.Windows.Forms.Label();
            this.LblNumLogradouro = new System.Windows.Forms.Label();
            this.LblLogradouro = new System.Windows.Forms.Label();
            this.TxtLogradouro = new System.Windows.Forms.TextBox();
            this.LblSituacao = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblNomeFornecedor = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblTipoTel = new System.Windows.Forms.Label();
            this.LblNumCodigo = new System.Windows.Forms.Label();
            this.LvwTel = new System.Windows.Forms.ListView();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnIncluir = new System.Windows.Forms.Button();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgFornecedor)).BeginInit();
            this.panelDados.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgFornecedor
            // 
            this.DtgFornecedor.AllowUserToAddRows = false;
            this.DtgFornecedor.AllowUserToDeleteRows = false;
            this.DtgFornecedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgFornecedor.BackgroundColor = System.Drawing.Color.White;
            this.DtgFornecedor.ColumnHeadersHeight = 40;
            this.DtgFornecedor.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgFornecedor.Location = new System.Drawing.Point(541, 61);
            this.DtgFornecedor.Name = "DtgFornecedor";
            this.DtgFornecedor.RowTemplate.Height = 35;
            this.DtgFornecedor.Size = new System.Drawing.Size(644, 589);
            this.DtgFornecedor.TabIndex = 22;
            this.DtgFornecedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgFornecedor_CellClick);
            this.DtgFornecedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgFornecedor_KeyUp);
            // 
            // panelDados
            // 
            this.panelDados.Controls.Add(this.TxtCnpj);
            this.panelDados.Controls.Add(this.LblCnpj);
            this.panelDados.Controls.Add(this.LblDescForn);
            this.panelDados.Controls.Add(this.TxtDescForn);
            this.panelDados.Controls.Add(this.TxtPesquisar);
            this.panelDados.Controls.Add(this.TxtNomeFornecedor);
            this.panelDados.Controls.Add(this.TxtEmail);
            this.panelDados.Controls.Add(this.BtnListaExcluirTel);
            this.panelDados.Controls.Add(this.BtnListaIncluirTel);
            this.panelDados.Controls.Add(this.BtnListaCancelarTel);
            this.panelDados.Controls.Add(this.MskTelefone);
            this.panelDados.Controls.Add(this.MskDDD);
            this.panelDados.Controls.Add(this.CboTipoTel);
            this.panelDados.Controls.Add(this.MskCep);
            this.panelDados.Controls.Add(this.CboBairro);
            this.panelDados.Controls.Add(this.TxtNumLogradouro);
            this.panelDados.Controls.Add(this.CboSituacao);
            this.panelDados.Controls.Add(this.panel7);
            this.panelDados.Controls.Add(this.LblPesquisaCli);
            this.panelDados.Controls.Add(this.LblNumTel);
            this.panelDados.Controls.Add(this.LblBairro);
            this.panelDados.Controls.Add(this.LblCep);
            this.panelDados.Controls.Add(this.LblNumLogradouro);
            this.panelDados.Controls.Add(this.LblLogradouro);
            this.panelDados.Controls.Add(this.TxtLogradouro);
            this.panelDados.Controls.Add(this.LblSituacao);
            this.panelDados.Controls.Add(this.LblEmail);
            this.panelDados.Controls.Add(this.LblNomeFornecedor);
            this.panelDados.Controls.Add(this.panel5);
            this.panelDados.Controls.Add(this.panel4);
            this.panelDados.Controls.Add(this.panel3);
            this.panelDados.Controls.Add(this.LblTipoTel);
            this.panelDados.Controls.Add(this.LblNumCodigo);
            this.panelDados.Controls.Add(this.LvwTel);
            this.panelDados.ForeColor = System.Drawing.Color.Black;
            this.panelDados.Location = new System.Drawing.Point(2, 52);
            this.panelDados.Name = "panelDados";
            this.panelDados.Size = new System.Drawing.Size(533, 656);
            this.panelDados.TabIndex = 21;
            // 
            // TxtCnpj
            // 
            this.TxtCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCnpj.Location = new System.Drawing.Point(224, 122);
            this.TxtCnpj.MaxLength = 14;
            this.TxtCnpj.Multiline = true;
            this.TxtCnpj.Name = "TxtCnpj";
            this.TxtCnpj.Size = new System.Drawing.Size(293, 32);
            this.TxtCnpj.TabIndex = 46;
            // 
            // LblCnpj
            // 
            this.LblCnpj.AutoSize = true;
            this.LblCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCnpj.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCnpj.Location = new System.Drawing.Point(186, 125);
            this.LblCnpj.Name = "LblCnpj";
            this.LblCnpj.Size = new System.Drawing.Size(32, 20);
            this.LblCnpj.TabIndex = 45;
            this.LblCnpj.Text = "Nif:";
            // 
            // LblDescForn
            // 
            this.LblDescForn.AutoSize = true;
            this.LblDescForn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescForn.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDescForn.Location = new System.Drawing.Point(134, 166);
            this.LblDescForn.Name = "LblDescForn";
            this.LblDescForn.Size = new System.Drawing.Size(84, 20);
            this.LblDescForn.TabIndex = 42;
            this.LblDescForn.Text = "Descrição:";
            // 
            // TxtDescForn
            // 
            this.TxtDescForn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescForn.Location = new System.Drawing.Point(224, 163);
            this.TxtDescForn.Multiline = true;
            this.TxtDescForn.Name = "TxtDescForn";
            this.TxtDescForn.Size = new System.Drawing.Size(293, 85);
            this.TxtDescForn.TabIndex = 41;
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(240, 624);
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(277, 26);
            this.TxtPesquisar.TabIndex = 38;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            this.TxtPesquisar.Leave += new System.EventHandler(this.TxtPesquisar_Leave);
            // 
            // TxtNomeFornecedor
            // 
            this.TxtNomeFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeFornecedor.Location = new System.Drawing.Point(224, 6);
            this.TxtNomeFornecedor.MaxLength = 50;
            this.TxtNomeFornecedor.Multiline = true;
            this.TxtNomeFornecedor.Name = "TxtNomeFornecedor";
            this.TxtNomeFornecedor.Size = new System.Drawing.Size(293, 34);
            this.TxtNomeFornecedor.TabIndex = 5;
            this.TxtNomeFornecedor.Enter += new System.EventHandler(this.TxtNomeFornecedor_Enter);
            this.TxtNomeFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNomeFornecedor_KeyPress);
            this.TxtNomeFornecedor.Leave += new System.EventHandler(this.TxtNomeFornecedor_Leave);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(224, 47);
            this.TxtEmail.MaxLength = 30;
            this.TxtEmail.Multiline = true;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(293, 32);
            this.TxtEmail.TabIndex = 17;
            this.TxtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEmail_KeyPress);
            this.TxtEmail.Leave += new System.EventHandler(this.TxtEmail_Leave);
            // 
            // BtnListaExcluirTel
            // 
            this.BtnListaExcluirTel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListaExcluirTel.FlatAppearance.BorderSize = 0;
            this.BtnListaExcluirTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListaExcluirTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnListaExcluirTel.ForeColor = System.Drawing.Color.Black;
            this.BtnListaExcluirTel.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Delete_36px;
            this.BtnListaExcluirTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnListaExcluirTel.Location = new System.Drawing.Point(424, 414);
            this.BtnListaExcluirTel.Name = "BtnListaExcluirTel";
            this.BtnListaExcluirTel.Size = new System.Drawing.Size(37, 36);
            this.BtnListaExcluirTel.TabIndex = 37;
            this.BtnListaExcluirTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnListaExcluirTel.UseVisualStyleBackColor = true;
            this.BtnListaExcluirTel.Click += new System.EventHandler(this.BtnListaExcluirTel_Click);
            // 
            // BtnListaIncluirTel
            // 
            this.BtnListaIncluirTel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListaIncluirTel.FlatAppearance.BorderSize = 0;
            this.BtnListaIncluirTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListaIncluirTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnListaIncluirTel.ForeColor = System.Drawing.Color.White;
            this.BtnListaIncluirTel.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Plus_36px;
            this.BtnListaIncluirTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnListaIncluirTel.Location = new System.Drawing.Point(373, 414);
            this.BtnListaIncluirTel.Name = "BtnListaIncluirTel";
            this.BtnListaIncluirTel.Size = new System.Drawing.Size(31, 37);
            this.BtnListaIncluirTel.TabIndex = 36;
            this.BtnListaIncluirTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnListaIncluirTel.UseVisualStyleBackColor = true;
            this.BtnListaIncluirTel.Click += new System.EventHandler(this.BtnListaIncluirTel_Click);
            // 
            // BtnListaCancelarTel
            // 
            this.BtnListaCancelarTel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnListaCancelarTel.FlatAppearance.BorderSize = 0;
            this.BtnListaCancelarTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnListaCancelarTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnListaCancelarTel.ForeColor = System.Drawing.Color.White;
            this.BtnListaCancelarTel.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.Cancel_36px;
            this.BtnListaCancelarTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BtnListaCancelarTel.Location = new System.Drawing.Point(478, 414);
            this.BtnListaCancelarTel.Name = "BtnListaCancelarTel";
            this.BtnListaCancelarTel.Size = new System.Drawing.Size(36, 36);
            this.BtnListaCancelarTel.TabIndex = 35;
            this.BtnListaCancelarTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnListaCancelarTel.UseVisualStyleBackColor = true;
            this.BtnListaCancelarTel.Click += new System.EventHandler(this.BtnListaCancelarTel_Click);
            // 
            // MskTelefone
            // 
            this.MskTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskTelefone.Location = new System.Drawing.Point(190, 454);
            this.MskTelefone.Mask = "999-999-999";
            this.MskTelefone.Name = "MskTelefone";
            this.MskTelefone.Size = new System.Drawing.Size(174, 26);
            this.MskTelefone.TabIndex = 34;
            this.MskTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MskTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MskTelefone_KeyPress);
            // 
            // MskDDD
            // 
            this.MskDDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskDDD.Location = new System.Drawing.Point(146, 454);
            this.MskDDD.Mask = "(99)";
            this.MskDDD.Name = "MskDDD";
            this.MskDDD.Size = new System.Drawing.Size(33, 26);
            this.MskDDD.TabIndex = 33;
            this.MskDDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MskDDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MskDDD_KeyPress);
            // 
            // CboTipoTel
            // 
            this.CboTipoTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoTel.FormattingEnabled = true;
            this.CboTipoTel.Location = new System.Drawing.Point(146, 415);
            this.CboTipoTel.Name = "CboTipoTel";
            this.CboTipoTel.Size = new System.Drawing.Size(218, 28);
            this.CboTipoTel.TabIndex = 32;
            this.CboTipoTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboTipoTel_KeyDown);
            this.CboTipoTel.Leave += new System.EventHandler(this.CboTipoTel_Leave);
            // 
            // MskCep
            // 
            this.MskCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskCep.Location = new System.Drawing.Point(346, 370);
            this.MskCep.Mask = "99999-999";
            this.MskCep.Name = "MskCep";
            this.MskCep.Size = new System.Drawing.Size(174, 26);
            this.MskCep.TabIndex = 31;
            this.MskCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.MskCep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MskCep_KeyPress);
            this.MskCep.Leave += new System.EventHandler(this.MskCep_Leave);
            // 
            // CboBairro
            // 
            this.CboBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboBairro.FormattingEnabled = true;
            this.CboBairro.Location = new System.Drawing.Point(346, 336);
            this.CboBairro.Name = "CboBairro";
            this.CboBairro.Size = new System.Drawing.Size(171, 28);
            this.CboBairro.TabIndex = 30;
            // 
            // TxtNumLogradouro
            // 
            this.TxtNumLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumLogradouro.Location = new System.Drawing.Point(224, 301);
            this.TxtNumLogradouro.Multiline = true;
            this.TxtNumLogradouro.Name = "TxtNumLogradouro";
            this.TxtNumLogradouro.Size = new System.Drawing.Size(293, 29);
            this.TxtNumLogradouro.TabIndex = 29;
            // 
            // CboSituacao
            // 
            this.CboSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSituacao.FormattingEnabled = true;
            this.CboSituacao.Location = new System.Drawing.Point(346, 85);
            this.CboSituacao.Name = "CboSituacao";
            this.CboSituacao.Size = new System.Drawing.Size(171, 28);
            this.CboSituacao.TabIndex = 27;
            this.CboSituacao.Enter += new System.EventHandler(this.CboSituacao_Enter);
            this.CboSituacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboSituacao_KeyDown);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DimGray;
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(6, 614);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(514, 1);
            this.panel7.TabIndex = 26;
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
            // LblPesquisaCli
            // 
            this.LblPesquisaCli.AutoSize = true;
            this.LblPesquisaCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesquisaCli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPesquisaCli.Location = new System.Drawing.Point(6, 627);
            this.LblPesquisaCli.Name = "LblPesquisaCli";
            this.LblPesquisaCli.Size = new System.Drawing.Size(158, 20);
            this.LblPesquisaCli.TabIndex = 25;
            this.LblPesquisaCli.Text = "Pesquisar por nome :";
            // 
            // LblNumTel
            // 
            this.LblNumTel.AutoSize = true;
            this.LblNumTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumTel.Location = new System.Drawing.Point(5, 454);
            this.LblNumTel.Name = "LblNumTel";
            this.LblNumTel.Size = new System.Drawing.Size(132, 20);
            this.LblNumTel.TabIndex = 24;
            this.LblNumTel.Text = "DDD Nº telefone:";
            // 
            // LblBairro
            // 
            this.LblBairro.AutoSize = true;
            this.LblBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBairro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblBairro.Location = new System.Drawing.Point(161, 336);
            this.LblBairro.Name = "LblBairro";
            this.LblBairro.Size = new System.Drawing.Size(55, 20);
            this.LblBairro.TabIndex = 23;
            this.LblBairro.Text = "Bairro:";
            // 
            // LblCep
            // 
            this.LblCep.AutoSize = true;
            this.LblCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCep.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCep.Location = new System.Drawing.Point(170, 370);
            this.LblCep.Name = "LblCep";
            this.LblCep.Size = new System.Drawing.Size(45, 20);
            this.LblCep.TabIndex = 21;
            this.LblCep.Text = "CEP:";
            // 
            // LblNumLogradouro
            // 
            this.LblNumLogradouro.AutoSize = true;
            this.LblNumLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumLogradouro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumLogradouro.Location = new System.Drawing.Point(102, 301);
            this.LblNumLogradouro.Name = "LblNumLogradouro";
            this.LblNumLogradouro.Size = new System.Drawing.Size(116, 20);
            this.LblNumLogradouro.TabIndex = 20;
            this.LblNumLogradouro.Text = "Nº Logradouro:";
            // 
            // LblLogradouro
            // 
            this.LblLogradouro.AutoSize = true;
            this.LblLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogradouro.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblLogradouro.Location = new System.Drawing.Point(123, 266);
            this.LblLogradouro.Name = "LblLogradouro";
            this.LblLogradouro.Size = new System.Drawing.Size(95, 20);
            this.LblLogradouro.TabIndex = 19;
            this.LblLogradouro.Text = "Logradouro:";
            // 
            // TxtLogradouro
            // 
            this.TxtLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogradouro.Location = new System.Drawing.Point(224, 263);
            this.TxtLogradouro.Multiline = true;
            this.TxtLogradouro.Name = "TxtLogradouro";
            this.TxtLogradouro.Size = new System.Drawing.Size(293, 32);
            this.TxtLogradouro.TabIndex = 18;
            this.TxtLogradouro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLogradouro_KeyPress);
            // 
            // LblSituacao
            // 
            this.LblSituacao.AutoSize = true;
            this.LblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSituacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSituacao.Location = new System.Drawing.Point(146, 88);
            this.LblSituacao.Name = "LblSituacao";
            this.LblSituacao.Size = new System.Drawing.Size(76, 20);
            this.LblSituacao.TabIndex = 16;
            this.LblSituacao.Text = "Situação:";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblEmail.Location = new System.Drawing.Point(170, 50);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(52, 20);
            this.LblEmail.TabIndex = 15;
            this.LblEmail.Text = "Email:";
            // 
            // LblNomeFornecedor
            // 
            this.LblNomeFornecedor.AutoSize = true;
            this.LblNomeFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomeFornecedor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNomeFornecedor.Location = new System.Drawing.Point(170, 9);
            this.LblNomeFornecedor.Name = "LblNomeFornecedor";
            this.LblNomeFornecedor.Size = new System.Drawing.Size(55, 20);
            this.LblNomeFornecedor.TabIndex = 14;
            this.LblNomeFornecedor.Text = "Nome:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(9, 484);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(509, 1);
            this.panel5.TabIndex = 13;
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(9, 403);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(511, 1);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(9, 263);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(511, 1);
            this.panel3.TabIndex = 8;
            // 
            // LblTipoTel
            // 
            this.LblTipoTel.AutoSize = true;
            this.LblTipoTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTipoTel.Location = new System.Drawing.Point(5, 414);
            this.LblTipoTel.Name = "LblTipoTel";
            this.LblTipoTel.Size = new System.Drawing.Size(105, 20);
            this.LblTipoTel.TabIndex = 3;
            this.LblTipoTel.Text = "Tipo telefone:";
            // 
            // LblNumCodigo
            // 
            this.LblNumCodigo.AutoSize = true;
            this.LblNumCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumCodigo.Location = new System.Drawing.Point(6, 9);
            this.LblNumCodigo.Name = "LblNumCodigo";
            this.LblNumCodigo.Size = new System.Drawing.Size(63, 20);
            this.LblNumCodigo.TabIndex = 2;
            this.LblNumCodigo.Text = "Código:";
            // 
            // LvwTel
            // 
            this.LvwTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwTel.HideSelection = false;
            this.LvwTel.Location = new System.Drawing.Point(10, 489);
            this.LvwTel.Name = "LvwTel";
            this.LvwTel.Size = new System.Drawing.Size(507, 123);
            this.LvwTel.TabIndex = 39;
            this.LvwTel.UseCompatibleStateImageBehavior = false;
            this.LvwTel.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.LvwTel_ColumnWidthChanged);
            this.LvwTel.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.LvwTel_ItemSelectionChanged);
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
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(541, 652);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(141, 20);
            this.LblTotalRegistros.TabIndex = 23;
            this.LblTotalRegistros.Text = "Total de Registos: ";
            // 
            // WFFornecedorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 714);
            this.Controls.Add(this.LblTotalRegistros);
            this.Controls.Add(this.DtgFornecedor);
            this.Controls.Add(this.panelDados);
            this.Controls.Add(this.panelBar);
            this.Name = "WFFornecedorView";
            this.Text = "Cadastro de Fornecedores";
            this.Load += new System.EventHandler(this.WFFornecedorView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WFFornecedorView_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DtgFornecedor)).EndInit();
            this.panelDados.ResumeLayout(false);
            this.panelDados.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgFornecedor;
        private System.Windows.Forms.Panel panelDados;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.TextBox TxtNomeFornecedor;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Button BtnListaExcluirTel;
        private System.Windows.Forms.Button BtnListaIncluirTel;
        private System.Windows.Forms.Button BtnListaCancelarTel;
        private System.Windows.Forms.MaskedTextBox MskTelefone;
        private System.Windows.Forms.MaskedTextBox MskDDD;
        private System.Windows.Forms.ComboBox CboTipoTel;
        private System.Windows.Forms.MaskedTextBox MskCep;
        private System.Windows.Forms.ComboBox CboBairro;
        private System.Windows.Forms.TextBox TxtNumLogradouro;
        private System.Windows.Forms.ComboBox CboSituacao;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label LblPesquisaCli;
        private System.Windows.Forms.Label LblNumTel;
        private System.Windows.Forms.Label LblBairro;
        private System.Windows.Forms.Label LblCep;
        private System.Windows.Forms.Label LblNumLogradouro;
        private System.Windows.Forms.Label LblLogradouro;
        private System.Windows.Forms.TextBox TxtLogradouro;
        private System.Windows.Forms.Label LblSituacao;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblNomeFornecedor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblTipoTel;
        private System.Windows.Forms.Label LblNumCodigo;
        private System.Windows.Forms.ListView LvwTel;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.Label LblDescForn;
        private System.Windows.Forms.TextBox TxtDescForn;
        private System.Windows.Forms.TextBox TxtCnpj;
        private System.Windows.Forms.Label LblCnpj;
    }
}