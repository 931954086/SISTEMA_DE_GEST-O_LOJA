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
    public partial class WFMaterialView : Form
    {

        #region Variáveis
        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "MaterialId", "Nome Material", "Cor", "Modelo", "Descrição", "Qtd Total", "Qtd Disponível", "PrecoAluguel", "Código Barra" };
        bool[] colunaVisivel = { false, true, true, true, true, true, false, false, false, false };
  

        /// <summary>
        /// colwidth[] é um array que define a largura das colunas do listview de exibição.
        /// </summary>
        int[] colwidth = { 0, 0, 210, 150, 140 };
        #endregion Variáveis

        #region Construtor
        public WFMaterialView()
        {
            InitializeComponent();
            DtgMaterial.CellFormatting += dataGridView1_CellFormatting;
            PadraoForm.SettingsForm(this);
        }
        #endregion Construtor

        #region Eventos
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula é uma célula de cabeçalho (header) ou de dados
            if (e.RowIndex == -1) // Cabeçalho
            {
                DtgMaterial.Columns[e.ColumnIndex].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Dados
            {
                e.CellStyle.Font = new Font("Arial", 12);
            }
        }
        #endregion Eventos

        private void panelDados_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Form
        private void WFMaterialView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgMaterial.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgMaterial.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
            LblNumCodigo.Enabled = false;
        }

        private void WFMaterialView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                BtnIncluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                BtnAlterar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                BtnExcluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                BtnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                TxtPesquisar.Focus();
            }
        }
        #endregion Form


        private void TxtNomeMaterial_Enter(object sender, EventArgs e)
        {
            Diversos.ControlBackColorGot(sender);
            Diversos.PrimeirasMaiusculas(TxtNomeMaterial.Text);
        }
        private void TxtNomeMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtCorMaterial);
        }

        private void TxtNomeMaterial_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }
        //===================================================================
        private void TxtCorMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtModeloMaterial);
        }
        private void TxtCorMaterial_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtModeloMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtQtdDisponivel);
        }
        private void TxtModeloMaterial_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }
        //===================================================================

        private void TxtQtdDisponivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtQdtTotal);
        }
        private void TxtQtdDisponivel_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtQdtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtPrecoMaterial);
        }
        private void TxtQdtTotal_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }
        private void TxtPrecoMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, RTxtDescricaoMaterial);
        }
        private void TxtPrecoMaterial_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void RTxtDescricaoMaterial_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtPrecoMaterial);
        }

        private void RTxtDescricaoMaterial_Leave(object sender, EventArgs e)
        {
            ////
        }


        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgMaterial.DataSource != null)
            {
                MaterialController materialController = new MaterialController();
                materialController.PesquisarMaterial
                    (DtgMaterial, TxtPesquisar.Text.Trim());

                //((System.Data.DataTable)DtgCidade.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", TxtPesquisar.Text.Trim().Replace("'", "''"));
                TotalRegistroNoDataGridView(DtgMaterial, LblTotalRegistros);// LblTotalRegistros.Text = (DtgCidade.Rows.Count - 1).ToString();
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-08", "x");
            }
        }
        //=====================================================================================

        private void DtgMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgMaterial_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        #region Métodos

        private bool Validar(object sender, EventArgs e)
        {
            if (TxtNomeMaterial.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeMaterial.Text + " é obrigatório.", "20240829-29", "a");
                TxtNomeMaterial.Focus();
                return false;
            }

            if (TxtCorMaterial.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblCor.Text + " é obrigatório.", "20240829-29", "a");
                TxtCorMaterial.Focus();
                return false;
            }

            if (TxtModeloMaterial.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblModelo.Text + " é obrigatório.", "20240829-29", "a");
                TxtModeloMaterial.Focus();
                return false;
            }
            if (TxtQtdDisponivel.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblQtdDisponivel.Text + " é obrigatório.", "20240829-29", "a");
                TxtQtdDisponivel.Focus();
                return false;
            }
            if (TxtQdtTotal.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblQtdTotal.Text + " é obrigatório.", "20240829-29", "a");
                TxtQdtTotal.Focus();
                return false;
            }
            if (TxtPrecoMaterial.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblPreço.Text + " é obrigatório.", "20240829-29", "a");
                TxtPrecoMaterial.Focus();
                return false;
            }
            if (RTxtDescricaoMaterial.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblDescricao.Text + " é obrigatório.", "20240829-29", "a");
                RTxtDescricaoMaterial.Focus();
                return false;
            }
            if (TxtCodigoBarra.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblCodigoBarra.Text + " é obrigatório.", "20240829-29", "a");
                TxtCodigoBarra.Focus();
                return false;
            }
            if (TxtQtdMin.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblQtdMin.Text + " é obrigatório.", "20240829-29", "a");
                TxtQtdMin.Focus();
                return false;
            }


            return true;
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
                    ((Button)controle).Focus();
            }
        }


        private void LimparCampos()
        {
            TxtQtdMin.Text =TxtCodigoBarra.Text = TxtPrecoMaterial.Text = TxtQdtTotal.Text = TxtQtdDisponivel.Text = LblNumCodigo.Text = TxtNomeMaterial.Text = TxtPesquisar.Text = TxtCorMaterial.Text = TxtModeloMaterial.Text = RTxtDescricaoMaterial.Text = string.Empty;
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
            //LblNumCodigo.ForeColor = ThemeColor.PrimaryColor;
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
                RefreshDataGrid(DtgMaterial, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgMaterial, nomeColuna, colunaVisivel);
            }
        }

        private void HabilitarCampos(bool bolHabil)
        {
            TxtCodigoBarra.Enabled    = bolHabil;
            TxtNomeMaterial.Enabled   = bolHabil;
            TxtCorMaterial.Enabled    = bolHabil;
            TxtModeloMaterial.Enabled = bolHabil;
            TxtQtdDisponivel.Enabled  = bolHabil;
            TxtQdtTotal.Enabled       = bolHabil;
            TxtPrecoMaterial.Enabled  = bolHabil;
            RTxtDescricaoMaterial.Enabled = bolHabil;
            TxtQtdMin.Enabled = bolHabil;
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
                DataGridViewRow linhaAtual = DtgMaterial.CurrentRow;

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
            LblNumCodigo.Text      = DtgMaterial.Rows[index].Cells[0].Value.ToString();
            TxtNomeMaterial.Text   = DtgMaterial.Rows[index].Cells[1].Value.ToString();
            TxtCorMaterial.Text    = DtgMaterial.Rows[index].Cells[2].Value.ToString();
            TxtModeloMaterial.Text = DtgMaterial.Rows[index].Cells[3].Value.ToString();
            TxtQtdDisponivel.Text  = Convert.ToInt32(DtgMaterial.Rows[index].Cells[6].Value).ToString();
            TxtQdtTotal.Text       = Convert.ToInt32(DtgMaterial.Rows[index].Cells[5].Value).ToString();
            RTxtDescricaoMaterial.Text = DtgMaterial.Rows[index].Cells[4].Value.ToString();
            TxtPrecoMaterial.Text = DtgMaterial.Rows[index].Cells[7].Value.ToString();
            TxtCodigoBarra.Text = DtgMaterial.Rows[index].Cells[8].Value.ToString();
            TxtQtdMin.Text = Convert.ToInt32(DtgMaterial.Rows[index].Cells[9].Value).ToString();
        }


        private void RefreshDataGrid(DataGridView dtgMaterial, bool bolRefresh)
        {

            if (bolRefresh)
            {
                PreencherDataGridView(dtgMaterial);
            }
        }
        /// <summary>
        /// Popula o datagridview com registros do banco de dados.
        /// </summary>
        /// <param name="Dtg"></param>
        private void PreencherDataGridView(object dtgEmpresa)
        {
            List<MaterialModel> listaMaterial = new List<MaterialModel>();
            MaterialController materialController = new MaterialController();

            try
            {
                DtgMaterial.DataSource = null;
                DtgMaterial.Rows.Clear();
                DtgMaterial.DataSource = materialController.ObterRegistrosMaterial();
                TotalRegistroNoDataGridView(DtgMaterial, LblTotalRegistros);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20200721-01", "e");
            }
        }

        private void TotalRegistroNoDataGridView(DataGridView dtgMaterial, Label lblTotalRegistros)
        {
            lblTotalRegistros.Text = "Total de Registros: " + (dtgMaterial.Rows.Count).ToString();
        }

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgMaterial.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        #endregion Métodos







    #region BUTÕES

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtNomeMaterial.Focus();
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
                    TxtNomeMaterial.Focus();
                }
                else
                {
                    TelaInicial(false);
                    MGMensagemErro.MensagensErro("O usuário não selecionou um registro no grid ou" +
                        " o grid está sem registros.", "20240829-29", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20240829-29", "E");
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
                        " o grid está sem registros.", "20240829-29", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20240829-29", "E");
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
                MaterialModel materialModel = new MaterialModel();
                MaterialController materialController = new MaterialController();

                materialModel.NomeMaterial   = TxtNomeMaterial.Text.Trim();
                materialModel.CorMaterial    = TxtCorMaterial.Text.Trim();
                materialModel.ModeloMaterial = TxtModeloMaterial.Text.Trim(); 
                materialModel.QtdDisponivelMaterial = Convert.ToDecimal(TxtQtdDisponivel.Text.Trim());
                materialModel.QtdTotal = Convert.ToDecimal(TxtQdtTotal.Text.Trim());
                materialModel.Preco =    Convert.ToDecimal(TxtPrecoMaterial.Text.Trim());
                materialModel.DescricaoMaterial = RTxtDescricaoMaterial.Text.Trim();
                materialModel.CodigoBarra = TxtCodigoBarra.Text.Trim();
                materialModel.Qtdmin = Convert.ToDecimal(TxtQtdMin.Text.Trim());

                //============ LOGICA PARA POPULAR CBO  =====================

                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = materialController.IncluirMaterialController(materialModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            materialModel.IdMaterial = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = materialController.AlterarMaterialController(materialModel);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            materialModel.IdMaterial = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = materialController.ExcluirMaterialController(materialModel.IdMaterial);
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


        #endregion BUTÕES

        private void TxtQtdDisponivel_TextChanged(object sender, EventArgs e)
        {
            if ((TxtQtdMin.Text != "") && (TxtQdtTotal.Text != "") && (TxtQtdDisponivel.Text != ""))
            {
                if ((Convert.ToInt32(TxtQtdMin.Text) > Convert.ToInt32(TxtQdtTotal.Text)) || (Convert.ToInt32(TxtQtdMin.Text) > Convert.ToInt32(TxtQtdDisponivel.Text)))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo " + " não deve ser maior que a quantidade total em estoque ou maior que a quantidade disponível em estoque!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if ((Convert.ToInt32(TxtQtdMin.Text) == Convert.ToInt32(TxtQdtTotal.Text)) || (Convert.ToInt32(TxtQtdMin.Text) == Convert.ToInt32(TxtQtdDisponivel.Text)))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + " não deve ser igual a quantidade total ou quantidade  disponível!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if (Convert.ToInt32(TxtQtdMin.Text) > 5)
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + LblQtdMin.Text + " não deve ser maior que 5!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if (Convert.ToInt32(TxtQtdDisponivel) > Convert.ToInt32(TxtQtdDisponivel))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade disponivel do estoque no campo  " + LblQtdDisponivel.Text + " não deve ser maior que quantidade total!", "20240915-15", "a");
                    TxtQtdDisponivel.Focus();
                }
                else
                {
                    BtnSalvar.Enabled = true;
                }
            }
        }
        private void TxtQdtTotal_TextChanged(object sender, EventArgs e)
        {
            if ((TxtQtdMin.Text != "") && (TxtQdtTotal.Text != "") && (TxtQtdDisponivel.Text != ""))
            {
                if ((Convert.ToInt32(TxtQtdMin.Text) > Convert.ToInt32(TxtQdtTotal.Text)) || (Convert.ToInt32(TxtQtdMin.Text) > Convert.ToInt32(TxtQtdDisponivel.Text)))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo " + " não deve ser maior que a quantidade total em estoque ou maior que a quantidade disponível em estoque!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if ((Convert.ToInt32(TxtQtdMin.Text) == Convert.ToInt32(TxtQdtTotal.Text)) || (Convert.ToInt32(TxtQtdMin.Text) == Convert.ToInt32(TxtQtdDisponivel.Text)))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + " não deve ser igual a quantidade total ou quantidade  disponível!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if (Convert.ToInt32(TxtQtdMin.Text) > 5)
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + LblQtdMin.Text + " não deve ser maior que 5!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else
                {
                    BtnSalvar.Enabled = true;
                }
            }
        }

        private void TxtQtdMin_TextChanged(object sender, EventArgs e)
        {
            if ((TxtQtdMin.Text != "") && (TxtQdtTotal.Text != "") && (TxtQtdDisponivel.Text != ""))
            {
                if ((Convert.ToInt32(TxtQtdMin.Text) > Convert.ToInt32(TxtQdtTotal.Text)) || (Convert.ToInt32(TxtQtdMin.Text) > Convert.ToInt32(TxtQtdDisponivel.Text)))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo "+ " não deve ser maior que a quantidade total em estoque ou maior que a quantidade disponível em estoque!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if ((Convert.ToInt32(TxtQtdMin.Text) == Convert.ToInt32(TxtQdtTotal.Text)) || (Convert.ToInt32(TxtQtdMin.Text) == Convert.ToInt32(TxtQtdDisponivel.Text)))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + " não deve ser igual a quantidade total ou quantidade  disponível!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else if (Convert.ToInt32(TxtQtdMin.Text) > 5)
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + LblQtdMin.Text + " não deve ser maior que 5!", "20240915-15", "a");
                    TxtQtdMin.Focus();
                }
                else
                {
                    BtnSalvar.Enabled = true;
                }
            }
        }



    }
}
