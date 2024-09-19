using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFTipoTelefoneView : Form
    {

        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "Código", "Tipo Telefone", "Id Estado" };
        bool[] colunaVisivel = { true, true };

        #endregion Variáveis

        #region Construtor
        public WFTipoTelefoneView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
        }
        #endregion Construtor


        #region Form
        private void WFTipoTelefoneView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgTipoTelefone.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgTipoTelefone.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }

        #endregion Form


        #region TEXTBOX

        private void TxtDescTelefone_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtDescTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSalvar.Focus();
            }
        }

        private void TxtDescTelefone_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }


        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgTipoTelefone.DataSource != null)
            {
                TipoTelefoneController tipoTelefoneController = new TipoTelefoneController();
                tipoTelefoneController.PesquisarTipoTelefone(DtgTipoTelefone, TxtPesquisar.Text.Trim());

                TotalRegistroNoDataGridView(DtgTipoTelefone, LblTotalRegistros);
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
            TxtDescTelefone.Focus();
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
                    TxtDescTelefone.Focus();
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

                TipoTelefoneModel tipoTelefoneModel = new TipoTelefoneModel();
                TipoTelefoneController tipoTelefoneController = new TipoTelefoneController();

                tipoTelefoneModel.DescTipoTelefone = TxtDescTelefone.Text.Trim();

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = tipoTelefoneController.IncluirTipoTelefonelController(tipoTelefoneModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            tipoTelefoneModel.IdTipoTelefone = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = tipoTelefoneController.AlterarTipoTelefonelController(tipoTelefoneModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            tipoTelefoneModel.IdTipoTelefone = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = tipoTelefoneController.ExcluirTipoTelefonelController(tipoTelefoneModel.IdTipoTelefone);
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

        private void DtgTipoTelefone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgTipoTelefone_KeyUp(object sender, KeyEventArgs e)
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
            return DtgTipoTelefone.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                DataGridViewRow linhaAtual = DtgTipoTelefone.CurrentRow;

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
            LblNumCodigo.Text = DtgTipoTelefone.Rows[index].Cells[0].Value.ToString();
            TxtDescTelefone.Text = DtgTipoTelefone.Rows[index].Cells[1].Value.ToString();


        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {
            if (TxtDescTelefone.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblTipoTelefone.Text + " é obrigatório.", "20200720-02", "a");
                TxtDescTelefone.Focus();
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
            TxtDescTelefone.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtDescTelefone.Text = TxtPesquisar.Text = string.Empty;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgTipoTelefone, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgTipoTelefone, nomeColuna, colunaVisivel);
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
            TipoTelefoneController tipoTelefoneModelController = new TipoTelefoneController();
            TipoTelefoneModel tipoTelefoneModel = new TipoTelefoneModel();

            try
            {
                DtgTipoTelefone.DataSource = null;
                DtgTipoTelefone.Rows.Clear();
                DtgTipoTelefone.DataSource = tipoTelefoneModelController.ObterRegistrosTipoTelefone();
                TotalRegistroNoDataGridView(DtgTipoTelefone, LblTotalRegistros);
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
