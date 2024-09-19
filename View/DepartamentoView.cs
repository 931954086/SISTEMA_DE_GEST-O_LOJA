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
    public partial class WFDepartamentoView : MetroFramework.Forms.MetroForm
    {

        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "IdDepartamento", "Departamento", "Descrição", "IdEmpresa" };
        bool[] colunaVisivel = { false, true, true, false};

        #endregion Variáveis

        #region Construtor

        public WFDepartamentoView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
        }


        private void WFDepartamentoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgDepartamento.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgDepartamento.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }
        #endregion Construtor

        #region Eventos

        #endregion Eventos


        #region Boteos
        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtDepartamento.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
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
                    TxtDepartamento.Focus();
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
                DepartamentoModel departamentoModel = new DepartamentoModel();
                DepartamentoController departamentoController = new DepartamentoController();

                departamentoModel.NomeDepartamento = TxtDepartamento.Text.Trim();
                departamentoModel.Descricao = RichTextDescricao.Text.Trim();
                departamentoModel.EmpresaModel.IdEmpresa = (int)CboEmpresa.SelectedValue;

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = departamentoController.IncluirDepartaController(departamentoModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            departamentoModel.IdDepartamento = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = departamentoController.AlterarDepartaController(departamentoModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            departamentoModel.IdDepartamento = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = departamentoController.ExcluirDepartaController(departamentoModel.IdDepartamento);
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
        #endregion Boteos







        #region Métodos

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgDepartamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
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
                DataGridViewRow linhaAtual = DtgDepartamento.CurrentRow;

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
            LblNumCodigo.Text  = DtgDepartamento.Rows[index].Cells[0].Value.ToString();
            TxtDepartamento.Text = DtgDepartamento.Rows[index].Cells[1].Value.ToString();
            RichTextDescricao.Text = DtgDepartamento.Rows[index].Cells[2].Value.ToString();
            CboEmpresa.SelectedValue = (int)DtgDepartamento.Rows[index].Cells[3].Value;
        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar()
        {
            if (TxtDepartamento.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeCidade.Text + " é obrigatório.", "20200720-02", "a");
                TxtDepartamento
                    .Focus();
                return false;
            }

            if (CboEmpresa.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblCboEmpresa.Text + " é obrigatório.", "20200720-01", "A");
                CboEmpresa.Focus();
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
            TxtDepartamento  .Enabled = bolHabil;
            CboEmpresa.Enabled = bolHabil;
            RichTextDescricao.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtDepartamento.Text = RichTextDescricao.Text = TxtPesquisar.Text = string.Empty;
            CboEmpresa.SelectedIndex = -1;
        }

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgDepartamento, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgDepartamento, nomeColuna, colunaVisivel);
                CarregarCboEmpresa(CboEmpresa);
            }
            CboEmpresa.SelectedIndex = -1;
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
            List<DepartamentoModel> listaDepartamentos = new List<DepartamentoModel> ();
            DepartamentoController departamentoController = new DepartamentoController();

            try
            {
                DtgDepartamento.DataSource = null;
                DtgDepartamento.Rows.Clear();
                DtgDepartamento.DataSource = departamentoController.ObterRegistrosDepartamentos();
                TotalRegistroNoDataGridView(DtgDepartamento, LblTotalRegistros);
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
        private void CarregarCboEmpresa(ComboBox cbo)
        {
            EmpresaController empresaController = new EmpresaController();
            empresaController.PopularCboEmpresa(cbo);
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

        private void TxtDepartamento_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtDepartamento_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
            if (DtgDepartamento.DataSource != null)
            {
                DepartamentoController departamentoController = new DepartamentoController();
                departamentoController.PesquisarDepartamentos(DtgDepartamento, TxtPesquisar.Text.Trim());

                //((System.Data.DataTable)DtgCidade.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", TxtPesquisar.Text.Trim().Replace("'", "''"));
                TotalRegistroNoDataGridView(DtgDepartamento, LblTotalRegistros);// LblTotalRegistros.Text = (DtgCidade.Rows.Count - 1).ToString();
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-08", "x");
            }
        }

        private void TxtPesquisar_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void DtgDepartamento_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        private void DtgDepartamento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void RichTextDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                BtnSalvar.Focus();
        }
    }
}
