using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Relatorios;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;
namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFMateriaAluguerView : Form
    {

        #region     Variáveis
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int RightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);


        // Configurando o datagridview
        List<string> ListaColunaVisivel = new List<string>() {"MaterialId", "Nome", "Cor", "Modelo", "Descrição", "QtdTotal", "QtdDisponivel"};
        List<string> ListaCabecalho = new List<string>() {"Código", "Material", "Cor", "Modelo", "Descrição", "Total", "Disponível"};
        List<int> ListaLarguraColuna = new List<int>() { 15, 20, 15, 15, 15, 15 };

        private enum OPERACAO { ALTERAR, STANDBY }
        private OPERACAO enuAcao;
        /// <summary>
        /// /{ "Código", "Material", "Cor", "Modelo.", "Descrição.", "QtdTotal", "QtdDisponivel", "PrecoAluguel" };
        /// </summary>
        // Configurando o ListView
        int[] colwidth = { 70, 240, 80, 80, 90 };   // colwidth[] é um array que define a largura das colunas do listview de exibição.
        int linhaSelecionadaListView = 0;           // recupera o índice da linha selecionada no ListView

        AluguerModel aluguerModel = null;
        ItemAluguerModel itemAluguerModel = null;
        AgendamentoModel    agendamentoModel = null;
        ItemAgendamentoModel itemAgendamentoModel = null;

        // Converte o subtotal para decimal
        private decimal porcento = 0.25m; // Porcentagem de 25% representada como decimal
        private decimal caucao;
        private decimal total = 0m;
        private decimal fretePreco;

        // Variáveis de controle do construtor
        int idFuncionario, idTipoUsuario = 0;
        string nomeUsuario = string.Empty;
        string login = string.Empty;
        string siglaTipoUsuario = string.Empty;
        string nomeFunc = string.Empty;
        string frete;
        #endregion Variáveis



        #region Construtor
        public WFMateriaAluguerView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
            aluguerModel = new AluguerModel();
            itemAluguerModel = new ItemAluguerModel();
            agendamentoModel = new AgendamentoModel();
            itemAgendamentoModel = new ItemAgendamentoModel();
           // ConfigurarTimer();

        }

        public WFMateriaAluguerView(int IdTipoUsuario, string login, string siglaTipoUsuario, string nomeFunc, int IdFuncionario)
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
            LblDataVenda.Text = "Data Aluguer: " + DateTime.Now.ToShortDateString();
            horaAtual();
            // itemVendaModel = new ItemVendaModel();
            this.idFuncionario = IdFuncionario;
            this.idTipoUsuario = IdTipoUsuario;
            this.login = login;
            this.siglaTipoUsuario = siglaTipoUsuario;
            this.nomeFunc = nomeFunc;
            aluguerModel = new AluguerModel();
            itemAluguerModel = new ItemAluguerModel();
            agendamentoModel = new AgendamentoModel();
            itemAgendamentoModel = new ItemAgendamentoModel();
            //ConfigurarTimer();
        }
        private void WFMateriaAluguerView_Load(object sender, System.EventArgs e)
        {
            TelaInicial(true);
            //Configuração da fonte para o cabeçalho
            DtgMaterias.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            //Configuração da fonte para as células
            DtgMaterias.DefaultCellStyle.Font = new Font("Arial", 12);
          //loadtheme();
            horaAtual();
            AtualizarFrete();
        }
        #endregion Construtor



        #region    Form

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


        private void ConfigurarTimer()
        {
            // Cria uma instância do Timer
            timer1 = new Timer();

            // Define o intervalo para 2000 milissegundos (2 segundos)
            timer1.Interval = 2000;

            // Associa o evento Tick ao método que atualiza o total
            timer1.Tick += Timer_Tick;

            // Inicia o timer
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Chama o método para atualizar o total
            RefreshTotal();
        }
        private void TxtDesconto_TextChanged(object sender, EventArgs e)
        {
            ValidarTeclaPressionada(sender);
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

        private void RdbMaterial_Click(object sender, EventArgs e)
        {
            TxtPesquisar.Focus();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TxtQtdAluguerMaterial_TextChanged(object sender, EventArgs e)
        {
            if (!ValidarSaida())
            {
                TxtQtdDisponivel.Focus();
                Diversos.ControlBackColorGot(sender);
            }
        }


        private void TxtDiasUteis_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtPesquisar_TextChanged_1(object sender, EventArgs e)
        {
            if (DtgMaterias.DataSource != null)
            {
                MaterialController materialController = new MaterialController();
                if (RdbMaterial.Checked == true)
                    materialController.PesquisarMaterial(DtgMaterias, TxtPesquisar.Text.Trim());
                else if (RdbCodBarra.Checked == true)
                {
                    materialController.PesquisarCodigoBarra(DtgMaterias, TxtPesquisar.Text.Trim());
                }
                AtribuirValoresDaLinhaDoDataGridView();

                TotalRegistroNoDataGridView(DtgMaterias, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "202000911-09", "x");
            }
        }
        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }
        private void TxtQtdVendaMaterial_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }
        private void TxtQtdVendaMaterial_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtQtdVendaMaterial_KeyPress(object sender, KeyPressEventArgs e)
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

        private void LvwVenda_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            linhaSelecionadaListView = e.ItemIndex;
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

        private void TxtDinheiro_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Trim().Length == 0 ? "0.00" : Diversos.FormataStringDecimal2(((TextBox)sender).Text);
            Diversos.ControlBackColorLost(sender);
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
            ValidarTeclaPressionada(sender);
        }
        #endregion Form




        #region    Button
        private void BtnLocalizarCliente_Click(object sender, EventArgs e)
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
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
        }

        private void BtnAdicionarLista_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(TxtQtdAluguerMaterial.Text.Trim()))
                {
                    MGMensagemErro.MensagensErro("Informe a quantidade de aluguer do material.", "20201229-01", "a");
                    TxtQtdAluguerMaterial.Focus();
                    return;
                }
                if (LvwAluguer.Items.Count == 0)
                {
                    PreencherListView();
                }
                else
                {

                    ListViewItem item1 = LvwAluguer.FindItemWithText(TxtCodigo.Text, false, 0, true);
                    if (item1 != null)
                    {
                        item1.Selected = true;
                        LvwAluguer.SelectedItems[0].EnsureVisible();

                        int linha = LvwAluguer.SelectedIndices[0];

                        //Altera a linha do listview
                        //Coluna quantidade
                        LvwAluguer.Items[linha].SubItems[3].Text = (
                            Convert.ToDecimal(Diversos.FormataStringDecimal2(LvwAluguer.Items[linha].SubItems[3].Text)) +
                            Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtQtdAluguerMaterial.Text.Trim()))
                            ).ToString();

                        // Coluna total item (preço unitario * quantidade)
                        LvwAluguer.Items[linha].SubItems[4].Text =
                            Diversos.FormataStringDecimal2
                            (
                                (

                                    Convert.ToDecimal(Diversos.FormataStringDecimal2(LvwAluguer.Items[linha].SubItems[2].Text)) *
                                    Convert.ToDecimal(Diversos.FormataStringDecimal2(LvwAluguer.Items[linha].SubItems[3].Text))
                                ).ToString()
                            );
                        //METOTO DE ATUALIZACAO DO PROCESSO
                        Refresh();
                    }
                    else
                    {
                        PreencherListView();
                    }
                }
                // TxtQtdAluguerMaterial.Text = string.Empty;
                TxtSubTotal.Text = Diversos.FormataStringDecimal2(itemAluguerModel.SomarSubTotalItens(LvwAluguer, 4));
                RefreshTotal();
                TxtNomeMaterial.Text = TxtPrecoMaterial.Text = TxtQtdTotal.Text = TxtQtdDisponivel.Text = TxtPesquisar.Text = string.Empty;
                DtgMaterias.Focus();
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message, "20210102-01 ACHEI O ERRO LINHA 637", "e");
                //Erro: Referência de objecto não definida para instância de um objecto;
            }
        }





        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cofirma a exclusão do produto selecionado?", "Confirmação remoção do item",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (linhaSelecionadaListView >= 0)
                {
                    ConfigurarListView.RemoverLinhaCheckBox(LvwAluguer);
                    RefreshTotal();
                }
            }
        }


        private void BtnAlugar_Click(object sender, System.EventArgs e)
        {
            enuAcao = OPERACAO.ALTERAR;
            AluguerController aluguerController = new AluguerController();
            TxtNumFatura.Text = aluguerController.GerarNumeroFatura();
            HabilitarCampos(true);
            HabilitarBotoes(false);
            CboCliente.Focus();
        }

 

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if ((DateTimePickerInicio.Value.Date == DateTime.Now.Date) || (DateTimePickerInicio.Value.Date >= DateTime.Now.Date))
            {
                if (MessageBox.Show("Confirma o SubTotal do produto que está sendo vendido? Reveja!!!", "Confirmação remoção do item",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!ValidarCampos())
                    {
                        MGMensagemErro.MensagensErro("Por favor, preencha todos os campos obrigatórios.", "20201224-01", "e");
                        return;
                    }
                    try
                    {
                        // Criação e atribuição de valores ao objeto AluguerModel
                        AluguerModel aluguerModel = new AluguerModel
                        {
                            NumeroFatura = TxtNumFatura.Text.Trim(),
                            Frete = this.frete,
                            Clausula = RTxtClausulas.Text,
                            ValorliqVenda = Convert.ToDecimal(TxtTotal.Text), // Valor líquido da venda
                            Imposto = Convert.ToDecimal(TxtImpostos.Text), // Valor do imposto
                            ValorBrutoAluguer = Convert.ToDecimal(TxtSubTotal.Text), // Valor bruto do aluguel
                            Desconto = Convert.ToDecimal(TxtDesconto.Text), // Valor do desconto
                            Caucao = this.caucao, // Valor da caução
                            FretePreco = Convert.ToDecimal(TxtFretePreco.Text), // Preço do frete
                            SituacaoModel = new SituacaoModel { IdSituacao = 1 }, // ID da situação
                            FuncionarioModel = new FuncionarioModel { IdFuncionario = this.idFuncionario }, // ID do funcionário
                            Dias = Convert.ToInt32(TxtDiasUteis.Text), // Número de dias úteis
                            ClienteModel = new ClienteModel { Idcliente = Convert.ToInt32(CboCliente.SelectedValue) }, // ID do cliente
                            DataInicio = Convert.ToDateTime(DateTimePickerInicio.Value), // Data de início do aluguel
                            DataFim = Convert.ToDateTime(DateTimePickerInicio.Value).AddDays(Convert.ToInt32(TxtDiasUteis.Text)), // Data de fim do aluguel
                            Dtpagamento = Convert.ToDateTime(DateTimePickerPagamento.Value), // Data de pagamento
                            DataCadAluguer = DateTime.Now // Data de cadastro do aluguel
                        };
                        // Preenche a lista de itens do aluguel
                        itemAluguerModel.ListaItensAluguerModel.Clear();
                        for (int i = 0; i < LvwAluguer.Items.Count; i++)
                        {
                            ItemAluguerModel objAluguer = new ItemAluguerModel
                            {
                                MaterialModel = new MaterialModel { IdMaterial = Convert.ToInt32(LvwAluguer.Items[i].SubItems[0].Text) },
                                ValorUnit = Convert.ToDecimal(LvwAluguer.Items[i].SubItems[2].Text) * Convert.ToDecimal(LvwAluguer.Items[i].SubItems[3].Text),
                                QuantidadeItemAluguer = Convert.ToDecimal(LvwAluguer.Items[i].SubItems[3].Text)
                            };
                            itemAluguerModel.ListaItensAluguerModel.Add(objAluguer);
                        }
                        // Salva o aluguel
                        AluguerController aluguerController = new AluguerController();
                        if (aluguerController.IncluirAluguerController(aluguerModel, itemAluguerModel) != 0)
                        {
                            TelaInicial(true);
                            MGMensagemErro.MensagensErro("Atualização efetuada com sucesso!", "20201224-06", "X");
                        }
                        else
                        {
                            MGMensagemErro.MensagensErro("Atualização NÃO foi efetuada.\n\n Verifique e tente novamente.", "20201224-07", "e");
                        }
                    }
                    catch (Exception ex)
                    {
                        MGMensagemErro.MensagensErro($"Ocorreu um erro: {ex.Message}", "20201224-08", "e");
                    }
                }
            }
            else if ((DateTimePickerInicio.Value.Date >= DateTime.Now.Date))
            {
                if (MessageBox.Show("Confirma o SubTotal do produto que está sendo vendido? Reveja!!!", "Confirmação remoção do item",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!ValidarCampos())
                    {
                        MGMensagemErro.MensagensErro("Por favor, preencha todos os campos obrigatórios.", "20201224-01", "e");
                        return;
                    }
                    try
                    {
                        // Criação e atribuição de valores ao objeto AgendamentoModel
                        AgendamentoModel agendamentoModel = new AgendamentoModel
                        {
                            NumeroFatura = TxtNumFatura.Text.Trim(),
                            Frete = this.frete,
                            Clausulas = RTxtClausulas.Text,
                            ValorLiquido = Convert.ToDecimal(TxtTotal.Text),
                            Imposto = Convert.ToDecimal(TxtImpostos.Text),
                            ValorBruto = Convert.ToDecimal(TxtSubTotal.Text),
                            Desconto = Convert.ToDecimal(TxtDesconto.Text),
                            Caucao = this.caucao,
                            FretePreco = Convert.ToDecimal(TxtFretePreco.Text),
                            SituacaoModel = new SituacaoModel { IdSituacao = 1 },
                            FuncionarioModel = new FuncionarioModel { IdFuncionario = this.idFuncionario },
                            Dias = Convert.ToInt32(TxtDiasUteis.Text),
                            ClienteModel = new ClienteModel { Idcliente = Convert.ToInt32(CboCliente.SelectedValue) },
                            DataInicio = Convert.ToDateTime(DateTimePickerInicio.Value),
                            DataFim = Convert.ToDateTime(DateTimePickerInicio.Value).AddDays(Convert.ToInt32(TxtDiasUteis.Text)),
                            DataPagamento = Convert.ToDateTime(DateTimePickerPagamento.Value),
                            DataCadAgendamento = DateTime.Now
                        };
                        // Preenche a lista de itens do agendamento
                        itemAgendamentoModel.ListaItensAgendamentoModel.Clear();
                        for (int i = 0; i < LvwAluguer.Items.Count; i++)
                        {
                            ItemAgendamentoModel objAgendamento = new ItemAgendamentoModel
                            {
                                MaterialModel = new MaterialModel { IdMaterial = Convert.ToInt32(LvwAluguer.Items[i].SubItems[0].Text) },
                                ValorUnit = Convert.ToDecimal(LvwAluguer.Items[i].SubItems[2].Text) * Convert.ToDecimal(LvwAluguer.Items[i].SubItems[3].Text),
                                QuantidadeItemAgendamento = Convert.ToDecimal(LvwAluguer.Items[i].SubItems[3].Text)
                            };
                            itemAgendamentoModel.ListaItensAgendamentoModel.Add(objAgendamento);
                        }

                        // Salva o agendamento
                        AgendamentoController agendamentoController = new AgendamentoController();
                        if (agendamentoController.IncluirAgendamentoController(agendamentoModel, itemAgendamentoModel) != 0)
                        {
                            TelaInicial(true);
                            MGMensagemErro.MensagensErro("Atualização efetuada com sucesso!", "20201224-06", "X");
                        }
                        else
                        {
                            MGMensagemErro.MensagensErro("Atualização NÃO foi efetuada.\n\n Verifique e tente novamente.", "20201224-07", "e");
                        }
                    }
                    catch (Exception ex)
                    {
                        MGMensagemErro.MensagensErro($"Ocorreu um erro: {ex.Message}", "20201224-08", "e");
                    }
                }
            }
            else {

                MGMensagemErro.MensagensErro("A data não deve ser menor que a data actual!", "20201224-06", "X");
                DateTimePickerInicio.Focus();
                return;
            }
        }
        #endregion Button




        #region    DataGridView
        private void DtgMaterias_Enter(object sender, EventArgs e)
        {
            DtgMaterias.CurrentCell = DtgMaterias.Rows[0].Cells[DtgMaterias.CurrentCellAddress.X];
            DtgMaterias.Rows[RecuperarLinhaSelecionadaDataGridView()].Selected = true;
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgMaterias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                int linhaAtual = RecuperarLinhaSelecionadaDataGridView();
                if (linhaAtual == 0)
                {
                    DtgMaterias.Rows[linhaAtual].Selected = true;
                }
                else
                {
                    DtgMaterias.CurrentCell = DtgMaterias.Rows[linhaAtual - 1].Cells[DtgMaterias.CurrentCellAddress.X];
                }
                DtgMaterias.Focus();
            }
        }

        private void DtgMaterias_Click(object sender, EventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgMaterias_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }
        #endregion DataGridView




        #region    ComboBox  
        private void CboCliente_Enter(object sender, EventArgs e)
        {

        }

        private void CboCliente_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void CboCliente_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DtgMaterias.Focus();
            }
        }

        private void CboCliente_Enter_1(object sender, EventArgs e)
        {
            this.CboCliente.MaxDropDownItems = 6;
        }
        #endregion ComboBox




        #region ListView
        private void PreencherListView()
        {
            string[] mItens = new string[]
            {
                TxtCodigo.Text,
                TxtNomeMaterial.Text,
                Diversos.FormataStringDecimal2 (TxtPrecoMaterial.Text),
                Diversos.FormataStringDecimal2(TxtQtdAluguerMaterial.Text.Trim()),
                CalcularValorTotalItem()
            };

            ListViewItem lst = new ListViewItem(mItens);
            LvwAluguer.Items.Add(lst);
        }


        private void LvwAluguer_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            linhaSelecionadaListView = e.ItemIndex;
        }
        #endregion ListView



        #region    Métodos

        private void HabilitarBotoes(Boolean bolHabil)
        {
            BtnAlugar.Enabled = bolHabil;
        }

        private void HabilitarCampos(Boolean bolHabil)
        {
            TxtCaucao.Enabled = TxtDiasUteis.Enabled = TxtQtdAluguerMaterial.Enabled = bolHabil;
            CboCliente.Enabled = bolHabil;
        }


        private void TelaInicial(Boolean bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            if (bolIni)
            {
                RefreshDataGrid(DtgMaterias, true);
                EstilizarDataGridView.DefinirVisibilidadeDataGridView(DtgMaterias, ListaColunaVisivel);
                EstilizarDataGridView.DefinirCabecalhoDataGridView(DtgMaterias, ListaCabecalho);
                EstilizarDataGridView.DefinirLargurasDataGridView(DtgMaterias, ListaLarguraColuna);
                EstilizarDataGridView.EstiloDataGridView(DtgMaterias);
                ConfigurarListView.ConfigListView(LvwAluguer, NomeColunasListView(), Color.LightYellow, true);
                CarregarCboCliente();
            }

            HabilitarBotoes(true);
            LimparCampos();
            LimparCamposPedido();
            HabilitarCampos(false);
            RdbMaterial.Checked = true;
        }



        private void horaAtual()
        {
            timer1 = new Timer();
            timer1.Interval = 1000; // Intervalo de 1000 ms (1 segundo)
            timer1.Tick += AtualizarHora;
            timer1.Start();
        }


        private void AtualizarHora(object sender, EventArgs e)
        {
            DateTime horaAtual = DateTime.Now;
            LblHoraVenda.Text = ("Hora atual: " + horaAtual.ToString("HH:mm:ss"));
        }



        private void LimparCampos()
        {
            try
            {
               RTxtClausulas.Text =  TxtNumFatura.Text = TxtQtdAluguerMaterial.Text = TxtQtdMin.Text = TxtCodigoBarra.Text = TxtCodigo.Text = TxtNomeMaterial.Text = TxtPrecoMaterial.Text = TxtQtdTotal.Text = TxtQtdDisponivel.Text = TxtDiasUteis.Text = string.Empty;
                TxtPesquisar.Text = string.Empty;

                TxtSubTotal.Text = TxtImpostos.Text = TxtDesconto.Text = TxtTotal.Text = "0.00";
                TxtSubTotal.Text = TxtDinheiro.Text = TxtTroco.Text = "0.00";
                TxtResultadoImposto.Text = TxtResultadoDesconto.Text = "0.00";
                TxtCaucao.Text = TxtFretePreco.Text =  "0.00";

                RdbCodBarra.Checked = RdbMaterial.Checked = false;

                CboCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "20201227-02", "e");
            }
        }


        private void LimparCamposPedido()
        {
            RTxtClausulas.Text= TxtCodigo.Text  = TxtNomeMaterial.Text = TxtPrecoMaterial.Text = string.Empty;
            TxtQtdTotal.Text = TxtQtdDisponivel.Text = TxtDiasUteis.Text = string.Empty;
            TxtPesquisar.Text = string.Empty;

            TxtSubTotal.Text = TxtImpostos.Text = TxtDesconto.Text = TxtTotal.Text = "0.00";
            TxtSubTotal.Text = TxtDinheiro.Text = TxtTroco.Text = "0.00";
            TxtCaucao.Text =  TxtResultadoImposto.Text = TxtResultadoDesconto.Text = "0.00";

            RdbCodBarra.Checked = false; RdbMaterial.Checked = true;
            CboCliente.SelectedIndex = -1;
        }


        private void PreencherDataGridView(DataGridView Dtg)
        {
            MaterialController materialController = new MaterialController();
            try
            {
                DtgMaterias.DataSource = null;
                DtgMaterias.Rows.Clear();
                DtgMaterias.DataSource = materialController.ObterRegistrosMaterial();
                TotalRegistroNoDataGridView(DtgMaterias, LblTotalRegistros);
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

        private void RefreshDataGrid(DataGridView dtg, bool bolRefresh)
        {
            if (bolRefresh) { PreencherDataGridView(dtg); }
        }

        private ArrayList NomeColunasListView()
        {
            ArrayList arrCabec = new ArrayList();
            arrCabec.Add(colwidth[0] + "-Cód. Material");
            arrCabec.Add(colwidth[1] + "-Material");
            arrCabec.Add(colwidth[2] + "-Preço Material");
            arrCabec.Add(colwidth[3] + "-Qtd. Aluguer");
            arrCabec.Add(colwidth[4] + "-Valor Total");
            return arrCabec;
        }

        private void CarregarCboCliente()
        {
          //  Cursor.Current = Cursors.WaitCursor;
            ClienteController clienteController = new ClienteController();
            CboCliente.DataSource = clienteController.ObterRegistrosCliente();
            CboCliente.DisplayMember = "NomeCli";
            CboCliente.ValueMember   = "IdCliente";
            CboCliente.SelectedIndex = -1;
          //  Cursor.Current = Cursors.Default;
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




        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgMaterias.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns>Número da linha selecionada no DataGridView.</returns>
        private int RecuperarLinhaSelecionadaDataGridView()
        {
            try
            {
                DataGridViewRow linhaAtual = DtgMaterias.CurrentRow;
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


        // <summary>
        /// Atribui aos campos os valores das células da linha selecionada
        /// </summary>
        private void AtribuirValoresDaLinhaDoDataGridView()
        {
            // vamos obter a linha da célula selecionada
            int index = RecuperarLinhaSelecionadaDataGridView();
            if (index >= 0)
            {
                // configurando valor da primeira coluna, índice 0
                TxtCodigo.Text = DtgMaterias.Rows[index].Cells[0].Value.ToString();
                TxtNomeMaterial.Text = DtgMaterias.Rows[index].Cells[1].Value.ToString();
                TxtPrecoMaterial.Text = DtgMaterias.Rows[index].Cells[7].Value.ToString();
                TxtQtdTotal.Text = Convert.ToInt32(DtgMaterias.Rows[index].Cells[5].Value).ToString();
                TxtQtdDisponivel.Text = Convert.ToInt32(DtgMaterias.Rows[index].Cells[6].Value).ToString();
                //TxtSituacao.Text       = DtgMaterias.Rows[index].Cells[5].Value.ToString();
                TxtCodigoBarra.Text = DtgMaterias.Rows[index].Cells[8].Value.ToString();
                TxtQtdMin.Text = DtgMaterias.Rows[index].Cells[9].Value.ToString();
            }
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
                if (LvwAluguer.Items.Count > 0)
                {
                    itemAluguerModel = new ItemAluguerModel();

                    // Atualiza o SubTotal
                    TxtSubTotal.Text = itemAluguerModel.SomarSubTotalItens(LvwAluguer, 4);

                    // Calcula o imposto e o desconto
                    TxtResultadoImposto.Text = Diversos.FormataStringDecimal2(ObterImposto());
                    TxtResultadoDesconto.Text = Diversos.FormataStringDecimal2(ObterDesconto());

                    // Atualiza o valor da caução
                    TxtCaucao.Text = this.caucao.ToString("F2");  // Formata a caução com 2 casas decimais

                    // Calcula o total, somando SubTotal + Imposto + Caução - Desconto
                    TxtTotal.Text = (
                        (
                            Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtSubTotal.Text)) +    // SubTotal
                            Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtResultadoImposto.Text)) +   // Imposto
                            this.caucao + Convert.ToDecimal(TxtFretePreco.Text)// Caução
                        ) - Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtResultadoDesconto.Text))    // Desconto
                    ).ToString("F2");  // Formata o total com 2 casas decimais
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
                    AluguerModel aluguerModel = new AluguerModel();
                    aluguerModel.Desconto = Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtDesconto.Text.Trim()));
                    aluguerModel.ValorBrutoAluguer = Convert.ToDecimal(Diversos.FormataStringDecimal2(TxtTotal.Text.Trim()));
                    resultadoDesconto = aluguerModel.CalcularDesconto().ToString("N"); ;
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
                return Diversos.FormataStringDecimal2((Convert.ToDecimal(TxtPrecoMaterial.Text) * Convert.ToDecimal(TxtQtdAluguerMaterial.Text.Trim())).ToString("N"));
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void WFMateriaAluguerView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                BtnAlugar_Click(sender, e);
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
        #endregion Cálculo dos campos do Resumo




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

                if (LvwAluguer.Items.Count == 0)
                {
                    MGMensagemErro.MensagensErro("Não foi adicionado nenhum produto na lista.", "20201224-03", "a");
                    BtnAdicionarLista.Focus();
                    return false;
                }
                if (TxtDiasUteis.Text == string.Empty)
                {
                    MGMensagemErro.MensagensErro("O campo Dias não deve estar vazio.", "20201224-03", "a");
                    TxtDiasUteis.Focus();
                    return false;
                }


                if (!ValidarPagamento())
                {
                    TxtDinheiro.Focus();
                    return false;
                }
                if (TxtCodigo.Text.Trim().Length <= 0)
                {
                    MGMensagemErro.MensagensErro("Não foi selecionado um material para informar o aluguer.", "20201224-05", "a");
                    return false;
                }
                if (!ValidarSaida())
                {
                    TxtQtdAluguerMaterial.Focus();
                    return false;
                }

            }
            catch (Exception ex)
            {
                // Mensagem de erro genérica ao usuário
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado. Por favor, tente novamente.", "20201227-03", "e");
                // Log para fins de depuração
                Debug.WriteLine("Erro na validação de campos: " + ex.Message);
            }

            return true;
        }

        private bool ValidarSaida()
        {
            try
            {
                if (!string.IsNullOrEmpty(TxtQtdDisponivel.Text.Trim()) && !string.IsNullOrEmpty(TxtQtdAluguerMaterial.Text.Trim()))
                {
                    BtnAdicionarLista.Enabled = false;

                    // calcula a diferença entre a quantidade em disponivel com a quantidade pedida Alugar.
                    var resultado = Convert.ToDecimal(TxtQtdDisponivel.Text.Trim()) - Convert.ToDecimal(TxtQtdAluguerMaterial.Text.Trim());


                    // Valida se a quantidade pedida excede o estoque disponível
                    if (resultado < 0)
                    {
                        MGMensagemErro.MensagensErro("A quantidade pedida excede a quantidade em estoque. Verifique e tente novamente.", "20201223-01", "a");
                        TxtQtdAluguerMaterial.Focus();
                        return false;
                    }

                    // Valida se a quantidade pedida deixa o estoque no limite
                    if (resultado == Convert.ToDecimal(TxtQtdDisponivel.Text))
                    {
                        if (MessageBox.Show($"A quantidade de aluguel digitada ({TxtQtdAluguerMaterial.Text.Trim()}) deixa o estoque mínimo ({TxtQtdDisponivel.Text}) no limite. Deseja continuar com a operação?",
                            "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            BtnAdicionarLista.Enabled = true;
                            return true;
                        }
                        else
                        {
                            TxtQtdDisponivel.Focus();
                            return false;
                        }
                    }
                    // Valida se a quantidade pedida ultrapassa o estoque mínimo
                    if (resultado < Convert.ToDecimal(TxtQtdMin.Text))
                    {
                        if (MessageBox.Show($"A quantidade pedida ({TxtQtdAluguerMaterial.Text.Trim()}) ultrapassa o estoque mínimo ({TxtQtdMin.Text}). Deseja continuar com a operação?",
                            "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            BtnAdicionarLista.Enabled = true;
                            return true;
                        }
                        else
                        {
                            TxtQtdAluguerMaterial.Focus();
                            return false;
                        }
                    }

                    BtnAdicionarLista.Enabled = true;
                   
                }
            }
            catch (Exception ex)
            {
                //Exibe a mensagem de erro e relança a exceção
                MessageBox.Show(ex.Message);
                throw;
            }
            return true;
        }

        private void AtualizarFrete()
        {
            // Verifica se o valor do TxtFretePreco.Text é um número válido
            if (decimal.TryParse(TxtFretePreco.Text, out decimal fretePreco) && fretePreco != 0.00m)
            {
                // Se o preço do frete for diferente de 0.00, define Frete como "Sim"
                this.frete = "Sim";
                // Formata o valor do frete com duas casas decimais
                this.fretePreco = fretePreco;
                // Atualiza o texto do campo TxtFretePreco para garantir duas casas decimais
                TxtFretePreco.Text = fretePreco.ToString("F2");
            }
            else
            {
                // Caso contrário, define Frete como "Não"
                this.frete = "Não";
                // Define o texto do campo TxtFretePreco como "0.00"
                TxtFretePreco.Text = "0.00";
                // Define a variável fretePreco como 0.00
                this.fretePreco = 0.00m;
            }
        }


        private static void ArredondaBordas(Form form, int borderRadius)
        {
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }

        private void TxtDinheiro_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshTotal();
            TxtTroco.Text = Diversos.FormataStringDecimal2(CalcularTroco(TxtTotal.Text, TxtDinheiro.Text).ToString());
        }

        private void TxtFretePreco_TextChanged(object sender, EventArgs e)
        {
            // Verifica se o valor do TxtFretePreco.Text é um número válido
            if (decimal.TryParse(TxtFretePreco.Text, out decimal fretePreco) && fretePreco != 0.00m)
            {
                // Se o preço do frete for diferente de 0.00, define Frete como "Sim"
                this.frete = "Sim";
                // Formata o valor do frete com duas casas decimais
                this.fretePreco = fretePreco;
                // Atualiza o texto do campo TxtFretePreco para garantir duas casas decimais
                TxtFretePreco.Text = fretePreco.ToString("F2");
            }
            else
            {
                // Caso contrário, define Frete como "Não"
                this.frete = "Não";
                // Define o texto do campo TxtFretePreco como "0.00"
                TxtFretePreco.Text = "0.00";
                // Define a variável fretePreco como 0.00
                this.fretePreco = 0.00m;
            }

            try
            {
                TxtTroco.Text = Diversos.FormataStringDecimal2(CalcularTroco(TxtTotal.Text, TxtDinheiro.Text).ToString());
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: -> " + ex.Message, "20201227-01", "e");
            }
        }

        private void TxtSubTotal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(TxtSubTotal.Text, out decimal parsedTotal))
            {
                this.total = parsedTotal;
                this.caucao = Math.Round(this.porcento * this.total, 2); // Calcula e arredonda o valor da caução
                TxtCaucao.Text = this.caucao.ToString("F2"); // Exibe o valor da caução com 2 casas decimais
            }
            else
            {
                TxtCaucao.Text = "0.00"; // Se o valor for inválido, exibe 0.00 como padrão
            }
        }

        private void TxtFretePreco_KeyUp(object sender, KeyEventArgs e)
        {
            RefreshTotal();
        }

        private void TxtDinheiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            Diversos.PermiteSoNumeros(sender, e);
        }

        private void TxtDinheiro_KeyDown(object sender, KeyEventArgs e)
        {            
            TxtTroco.Text = Diversos.FormataStringDecimal2(CalcularTroco(TxtTotal.Text, TxtDinheiro.Text).ToString());
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {

  
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
            //LblNumCodigo.ForeColor = ThemeColor.PrimaryColor;
            panelBar.BackColor = ThemeColor.PrimaryColor;
        }
        #endregion ===== METODO PROVEDORES DE CORES DO FORM MAIN MENU ========


    }
}

