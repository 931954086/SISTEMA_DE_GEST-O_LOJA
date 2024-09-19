
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;



namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFUsuarioView : Form
    {
        #region CHAVE DE CRIPTOGRAFIA
        const string chave = "@!1#";
        string senha;
        #endregion CHAVE DE CRIPTOGRAFIA


        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;
        // "IdFuncionario, NomeFunc, [Login], Senha, A.Email, 
        //"DescSituacao", "IdSituacao","Foto", "IdTipoUsuario", "NomeTipoUsuario", "SiglaTipoUsuario", "IdUsuario"
        string[] nomeColuna  = {"IdFuncionario", "NomeFunc", "[Login]", "Senha",  "Email",   "DescSituacao",   "IdSituacao",   "Foto",   "IdTipoUsuario",  "NomeTipoUsuario",  "SiglaTipoUsuario",  "Código" };
        bool[] colunaVisivel = {false,            true,      true,       true,     true,     true,            false,           false,     false,             false,               true, false, false };
        UsuarioModel usuarioModel = null;
        #endregion Variáveis

        

        #region Construtor

        public WFUsuarioView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
            usuarioModel = new UsuarioModel();

        }

        #endregion Construtor



        #region Eventos

        #region Form
        private void WFUsuarioView_Load(object sender, EventArgs e)
        {

            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgUsuario.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgUsuario.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();

        }
        #endregion Form
        #endregion Eventos




        #region TEXTBOX

        private void checkBoxVerSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerSenha.Checked)
            {
                TxtSenha.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                this.senha = TxtSenha.Text;
            }
            else
            {
                //TxtSenha.TextMaskFormat = MaskFormat.IncludeLiterals;
                this.senha = string.Empty;
            }


            LblSenhadecod.Text = this.senha;
        }
        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgUsuario.DataSource != null)
            {

            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-09", "x");
            }
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, CboTipoUsuario);
            TxtEmail.Text.ToLower();
        }


        private void CboTipoUsuario_Enter(object sender, EventArgs e)
        {
            if (Diversos.ExisteItensComboBox(CboTipoUsuario))
            {
                if (CboTipoUsuario.SelectedIndex == -1)
                {
                    CboTipoUsuario.SelectedIndex = 0;
                }
            }
        }

        private void CboTipoUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CboSituacao.Focus();
            }
        }

        private void CboSituacao_Enter(object sender, EventArgs e)
        {
            if (Diversos.ExisteItensComboBox(CboTipoUsuario))
            {
                if (CboSituacao.SelectedIndex == -1)
                {
                    CboSituacao.SelectedIndex = 0;
                }
            }
        }

        private void CboSituacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSalvar.Focus();
            }
        }


        private void TxtLogin_KeyDown(object sender, KeyEventArgs e)
        {
             
             if (e.KeyCode == Keys.Enter)
             {
                   TxtSenha.Focus();
             }

        }


        private void TxtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtEmail.Focus();
                
            }
        }
        #endregion TEXTBOX



        #region DATAGRIVIEW 
        private void DtgUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }
        #endregion DATAGRIVIEW 



        #region Button

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            CboFuncionario.Focus();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecuperarLinhaSelecionadaDataGridView() >= 0)
                {
                    enuAcao = OPERACAO.ALTERAR;
                    HabilitarCampos(true);
                    AtribuirValoresDaLinhaDoDataGridView();
                    HabilitarBotoes(false);
                    CboFuncionario.Focus();
                }
                else
                {
                    TelaInicial(false);
                    MGMensagemErro.MensagensErro("O usuário não selecionou um registro no grid ou" +
                        " o grid está sem registros.", "20200721-02", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200903-02", "E");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecuperarLinhaSelecionadaDataGridView() >= 0)
                {
                    AtribuirValoresDaLinhaDoDataGridView();
                    HabilitarBotoes(false);
                    HabilitarCampos(false);

                    if (MessageBox.Show("Deseja excluir o registro selecionado?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        enuAcao = OPERACAO.EXCLUIR;
                        BtnSalvar_Click(sender, e);
                    }
                    else
                    {
                        TelaInicial(false);
                    }
                }
                else
                {
                    TelaInicial(false);
                    MGMensagemErro.MensagensErro("O usuário não selecionou um registro no grid ou" +
                        " o grid está sem registros.", "20200721-04", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200903-03", "E");
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            //Validando a ação do usuário (Incluir, Alterar ou Excluir)
            if (enuAcao == OPERACAO.STANDBY)
            {
                MGMensagemErro.MensagensErro("Primeiro selecione a ação que deseja realizar pressionando um" +
                    " dos botões do menu.", "20200720-06", "A");
                return;
            }

            try
            {
                //Validação dos campos obrigatórios
                if (!Validar())
                {
                    return;
                }
                UsuarioModel usuarioModel = new UsuarioModel();
                UsuarioController usuarioController = new UsuarioController();
                
                usuarioModel.Login = TxtLogin.Text.Trim();
                string textoCriptografado = CriptografiaOsvaldo.Seguranca.Criptografar(TxtSenha.Text.Trim(), chave);
                MessageBox.Show(textoCriptografado);
                usuarioModel.Senha = textoCriptografado;
                usuarioModel.Email = TxtEmail.Text.Trim();

                usuarioModel.SituacaoModel.IdSituacao = (int)CboSituacao.SelectedValue;
                usuarioModel.TipoUsuarioModel.IdTipoUsuario = (int)CboTipoUsuario.SelectedValue;
                usuarioModel.FuncionarioModel.IdFuncionario = (int)CboFuncionario.SelectedValue;

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = usuarioController.IncluirUsuarioController(usuarioModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {

                            usuarioModel.FuncionarioModel.IdFuncionario = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = usuarioController.AlterarUsuarioController(usuarioModel);
                           //usuarioModel.IdCidade = Convert.ToInt32(LblNumCodigo.Text);
                           //retorno = cidadeController.AlterarCidadeController(cidadeModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            usuarioModel.FuncionarioModel.IdFuncionario = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = usuarioController.ExcluirUsuarioController(usuarioModel.FuncionarioModel.IdFuncionario);
                            //cidadeModel.IdCidade = Convert.ToInt32(LblNumCodigo.Text);
                            // retorno = cidadeController.ExcluirCidadeController(cidadeModel.IdCidade);
                            break;
                        }
                }

                if (retorno != 0)
                {
                    TelaInicial(true);
                    MGMensagemErro.MensagensErro("Operação efetuada com sucesso!", "20200720-05", "X");
                }
                else
                {
                    MGMensagemErro.MensagensErro("Operação Não foi efetuada.\n Verifique e tente novamente.", "20200720-05", "e");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200907-01", "E");
            }
        }

        #endregion Button



        #region Métodos

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgUsuario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns>Número da linha selecionada no DataGridView.</returns>
        private int RecuperarLinhaSelecionadaDataGridView()
        {
            //DataGridViewRow linhaAtual = DtgCidade.CurrentRow;
            //int numeroLinha = linhaAtual.Index;
            //return numeroLinha;

            try
            {
                DataGridViewRow linhaAtual = DtgUsuario.CurrentRow;

                if (linhaAtual == null)
                {
                    return -1;
                }
                else
                {
                    int numeroLinha = linhaAtual.Index;
                    return numeroLinha;
                }
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Atribui aos campos os valores das células da linha selecionada
        /// </summary>
        private void AtribuirValoresDaLinhaDoDataGridView()
        {
            // vamos obter a linha da célula selecionada
            int index = RecuperarLinhaSelecionadaDataGridView();
            // configurando valor da primeira coluna, índice 0
            LblNumCodigo.Text = DtgUsuario.Rows[index].Cells[0].Value.ToString();
            TxtLogin.Text = DtgUsuario.Rows[index].Cells[2].Value.ToString();
            TxtEmail.Text = DtgUsuario.Rows[index].Cells[4].Value.ToString();
            string TextoDescriptografado = DtgUsuario.Rows[index].Cells[3].Value.ToString();
            TxtSenha.Text = CriptografiaOsvaldo.Seguranca.DesCriptografar(TextoDescriptografado, chave);
            CboTipoUsuario.SelectedValue = (int)DtgUsuario.Rows[index].Cells[8].Value;
            CboSituacao.SelectedValue = (int)DtgUsuario.Rows[index].Cells[6].Value;
            CboFuncionario.SelectedValue = (int)DtgUsuario.Rows[index].Cells[0].Value;

        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {

            try
            {
                if (!string.IsNullOrEmpty(TxtEmail.Text))
                {
                    MailAddress mailAddress;
                    mailAddress = new MailAddress(TxtEmail.Text);
                }
                else
                {
                    MGMensagemErro.MensagensErro("O campo " + LblEmail.Text + " é obrigatório.", "20200720-02", "I");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("O campo " + "Email" + " Digite um email válido.", "20201117-10", "A");
                return false;
            }

            if (TxtEmail.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblEmail.Text + " é obrigatório.", "20200720-02", "a");
                TxtEmail.Focus();
                return false;
            }

            TxtEmail.Text.ToLower();

            if (TxtSenha.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSenha.Text + " é obrigatório.", "20200720-02", "a");
                TxtSenha.Focus();
                return false;
            }

            if (TxtSenha.Text.Trim().Length <7)
            {

                MGMensagemErro.MensagensErro("O campo " + LblSenha.Text + " deve ter nomínimo 7 caracteres e no máximo 12", "20200720-02", "a");
                TxtSenha.Focus();
                return false;
            }

            if (TxtLogin.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblLogin.Text + " é obrigatório.", "20200720-02", "a");
                TxtLogin.Focus();
                return false;
            }


            if (CboFuncionario.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblFuncionario.Text + " é obrigatório.", "20200720-01", "A");
                CboFuncionario.Focus();
                return false;
            }

            if (CboSituacao.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSituacao.Text + " é obrigatório.", "20200720-01", "A");
                CboSituacao.Focus();
                return false;
            }

            if (CboTipoUsuario.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblTipoUsuario.Text + " é obrigatório.", "20200720-01", "A");
                CboTipoUsuario.Focus();
                return false;
            }
           return true;
        }

        private void HabilitarBotoes(bool bolHabil)
        {
            BtnIncluir.Enabled = bolHabil;
            BtnAlterar.Enabled = bolHabil;
            BtnExcluir.Enabled = bolHabil;
        }

        private void HabilitarCampos(bool bolHabil)
        {

            TxtEmail.Enabled = bolHabil;
            TxtLogin.Enabled = bolHabil;
            TxtSenha.Enabled = bolHabil;
            TxtEmail.Enabled = bolHabil;
            CboFuncionario.Enabled = bolHabil;
            CboSituacao.Enabled = bolHabil;
            CboTipoUsuario.Enabled = bolHabil;

        }

        private void LimparCampos()
        {
         LblNumCodigo.Text = TxtEmail.Text = TxtLogin.Text = TxtSenha.Text = TxtDescUsuario .Text = TxtPesquisar.Text = string.Empty;
    
            CboTipoUsuario.SelectedIndex = -1;
            CboSituacao.SelectedIndex    = -1;
            CboFuncionario.SelectedIndex = -1;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgUsuario, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgUsuario, nomeColuna, colunaVisivel);
                CarregarCboFuncionario(CboFuncionario);
                CarregarCboTipoUsuario(CboTipoUsuario);
                CarregarCboSituacao(CboSituacao);

            }
             CboFuncionario.SelectedIndex = -1;
             CboTipoUsuario.SelectedIndex = -1;
             CboSituacao.SelectedIndex = -1;
        }


        private void RefreshDataGrid(DataGridView dtg, bool bolRefresh)
        {
            if (bolRefresh) { PreencherDataGridView(dtg); }
        }


        /// <summary>
        /// Popula o datagridview com registros do banco de dados.
        /// </summary>
        /// <param name="Dtg"></param>
        private void PreencherDataGridView(DataGridView Dtg)
        {
            List<UsuarioModel> listaUsuarios = new List<UsuarioModel>();
            UsuarioController usuarioController = new UsuarioController();
            UsuarioModel usuarioModel = new UsuarioModel();
            //usuarioModel.SituacaoModel.IdSituacao = (int)CboSituacao.SelectedValue;
            try
            {
                DtgUsuario.DataSource = null;
                DtgUsuario.Rows.Clear();
                DtgUsuario.DataSource = usuarioController.ObterRegistrosUsuarios();
              //DtgUsuario.DataSource = usuarioController.ObterRegistrosUsuarios(usuarioModel.SituacaoModel.IdSituacao);
                TotalRegistroNoDataGridView(DtgUsuario, LblTotalRegistros);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20200721-01", "e");
            }
        }


        private void TotalRegistroNoDataGridView(DataGridView dtg, Label lbl)
        {
            lbl.Text = "Total de Registros: " + (dtg.Rows.Count).ToString();
        }

        

        private void CarregarCboTipoUsuario(ComboBox cbo)
        {
            TipoUsuarioController tipoUsuarioController = new TipoUsuarioController();
            tipoUsuarioController.PreencherCboTipoUsuario(cbo);
        }


        private void CarregarCboSituacao(ComboBox cbo)
        {
            SituacaoController situacaoController = new SituacaoController();
            situacaoController.PreencherCboSituacao(cbo);
        }


        private void CarregarCboFuncionario(ComboBox cbo)
        {
            FuncionarioController funcionarioController = new FuncionarioController();
            funcionarioController.PreencherCboFuncionario(cbo);
        }

        private void PosicionarFoco(KeyPressEventArgs e, object controle)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (controle.GetType().Name.ToLower().Equals("textbox"))
                {
                    ((TextBox)controle).Focus();
                }
                else if (controle.GetType().Name.ToLower().Equals("maskedtextbox"))
                {
                    ((MaskedTextBox)controle).Focus();
                }
                else if (controle.GetType().Name.ToLower().Equals("combobox"))
                {
                    ((ComboBox)controle).Focus();
                }
                else if (controle.GetType().Name.ToLower().Equals("button"))
                {
                    ((Button)controle).Focus();
                }
                else if (controle.GetType().Name.ToLower().Equals("radiobutton"))
                {
                    ((RadioButton)controle).Focus();
                }

            }
        }

        public static Boolean ExisteItensComboBox(System.Windows.Forms.ComboBox cbo)
        {
            try
            {
                if (cbo.Items.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region ===== METODO PROVEDORES DE CORES DO FORM MAIN MENU ========
        private void loadtheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;

                }
            }

            //LblTotalRegistros.ForeColor = ThemeColor.SecondaryColor;
            // LblNumCodigo.ForeColor = ThemeColor.PrimaryColor;
            panelBar.BackColor = ThemeColor.PrimaryColor;
        }
        #endregion ===== METODO PROVEDORES DE CORES DO FORM MAIN MENU ========

        #endregion Métodos

      
    }
}
