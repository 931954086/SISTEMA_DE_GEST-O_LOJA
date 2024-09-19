using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFEmpresaView : Form
    {

        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "IdEmpresa", "Empresa", "NIF", "Fundação", "Site", "Email" };
        bool[] colunaVisivel = { false, true,  true, true,  true,  true};

   

        #endregion Variáveis

        #region Construtor
        public WFEmpresaView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
        }
        #endregion Construtor


        #region Eventos
        #region Form

        private void WFEmpresaView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgEmpresa.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgEmpresa.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }
        private void BtnDepartamento_Click(object sender, EventArgs e)
        {
            WFDepartamentoView departamentoView = new WFDepartamentoView();
            departamentoView.ShowDialog();

        }

        #endregion Form
        #endregion Eventos


        #region BUTOES_MENU 
        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtNomeEmpresa.Focus();
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
                    TxtNomeEmpresa.Focus();
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
                        " o grid está sem registros.", "20200930-03", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200930-04", "E");
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
                if (!Validar(sender, e))
                {
                    return;
                }
                EmpresaModel empresaModel = new EmpresaModel();
                EmpresaController empresaController = new EmpresaController();

                empresaModel.NomeEmpresa = TxtNomeEmpresa.Text.Trim();
                empresaModel.Nif         = TxtNif.Text.Trim();
                empresaModel.Fundacao    = DateTime.Now;
                empresaModel.Site        = TxtSite.Text.Trim();
                empresaModel.Email       = TxtEmail.Text.Trim(); 

               //============ LOGICA PARA POPULAR CBO  =====================

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = empresaController.IncluirEmpresaController(empresaModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            empresaModel.IdEmpresa = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = empresaController.AlterarEmpresaController(empresaModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            empresaModel.IdEmpresa = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = empresaController.ExcluirEmpresaController(empresaModel.IdEmpresa);
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



        #endregion BUTOES_MENU 


        #region Métodos

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private bool Validar(object sender, EventArgs e)
        {
            if (TxtNomeEmpresa.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeEmpresa.Text + " é obrigatório.", "20200720-02", "a");
                TxtNomeEmpresa.Focus();
                return false;
            }

            if (TxtSite.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSite.Text + " é obrigatório.", "20200720-02", "a");
                TxtSite.Focus();
                return false;
            }

            if (TxtNif.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNif.Text + " é obrigatório.", "20200720-02", "a");
                TxtNif.Focus();
                return false;
            }

            if (TxtEmail.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblEmail.Text + " é obrigatório.", "20200720-02", "a");
                TxtEmail.Focus();
                return false;
            }


            if (!string.IsNullOrEmpty(TxtEmail.Text))
            {
                MailAddress mailAddress;
                mailAddress = new MailAddress(TxtEmail.Text);
            }
            else
            {
                MGMensagemErro.MensagensErro("O campo " + "Email" + " é de caracter obrigatório.", "20201117-10", "I");
                return false;
            }
            return true;
        }



        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeEmpresa.Text = TxtPesquisar.Text  = TxtNif.Text = TxtEmail.Text = TxtSite.Text = string.Empty;
        }

        private void HabilitarBotoes(bool bolHabil)
        {
            BtnIncluir.Enabled = bolHabil;
            BtnAlterar.Enabled = bolHabil;
            BtnExcluir.Enabled = bolHabil;
        }




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

        private void TelaInicial(bool bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgEmpresa, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgEmpresa, nomeColuna, colunaVisivel);
            }
        }



        private void HabilitarCampos(bool bolHabil)
        {
            TxtNomeEmpresa.Enabled = bolHabil;
            TxtEmail.Enabled = bolHabil;
            TxtSite.Enabled = bolHabil;
            TxtNif.Enabled = bolHabil;
        }


        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns> Número da linha selecionada no DataGridView.</returns>
        private int RecuperarLinhaSelecionadaDataGridView()
        {
            //DataGridViewRow linhaAtual = DtgCidade.CurrentRow;
            //int numeroLinha = linhaAtual.Index;
            //return numeroLinha;

            try
            {
                DataGridViewRow linhaAtual = DtgEmpresa.CurrentRow;

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
            //vamos obter a linha da célula selecionada
            int index = RecuperarLinhaSelecionadaDataGridView();
            // configurando valor da primeira coluna, índice 0
            LblNumCodigo.Text   = DtgEmpresa.Rows[index].Cells[0].Value.ToString();
            TxtNomeEmpresa.Text = DtgEmpresa.Rows[index].Cells[1].Value.ToString();
            TxtNif.Text = DtgEmpresa.Rows[index].Cells[2].Value.ToString();
            TxtEmail.Text = DtgEmpresa.Rows[index].Cells[5].Value.ToString();
            TxtSite.Text = DtgEmpresa.Rows[index].Cells[4].Value.ToString();
        }


        private void RefreshDataGrid(DataGridView dtgEmpresa, bool bolRefresh)
        {

            if (bolRefresh){
                PreencherDataGridView(dtgEmpresa); 
            }
        }



        /// <summary>
        /// Popula o datagridview com registros do banco de dados.
        /// </summary>
        /// <param name="Dtg"></param>
        private void PreencherDataGridView(object dtgEmpresa)
        {
            List<EmpresaModel> listaEpresa = new List<EmpresaModel>();
            EmpresaController empresaController = new EmpresaController();

            try
            {
                DtgEmpresa.DataSource = null;
                DtgEmpresa.Rows.Clear();
                DtgEmpresa.DataSource = empresaController.ObterRegistrosEmpresas();
                TotalRegistroNoDataGridView(DtgEmpresa, LblTotalRegistros);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20200721-01", "e");
            }
        }

        private void TotalRegistroNoDataGridView(DataGridView dtgEmpresa, Label lblTotalRegistros)
        {
            lblTotalRegistros.Text = "Total de Registros: " + (dtgEmpresa.Rows.Count).ToString();
        }


        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgEmpresa.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        #endregion Métodos

        private void DtgEmpresa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgEmpresa_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
                //   this.Pesquisa.Enter += new System.EventHandler(this.TxtPesquisar_GotFocus);
            }
        }

        private void TxtPesquisar_GotFocus(object sender, EventArgs e)
        {
            TxtPesquisar.Text = string.Empty;//LimparCampos();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgEmpresa.DataSource != null)
            {
                EmpresaController empresaController = new EmpresaController();
                empresaController.PesquisarEmpresas(DtgEmpresa, TxtPesquisar.Text.Trim());

                //((System.Data.DataTable)DtgCidade.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", TxtPesquisar.Text.Trim().Replace("'", "''"));
                TotalRegistroNoDataGridView(DtgEmpresa, LblTotalRegistros);// LblTotalRegistros.Text = (DtgCidade.Rows.Count - 1).ToString();
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-08", "x");
            }
        }

        private void TxtNomeEmpresa_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtNomeEmpresa_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtNif_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
            Diversos.PrimeirasMaiusculas(TxtNif.Text);
        }

        private void TxtNif_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtSite_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtSite_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
            TxtSite.Text.ToLower();
        }

        private void TxtEmail_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
            TxtEmail.Text.ToLower();
        }

        private void TxtPesquisar_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }
    }
}