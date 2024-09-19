using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Relatorios;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
//using Button = System.Windows.Forms.Button;
//using TextBox = System.Windows.Forms.TextBox;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFVendaProdutoView : Form
    {
        #region Variáveis

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        ItemVendaModel itemVendaModel = null;

        // Configurando o datagridview
        List<string> ListaColunaVisivel = new List<string>() { "IdProduto", "DescProduto", "PrecoProduto", "QuantidadeEstoque", "QtdMinimaEstoque", "DescSituacao" };
        List<string> ListaCabecalho = new List<string>() { "Código", "Produto", "Preço", "Quant.", "Qtd. Min.", "Situação", "IdSituacao" };
        List<int>    ListaLarguraColuna = new List<int>() { 10, 30, 15, 15, 15, 15 };

        private enum OPERACAO { ALTERAR, STANDBY }
        private OPERACAO enuAcao;

        // Configurando o ListView
        int[] colwidth = { 70, 240, 80, 80, 90 };   // colwidth[] é um array que define a largura das colunas do listview de exibição.
        int linhaSelecionadaListView = 0;           // recupera o índice da linha selecionada no ListView

        // Variáveis de controle do construtor
        int idFuncionario, idTipoUsuario = 0;
        string nomeUsuario = string.Empty;
        string login = string.Empty;
        string siglaTipoUsuario = string.Empty;
        string nomeFunc = string.Empty;

        #endregion Variáveis

        #region Construtor
        public WFVendaProdutoView()
        {

            InitializeComponent();
            PadraoForm.SettingsForm(this);
            LblDataVenda.Text = "Data Venda: " + DateTime.Now.ToShortDateString();
            horaAtual();
           itemVendaModel = new ItemVendaModel();

        }

        public WFVendaProdutoView(int IdTipoUsuario, string login, string siglaTipoUsuario, string nomeFunc, int IdFuncionario)
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
            LblDataVenda.Text = "Data Venda: " + DateTime.Now.ToShortDateString();
            horaAtual();
            itemVendaModel = new ItemVendaModel();

            this.idFuncionario = IdFuncionario;
            this.idTipoUsuario = IdTipoUsuario;
            this.login = login;
            this.siglaTipoUsuario = siglaTipoUsuario;
            this.nomeFunc = nomeFunc;
           
        }


        private void WFVendaProdutoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgProduto.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgProduto.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }
        private void WFProdutoEntradaSaidaView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
        }

        #endregion Construtor

        #region Eventos

        #region Form


        private void WFVendaProdutoView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                BtnFaturamento_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                BtnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                TxtPesquisar.Focus();
            }
            else if ((Control.ModifierKeys == Keys.Alt) && (e.KeyCode == Keys.R))
            {
                TxtImpostos.Focus();
            }
        }

        #endregion Form

        #region Button


        private void BtnFaturamento_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.ALTERAR;
            NtVendaController ntVendaController = new NtVendaController();
            TxtNumFatura.Text = ntVendaController.GerarNumeroFatura();
            HabilitarCampos(true);
            HabilitarBotoes(false);
            CboCliente.Focus();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {

          if(MessageBox.Show("Cofirma o SubTotal do produto que esta sendo vendido? Reveja!!!", "Confirmação remoção do item",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
           {

                if (!ValidarCampos())
                {
                   return;
                }
            try
            {
                NtVendaModel ntVendaModel = new NtVendaModel();
                ntVendaModel.Numerofatura = TxtNumFatura.Text.Trim();
                ntVendaModel.Valorbrutovenda = Convert.ToDecimal(TxtSubTotal.Text);
                ntVendaModel.Descontovenda = Convert.ToDecimal(TxtDesconto.Text);
                ntVendaModel.ValorliqVenda = Convert.ToDecimal(TxtTotal.Text);
                ntVendaModel.Imposto = Convert.ToDecimal(TxtImpostos.Text);
                ntVendaModel.Dtpagamento = Convert.ToDateTime(DateTime.Now);
                ntVendaModel.Cliente_Model.Idcliente = Convert.ToInt32(CboCliente.SelectedValue);
                ntVendaModel.Funcionario_Model.IdFuncionario = this.idFuncionario;
                ntVendaModel.Situacao_Model.IdSituacao = 1;

                itemVendaModel.ListaItensVendaModel.Clear();

                for (int i = 0; i < LvwVenda.Items.Count; i++)
                {
                    ItemVendaModel objVenda = new ItemVendaModel();

                    objVenda.Ntvenda_Model.Numerofatura = TxtNumFatura.Text;
                    objVenda.Produto_Model.Idproduto = Convert.ToInt32(LvwVenda.Items[i].SubItems[0].Text);
                    objVenda.Valorunit = Convert.ToDecimal(LvwVenda.Items[i].SubItems[2].Text) * Convert.ToDecimal(LvwVenda.Items[i].SubItems[3].Text);
                    objVenda.Quantidadeitemvenda = Convert.ToDecimal(LvwVenda.Items[i].SubItems[3].Text);
                    itemVendaModel.ListaItensVendaModel.Add(objVenda);
                }

                NtVendaController ntVendaController = new NtVendaController();

                if (ntVendaController.IncluirNtVendaController(ntVendaModel, itemVendaModel) != 0)
                {
 
                    ProdutoController produtoController = new ProdutoController();

                    TelaInicial(true);
                    MGMensagemErro.MensagensErro("Atualização efetuada com sucesso!", "20201224-06", "X");
                   //ExibirCupom(ntVendaModel.Numerofatura);
                   WFRelatorio fatura = new WFRelatorio(ntVendaModel.Numerofatura);
                   //ArredondaBordas(fatura, 15);
                   fatura.ShowDialog();
                }
                else
                {
                    MGMensagemErro.MensagensErro("Atualização NÃO foi efetuada.\n\n Verifique e tente novamente.", "20201224-07", "e");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "20201224-04 Sera???", "e");
            }
          }else{
                return;
            }
        }

        // Método para arredondar as bordas de um formulário
        private static void ArredondaBordas(Form form, int borderRadius)
        {
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }



        private void BtnAdicionarLista_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtQtdVendaProduto.Text.Trim()))
                {
                    MGMensagemErro.MensagensErro("Informe a quantidade de venda do produto.", "20201229-01", "a");
                    TxtQtdVendaProduto.Focus();
                    return;
                }
                if (LvwVenda.Items.Count == 0)
                {
                    PreencherListView();
                }
                else
                {
                    ListViewItem item1 = LvwVenda.FindItemWithText(LblNumCodigo.Text, false, 0, true);
                    if (item1 != null)
                    {
                        item1.Selected = true;
                        LvwVenda.SelectedItems[0].EnsureVisible();

                        int linha = LvwVenda.SelectedIndices[0];

                        //Altera a linha do listview
                        //Coluna quantidade
                        LvwVenda.Items[linha].SubItems[3].Text = (
                            Convert.ToDecimal(Diversos.FormataStringDecimal2(LvwVenda.Items[linha].SubItems[3].Text)) +
                            Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtQtdVendaProduto.Text.Trim()))
                            ).ToString();
                         
                        // Coluna total item (preço unitario * quantidade)
                        LvwVenda.Items[linha].SubItems[4].Text =
                            Diversos.FormataStringDecimal2
                            (
                                (
                                        
                                    Convert.ToDecimal(Diversos.FormataStringDecimal2(LvwVenda.Items[linha].SubItems[2].Text)) *
                                    Convert.ToDecimal(Diversos.FormataStringDecimal2(LvwVenda.Items[linha].SubItems[3].Text))
                                ).ToString()
                            );
                        // METOTO DE ATUALIZACAO DO PROCESSO
                        Refresh();
                    }
                    else
                    {
                        PreencherListView();
                    }
                }
                TxtQtdVendaProduto.Text = string.Empty;
                TxtSubTotal.Text = Diversos.FormataStringDecimal2(itemVendaModel.SomarSubTotalItens(LvwVenda, 4));
                RefreshTotal();
                TxtNomeProduto.Text = TxtPrecoProduto.Text = TxtQtdEstoque.Text = TxtQtdMinEstoque.Text = TxtSituacao.Text = TxtPesquisar.Text = string.Empty;
                DtgProduto.Focus();
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message, "20210102-01", "e");
            }
        }




        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cofirma a exclusão do produto selecionado?", "Confirmação remoção do item",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (linhaSelecionadaListView >= 0)
                {
                    ConfigurarListView.RemoverLinhaCheckBox(LvwVenda);
                    RefreshTotal();
                }
            }
        }


        #endregion Button

        #region ComboBox

        private void CboCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DtgProduto.Focus();
            }
        }

        private void CboCliente_Enter(object sender, EventArgs e)
        {
            this.CboCliente.MaxDropDownItems = 6;
        }

        #endregion ComboBox

        #region TextBox

        private void TxtNumFatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CboCliente.Focus();
            }
        }

        private void TxtQtdVendaProduto_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtQtdVendaProduto_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtQtdVendaProduto_TextChanged(object sender, EventArgs e)
        {
            if (!ValidarSaida())
            {
                TxtQtdVendaProduto.Focus();
                Diversos.ControlBackColorGot(sender);
            }
        }

        private void TxtQtdVendaProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnAdicionarLista.Focus();
            }
            else
            {
                Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtImpostos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDesconto.Focus();
            }
            else
            {
                Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtImpostos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ValidarTeclaPressionada(sender);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "Teste", "e");
            }
        }

        private void TxtImpostos_Leave(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Trim().Length == 0 ? "0.00" : Diversos.FormataStringDecimal2(((TextBox)sender).Text);
                Diversos.ControlBackColorLost(sender);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message + "\n\rStackTrace: " + ex.StackTrace, "20210102-06", "E"); ;
                throw;
            }
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgProduto.DataSource != null)
            {
                NtVendaController ntVendaController = new NtVendaController();
                if (RdbProduto.Checked == true)
                    ntVendaController.PesquisarProduto(DtgProduto, TxtPesquisar.Text.Trim());
                else if (RdbCodBarra.Checked == true)
                {
                    ntVendaController.PesquisarCodigoBarra(DtgProduto, TxtPesquisar.Text.Trim());
                }
                AtribuirValoresDaLinhaDoDataGridView();

                TotalRegistroNoDataGridView(DtgProduto, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-09", "x");
            }
        }

        private void TxtImpostos_Enter(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
            if (txt.Text.Trim() == "0.00")
            {
                txt.Text = string.Empty;
            }
        }

        private void TxtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtDinheiro.Focus();
            }
            else
            {
                Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtDesconto_TextChanged(object sender, EventArgs e)
        {
            ValidarTeclaPressionada(sender);
        }

        private void TxtDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                ((TextBox)sender).Text = ((TextBox)sender).Text.Trim().Length == 0 ? "0.00" : Diversos.FormataStringDecimal2(((TextBox)sender).Text);
                Diversos.ControlBackColorLost(sender);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message + "\n\rStackTrace: " + ex.StackTrace, "20210102-06", "E");
                throw;
            }
        }

        private void TxtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSalvar.Focus();
            }
            else
            {
                Diversos.PermiteSoNumeros(sender, e);
            }
        }

        private void TxtTroco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Diversos.PermiteSoNumeros(sender, e);
        }

        private void TxtDinheiro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TxtTroco.Text = Diversos.FormataStringDecimal2(CalcularTroco(TxtTotal.Text, TxtDinheiro.Text).ToString());
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "20201227-01", "e");
            }
        }

        private void TxtDinheiro_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim().Length == 0 ? "0.00" : Diversos.FormataStringDecimal2(((TextBox)sender).Text);
            Diversos.ControlBackColorLost(sender);
        }

        #endregion TextBox

        #region Timer

        // Atualiza a hora

        private void timer_Tick(object sender, EventArgs e)
        {
        }
        #endregion Timer

        #region RadioButton

        private void RdbProduto_Click(object sender, EventArgs e)
        {
            TxtPesquisar.Focus();
        }

        #endregion RadioButton

        #region DataGridView

        private void DtgProduto_Enter(object sender, EventArgs e)
        {
            DtgProduto.CurrentCell = DtgProduto.Rows[0].Cells[DtgProduto.CurrentCellAddress.X];
            DtgProduto.Rows[RecuperarLinhaSelecionadaDataGridView()].Selected = true;
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                int linhaAtual = RecuperarLinhaSelecionadaDataGridView();
                if (linhaAtual == 0)
                {
                    DtgProduto.Rows[linhaAtual].Selected = true;
                }
                else
                {
                    DtgProduto.CurrentCell = DtgProduto.Rows[linhaAtual - 1].Cells[DtgProduto.CurrentCellAddress.X];
                }
                TxtQtdVendaProduto.Focus();
            }
        }

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

        #region ListView

        private void LvwVenda_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            linhaSelecionadaListView = e.ItemIndex;
        }

        #endregion ListView

        #endregion Eventos

        #region Métodos
        // =======================
        private void ExibirCupom(string numeroFatura)
        {
            /*
              MessageBox.Show(numeroFatura);
             //WFRelCupomFiscal frm = new WFRelCupomFiscal(numeroFatura);
             frm.ShowDialog();
             frm.Dispose();
             MessageBox.Show(numeroFatura);
            */
        }

        private void ValidarTeclaPressionada(object sender)
        {
            TextBox txt = (TextBox)sender;
            if (isDecimal(txt))
            {
                RefreshTotal();
            }
            else
            {
                txt.Text = "0.00";
            }
        }

        private bool ValidarPagamento()
        {
            bool bolRet = true;
            try
            {
                if (Convert.ToDecimal(TxtDinheiro.Text.Trim()) - Convert.ToDecimal(TxtTotal.Text.Trim()) >= 0)
                {
                    if (CalcularTroco(TxtTotal.Text.Trim(), TxtDinheiro.Text.Trim()) < 0)
                    {
                        bolRet = false;
                    }
                }
                else
                {
                    bolRet = false;
                }
                if (!bolRet)
                {
                    MGMensagemErro.MensagensErro("Valor do pagamento (AOA " + TxtDinheiro.Text + " ) menor que o valor total da venda (R$ " +
                       TxtTotal.Text + ")!\n\rInforme ao cliente.", "20210102-02", "i");
                    TxtDinheiro.Focus();
                    TxtDinheiro.SelectAll();
                }
                return bolRet;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                if (enuAcao == OPERACAO.STANDBY)
                {
                    MGMensagemErro.MensagensErro("Selecione a opção Faturamento do menu.", "20201224-01", "a");
                    return false;
                }

                if (CboCliente.SelectedIndex == -1)
                {
                    MGMensagemErro.MensagensErro("Não foi selecionado um cliente para este faturamento. Verifique e tente novamente.", "20210122-02", "a");
                    CboCliente.Focus();
                    return false;
                }

                if (LvwVenda.Items.Count == 0)
                {
                    MGMensagemErro.MensagensErro("Não foi adicionado nenhum produto na lista.", "20201224-03", "a");
                    BtnAdicionarLista.Focus();
                    return false;
                }

                if (!ValidarPagamento())
                {
                    TxtDinheiro.Focus();
                    return false;
                }
                if (LblNumCodigo.Text.Trim().Length <= 0)
                {
                    MGMensagemErro.MensagensErro("Não foi selecionado um produto para informar a venda.", "20201224-05", "a");
                    return false;
                }
                if (!ValidarSaida())
                {
                    TxtQtdVendaProduto.Focus();
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "20201227-03", "e");
            }
            return true;
        }

        private bool ValidarSaida()
        {
            try
            {
                if (!string.IsNullOrEmpty(TxtQtdEstoque.Text.Trim()) && !string.IsNullOrEmpty(TxtQtdVendaProduto.Text.Trim()))
                {
                    BtnAdicionarLista.Enabled = false;

                    // calcula a diferença entre a quantidade em estoque com a quantidade pedida na venda.
                    var resultado = Convert.ToDecimal(TxtQtdEstoque.Text.Trim()) - Convert.ToDecimal(TxtQtdVendaProduto.Text.Trim());

                    if (resultado < 0)
                    {
                        MGMensagemErro.MensagensErro("A T E N Ç Ã O:\nO valor da quantidade pedida excede a quantidade em estoque!\n\rVerifique e tente novamente.", "20201223-01", "a");
                        TxtQtdVendaProduto.Focus();
                        return false;
                    }
                    else if (resultado == Convert.ToDecimal(TxtQtdMinEstoque.Text))
                    {
                        if (MessageBox.Show("A T E N Ç Ã O:\nA quantidade de venda digitada ( " + TxtQtdVendaProduto.Text.Trim() + " ) deixa " +
                            "o estoque mínimo ( " + TxtQtdMinEstoque.Text + " ) no limite!\n\rDeseja continuar com a operação?", "Confirmação",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            BtnAdicionarLista.Enabled = true;
                            return true;
                        }
                        else
                        {
                            TxtQtdVendaProduto.Focus();
                            return false;
                        }
                    }
                    else if (resultado < Convert.ToDecimal(TxtQtdMinEstoque.Text))
                    {
                        if (MessageBox.Show("A T E N Ç Ã O:\nA quantidade pedida de venda ( " + TxtQtdVendaProduto.Text.Trim() + " ) ultrapassa o valor " +
                            "do estoque mínimo ( " + TxtQtdMinEstoque.Text + " )!\n\r Deseja continuar com a operação?", "Confirmação",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            BtnAdicionarLista.Enabled = true;
                            return true;
                        }
                        else
                        {
                            TxtQtdVendaProduto.Focus();
                            return false;
                        }
                    }
                    BtnAdicionarLista.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return true;
        }

        private void CarregarCboCliente()
        {
            Cursor.Current = Cursors.WaitCursor;
            ClienteController clienteController = new ClienteController();
            CboCliente.DataSource = clienteController.ObterRegistrosCliente();
            CboCliente.DisplayMember = "NomeCli";
            CboCliente.ValueMember = "IdCliente";
            CboCliente.SelectedIndex = -1;
            Cursor.Current = Cursors.Default;
        }

        private ArrayList NomeColunasListView()
        {
            ArrayList arrCabec = new ArrayList();
            arrCabec.Add(colwidth[0] + "-Cód. Produto");
            arrCabec.Add(colwidth[1] + "-Produto");
            arrCabec.Add(colwidth[2] + "-Preço Produto");
            arrCabec.Add(colwidth[3] + "-Qtd. Venda");
            arrCabec.Add(colwidth[4] + "-Valor Total");
            return arrCabec;
        }



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
                ConfigurarListView.ConfigListView(LvwVenda, NomeColunasListView(), Color.LightYellow, true);
                CarregarCboCliente();
            }
            HabilitarBotoes(true);
            LimparCampos();
            LimparCamposPedido();
            HabilitarCampos(false);
            RdbProduto.Checked = true;
        }




        private void HabilitarBotoes(Boolean bolHabil)
        {
            BtnFaturamento.Enabled = bolHabil;
        }

        private void HabilitarCampos(Boolean bolHabil)
        {
            TxtNumFatura.Enabled = TxtQtdVendaProduto.Enabled = bolHabil;
            TxtNumFatura.ReadOnly = true;
            CboCliente.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            try
            {
                TxtNumFatura.Text = LblNumCodigo.Text = LblValorCodBarra.Text = TxtNomeProduto.Text = TxtPrecoProduto.Text = string.Empty;
                TxtQtdEstoque.Text = TxtQtdMinEstoque.Text = TxtSituacao.Text = TxtQtdVendaProduto.Text = string.Empty;
                TxtPesquisar.Text = string.Empty;

                TxtSubTotal.Text = TxtImpostos.Text = TxtDesconto.Text = TxtTotal.Text = "0.00";
                TxtSubTotal.Text = TxtDinheiro.Text = TxtTroco.Text = "0.00";
                TxtResultadoImposto.Text = TxtResultadoDesconto.Text = "0.00";

                RdbCodBarra.Checked = RdbProduto.Checked = false;

                CboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "20201227-02", "e");
            }
        }

        private void LimparCamposPedido()
        {
            LblNumCodigo.Text = LblValorCodBarra.Text = TxtNomeProduto.Text = TxtPrecoProduto.Text = string.Empty;
            TxtQtdEstoque.Text = TxtQtdMinEstoque.Text = TxtSituacao.Text = TxtQtdVendaProduto.Text = string.Empty;
            TxtPesquisar.Text = string.Empty;

            TxtSubTotal.Text = TxtImpostos.Text = TxtDesconto.Text = TxtTotal.Text = "0.00";
            TxtSubTotal.Text = TxtDinheiro.Text = TxtTroco.Text = "0.00";
            TxtResultadoImposto.Text = TxtResultadoDesconto.Text = "0.00";

            RdbCodBarra.Checked = false; RdbProduto.Checked = true;
        }

        private void RefreshDataGrid(DataGridView dtg, bool bolRefresh)
        {
            if (bolRefresh) { PreencherDataGridView(dtg); }
        }

        /// <summary>
        /// Popula o datagridview com registros do banco de dados.
        /// </summary>
        /// <param name="Dtg"></param>
        /// 
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
            // vamos obter a linha da célula selecionada
            int index = RecuperarLinhaSelecionadaDataGridView();
            if (index >= 0)
            {
                // configurando valor da primeira coluna, índice 0
                LblNumCodigo.Text = DtgProduto.Rows[index].Cells[0].Value.ToString();
                TxtNomeProduto.Text = DtgProduto.Rows[index].Cells[1].Value.ToString();
                TxtPrecoProduto.Text = DtgProduto.Rows[index].Cells[2].Value.ToString();
                TxtQtdEstoque.Text = Convert.ToInt32(DtgProduto.Rows[index].Cells[3].Value).ToString();
                TxtQtdMinEstoque.Text = Convert.ToInt32(DtgProduto.Rows[index].Cells[4].Value).ToString();
                TxtSituacao.Text = DtgProduto.Rows[index].Cells[5].Value.ToString();
                LblValorCodBarra.Text = DtgProduto.Rows[index].Cells[7].Value.ToString();
            }
        }

        
        private void PreencherListView()
        {
            string[] mItens = new string[]
            {
                LblNumCodigo.Text,
                TxtNomeProduto.Text,
                Diversos.FormataStringDecimal2 (TxtPrecoProduto.Text),
                Diversos.FormataStringDecimal2 (TxtQtdVendaProduto.Text.Trim()),
                CalcularValorTotalItem()
            };

            ListViewItem lst = new ListViewItem(mItens);
            LvwVenda.Items.Add(lst);
        }

        #region Cálculo dos campos do Resumo

        private bool isDecimal(TextBox txt)
        {
            string Str = txt.Text.Trim();
            decimal Num;
            bool isNum = decimal.TryParse(Str, out Num);
            if (isNum)
                return true;
            else
                return false;
        }

        private void RefreshTotal()
        {
            try
            {
                if (LvwVenda.Items.Count > 0)
                {
                    itemVendaModel = new ItemVendaModel();
                    TxtSubTotal.Text = itemVendaModel.SomarSubTotalItens(LvwVenda, 4);
                    TxtResultadoImposto.Text = Diversos.FormataStringDecimal2(ObterImposto());
                    TxtResultadoDesconto.Text = Diversos.FormataStringDecimal2(ObterDesconto());
                    TxtTotal.Text =
                        (
                            (
                                Convert.ToDecimal(Diversos.FormataStringDecimal2(itemVendaModel.SomarSubTotalItens(LvwVenda, 4))) +
                                Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtResultadoImposto.Text))
                            ) - Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtResultadoDesconto.Text))
                        ).ToString();
                }
                else
                {
                    LimparCampos();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string ObterImposto()
        {
            decimal subtotal = Convert.ToDecimal(TxtSubTotal.Text);
            TxtImpostos.Text = TxtImpostos.Text.Trim().Length == 0 ? "0.00" : TxtImpostos.Text;
            decimal imposto = Convert.ToDecimal(TxtImpostos.Text);
            decimal resultado = 0;
            try
            {
                if (!string.IsNullOrEmpty(TxtSubTotal.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(TxtImpostos.Text))
                    {
                        resultado = (subtotal * (imposto / 100));
                    }
                }
                else
                {
                    resultado = Convert.ToDecimal(TxtResultadoImposto.Text);
                    resultado = subtotal - resultado;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado.ToString();
        }

        private string ObterDesconto()
        {
            string resultadoDesconto = "0";
            if (!string.IsNullOrEmpty(TxtTotal.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(TxtDesconto.Text.Trim()))
                {
                    decimal total = Convert.ToDecimal(TxtTotal.Text);
                    NtVendaModel ntVendaModel = new NtVendaModel();
                    ntVendaModel.Descontovenda = Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtDesconto.Text.Trim()));
                    ntVendaModel.ValorliqVenda = Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtTotal.Text.Trim()));
                    resultadoDesconto = ntVendaModel.CalcularDesconto();
                }
                else
                {
                    TxtTotal.Text = Diversos.FormataStringDecimal2
                        (
                            (
                                Convert.ToDecimal(TxtTotal.Text) + Convert.ToDecimal(TxtResultadoDesconto.Text)
                            ).ToString()
                        );
                }
            }
            return resultadoDesconto;
        }

        private string CalcularValorTotalItem()
        {
            try
            {
                return Diversos.FormataStringDecimal2((Convert.ToDecimal(TxtPrecoProduto.Text) * Convert.ToDecimal(TxtQtdVendaProduto.Text.Trim())).ToString("N"));
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnConsultarFatura_Click(object sender, EventArgs e)
        {
            WFConsultaNtVendaView frm = new WFConsultaNtVendaView();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void BtnLocalizarCliente_Click(object sender, EventArgs e)
        {
            WFClienteView frm = new WFClienteView();
            frm.ShowDialog();
            frm.Dispose();
            CarregarCboCliente();
        }



        private void BtnLocalizarCliente_Click_1(object sender, EventArgs e)
        {
            WFClienteView frm = new WFClienteView();
            frm.ShowDialog();
            frm.Dispose();
            CarregarCboCliente();
        }

        private void BtnAtulizarCboCliente_Click(object sender, EventArgs e)
        {
            CarregarCboCliente();
        }

        private void BtnLocalizarCliente_MouseHover(object sender, EventArgs e)
        {
            BtnLocalizarCliente.BackColor = Color.Gray;
            BtnLocalizarCliente.ForeColor = Color.White;
        }

        private void BtnAtulizarCboCliente_MouseHover(object sender, EventArgs e)
        {
            BtnAtulizarCboCliente.BackColor = Color.Gray;
            BtnAtulizarCboCliente.ForeColor = Color.White;
        }

        private void BtnLocalizarCliente_MouseLeave(object sender, EventArgs e)
        {
            BtnLocalizarCliente.BackColor = Color.White;
            BtnLocalizarCliente.ForeColor = Color.DimGray;
        }

        private void BtnAtulizarCboCliente_MouseLeave(object sender, EventArgs e)
        {
            BtnAtulizarCboCliente.BackColor = Color.White;
            BtnAtulizarCboCliente.ForeColor = Color.DimGray;
        }

        private decimal CalcularTroco(string valorVenda, string valorPago)
        {
            decimal troco = 0;
            decimal valVenda = Convert.ToDecimal(valorVenda.Trim());
            decimal valPago = Convert.ToDecimal(valorPago.Trim());
            try
            {
                if (valorPago.Trim().Length != 0 && valorVenda.Trim().Length != 0)
                {
                    //Troco = Dinheiro - Total
                    troco = valPago - valVenda;
                }
                return troco;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Cálculo dos campos do Resumo



        

        private void horaAtual()
        {
            timer1 = new Timer();
            timer1.Interval = 1000; // Intervalo de 1000 ms (1 segundo)
            timer1.Tick += AtualizarHora;
            timer1.Start();
        }

         

        private void BtnFaturaPDF_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //this.Dispose();
            WFRelatorioComPesquisa view = new WFRelatorioComPesquisa();
            ArredondaBordas(view, 15);
            view.ShowDialog();
            view.Dispose();
        }

        private void AtualizarHora(object sender, EventArgs e)
        {
            DateTime horaAtual = DateTime.Now;
            LblHoraVenda.Text = ("Hora atual: " + horaAtual.ToString("HH:mm:ss"));
        }



        #endregion Métodos

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




    }
}

