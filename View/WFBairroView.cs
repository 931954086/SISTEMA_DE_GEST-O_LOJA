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
    public partial class WFBairroView : Form
    {


        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        //  string[] nomeColuna = { "Código", "Bairro", "Id Cidade", "Cidade" };
        // bool[] colunaVisivel = { true, true, false, true };

        string[] nomeColuna = { "Código", "Bairro", "Id Cidade", "IdEstado", "NomeEstado" };
        bool[] colunaVisivel = { true, true, false, true, false, false};
        #endregion Variáveis

        #region Construtor

        public WFBairroView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);

        }

        #endregion Construtor

        #region Eventos

        #region Form

        private void WFBairroView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgBairro.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgBairro.DefaultCellStyle.Font = new Font("Arial", 12);
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
            TxtNomeBairro.Focus();
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
                    TxtNomeBairro.Focus();
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
                BairroModel bairroModel = new BairroModel();
                BairroController bairroController = new BairroController();

                bairroModel.NomeBairro = TxtNomeBairro.Text.Trim();
                bairroModel.Cidade_Model.IdCidade = (int)CboCidade.SelectedValue;

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = bairroController.IncluirBairroController(bairroModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            bairroModel.IdBairro = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = bairroController.AlterarBairroController(bairroModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            bairroModel.IdBairro = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = bairroController.ExcluirBairroController(bairroModel.IdBairro);
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

        private void TxtNomeBairro_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }


        private void TxtNomeBairro_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtNomeBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CboCidade.Focus();
            }
        }

     
        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgBairro.DataSource != null)
            {
                BairroController bairroController = new BairroController();
                bairroController.PesquisarBairros(DtgBairro, TxtPesquisar.Text.Trim());

                //((System.Data.DataTable)DtgCidade.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", TxtPesquisar.Text.Trim().Replace("'", "''"));
                TotalRegistroNoDataGridView(DtgBairro, LblTotalRegistros);// LblTotalRegistros.Text = (DtgCidade.Rows.Count - 1).ToString();
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



        private void DtgBairro_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        private void DtgBairro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }
        #endregion DataGridView

        #region ComboBox

        private void CboCidade_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                CboCidade.SelectedIndex = -1;
            }
        }

        private void CboCidade_KeyDown(object sender, KeyEventArgs e)
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
            return DtgBairro.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                DataGridViewRow linhaAtual = DtgBairro.CurrentRow;

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
            LblNumCodigo.Text = DtgBairro.Rows[index].Cells[0].Value.ToString();
            TxtNomeBairro.Text = DtgBairro.Rows[index].Cells[1].Value.ToString();
            CboCidade.SelectedValue = (int)DtgBairro.Rows[index].Cells[2].Value;
        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {
            if (TxtNomeBairro.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeCidade.Text + " é obrigatório.", "20200720-02", "a");
                TxtNomeBairro.Focus();
                return false;
            }

            if (CboCidade.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblCidade.Text + " é obrigatório.", "20200720-01", "A");
                CboCidade.Focus();
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
            TxtNomeBairro.Enabled = bolHabil;
            CboCidade.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeBairro.Text = TxtPesquisar.Text = string.Empty;
            CboCidade.SelectedIndex = -1;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgBairro, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgBairro, nomeColuna, colunaVisivel);
                CarregarCboCidade(CboCidade);
            }
            CboCidade.SelectedIndex = -1;
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
            List<BairroModel> listaBairros = new List<BairroModel>();
            BairroController bairroController = new BairroController();

            try
            {
                DtgBairro.DataSource = null;
                DtgBairro.Rows.Clear();
                DtgBairro.DataSource = bairroController.ObterRegistrosBairro();
                TotalRegistroNoDataGridView(DtgBairro, LblTotalRegistros);
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
        private void CarregarCboCidade(ComboBox cbo)
        {
            BairroController bairroController = new BairroController();
            bairroController.PopularCboCidade(cbo);
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
