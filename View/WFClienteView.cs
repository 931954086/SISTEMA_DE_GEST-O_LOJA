using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFClienteView : Form
    {
        #region Variáveis

        ClienteModel clienteModel;
        ClienteController clienteController = null;
        TipoTelefoneModel tipoTelefoneModel;
        EnderecoCliModel enderecoCliModel;
        private Int32 intEnderecoID, intTelefoneID = 0;
        private Int32 indiceLvw; //recupera o índice do item selecionado no listview telefone dentro do evento ItemSelectionChanged

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao, enuTelefone;

        private enum TIPOTEL
        {
            CELULARRESIDENCIAL = 1, CELULARCOMERCIAL = 2, FIXORESIDENCIAL = 3, FIXOCOMERCIAL = 4, FAXRESIDENCIAL = 5,
            FAXCOMERCIAL = 6, FIXOEMERGENCIA = 7, CELULAREMERGENCIA = 8, NAOINFORMADO = 9
        };
        TIPOTEL enuTipoTel;

        string[] nomeColuna = {
            "Código",
            "Nome",
            "Email",
            "Id Situação",
            "Situação",
            "IdEnderecoCli",
            "LogradouroCli",
            "NumLogradouroCli",
            "ComplementoLogradouroCli",
            "CEPCli",
            "IdBairro"
        };
        // Nomes dos campos existentes na tabela
        string[] colVisivel = { "IdCliente", "NomeCli", "EmailCli", "DescSituacao" };
        int[] larguraColuna = { 40, 90, 80, 0, 40, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// colwidth[] é um array que define a largura das colunas do listview de exibição.
        /// </summary>
        int[] colwidth = { 0, 0, 210, 150, 140 };

        //{ 0, 0, 210, 70, 120 };
        #endregion Variáveis

        #region Construtor

        public WFClienteView()
        {
            clienteModel = new ClienteModel();
            tipoTelefoneModel = new TipoTelefoneModel();
            clienteController = new ClienteController();
            InitializeComponent();
            DtgCliente.CellFormatting += dataGridView1_CellFormatting;
            PadraoForm.SettingsForm(this);
        }

        #endregion Construtor

        #region Eventos

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verifica se a célula é uma célula de cabeçalho (header) ou de dados
            if (e.RowIndex == -1) // Cabeçalho
            {
                DtgCliente.Columns[e.ColumnIndex].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
            }
            else if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Dados
            {
                e.CellStyle.Font = new Font("Arial", 12);
            }
        }


        #region Form

        private void WFClienteView_KeyDown(object sender, KeyEventArgs e)
        {
            // não se esqueça de definir KeyPreview = true para o
            // formulário

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

        private void WFClienteView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgCliente.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgCliente.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }

        #endregion Form

        #region MaskEdTextBox

        private void MskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, CboBairro);
        }

        private void MskCep_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void MskDDD_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, MskTelefone);
        }

        private void MskTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, BtnListaIncluirTel);
        }

        #endregion MaskEdTextBox

        #region TextBox

        private void TxtNomeCliente_Enter(object sender, EventArgs e)
        {
            TxtPesquisar_GotFocus(sender, e);

            switch (sender.GetType().Name.ToUpper())
            {
                case "TEXTBOX":
                    {
                        ((TextBox)sender).SelectAll();
                        break;
                    }

                case "MASKEDTEXTBOX":
                    {
                        ((MaskedTextBox)sender).SelectAll();
                        break;
                    }
            }
            //Diversos.ControlBackColorGot(sender);
        }

        private void TxtNomeCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtEmail);
        }

        private void TxtNomeCliente_Leave(object sender, EventArgs e)
        {
            switch (sender.GetType().Name.ToUpper())
            {
                case "TEXTBOX":
                    {
                        TextBox obj = sender as TextBox;
                        obj.Text = Diversos.PrimeiraLetraMaiusculaNomesProprios(obj.Text);
                        break;
                    }
                case "MASKEDTEXTBOX":
                    {
                        MaskedTextBox obj = sender as MaskedTextBox;
                        obj.Text = Diversos.PrimeiraLetraMaiusculaNomesProprios(obj.Text);
                        break;
                    }
            }
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, CboSituacao);
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtLogradouro_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtNumLogradouro);
        }

        private void TxtNumLogradouro_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtNif);
        }

        private void TxtComplemento_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, MskCep);
        }

        private void TxtPesquisar_GotFocus(object sender, EventArgs e)
        {
            if (sender.GetType().Name == "TxtPesquisar")
            {
                TxtPesquisar.Text = string.Empty;//LimparCampos();
            }
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgCliente.DataSource != null)
            {

                this.clienteController.PesquisarClientes(DtgCliente, TxtPesquisar.Text.Trim());

                TotalRegistroNoDataGridView(DtgCliente, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "20200824-01", "x");
            }
        }

        #endregion TextBox

        #region ComboBox

        private void CboTipoTel_KeyDown(object sender, KeyEventArgs e)
        {
            PosicionarFoco(e, MskDDD);
        }

        private void CboTipoTel_Leave(object sender, EventArgs e)
        {
            if (enuTelefone == OPERACAO.INCLUIR)
            {
                this.MskTelefone.Text = string.Empty;
            }

            this.definirEnumTipoTelefone();

            if (this.MskDDD.Text.Replace("(", "").Replace(")", "") == string.Empty)
            {
                this.MskDDD.Text = "21";
            }
        }

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
            PosicionarFoco(e, TxtLogradouro);
        }

        private void CboBairro_KeyDown(object sender, KeyEventArgs e)
        {
            PosicionarFoco(e, CboTipoTel);
        }

        #endregion ComboBox

        #region ListView

        private void LvwTel_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            try
            {
                if (colwidth.Length != 0) { AlterarTamanho(LvwTel, colwidth, e.ColumnIndex); }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LvwTel_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
                enuTelefone = OPERACAO.ALTERAR;
                // Tipo Telefone
                CboTipoTel.SelectedValue = Convert.ToInt16(LvwTel.Items[e.ItemIndex].SubItems[1].Text);

                this.definirEnumTipoTelefone();

                // Numero do DDD
                MskDDD.Text = LvwTel.Items[e.ItemIndex].SubItems[3].Text;

                //Número do telefone/celular/fax
                MskTelefone.Text = LvwTel.Items[e.ItemIndex].SubItems[4].Text.Replace("-", "");

                //Descrição do tipo de telefone
                tipoTelefoneModel.DescTipoTelefone = LvwTel.Items[e.ItemIndex].SubItems[2].Text;

                // Codigo do tipo de telefone
                tipoTelefoneModel.IdTipoTelefone = Convert.ToInt16(CboTipoTel.SelectedValue);

                intTelefoneID = Convert.ToInt32(LvwTel.Items[e.ItemIndex].SubItems[0].Text);

                //Indice do item(linha) selecionado
                indiceLvw = e.ItemIndex;
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro(ex.Message.ToString(), "20130117-3", "E");
            }
        }

        #endregion ListView

        #region DataGridView

        private void DtgCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgCliente_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        #endregion DataGridView

        #region Botões

        #region Botões Menu

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();
            TxtNomeCliente.Focus();
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
                    TxtNomeCliente.Focus();
                }
                else
                {
                    TelaInicial(false);
                    MGMensagemErro.MensagensErro("O usuário não selecionou um registro no grid ou" +
                        " o grid está sem registros.", "20200911-01", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200911-02", "E");
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
                        " o grid está sem registros.", "20200911-03", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200911-04", "E");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            clienteModel = new ClienteModel();
            tipoTelefoneModel = new TipoTelefoneModel();
            clienteController = new ClienteController();
            //Validando a ação do usuário (Incluir, Alterar ou Excluir)
            if (enuAcao == OPERACAO.STANDBY)
            {
                MGMensagemErro.MensagensErro("Primeiro selecione a ação que deseja realizar pressionando um" +
                    " dos botões do menu.", "20200911-05", "A");
                return;
            }

            try
            {
                //Validação dos campos obrigatórios
                if (!Validar())
                {
                    return;
                }

                clienteModel.Nomecli = TxtNomeCliente.Text.Trim();
                clienteModel.Emailcli = TxtEmail.Text.Trim();
                clienteModel.Situacao_Model.IdSituacao = Convert.ToInt16(CboSituacao.SelectedValue);
                clienteModel.NIf = TxtNif.Text.Trim();

                enderecoCliModel = new EnderecoCliModel(clienteModel);
                enderecoCliModel.IdEnderecoCli = intEnderecoID;
                enderecoCliModel.LogradouroCli = TxtLogradouro.Text.Trim();
                enderecoCliModel.NumLogradouroCli = TxtNumLogradouro.Text.Trim();
                enderecoCliModel.CepCli = Diversos.TextNoFormatting(MskCep);
                enderecoCliModel.Bairro_Model.IdBairro = Convert.ToInt32(CboBairro.SelectedValue);

                TelefoneCliModel telefoneCliModel = new TelefoneCliModel(clienteModel);

                telefoneCliModel.ListTelefone.Clear();

                // objeto Telefone
                for (Int16 i = 0; i < LvwTel.Items.Count; i++)
                {
                    TelefoneCliModel objTel = new TelefoneCliModel(clienteModel);

                    //IdTelefone
                    if (!LvwTel.Items[i].SubItems[0].Text.Trim().Length.Equals(0))
                    {
                        objTel.IdTelefoneCli = Convert.ToInt16(LvwTel.Items[i].SubItems[0].Text);
                    }

                    //Tipo do telefone
                    objTel.TipoTelefone.IdTipoTelefone = Convert.ToInt16(LvwTel.Items[i].SubItems[1].Text);

                    //DDD
                    if (!LvwTel.Items[i].SubItems[3].Text.Trim().Length.Equals(0))
                    {
                        objTel.DDD = LvwTel.Items[i].SubItems[3].Text;
                    }

                    //Número do telefone
                    objTel.NumeroTelefone = Convert.ToInt32(LvwTel.Items[i].SubItems[4].Text.Replace("-", ""));

                    //adiciona no list LvwTel
                    telefoneCliModel.ListTelefone.Add(objTel);
                }

                int retorno = 0;
                try
                {
                    switch (enuAcao)
                    {
                        case OPERACAO.INCLUIR:
                            {
                                retorno = clienteController.IncluirClienteController(clienteModel, enderecoCliModel, telefoneCliModel);
                                break;
                            }
                        case OPERACAO.ALTERAR:
                            {
                                clienteModel.Idcliente = Convert.ToInt32(LblNumCodigo.Text);
                                enderecoCliModel.Cliente_Model.Idcliente = clienteModel.Idcliente;
                                telefoneCliModel.Cliente.Idcliente = clienteModel.Idcliente;
                                retorno = clienteController.AlterarClienteController(clienteModel, enderecoCliModel, telefoneCliModel);
                                break;
                            }
                        case OPERACAO.EXCLUIR:
                            {
                                clienteModel.Idcliente = Convert.ToInt32(LblNumCodigo.Text);
                                retorno = clienteController.ExcluirClienteController(clienteModel.Idcliente);
                                break;
                            }
                    }
                    if (retorno != 0)
                    {
                        TelaInicial(true);
                        MGMensagemErro.MensagensErro("Operação efetuada com sucesso!", "20200911-06", "X");
                    }
                    else
                    {
                        MGMensagemErro.MensagensErro("Operação Não foi efetuada.\n Verifique e tente novamente.",
                            "20200911-07", "e");
                    }
                }
                catch (Exception ex)
                {
                    MGMensagemErro.MensagensErro(ex.Message.ToString(), "20201006-1", "e");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200911-08", "E");
            }
        }

        #endregion Botões Menu

        #region Botões Telefone

        private void BtnListaCancelarTel_Click(object sender, EventArgs e)
        {
            CboTipoTel.SelectedIndex = -1;
            MskDDD.Text = MskTelefone.Text = string.Empty;
        }

        private void BtnListaIncluirTel_Click(object sender, EventArgs e)
        {
            string strMsg = "Sr. usuário, o número do telefone informado (" + MskTelefone.Text +
                ") é incompatível com o Tipo (" + CboTipoTel.Text + ") selecionado. Verifique e tente novamente.";

            MskTelefone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            string strNumeroTelefone = MskTelefone.Text;
            MskTelefone.TextMaskFormat = MaskFormat.IncludeLiterals;
            try
            {
                if (CboTipoTel.SelectedIndex == -1)
                {
                    MGMensagemErro.MensagensErro("Sr. usuário, informe o Tipo do telefone.", "20130110-3", "I");
                    CboTipoTel.Focus();
                    return;
                }

                if (strNumeroTelefone.Length == 0)
                {
                    MGMensagemErro.MensagensErro("Sr. usuário, informe o número do telefone.", "20130110-4", "I");
                    this.MskTelefone.Focus();
                    return;
                }

                if (!ValidarTelefone())
                {
                    MGMensagemErro.MensagensErro(strMsg, "20130110-5", "I");
                    this.MskTelefone.Focus();
                    return;
                }

                //Verificar se já existe na lista
                if (VerificaSeExisteItem(strNumeroTelefone))
                {
                    MGMensagemErro.MensagensErro("Sr. usuário, o número do telefone (" + MskTelefone.Text + ") informado já existe na lista.", "20130113-1", "I");
                    return;
                }
                else
                {
                    this.CarregarListViewTelefone();
                    this.CboTipoTel.Focus();

                    enuTelefone = OPERACAO.INCLUIR;
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro(ex.Message.ToString(), "20130110-2", "E");
            }
        }

        private void BtnListaExcluirTel_Click(object sender, EventArgs e)
        {
            if (indiceLvw >= 0)
            {
                LvwTel.Items.RemoveAt(indiceLvw);
                CboTipoTel.SelectedIndex = -1;
                MskDDD.Text = MskTelefone.Text = string.Empty;
            }
        }

        #endregion Botões Telefone

        #endregion Botões

        #endregion Eventos

        #region Métodos
 

        private void TelaInicial(Boolean bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgCliente, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgCliente, nomeColuna);
                EstilizarDataGridView.LarguraColuna(DtgCliente, larguraColuna);
                EstilizarDataGridView.ColunaVisivel(DtgCliente, colVisivel);

                ConfigurarListView.ConfigListView(LvwTel, NomeColunasListView(), Color.LightYellow, false);
                CarregarCboSituacao(CboSituacao);
                CarregarCboBairro(CboBairro);
                CarregarCboTipoTelefone(CboTipoTel);
            }
            CboSituacao.SelectedIndex = CboBairro.SelectedIndex = CboTipoTel.SelectedIndex = -1;
        }

        private void TotalRegistroNoDataGridView(DataGridView dtg, Label lbl)
        {
            lbl.Text = "Total de Registros: " + (dtg.Rows.Count).ToString();
        }

        private void CarregarCboTipoTelefone(ComboBox cbo)
        {
            TipoTelefoneController tipoTelefoneController = new TipoTelefoneController();
            cbo.DataSource = tipoTelefoneController.ObterRegistrosTipoTelefone();
            cbo.DisplayMember = "DescTipoTel";
            cbo.ValueMember = "IdTipoTelefone";
        }

        private void CarregarCboBairro(ComboBox cbo)
        {
            BairroController bairroController = new BairroController();
            cbo.DataSource = bairroController.ObterRegistrosBairro();
            cbo.DisplayMember = "NomeBairro";
            cbo.ValueMember = "IdBairro";

        }

        private void CarregarCboSituacao(ComboBox cbo)
        {
            SituacaoController situacaoController = new SituacaoController();
            cbo.DataSource = situacaoController.ObterRegistrosSituacao();// .PreencherCboSituacao(cbo);
            cbo.DisplayMember = "DescSituacao";
            cbo.ValueMember = "IdSituacao";
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
                    // configurando valor da primeira coluna, índice 0
                    LblNumCodigo.Text = DtgCliente.Rows[index].Cells[0].Value.ToString();
                    TxtNomeCliente.Text = DtgCliente.Rows[index].Cells[1].Value.ToString();
                    TxtEmail.Text = DtgCliente.Rows[index].Cells[2].Value.ToString();
                    CboSituacao.SelectedValue = (int)DtgCliente.Rows[index].Cells[3].Value;

                    if (!string.IsNullOrEmpty(DtgCliente.Rows[index].Cells[5].Value.ToString()))
                    {
                        intEnderecoID = (int)DtgCliente.Rows[index].Cells[5].Value;
                    }
                    TxtLogradouro.Text = DtgCliente.Rows[index].Cells[6].Value.ToString();
                    TxtNumLogradouro.Text = DtgCliente.Rows[index].Cells[7].Value.ToString();
                    MskCep.Text = DtgCliente.Rows[index].Cells[8].Value.ToString();

                    if (!string.IsNullOrEmpty(DtgCliente.Rows[index].Cells[9].Value.ToString()))
                    {
                        CboBairro.SelectedValue = (int)DtgCliente.Rows[index].Cells[9].Value;
                    }
                    TxtNif.Text = DtgCliente.Rows[index].Cells[15].Value.ToString();
                }

                //recupera o telefone
                TelefoneCliController telefoneCliController = new TelefoneCliController();
                telefoneCliController.ObterTelefonePorCliente(LvwTel, Convert.ToInt32(LblNumCodigo.Text));
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20201007-01", "E");
            }
        }

        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns>Número da linha selecionada no DataGridView.</returns>
        private int RecuperarLinhaSelecionadaDataGridView()
        {
            try
            {
                DataGridViewRow linhaAtual = DtgCliente.CurrentRow;

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

        private ArrayList NomeColunasListView()
        {
            ArrayList arrCabec = new ArrayList();
            arrCabec.Add(colwidth[0] + "-Código");
            arrCabec.Add(colwidth[1] + "-IdTipoTelefone");
            arrCabec.Add(colwidth[2] + "-Tipo Telefone");
            arrCabec.Add(colwidth[3] + "-DDD");
            arrCabec.Add(colwidth[4] + "-Telefone");
            return arrCabec;
        }

        private void AlterarTamanho(ListView lvw, int[] lista, int iWidth)
        {
            if (lvw.Columns[iWidth].Width != lista[iWidth])
            {
                lvw.Columns[iWidth].Width = lista[iWidth];
            }
        }

        private bool ValidarTelefone()
        {
            //string selectedItem = CboTipoTel.Text;
            //string strMsg = "Sr. usuário, o número do telefone informado (" + MskTelefone.Text + ") é incompatível com o Tipo (" + selectedItem.ToString() + ") selecionado. Verifique e tente novamente.";
            try
            {
                if (MskTelefone.Text.Replace("-", "").Replace("_", "").Trim().Length == 0)
                {
                    return true;
                }

                TelefoneCliModel objTel = new TelefoneCliModel(clienteModel);

                switch (enuTipoTel)
                {
                    case TIPOTEL.FIXORESIDENCIAL:
                    case TIPOTEL.FAXCOMERCIAL:
                    case TIPOTEL.FAXRESIDENCIAL:
                    case TIPOTEL.FIXOCOMERCIAL:
                        if (!Diversos.ValidarNumeroTelefone(MskTelefone.Text))
                        {
                            //MGMensagemErro.MensagensErro(strMsg, "20130101-7", "I");
                            this.MskTelefone.Focus();
                            return false;
                        }
                        break;

                    case TIPOTEL.CELULARRESIDENCIAL:
                    case TIPOTEL.CELULARCOMERCIAL:
                        if (!Diversos.ValidarNumeroCelular(MskTelefone.Text))
                        {
                            //MGMensagemErro.MensagensErro(strMsg, "20130101-9", "I");
                            this.MskTelefone.Focus();
                            return false;
                        }
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro(ex.Message.ToString(), "20130110-1", "E");
                return false;
            }
        }

        private bool VerificaSeExisteItem(string Search)
        {
            try
            {
                if (enuTelefone == OPERACAO.ALTERAR)
                {
                    return false;
                }

                string iSearch = Search.ToLower();

                foreach (ListViewItem item in LvwTel.Items)
                {
                    if (item.Text.ToLower().Contains(MskDDD.Text.Trim().Replace("(", string.Empty).Replace(")", string.Empty)))
                    {
                        if (item.SubItems[2].Text.Replace("-", "").Replace("_", "").ToLower().Contains(iSearch))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função expecífica para criar um valor para o id do telefone
        /// </summary>
        /// <param name="pCodTel"></param>
        /// <returns></returns>
        private int DefinirCodigoDoTelefone(int pCodTel)
        {
            Boolean bAchou = true;
            while (bAchou)
            {
                if (pCodTel == 0) { pCodTel++; }

                if (!ConfigurarListView.LocalizarValorEmUmaColuna(LvwTel, 0, pCodTel))
                {
                    bAchou = false;
                }
                else
                {
                    pCodTel++;
                }
            }
            return pCodTel;
        }

        private void CarregarListViewTelefone()
        {
            try
            {
                if (enuTelefone.Equals(OPERACAO.INCLUIR))
                {
                    intTelefoneID = DefinirCodigoDoTelefone(intTelefoneID);

                    string[] mItems = new string[]
                    {
                        intTelefoneID.ToString(),
                        CboTipoTel.SelectedValue.ToString(),
                        CboTipoTel.Text,
                        MskDDD.Text.Replace("(","").Replace(")","").Replace("_",""),
                        MskTelefone.Text
                    };

                    ListViewItem lvi = new ListViewItem(mItems);
                    LvwTel.Items.Add(lvi);

                }
                else if (enuTelefone.Equals(OPERACAO.ALTERAR))
                {

                    ListViewItem lvi = new ListViewItem(intTelefoneID.ToString());
                    lvi.SubItems.Add(CboTipoTel.SelectedValue.ToString());
                    lvi.SubItems.Add(CboTipoTel.Text);
                    lvi.SubItems.Add(MskDDD.Text.Replace("(", "").Replace(")", "").Replace("_", ""));
                    lvi.SubItems.Add(MskTelefone.Text.Replace("_", ""));

                    // Inclui os itens no ListView
                    LvwTel.Items.Add(lvi);

                    //LvwTel.Items[indiceLvw].SubItems[0].Text = intTelefoneID.ToString();
                    //LvwTel.Items[indiceLvw].SubItems[1].Text = CboTipoTel.SelectedValue.ToString();
                    //LvwTel.Items[indiceLvw].SubItems[2].Text = CboTipoTel.Text;
                    //LvwTel.Items[indiceLvw].SubItems[3].Text = MskDDD.Text.Replace("(", "").Replace(")", "").Replace("_", "");
                    //LvwTel.Items[indiceLvw].SubItems[4].Text = MskTelefone.Text.Replace("_", "");

                    indiceLvw = 0;
                }

                CboTipoTel.SelectedValue = -1;
                MskDDD.Text = MskTelefone.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            List<ClienteModel> listaCliente = new List<ClienteModel>();

            try
            {
                DtgCliente.DataSource = null;
                DtgCliente.Rows.Clear();
                DtgCliente.DataSource = clienteController.ObterRegistrosCliente();
                TotalRegistroNoDataGridView(DtgCliente, LblTotalRegistros);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20200721-01", "e");
            }
        }

        private void HabilitarBotoes(Boolean bolHabil)
        {
            BtnIncluir.Enabled = bolHabil;
            BtnAlterar.Enabled = bolHabil;
            BtnExcluir.Enabled = bolHabil;
        }

        private void HabilitarCampos(Boolean bolHabil)
        {
            TxtNomeCliente.Enabled = TxtEmail.Enabled = TxtLogradouro.Enabled =
            TxtNumLogradouro.Enabled = TxtNif.Enabled = bolHabil;
            MskCep.Enabled = MskDDD.Enabled = MskTelefone.Enabled = bolHabil;
            CboSituacao.Enabled = CboBairro.Enabled = CboTipoTel.Enabled = bolHabil;
            LvwTel.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeCliente.Text = TxtEmail.Text =
            TxtLogradouro.Text = TxtNumLogradouro.Text = TxtNif.Text =
            TxtPesquisar.Text = string.Empty;
            MskCep.Text = MskDDD.Text = MskTelefone.Text = string.Empty;
            CboSituacao.SelectedIndex = CboBairro.SelectedIndex = CboTipoTel.SelectedIndex = -1;
            LvwTel.Items.Clear();
        }

        private void definirEnumTipoTelefone()
        {
            MskTelefone.Mask = "999-999-999";

            enuTipoTel = (TIPOTEL)Convert.ToInt16(CboTipoTel.SelectedValue);

            //switch (Convert.ToInt16(CboTipoTel.SelectedValue))
            switch (enuTipoTel)
            {
                case TIPOTEL.NAOINFORMADO://case 1:
                    {
                        enuTipoTel = TIPOTEL.NAOINFORMADO;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.FIXORESIDENCIAL://case 2:
                    {
                        enuTipoTel = TIPOTEL.FIXORESIDENCIAL;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.FIXOCOMERCIAL: //case 3:
                    {
                        enuTipoTel = TIPOTEL.FIXOCOMERCIAL;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.CELULARRESIDENCIAL:// case 4:
                    {
                        enuTipoTel = TIPOTEL.CELULARRESIDENCIAL;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.CELULARCOMERCIAL:// case 5:
                    {
                        enuTipoTel = TIPOTEL.CELULARCOMERCIAL;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.FAXCOMERCIAL:// case 6:
                    {
                        enuTipoTel = TIPOTEL.FAXCOMERCIAL;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.FIXOEMERGENCIA:// case 7:
                    {
                        enuTipoTel = TIPOTEL.FIXOEMERGENCIA;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                case TIPOTEL.CELULAREMERGENCIA:// case 8:
                    {
                        enuTipoTel = TIPOTEL.CELULAREMERGENCIA;
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
                //case 9:
                //    {
                //        enuTipoTel = TIPOTEL.CENTRALDEATENDIMENTO;
                //        MskTelefone.Mask = "999";
                //        break;
                //    }
                default:
                    {
                        MskTelefone.Mask = "999-999-999";
                        break;
                    }
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

        /// <summary>
        /// Usar preferencialmente nos controles de texto. Usar no evento keypress.
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

        private void panelDados_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private Boolean Validar()
        {
            if (TxtNomeCliente.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeCliente.Text + " é obrigatório.", "20200911-10", "a");
                TxtNomeCliente.Focus();
                return false;
            }
            //if (TxtEmail.Text.Trim().Length == 0)
            //{
            //    MGMensagemErro.MensagensErro("O campo " + LblEmail.Text + " é obrigatório.", "20200911-10", "a");
            //    TxtEmail.Focus();
            //    return false;
            //}

            if (CboSituacao.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSituacao.Text + " é obrigatório.", "20200911-10", "A");
                CboSituacao.Focus();
                return false;
            }
            return true;
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
