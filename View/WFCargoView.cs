using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFCargoView : Form
    {
        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "Código", "Cargo", "Sigla Cargo", "Id Estado" };
        bool[] colunaVisivel = { true, true, true};

        #endregion Variáveis

        #region Construtor

        #endregion Construtor

        public WFCargoView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
        }

        #region Form

        private void WFCargoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgCargo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgCargo.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }

        #endregion Form

        #region DataGridView

        private void DtgCargo_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        private void DtgCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        #endregion DataGridView


        #region Button

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtNomeCargo.Focus();
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
                    TxtNomeCargo.Focus();
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

                CargoModel cargoModel = new CargoModel();
                CargoController cargoController = new CargoController();

                cargoModel.NomeCargo = TxtNomeCargo.Text.Trim();
                cargoModel.SiglaCargo = TxtSiglaCargo.Text.Trim();

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = cargoController.IncluirCargoController(cargoModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            cargoModel.IdCargo = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = cargoController.AlterarCargoController(cargoModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            cargoModel.IdCargo = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = cargoController.ExcluirCargoController(cargoModel.IdCargo);
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



        #region TEXTBOX
        private void TxtNomeCargo_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtNomeCargo_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }



        private void TxtSiglaCargo_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }



        private void TxtSiglaCargo_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgCargo.DataSource != null)
            {
                CargoController cargoController = new CargoController();
                cargoController.PesquisarCargos(DtgCargo, TxtPesquisar.Text.Trim());

                TotalRegistroNoDataGridView(DtgCargo, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-08", "x");
            }
        }


        private void TxtNomeCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtSiglaCargo.Focus();
            }
        }

        private void TxtSiglaCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSalvar.Focus();
            }
        }
        #endregion TEXTBOX


        #region Métodos

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgCargo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                DataGridViewRow linhaAtual = DtgCargo.CurrentRow;

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
            LblNumCodigo.Text = DtgCargo.Rows[index].Cells[0].Value.ToString();
            TxtNomeCargo.Text = DtgCargo.Rows[index].Cells[1].Value.ToString();
            TxtSiglaCargo.Text = DtgCargo.Rows[index].Cells[2].Value.ToString();

        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {
            if (TxtNomeCargo.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeCidade.Text + " é obrigatório.", "20200720-02", "a");
                TxtNomeCargo.Focus();
                return false;
            }

            if (TxtSiglaCargo.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSiglaCargo + " é obrigatório.", "20200720-02", "a");
                TxtSiglaCargo.Focus();
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
            TxtNomeCargo.Enabled = bolHabil;
            TxtSiglaCargo.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeCargo.Text = TxtSiglaCargo.Text = TxtPesquisar.Text = string.Empty;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgCargo, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgCargo, nomeColuna, colunaVisivel);
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
            CargoController cargoController = new CargoController();
            CargoModel cargoModel = new CargoModel();
            //usuarioModel.SituacaoModel.IdSituacao = (int)CboSituacao.SelectedValue;
            try
            {
                DtgCargo.DataSource = null;
                DtgCargo.Rows.Clear();
                DtgCargo.DataSource = cargoController.ObterRegistrosCargo();
                TotalRegistroNoDataGridView(DtgCargo, LblTotalRegistros);
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
