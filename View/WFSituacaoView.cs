using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFSituacaoView : Form
    {
        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "Código", "Situação","Id Estado" };
        bool[] colunaVisivel = { true, true};

        #endregion Variáveis

        #region Construtor
        public WFSituacaoView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
        }
        #endregion Construtor


        private void WFSituacaoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgSituacao.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgSituacao.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }


        #region Form

        private void WFCargoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            loadtheme();
        }

        #endregion Form
     

        #region TEXTBOX

        private void TxtSituacao_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtSituacao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSalvar.Focus();
            }
        }

        private void TxtSituacao_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }


        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgSituacao.DataSource != null)
            {
                SituacaoController situacaoController = new SituacaoController();
                situacaoController.PesquisarSituacaos(DtgSituacao, TxtPesquisar.Text.Trim());

                TotalRegistroNoDataGridView(DtgSituacao, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-08", "x");
            }
        }

        #endregion TEXTBOX

        #region Button

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtSituacao.Focus();
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
                    TxtSituacao.Focus();
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

                SituacaoModel situacaoModel = new SituacaoModel();
                SituacaoController situacaoController = new SituacaoController();

                situacaoModel.DescSituacao = TxtSituacao.Text.Trim();

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = situacaoController.IncluirSituacaoController(situacaoModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            situacaoModel.IdSituacao = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = situacaoController.AlterarSituacaoController(situacaoModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            situacaoModel.IdSituacao = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = situacaoController.ExcluirSituacaoController(situacaoModel.IdSituacao);
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

        #region DATAGRIDVIEW 
        private void DtgSituacao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgSituacao_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        #endregion DATAGRIDVIEW 

        #region Métodos

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgSituacao.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                DataGridViewRow linhaAtual = DtgSituacao.CurrentRow;

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
            LblNumCodigo.Text = DtgSituacao.Rows[index].Cells[0].Value.ToString();
            TxtSituacao.Text = DtgSituacao.Rows[index].Cells[1].Value.ToString();


        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {
            if (TxtSituacao.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSituacao.Text + " é obrigatório.", "20200720-02", "a");
                TxtSituacao.Focus();
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
            TxtSituacao.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtSituacao.Text = TxtPesquisar.Text = string.Empty;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgSituacao, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgSituacao, nomeColuna, colunaVisivel);
            }

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
            // List<UsuarioModel> listatipoUsuarios = new List<UsuarioModel>();
            SituacaoController situacaoController = new SituacaoController();
            SituacaoModel situacaoModel = new SituacaoModel();

            try
            {
                DtgSituacao.DataSource = null;
                DtgSituacao.Rows.Clear();
                DtgSituacao.DataSource = situacaoController.ObterRegistrosSituacao();
                TotalRegistroNoDataGridView(DtgSituacao, LblTotalRegistros);
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
