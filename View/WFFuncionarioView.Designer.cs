namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    partial class WFFuncionarioView
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
            this.DtgFuncionario = new System.Windows.Forms.DataGridView();
            this.panelDados = new System.Windows.Forms.Panel();
            this.CboDepartamento = new System.Windows.Forms.ComboBox();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnProcurar = new System.Windows.Forms.Button();
            this.LblCargo = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.CboCargo = new System.Windows.Forms.ComboBox();
            this.LblTotalRegistros = new System.Windows.Forms.Label();
            this.TxtPesquisar = new System.Windows.Forms.TextBox();
            this.TxtNif = new System.Windows.Forms.TextBox();
            this.TxtNomeFuncionario = new System.Windows.Forms.TextBox();
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
            this.LblPesquisaCli = new System.Windows.Forms.Label();
            this.LblNumTel = new System.Windows.Forms.Label();
            this.LblBairro = new System.Windows.Forms.Label();
            this.LblComplemento = new System.Windows.Forms.Label();
            this.LblCep = new System.Windows.Forms.Label();
            this.LblNumLogradouro = new System.Windows.Forms.Label();
            this.LblLogradouro = new System.Windows.Forms.Label();
            this.TxtLogradouro = new System.Windows.Forms.TextBox();
            this.LblSituacao = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblNomeFuncionario = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.DtgFuncionario)).BeginInit();
            this.panelDados.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.panel5.SuspendLayout();
            this.panelBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtgFuncionario
            // 
            this.DtgFuncionario.AllowUserToAddRows = false;
            this.DtgFuncionario.AllowUserToDeleteRows = false;
            this.DtgFuncionario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DtgFuncionario.BackgroundColor = System.Drawing.Color.White;
            this.DtgFuncionario.ColumnHeadersHeight = 40;
            this.DtgFuncionario.GridColor = System.Drawing.Color.Gainsboro;
            this.DtgFuncionario.Location = new System.Drawing.Point(511, 293);
            this.DtgFuncionario.Name = "DtgFuncionario";
            this.DtgFuncionario.RowTemplate.Height = 35;
            this.DtgFuncionario.Size = new System.Drawing.Size(667, 284);
            this.DtgFuncionario.TabIndex = 22;
            this.DtgFuncionario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgFuncionario_CellClick);
            this.DtgFuncionario.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DtgFuncionario_KeyUp);
            // 
            // panelDados
            // 
            this.panelDados.Controls.Add(this.CboDepartamento);
            this.panelDados.Controls.Add(this.LblDepartamento);
            this.panelDados.Controls.Add(this.panel1);
            this.panelDados.Controls.Add(this.BtnProcurar);
            this.panelDados.Controls.Add(this.LblCargo);
            this.panelDados.Controls.Add(this.picBox);
            this.panelDados.Controls.Add(this.CboCargo);
            this.panelDados.Controls.Add(this.LblTotalRegistros);
            this.panelDados.Controls.Add(this.DtgFuncionario);
            this.panelDados.Controls.Add(this.TxtPesquisar);
            this.panelDados.Controls.Add(this.TxtNif);
            this.panelDados.Controls.Add(this.TxtNomeFuncionario);
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
            this.panelDados.Controls.Add(this.LblPesquisaCli);
            this.panelDados.Controls.Add(this.LblNumTel);
            this.panelDados.Controls.Add(this.LblBairro);
            this.panelDados.Controls.Add(this.LblComplemento);
            this.panelDados.Controls.Add(this.LblCep);
            this.panelDados.Controls.Add(this.LblNumLogradouro);
            this.panelDados.Controls.Add(this.LblLogradouro);
            this.panelDados.Controls.Add(this.TxtLogradouro);
            this.panelDados.Controls.Add(this.LblSituacao);
            this.panelDados.Controls.Add(this.LblEmail);
            this.panelDados.Controls.Add(this.LblNomeFuncionario);
            this.panelDados.Controls.Add(this.panel5);
            this.panelDados.Controls.Add(this.panel4);
            this.panelDados.Controls.Add(this.panel3);
            this.panelDados.Controls.Add(this.LblTipoTel);
            this.panelDados.Controls.Add(this.LblNumCodigo);
            this.panelDados.Controls.Add(this.LvwTel);
            this.panelDados.ForeColor = System.Drawing.Color.Black;
            this.panelDados.Location = new System.Drawing.Point(2, 68);
            this.panelDados.Name = "panelDados";
            this.panelDados.Size = new System.Drawing.Size(1181, 629);
            this.panelDados.TabIndex = 21;
            // 
            // CboDepartamento
            // 
            this.CboDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboDepartamento.FormattingEnabled = true;
            this.CboDepartamento.Location = new System.Drawing.Point(174, 77);
            this.CboDepartamento.Name = "CboDepartamento";
            this.CboDepartamento.Size = new System.Drawing.Size(329, 28);
            this.CboDepartamento.TabIndex = 62;
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDepartamento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblDepartamento.Location = new System.Drawing.Point(49, 78);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(116, 20);
            this.LblDepartamento.TabIndex = 59;
            this.LblDepartamento.Text = "Departamento:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 592);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 1);
            this.panel1.TabIndex = 58;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 1);
            this.panel2.TabIndex = 14;
            // 
            // BtnProcurar
            // 
            this.BtnProcurar.BackColor = System.Drawing.Color.Silver;
            this.BtnProcurar.FlatAppearance.BorderSize = 0;
            this.BtnProcurar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProcurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnProcurar.Location = new System.Drawing.Point(796, 257);
            this.BtnProcurar.Name = "BtnProcurar";
            this.BtnProcurar.Size = new System.Drawing.Size(371, 27);
            this.BtnProcurar.TabIndex = 56;
            this.BtnProcurar.Text = "Adicionar Foto";
            this.BtnProcurar.UseVisualStyleBackColor = false;
            this.BtnProcurar.Click += new System.EventHandler(this.BtnProcurar_Click);
            // 
            // LblCargo
            // 
            this.LblCargo.AutoSize = true;
            this.LblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCargo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCargo.Location = new System.Drawing.Point(106, 109);
            this.LblCargo.Name = "LblCargo";
            this.LblCargo.Size = new System.Drawing.Size(56, 20);
            this.LblCargo.TabIndex = 42;
            this.LblCargo.Text = "Cargo:";
            // 
            // picBox
            // 
            this.picBox.Image = global::SISTEMA_DE_GESTÃO_LOJA.Properties.Resources.images;
            this.picBox.Location = new System.Drawing.Point(796, 4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(373, 247);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 55;
            this.picBox.TabStop = false;
            this.picBox.DoubleClick += new System.EventHandler(this.picBox_DoubleClick);
            // 
            // CboCargo
            // 
            this.CboCargo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboCargo.FormattingEnabled = true;
            this.CboCargo.Location = new System.Drawing.Point(174, 111);
            this.CboCargo.Name = "CboCargo";
            this.CboCargo.Size = new System.Drawing.Size(328, 28);
            this.CboCargo.TabIndex = 41;
            this.CboCargo.Enter += new System.EventHandler(this.CboCargo_Enter);
            this.CboCargo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboCargo_KeyDown);
            // 
            // LblTotalRegistros
            // 
            this.LblTotalRegistros.AutoSize = true;
            this.LblTotalRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalRegistros.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTotalRegistros.Location = new System.Drawing.Point(533, 583);
            this.LblTotalRegistros.Name = "LblTotalRegistros";
            this.LblTotalRegistros.Size = new System.Drawing.Size(141, 20);
            this.LblTotalRegistros.TabIndex = 23;
            this.LblTotalRegistros.Text = "Total de Registos: ";
            // 
            // TxtPesquisar
            // 
            this.TxtPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPesquisar.Location = new System.Drawing.Point(197, 596);
            this.TxtPesquisar.Multiline = true;
            this.TxtPesquisar.Name = "TxtPesquisar";
            this.TxtPesquisar.Size = new System.Drawing.Size(294, 26);
            this.TxtPesquisar.TabIndex = 38;
            this.TxtPesquisar.TextChanged += new System.EventHandler(this.TxtPesquisar_TextChanged);
            // 
            // TxtNif
            // 
            this.TxtNif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNif.Location = new System.Drawing.Point(328, 175);
            this.TxtNif.MaxLength = 14;
            this.TxtNif.Multiline = true;
            this.TxtNif.Name = "TxtNif";
            this.TxtNif.Size = new System.Drawing.Size(174, 29);
            this.TxtNif.TabIndex = 28;
            this.TxtNif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtComplemento_KeyPress);
            // 
            // TxtNomeFuncionario
            // 
            this.TxtNomeFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNomeFuncionario.Location = new System.Drawing.Point(174, 3);
            this.TxtNomeFuncionario.Multiline = true;
            this.TxtNomeFuncionario.Name = "TxtNomeFuncionario";
            this.TxtNomeFuncionario.Size = new System.Drawing.Size(328, 32);
            this.TxtNomeFuncionario.TabIndex = 5;
            this.TxtNomeFuncionario.Enter += new System.EventHandler(this.TxtNomeFuncionario_Enter);
            this.TxtNomeFuncionario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNomeFuncionario_KeyPress);
            this.TxtNomeFuncionario.Leave += new System.EventHandler(this.TxtNomeFuncionario_Leave);
            // 
            // TxtEmail
            // 
            this.TxtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(174, 40);
            this.TxtEmail.Multiline = true;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(329, 32);
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
            this.BtnListaExcluirTel.Location = new System.Drawing.Point(400, 345);
            this.BtnListaExcluirTel.Name = "BtnListaExcluirTel";
            this.BtnListaExcluirTel.Size = new System.Drawing.Size(40, 36);
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
            this.BtnListaIncluirTel.Location = new System.Drawing.Point(349, 345);
            this.BtnListaIncluirTel.Name = "BtnListaIncluirTel";
            this.BtnListaIncluirTel.Size = new System.Drawing.Size(34, 37);
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
            this.BtnListaCancelarTel.Location = new System.Drawing.Point(448, 345);
            this.BtnListaCancelarTel.Name = "BtnListaCancelarTel";
            this.BtnListaCancelarTel.Size = new System.Drawing.Size(39, 36);
            this.BtnListaCancelarTel.TabIndex = 35;
            this.BtnListaCancelarTel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnListaCancelarTel.UseVisualStyleBackColor = true;
            this.BtnListaCancelarTel.Click += new System.EventHandler(this.BtnListaCancelarTel_Click);
            // 
            // MskTelefone
            // 
            this.MskTelefone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskTelefone.Location = new System.Drawing.Point(174, 386);
            this.MskTelefone.Mask = "999-999-999";
            this.MskTelefone.Name = "MskTelefone";
            this.MskTelefone.Size = new System.Drawing.Size(168, 26);
            this.MskTelefone.TabIndex = 34;
            this.MskTelefone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MskTelefone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MskTelefone_KeyPress);
            // 
            // MskDDD
            // 
            this.MskDDD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskDDD.Location = new System.Drawing.Point(135, 386);
            this.MskDDD.Mask = "(99)";
            this.MskDDD.Name = "MskDDD";
            this.MskDDD.Size = new System.Drawing.Size(33, 26);
            this.MskDDD.TabIndex = 33;
            this.MskDDD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MskDDD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MskDDD_KeyPress);
            // 
            // CboTipoTel
            // 
            this.CboTipoTel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboTipoTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboTipoTel.FormattingEnabled = true;
            this.CboTipoTel.Location = new System.Drawing.Point(135, 352);
            this.CboTipoTel.Name = "CboTipoTel";
            this.CboTipoTel.Size = new System.Drawing.Size(207, 28);
            this.CboTipoTel.TabIndex = 32;
            this.CboTipoTel.UseWaitCursor = true;
            this.CboTipoTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboTipoTel_KeyDown);
            this.CboTipoTel.Leave += new System.EventHandler(this.CboTipoTel_Leave);
            // 
            // MskCep
            // 
            this.MskCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MskCep.Location = new System.Drawing.Point(388, 312);
            this.MskCep.Mask = "99999-999";
            this.MskCep.Name = "MskCep";
            this.MskCep.Size = new System.Drawing.Size(114, 26);
            this.MskCep.TabIndex = 31;
            this.MskCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CboBairro
            // 
            this.CboBairro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboBairro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboBairro.FormattingEnabled = true;
            this.CboBairro.Location = new System.Drawing.Point(174, 279);
            this.CboBairro.Name = "CboBairro";
            this.CboBairro.Size = new System.Drawing.Size(329, 28);
            this.CboBairro.TabIndex = 30;
            this.CboBairro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboBairro_KeyDown);
            // 
            // TxtNumLogradouro
            // 
            this.TxtNumLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumLogradouro.Location = new System.Drawing.Point(174, 209);
            this.TxtNumLogradouro.Multiline = true;
            this.TxtNumLogradouro.Name = "TxtNumLogradouro";
            this.TxtNumLogradouro.Size = new System.Drawing.Size(329, 29);
            this.TxtNumLogradouro.TabIndex = 29;
            this.TxtNumLogradouro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNumLogradouro_KeyPress);
            // 
            // CboSituacao
            // 
            this.CboSituacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSituacao.FormattingEnabled = true;
            this.CboSituacao.Location = new System.Drawing.Point(328, 146);
            this.CboSituacao.Name = "CboSituacao";
            this.CboSituacao.Size = new System.Drawing.Size(174, 28);
            this.CboSituacao.TabIndex = 27;
            this.CboSituacao.Enter += new System.EventHandler(this.CboSituacao_Enter);
            this.CboSituacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CboSituacao_KeyDown);
            // 
            // LblPesquisaCli
            // 
            this.LblPesquisaCli.AutoSize = true;
            this.LblPesquisaCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPesquisaCli.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblPesquisaCli.Location = new System.Drawing.Point(98, 596);
            this.LblPesquisaCli.Name = "LblPesquisaCli";
            this.LblPesquisaCli.Size = new System.Drawing.Size(87, 20);
            this.LblPesquisaCli.TabIndex = 25;
            this.LblPesquisaCli.Text = "Pesquisar :\r\n";
            // 
            // LblNumTel
            // 
            this.LblNumTel.AutoSize = true;
            this.LblNumTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNumTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNumTel.Location = new System.Drawing.Point(5, 386);
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
            this.LblBairro.Location = new System.Drawing.Point(107, 281);
            this.LblBairro.Name = "LblBairro";
            this.LblBairro.Size = new System.Drawing.Size(55, 20);
            this.LblBairro.TabIndex = 23;
            this.LblBairro.Text = "Bairro:";
            // 
            // LblComplemento
            // 
            this.LblComplemento.AutoSize = true;
            this.LblComplemento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblComplemento.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblComplemento.Location = new System.Drawing.Point(130, 178);
            this.LblComplemento.Name = "LblComplemento";
            this.LblComplemento.Size = new System.Drawing.Size(32, 20);
            this.LblComplemento.TabIndex = 22;
            this.LblComplemento.Text = "Nif:";
            // 
            // LblCep
            // 
            this.LblCep.AutoSize = true;
            this.LblCep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCep.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblCep.Location = new System.Drawing.Point(114, 314);
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
            this.LblNumLogradouro.Location = new System.Drawing.Point(49, 212);
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
            this.LblLogradouro.Location = new System.Drawing.Point(70, 247);
            this.LblLogradouro.Name = "LblLogradouro";
            this.LblLogradouro.Size = new System.Drawing.Size(95, 20);
            this.LblLogradouro.TabIndex = 19;
            this.LblLogradouro.Text = "Logradouro:";
            // 
            // TxtLogradouro
            // 
            this.TxtLogradouro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLogradouro.Location = new System.Drawing.Point(174, 244);
            this.TxtLogradouro.Multiline = true;
            this.TxtLogradouro.Name = "TxtLogradouro";
            this.TxtLogradouro.Size = new System.Drawing.Size(328, 32);
            this.TxtLogradouro.TabIndex = 18;
            this.TxtLogradouro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtLogradouro_KeyPress);
            // 
            // LblSituacao
            // 
            this.LblSituacao.AutoSize = true;
            this.LblSituacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSituacao.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblSituacao.Location = new System.Drawing.Point(86, 146);
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
            this.LblEmail.Location = new System.Drawing.Point(113, 44);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(52, 20);
            this.LblEmail.TabIndex = 15;
            this.LblEmail.Text = "Email:";
            // 
            // LblNomeFuncionario
            // 
            this.LblNomeFuncionario.AutoSize = true;
            this.LblNomeFuncionario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNomeFuncionario.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblNomeFuncionario.Location = new System.Drawing.Point(113, 3);
            this.LblNomeFuncionario.Name = "LblNomeFuncionario";
            this.LblNomeFuncionario.Size = new System.Drawing.Size(55, 20);
            this.LblNomeFuncionario.TabIndex = 14;
            this.LblNomeFuncionario.Text = "Nome:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DimGray;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(2, 418);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(488, 1);
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
            this.panel4.Location = new System.Drawing.Point(5, 341);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(497, 1);
            this.panel4.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(9, 207);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(497, 1);
            this.panel3.TabIndex = 8;
            // 
            // LblTipoTel
            // 
            this.LblTipoTel.AutoSize = true;
            this.LblTipoTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipoTel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LblTipoTel.Location = new System.Drawing.Point(0, 352);
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
            this.LblNumCodigo.Location = new System.Drawing.Point(4, 4);
            this.LblNumCodigo.Name = "LblNumCodigo";
            this.LblNumCodigo.Size = new System.Drawing.Size(63, 20);
            this.LblNumCodigo.TabIndex = 2;
            this.LblNumCodigo.Text = "Código:";
            // 
            // LvwTel
            // 
            this.LvwTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwTel.HideSelection = false;
            this.LvwTel.Location = new System.Drawing.Point(2, 421);
            this.LvwTel.Name = "LvwTel";
            this.LvwTel.Size = new System.Drawing.Size(489, 165);
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
            this.BtnSalvar.Location = new System.Drawing.Point(552, 1);
            this.BtnSalvar.Name = "BtnSalvar";
            this.BtnSalvar.Size = new System.Drawing.Size(107, 42);
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
            // WFFuncionarioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1195, 780);
            this.Controls.Add(this.panelDados);
            this.Controls.Add(this.panelBar);
            this.Name = "WFFuncionarioView";
            this.Text = "Cadastrar Funcionários";
            this.Load += new System.EventHandler(this.WFFuncionarioView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgFuncionario)).EndInit();
            this.panelDados.ResumeLayout(false);
            this.panelDados.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panelBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgFuncionario;
        private System.Windows.Forms.Panel panelDados;
        private System.Windows.Forms.TextBox TxtPesquisar;
        private System.Windows.Forms.TextBox TxtNif;
        private System.Windows.Forms.TextBox TxtNomeFuncionario;
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
        private System.Windows.Forms.Label LblPesquisaCli;
        private System.Windows.Forms.Label LblNumTel;
        private System.Windows.Forms.Label LblBairro;
        private System.Windows.Forms.Label LblComplemento;
        private System.Windows.Forms.Label LblCep;
        private System.Windows.Forms.Label LblNumLogradouro;
        private System.Windows.Forms.Label LblLogradouro;
        private System.Windows.Forms.TextBox TxtLogradouro;
        private System.Windows.Forms.Label LblSituacao;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblNomeFuncionario;
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
        private System.Windows.Forms.Label LblCargo;
        private System.Windows.Forms.ComboBox CboCargo;
        private System.Windows.Forms.Button BtnProcurar;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.ComboBox CboDepartamento;
    }
}