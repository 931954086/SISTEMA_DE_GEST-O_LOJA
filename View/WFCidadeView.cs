using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFCidadeView : Form
    {
        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "Código", "Cidade", "Id Estado", "Estado" };
        bool[] colunaVisivel = { true, true, false, true };

        #endregion Variáveis

        #region Construtor

        public WFCidadeView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
           
        }

        #endregion Construtor

        #region Eventos

        #region Form

        private void WFCidadeView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgCidade.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgCidade.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }

        #endregion Form

        #region Button

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtNomeCidade.Focus();
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
                    TxtNomeCidade.Focus();
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
                CidadeModel cidadeModel = new CidadeModel();
                CidadeController cidadeController = new CidadeController();

                cidadeModel.NomeCidade = TxtNomeCidade.Text.Trim();
                cidadeModel.EstadoModel.IdEstado = (int)CboEstado.SelectedValue;

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = cidadeController.IncluirCidadeController(cidadeModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            cidadeModel.IdCidade = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = cidadeController.AlterarCidadeController(cidadeModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            cidadeModel.IdCidade = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = cidadeController.ExcluirCidadeController(cidadeModel.IdCidade);
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

        #region TextBox

        private void TxtNomeCidade_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtNomeCidade_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtNomeCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CboEstado.Focus();
            }
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
            if (DtgCidade.DataSource != null)
            {
                CidadeController cidadeController = new CidadeController();
                cidadeController.PesquisarCidades(DtgCidade, TxtPesquisar.Text.Trim());

                //((System.Data.DataTable)DtgCidade.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", TxtPesquisar.Text.Trim().Replace("'", "''"));
                TotalRegistroNoDataGridView(DtgCidade, LblTotalRegistros);// LblTotalRegistros.Text = (DtgCidade.Rows.Count - 1).ToString();
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-08", "x");
            }
        }

        private void TxtPesquisar_GotFocus(object sender, EventArgs e)
        {
            TxtPesquisar.Text = string.Empty;//LimparCampos();
            Diversos.ControlBackColorGot(sender);
        }

        #endregion TextBox

        #region DataGridView

        private void DtgCidade_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        private void DtgCidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        #endregion DataGridView

        #region ComboBox

        private void CboEstado_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CboEstado.SelectedIndex = -1;
            }
        }

        private void CboEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSalvar.Focus();
        }

        #endregion ComboBox

        #endregion Eventos

        #region Métodos

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgCidade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                DataGridViewRow linhaAtual = DtgCidade.CurrentRow;

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
            LblNumCodigo.Text = DtgCidade.Rows[index].Cells[0].Value.ToString();
            TxtNomeCidade.Text = DtgCidade.Rows[index].Cells[1].Value.ToString();
            CboEstado.SelectedValue = (int)DtgCidade.Rows[index].Cells[2].Value;
        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {
            if (TxtNomeCidade.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeCidade.Text + " é obrigatório.", "20200720-02", "a");
                TxtNomeCidade.Focus();
                return false;
            }

            if (CboEstado.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblEstado.Text + " é obrigatório.", "20200720-01", "A");
                CboEstado.Focus();
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
            TxtNomeCidade.Enabled = bolHabil;
            CboEstado.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeCidade.Text = TxtPesquisar.Text = string.Empty;
            CboEstado.SelectedIndex = -1;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgCidade, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgCidade, nomeColuna, colunaVisivel);
                CarregarCboEstado(CboEstado);
            }
            CboEstado.SelectedIndex = -1;
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
            List<CidadeModel> listaCidades = new List<CidadeModel>();
            CidadeController cidadeController = new CidadeController();

            try
            {
                DtgCidade.DataSource = null;
                DtgCidade.Rows.Clear();
                DtgCidade.DataSource = cidadeController.ObterRegistrosCidade();
                TotalRegistroNoDataGridView(DtgCidade, LblTotalRegistros);
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

        /// <summary>
        /// Preenche a ComboBox com os registros da tabela de Estados vindos do banco de dados.
        /// </summary>
        /// <param name="cbo"></param>
        private void CarregarCboEstado(ComboBox cbo)
        {
            CidadeController cidadeController = new CidadeController();
            cidadeController.PopularCboEstado(cbo);
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
