namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFUsuarioView
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
            this.LblSenhadecod = new System.Windows.Forms.Label();
            this.checkBoxVerSenha = new System.Windows.Forms.CheckBox();
            this.TxtSenha = new System.Windows.Forms.MaskedTextBox();
            this.CboFuncionario = new System.Windows.Forms.ComboBox();
            this.panelBar = new System.Windows.Forms.Panel();
            this.BtnSalvar = new System.Windows.Forms.Button();
            this.BtnExcluir = new System.Windows.Forms.Button();
            this.BtnAlterar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnIncluir = new System.Windows.Forms.Button();
            this.TxtDescUsuario = new System.Windows.Forms.RichTextBox();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.LblPesquisaCli = new System.Windows.Forms.Label();
            this.CboTipoUsuario = new System.Windows.Forms.ComboBox();
            this.LblTipoUsuario = new System.Windows.Forms.Label();
            this.CboSituacao = new System.Windows.Forms.ComboBox();
            this.LblSituacao = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblNumCodigo = new System.Windows.Forms.Label();
            this.LblNumC = new System.Windows.Forms.Label();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.DtgUsuario = new System.Windows.Forms.DataGridView();
            this.LblSenha = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtLogin = new System.Windows.Forms.TextBox();
            this.LblLogin = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblFuncionario = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblSenhadecod);
            this.panel1.Controls.Add(this.checkBoxVerSenha);
            this.panel1.Controls.Add(this.TxtSenha);
            this.panel1.Controls.Add(this.CboFuncionario);
            this.panel1.Controls.Add(this.panelBar);
            this.panel1.Controls.Add(this.TxtDescUsuario);
            this.panel1.Controls.Add(this.TxtPesquisar);
            this.panel1.Controls.Add(this.LblPesquisaCli);
            this.panel1.Controls.Add(this.CboTipoUsuario);
            this.panel1.Controls.Add(this.LblTipoUsuario);
            this.panel1.Controls.Add(this.CboSituacao);
            this.panel1.Controls.Add(this.LblSituacao);
            this.panel1.Controls.Add(this.TxtEmail);
            this.panel1.Controls.Add(this.LblNumCodigo);
            this.panel1.Controls.Add(this.LblNumC);
            this.panel1.Controls.Add(this.LblTotalRegistros);
            this.panel1.Controls.Add(this.DtgUsuario);
            this.panel1.Controls.Add(this.LblSenha);
            this.panel1.Controls.Add(this.LblEmail);
            this.panel1.Controls.Add(this.TxtLogin);
            this.panel1.Controls.Add(this.LblLogin);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LblFuncionario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1195, 780);
            this.panel1.TabIndex = 23;
            // 
            // LblSenhadecod
            // 
            this.LblSenhadecod.AutoSize = true;
            this.LblSenhadecod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenhadecod.ForeColor = System.Drawing.Color.Firebrick;
            this.LblSenhadecod.Location = new System.Drawing.Point(240, 279);
            this.LblSenhadecod.Name = "LblSenhadecod";
            this.LblSenhadecod.Size = new System.Drawing.Size(0, 20);
            this.LblSenhadecod.TabIndex = 117;
            // 
            // checkBoxVerSenha
            // 
            this.checkBoxVerSenha.AutoSize = true;
            this.checkBoxVerSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVerSenha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.checkBoxVerSenha.Location = new System.Drawing.Point(139, 277);
            this.checkBoxVerSenha.Name = "checkBoxVerSenha";
            this.checkBoxVerSenha.Size = new System.Drawing.Size(96, 22);
            this.checkBoxVerSenha.TabIndex = 116;
            this.checkBoxVerSenha.Text = "Ver senha!";
            this.checkBoxVerSenha.UseVisualStyleBackColor = true;
            this.checkBoxVerSenha.CheckedChanged += new System.EventHandler(this.checkBoxVerSenha_CheckedChanged);
            // 
            // TxtSenha
            // 
            this.TxtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSenha.Location = new System.Drawing.Point(136, 238);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(275, 35);
            this.TxtSenha.TabIndex = 115;
            this.TxtSenha.UseSystemPasswordChar = true;
            this.TxtSenha.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSenha_KeyDown);
            // 
            // CboFuncionario
            // 
            this.CboFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboFuncionario.FormattingEnabled = true;
            this.CboFuncionario.Location = new System.Drawing.Point(132, 89);
            this.CboFuncionario.Name = "CboFuncionario";
            this.CboFuncionario.Size = new System.Drawing.Size(274, 28);
            this.CboFuncionario.TabIndex = 30;
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
            this.panelBar.TabIndex = 114;
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
            this.BtnSalvar.Location = new System.Drawing.Point(552, 1);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(107, 42);
            this.BtnSalvar.TabIndex = 76;
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
            this.BtnAlterar.Size = new System.Drawing.Size(105, 42);
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
            // TxtDescUsuario
            // 
            this.TxtDescUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescUsuario.Location = new System.Drawing.Point(81, 462);
            this.TxtDescUsuario.Name = "TxtDescUsuario";
            this.TxtDescUsuario.Size = new System.Drawing.Size(329, 53);
            this.TxtDescUsuario.TabIndex = 113;
            this.TxtDescUsuario.Text = "";
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(136, 530);
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(273, 31);
            this.TxtPesquisar.TabIndex = 111;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            // 
            // LblPesquisaCli
            // 
            this.LblPesquisaCli.AutoSize = true;
            this.LblPesquisaCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesquisaCli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPesquisaCli.Location = new System.Drawing.Point(35, 530);
            this.LblPesquisaCli.Name = "LblPesquisaCli";
            this.LblPesquisaCli.Size = new System.Drawing.Size(87, 20);
            this.LblPesquisaCli.TabIndex = 110;
            this.LblPesquisaCli.Text = "Pesquisar :\r\n";
            // 
            // CboTipoUsuario
            // 
            this.CboTipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboTipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoUsuario.FormattingEnabled = true;
            this.CboTipoUsuario.Location = new System.Drawing.Point(135, 357);
            this.CboTipoUsuario.Name = "CboTipoUsuario";
            this.CboTipoUsuario.Size = new System.Drawing.Size(274, 28);
            this.CboTipoUsuario.TabIndex = 74;
            this.CboTipoUsuario.Enter += new System.EventHandler(this.CboTipoUsuario_Enter);
            this.CboTipoUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboTipoUsuario_KeyDown);
            // 
            // LblTipoUsuario
            // 
            this.LblTipoUsuario.AutoSize = true;
            this.LblTipoUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoUsuario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTipoUsuario.Location = new System.Drawing.Point(33, 357);
            this.LblTipoUsuario.Name = "LblTipoUsuario";
            this.LblTipoUsuario.Size = new System.Drawing.Size(101, 21);
            this.LblTipoUsuario.TabIndex = 108;
            this.LblTipoUsuario.Text = "Tipo Usuário:";
            // 
            // CboSituacao
            // 
            this.CboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSituacao.FormattingEnabled = true;
            this.CboSituacao.Location = new System.Drawing.Point(136, 411);
            this.CboSituacao.Name = "CboSituacao";
            this.CboSituacao.Size = new System.Drawing.Size(272, 28);
            this.CboSituacao.TabIndex = 75;
            this.CboSituacao.Enter += new System.EventHandler(this.CboSituacao_Enter);
            this.CboSituacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboSituacao_KeyDown);
            // 
            // LblSituacao
            // 
            this.LblSituacao.AutoSize = true;
            this.LblSituacao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSituacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSituacao.Location = new System.Drawing.Point(33, 411);
            this.LblSituacao.Name = "LblSituacao";
            this.LblSituacao.Size = new System.Drawing.Size(72, 21);
            this.LblSituacao.TabIndex = 106;
            this.LblSituacao.Text = "Situação:";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(135, 301);
            this.TxtEmail.Multiline = true;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(275, 35);
            this.TxtEmail.TabIndex = 73;
            this.TxtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtEmail_KeyPress);
            // 
            // LblNumCodigo
            // 
            this.LblNumCodigo.AutoSize = true;
            this.LblNumCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumCodigo.ForeColor = System.Drawing.Color.Blue;
            this.LblNumCodigo.Location = new System.Drawing.Point(139, 129);
            this.LblNumCodigo.Name = "LblNumCodigo";
            this.LblNumCodigo.Size = new System.Drawing.Size(0, 20);
            this.LblNumCodigo.TabIndex = 103;
            // 
            // LblNumC
            // 
            this.LblNumC.AutoSize = true;
            this.LblNumC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumC.Location = new System.Drawing.Point(34, 129);
            this.LblNumC.Name = "LblNumC";
            this.LblNumC.Size = new System.Drawing.Size(63, 20);
            this.LblNumC.TabIndex = 82;
            this.LblNumC.Text = "Código:";
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(429, 533);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(137, 20);
            this.LblTotalRegistros.TabIndex = 81;
            this.LblTotalRegistros.Text = "Total de Registos:";
            // 
            // DtgUsuario
            // 
            this.DtgUsuario.AllowUserToAddRows = false;
            this.DtgUsuario.AllowUserToDeleteRows = false;
            this.DtgUsuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgUsuario.BackgroundColor = System.Drawing.Color.White;
            this.DtgUsuario.ColumnHeadersHeight = 40;
            this.DtgUsuario.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgUsuario.Location = new System.Drawing.Point(433, 87);
            this.DtgUsuario.Name = "DtgUsuario";
            this.DtgUsuario.RowTemplate.Height = 35;
            this.DtgUsuario.Size = new System.Drawing.Size(750, 438);
            this.DtgUsuario.TabIndex = 105;
            this.DtgUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgUsuario_CellClick);
            this.DtgUsuario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgUsuario_KeyUp);
            // 
            // LblSenha
            // 
            this.LblSenha.AutoSize = true;
            this.LblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSenha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSenha.Location = new System.Drawing.Point(33, 238);
            this.LblSenha.Name = "LblSenha";
            this.LblSenha.Size = new System.Drawing.Size(60, 20);
            this.LblSenha.TabIndex = 63;
            this.LblSenha.Text = "Senha:";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblEmail.Location = new System.Drawing.Point(34, 301);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(51, 21);
            this.LblEmail.TabIndex = 61;
            this.LblEmail.Text = "Email:";
            // 
            // TxtLogin
            // 
            this.TxtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogin.Location = new System.Drawing.Point(136, 187);
            this.TxtLogin.Multiline = true;
            this.TxtLogin.Name = "TxtLogin";
            this.TxtLogin.Size = new System.Drawing.Size(274, 34);
            this.TxtLogin.TabIndex = 60;
            this.TxtLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLogin_KeyDown);
            // 
            // LblLogin
            // 
            this.LblLogin.AutoSize = true;
            this.LblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLogin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblLogin.Location = new System.Drawing.Point(35, 187);
            this.LblLogin.Name = "LblLogin";
            this.LblLogin.Size = new System.Drawing.Size(52, 20);
            this.LblLogin.TabIndex = 59;
            this.LblLogin.Text = "Login:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(10, 524);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 1);
            this.panel2.TabIndex = 56;
            // 
            // LblFuncionario
            // 
            this.LblFuncionario.AutoSize = true;
            this.LblFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFuncionario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblFuncionario.Location = new System.Drawing.Point(33, 87);
            this.LblFuncionario.Name = "LblFuncionario";
            this.LblFuncionario.Size = new System.Drawing.Size(96, 20);
            this.LblFuncionario.TabIndex = 29;
            this.LblFuncionario.Text = "Funcionário:";
            // 
            // WFUsuarioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 780);
            this.Controls.Add(this.panel1);
            this.Name = "WFUsuarioView";
            this.Text = "Cadastrar Usuários";
            this.Load += new System.EventHandler(this.WFUsuarioView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DtgUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblNumCodigo;
        private System.Windows.Forms.Label LblNumC;
        private System.Windows.Forms.Label LblTotalRegistros;
        private System.Windows.Forms.DataGridView DtgUsuario;
        private System.Windows.Forms.Label LblSenha;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtLogin;
        private System.Windows.Forms.Label LblLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblFuncionario;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.ComboBox CboSituacao;
        private System.Windows.Forms.Label LblSituacao;
        private System.Windows.Forms.ComboBox CboTipoUsuario;
        private System.Windows.Forms.Label LblTipoUsuario;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.Label LblPesquisaCli;
        private System.Windows.Forms.RichTextBox TxtDescUsuario;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.Button BtnSalvar;
        private System.Windows.Forms.Button BtnExcluir;
        private System.Windows.Forms.Button BtnAlterar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnIncluir;
        private System.Windows.Forms.ComboBox CboFuncionario;
        private System.Windows.Forms.MaskedTextBox TxtSenha;
        private System.Windows.Forms.Label LblSenhadecod;
        private System.Windows.Forms.CheckBox checkBoxVerSenha;
    }
}