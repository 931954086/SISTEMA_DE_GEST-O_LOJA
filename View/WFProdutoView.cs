using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFProdutoView : Form
    {
        #region Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        //string[] nomeColuna = { "Código", "Produto", "Preço", "Quant.", "Qtd. Min.", "IdSituacao", "Situação" };
        //string[] colVisivel = { "IdProduto", "DescProduto", "PrecoProduto", "QuantidadeEstoque", "QtdMinimaEstoque", "DescSituacao" };


        List<string> ListaColunaVisivel = new List<string>() { "IdProduto", "DescProduto", "PrecoProduto", "QuantidadeEstoque", "QtdMinimaEstoque", "DescSituacao" };
        List<string> ListaCabecalho = new List<string>() { "Código", "Produto", "Preço", "Quant.", "Qtd. Min.", "Situação", "IdSituacao" };
        List<int> ListaLarguraColuna = new List<int>() { 10, 29, 13, 13, 13, 12 };

        ProdutoController produtoController = null;
        Bitmap bmp = null;

        decimal precoAtual = 0;

        #endregion Variáveis

        #region Construtor

        public WFProdutoView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
            produtoController = new ProdutoController();
        }

        #endregion Construtor

        #region Eventos

        #region Form

        private void WFProdutoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgProduto.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgProduto.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
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

        #endregion Form

        #region TextBox

        private void TxtCodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDescProduto.Focus();
            }
        }

        private void TxtDescProduto_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtDescProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtPrecoProduto.Focus();
            }
        }

        private void TxtDescProduto_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtPrecoProduto_Click(object sender, EventArgs e)
        {
            Diversos.PosicionaCursorADireita(sender, e);
        }

        private void TxtPrecoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtPrecoProduto.Text = Diversos.FormataStringDecimal2(TxtPrecoProduto.Text);
                TxtQtdEstoque.Focus();
            }
            else
            {
                e.Handled = Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtPrecoProduto_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtQtdEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtQtdEstoque.Text = Diversos.FormataStringDecimal2(TxtQtdEstoque.Text);
                TxtQtdMinEstoque.Focus();
            }
            else
            {
                e.Handled = Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtQtdMinEstoque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtQtdMinEstoque.Text = Diversos.FormataStringInt2(TxtQtdMinEstoque.Text);
                CboSituacao.Focus();
            }
            else
            {
                e.Handled = Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtPesquisar_GotFocus(object sender, EventArgs e)
        {
            TxtPesquisar.Text = string.Empty;
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            RdbCodBarra.Checked = RdbProduto.Checked = false;
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgProduto.DataSource != null)
            {
                if (RdbProduto.Checked == true)
                {
                    produtoController.PesquisarProdutos(DtgProduto, TxtPesquisar.Text.Trim());
                }
                else if (RdbCodBarra.Checked == true)
                {
                    produtoController.PesquisarProdutosPorCodBarra(DtgProduto, TxtPesquisar.Text.Trim());
                }
                TotalRegistroNoDataGridView(DtgProduto, LblTotalRegistros);
                AtribuirValoresDaLinhaDoDataGridView();
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-09", "x");
            }
        }

        private void TxtDescricaoProduto_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtDescricaoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSalvar.Focus();
            }
        }

        #endregion TextBox

        #region Button
        private void BtnProcurar_Click(object sender, EventArgs e)
        {
            Util.ReadWriteFoto rwf = new ReadWriteFoto(picBox);
            bmp = rwf.EscolherFoto();
            rwf = null;
        }



        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtCodigoBarra.Focus();
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
                    TxtDescProduto.Focus();
                }
                else
                {
                    TelaInicial(false);
                    MGMensagemErro.MensagensErro("O usuário não selecionou um registro no grid ou" +
                        " o grid está sem registros.", "20201027-01", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20201027-02", "E");
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

                    if (MessageBox.Show("Deseja excluir o registro selecionado?", "Confirmação de Exclusão",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
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
                        " o grid está sem registros.", "20201027-03", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20201027-04", "E");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            //Validando a ação do usuário (Incluir, Alterar ou Excluir)
            if (enuAcao == OPERACAO.STANDBY)
            {
                MGMensagemErro.MensagensErro("Primeiro selecione a ação que deseja realizar pressionando um" +
                    " dos botões do menu.", "20201027-05", "A");
                return;
            }
            try
            {
                if (picBox.Image == null)
                {
                    if (MessageBox.Show("Não foi selecionada uma foto! Deseja escolher agora?", "Selecionar foto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        BtnProcurar_Click(sender, e);
                        MGMensagemErro.MensagensErro("Pressione o botão salvar novamente para finalizar a operação ou.", "20210111-01", "i");
                        return;
                    }
                }

                //Validação dos campos obrigatórios
                if (!Validar())
                {
                    return;
                }

                ProdutoModel produtoModel = new ProdutoModel();

                produtoModel.Descproduto = TxtDescProduto.Text.Trim();
                produtoModel.Precoproduto = Convert.ToDecimal(TxtPrecoProduto.Text.Trim());
                produtoModel.Quantidadeeestoque = Convert.ToDecimal(TxtQtdEstoque.Text.Trim());
                produtoModel.Qteminimaestoque   = Convert.ToDecimal(TxtQtdMinEstoque.Text.Trim());
                produtoModel.Codigobarra = TxtCodigoBarra.Text.Trim();
                produtoModel.Situacao_Model.IdSituacao = Convert.ToInt16(CboSituacao.SelectedValue);
                produtoModel.Descricaoproduto = TxtDescricaoProduto.Text.Trim();
                if (picBox.Image != null && picBox.Image != Properties.Resources.semimagem)
                {
                    Util.ReadWriteFoto rwf = new Util.ReadWriteFoto();
                    produtoModel.Foto = rwf.ConverteImagemParaByteArray(picBox.Image); // rwf.ConverterImagemToArray(rwf.ConverterParaBitMat(pathImage));// foto;
                    rwf = null;
                }
                int retorno = 0;
                switch (enuAcao)
                {
                    case OPERACAO.INCLUIR:
                        {
                            retorno = produtoController.IncluirProdutoController(produtoModel);
                            break;
                        }
                    case OPERACAO.ALTERAR:
                        {
                            bool bolGravarHistorico = false;
                            produtoModel.Idproduto = Convert.ToInt32(LblNumCodigo.Text);

                            if (Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtPrecoProduto.Text.Trim())) !=
                                Convert.ToDecimal(Diversos.FormataStringDecimal2(precoAtual.ToString())))
                            {
                                bolGravarHistorico = true;
                            }

                            retorno = produtoController.AlterarProdutoController(produtoModel, bolGravarHistorico);
                            break;
                        }
                    case OPERACAO.EXCLUIR:
                        {
                            produtoModel.Idproduto = Convert.ToInt32(LblNumCodigo.Text);
                            retorno = produtoController.ExcluirProdutoController(produtoModel.Idproduto);
                            break;
                        }
                }

                if (retorno != 0)
                {
                    TelaInicial(true);
                    MGMensagemErro.MensagensErro("Operação efetuada com sucesso!", "20201027-06", "X");
                }
                else
                {
                    MGMensagemErro.MensagensErro("Operação Não foi efetuada.\n Verifique e tente novamente.",
                        "20201027-07", "e");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20201027-08", "E");
            }
        }

        #endregion Button

        #region ComboBox

        private void CboSituacao_Enter(object sender, EventArgs e)
        {
            switch (sender.GetType().Name.ToUpper())
            {
                case "COMBOBOX":
                    {
                        ((ComboBox)sender).SelectedIndex = 0;
                        break;
                    }
            }
        }

        private void CboSituacao_KeyDown(object sender, KeyEventArgs e)
        {
            PosicionarFoco(e, TxtDescricaoProduto);
        }

        #endregion ComboBox

        #region DataGridView

        private void DtgProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgProduto_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        #endregion DataGridView

        #region RadioButton

        private void RdbProduto_MouseClick(object sender, MouseEventArgs e)
        {
            TxtPesquisar.Focus();
        }

        private void RdbCodBarra_MouseClick(object sender, MouseEventArgs e)
        {
            TxtPesquisar.Focus();
        }

        #endregion RadioButton

        #endregion Eventos

        #region Métodos

        private void TelaInicial(Boolean bolIni)
        {
            enuAcao = OPERACAO.STANDBY;

            if (bolIni)
            {
                RefreshDataGrid(DtgProduto, true);

                EstilizarDataGridView.DefinirVisibilidadeDataGridView(DtgProduto, ListaColunaVisivel);
                EstilizarDataGridView.DefinirCabecalhoDataGridView(DtgProduto, ListaCabecalho);
                EstilizarDataGridView.DefinirLargurasDataGridView(DtgProduto, ListaLarguraColuna);
                EstilizarDataGridView.EstiloDataGridView(DtgProduto);

                CarregarCboSituacao(CboSituacao);
            }
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();
            RdbProduto.Checked = true;
        }

        private void CarregarCboSituacao(ComboBox cbo)
        {
            SituacaoController situacaoController = new SituacaoController();
            cbo.DataSource = situacaoController.ObterRegistrosSituacao();
            cbo.DisplayMember = "DescSituacao";
            cbo.ValueMember = "IdSituacao";
        }

        private void HabilitarBotoes(Boolean bolHabil)
        {
            BtnIncluir.Enabled = bolHabil;
            BtnAlterar.Enabled = bolHabil;
            BtnExcluir.Enabled = bolHabil;
        }

        private void HabilitarCampos(Boolean bolHabil)
        {
            TxtDescProduto.Enabled      = bolHabil;
            TxtPrecoProduto.Enabled     = bolHabil;
            TxtQtdEstoque.Enabled       = bolHabil;
            TxtQtdMinEstoque.Enabled    = bolHabil;
            TxtCodigoBarra.Enabled      = bolHabil;
            CboSituacao.Enabled         = bolHabil;
            BtnProcurar.Enabled         = bolHabil;
            TxtDescricaoProduto.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtDescProduto.Text = TxtPrecoProduto.Text = TxtQtdEstoque.Text =
            TxtQtdMinEstoque.Text = TxtPesquisar.Text = TxtCodigoBarra.Text = TxtDescricaoProduto.Text = string.Empty;
            CboSituacao.SelectedIndex = -1;
            picBox.Image = null;
        }

        private void RefreshDataGrid(DataGridView dtg, Boolean bolRefresh)
        {
            if (bolRefresh) { PreencherDataGridView(dtg); }
        }

        /// <summary>
        /// Popula o datagridview com registros do banco de dados.
        /// </summary>
        /// <param name="Dtg"></param>
        private void PreencherDataGridView(DataGridView Dtg)
        {
            ProdutoController produtoController = new ProdutoController();

            try
            {
                DtgProduto.DataSource = null;
                DtgProduto.Rows.Clear();
                DtgProduto.DataSource = produtoController.ObterRegistrosProduto();
                TotalRegistroNoDataGridView(DtgProduto, LblTotalRegistros);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20201027-11", "e");
            }
        }

        private void TotalRegistroNoDataGridView(DataGridView dtg, Label lbl)
        {
            lbl.Text = "Total de Registros: " + (dtg.Rows.Count).ToString();
        }
        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgProduto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns>Número da linha selecionada no DataGridView.</returns>
        private int RecuperarLinhaSelecionadaDataGridView()
        {
            try
            {
                DataGridViewRow linhaAtual = DtgProduto.CurrentRow;

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
            try
            {
                // vamos obter a linha da célula selecionada
                int index = RecuperarLinhaSelecionadaDataGridView();
                if (index >= 0)
                {
                    if ((object)DtgProduto.Rows[index].Cells[8].Value != System.DBNull.Value)
                    {
                        Util.ReadWriteFoto rwf = new Util.ReadWriteFoto(picBox);
                        rwf.LendoVarbinary((byte[])DtgProduto.Rows[index].Cells[8].Value);
                    }
                    else
                    {
                        picBox.Image = null;
                    }
                    // configurando valor da primeira coluna, índice 0
                    LblNumCodigo.Text = DtgProduto.Rows[index].Cells[0].Value.ToString();
                    TxtDescProduto.Text = DtgProduto.Rows[index].Cells[1].Value.ToString();
                    TxtPrecoProduto.Text = DtgProduto.Rows[index].Cells[2].Value.ToString();
                    precoAtual = Convert.ToDecimal(DtgProduto.Rows[index].Cells[2].Value.ToString());
                    TxtQtdEstoque.Text = Convert.ToInt32(DtgProduto.Rows[index].Cells[3].Value).ToString();
                    TxtQtdMinEstoque.Text = Convert.ToInt32(DtgProduto.Rows[index].Cells[4].Value).ToString();
                    CboSituacao.SelectedValue = Convert.ToInt16(DtgProduto.Rows[index].Cells[6].Value.ToString());
                    TxtCodigoBarra.Text = DtgProduto.Rows[index].Cells[7].Value.ToString();
                    TxtDescricaoProduto.Text = DtgProduto.Rows[index].Cells[9].Value.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private Boolean Validar()
        {
            if (TxtDescProduto.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblDescProduto.Text + " é obrigatório.", "20201027-10", "a");
                TxtDescProduto.Focus();
                return false;
            }

            if (TxtQtdEstoque.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblQtdEstoque.Text + " é obrigatório.", "20201027-10", "a");
                TxtQtdEstoque.Focus();
                return false;
            }
            if (TxtQtdMinEstoque.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblQtdMinEstoque.Text + " é obrigatório.", "20201027-10", "a");
                TxtQtdMinEstoque.Focus();
                return false;
            }
            if (TxtPrecoProduto.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblPrecoProduto.Text + " é obrigatório.", "20201027-10", "a");
                TxtPrecoProduto.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Usar preferencialmente nos controles de texto. Usar no evento keypress texbox e maskedtextbox.
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        /// <param name="controle">Nome do objeto.</param>
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

        /// <summary>
        /// Usar no evento KeyDown da ComboBox
        /// </summary>
        /// <param name="e"></param>
        /// <param name="controle"></param>
        private void PosicionarFoco(KeyEventArgs e, object controle)
        {
            if (e.KeyCode == Keys.Enter)
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




        #endregion Métodos

        private void panelDados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtQtdMinEstoque_TextChanged(object sender, EventArgs e)
        {
            if ((TxtQtdMinEstoque.Text != "") && (TxtQtdEstoque.Text != ""))
            {
                if (Convert.ToInt32(TxtQtdMinEstoque.Text) > Convert.ToInt32(TxtQtdEstoque.Text))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade total do estoque no campo " + LblQtdEstoque.Text + " não deve ser menor que a quantidade mínima em estoque!", "20240915-15", "a");
                    TxtQtdMinEstoque.Focus();
                }
                else if (Convert.ToInt32(TxtQtdMinEstoque.Text) == Convert.ToInt32(TxtQtdEstoque.Text))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + LblQtdMinEstoque.Text + " não deve ser igual a quantidade total em estoque!", "20240915-15", "a");
                    TxtQtdMinEstoque.Focus();
                }
                else if (Convert.ToInt32(TxtQtdMinEstoque.Text) > 5)
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo  " + LblQtdMinEstoque.Text + " não deve ser maior que 5!", "20240915-15", "a");
                    TxtQtdMinEstoque.Focus();
                }
                else
                {
                    BtnSalvar.Enabled = true;
                }
            }
        }

        private void TxtQtdEstoque_TextChanged(object sender, EventArgs e)
        {
            if ((TxtQtdMinEstoque.Text != "") && (TxtQtdEstoque.Text != ""))
            {
                if (Convert.ToInt32(TxtQtdEstoque.Text) < Convert.ToInt32(TxtQtdMinEstoque.Text))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade mínima do estoque no campo " + LblQtdMinEstoque.Text + " não deve ser maior que a quantidade total em estoque!", "20240915-15", "a");
                    TxtQtdMinEstoque.Focus();
                }
                else if (Convert.ToInt32(TxtQtdEstoque.Text) == Convert.ToInt32(TxtQtdMinEstoque.Text))
                {
                    BtnSalvar.Enabled = false;
                    MGMensagemErro.MensagensErro("A quantidade total do estoque no campo  " + LblQtdEstoque.Text + " não deve ser igual a quantidade mínima em estoque!", "20240915-15", "a");
                    TxtQtdEstoque.Focus();
                }
                else
                {
                    BtnSalvar.Enabled = true;
                }
            }
        }
    }
}
