using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFFuncionarioView : Form
    {
        #region Variáveis

        FuncionarioModel funcionarioModel = null;
        FuncionarioController funcionarioController = null;
        EnderecoFunModel enderecoFunModel = null;
        private Int32 intTelefoneID, idEnderecoFuncionario = 0;
        private Int32 indiceLvw;
        Bitmap bmp = null;

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao, enuTelefone;

        private enum TIPOTEL
        {
            CELULARRESIDENCIAL = 1, CELULARCOMERCIAL = 2, FIXORESIDENCIAL = 3, FIXOCOMERCIAL = 4, FAXRESIDENCIAL = 5,
            FAXCOMERCIAL = 6, FIXOEMERGENCIA = 7, CELULAREMERGENCIA = 8, NAOINFORMADO = 9
        };
        TIPOTEL enuTipoTel;

        List<string> ListaColunaVisivel = new List<string>() { "IdFuncionario", "NomeFunc", "NomeCargo", "DescSituacao" };
        List<string> ListaCabecalho = new List<string>() { "Código", "Funcionário", "Cargo", "Situação", "Email" };
        List<int> ListaLarguraColuna = new List<int>() { 10, 45, 30, 15, 30};

        /// <summary>
        /// colwidth[] é um array que define a largura das colunas do listview de exibição.
        /// </summary>
        int[] colwidth = { 0, 0, 200, 70, 120 };

        #endregion Variáveis

        #region Construtor

        public WFFuncionarioView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);

            funcionarioModel = new FuncionarioModel();
            funcionarioController = new FuncionarioController();
        }

        #endregion Construtor

        #region Eventos

        #region Form

        private void WFFuncionarioView_KeyDown(object sender, KeyEventArgs e)
        {
            // não se esqueça de definir KeyPreview = true para o formulário

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
            else if (e.KeyCode == Keys.F7)
            {
              //  TabFuncionario.SelectedTab = tabPageEndTel; ==============================
            }
            else if (e.KeyCode == Keys.F8)
            {
               // TabFuncionario.SelectedTab = tabPageDados;  ==============================
            }
        }

        private void WFFuncionarioView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgFuncionario.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgFuncionario.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }

        #endregion Form

        #region Button

        #region Button Menu

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            BtnVoltar_Click(sender, e);
            HabilitarBotoes(false);
            HabilitarCampos(true);
            LimparCampos();

            TxtNomeFuncionario.Focus();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (RecuperarLinhaSelecionadaDataGridView() >= 0)
                {
                    enuAcao = OPERACAO.ALTERAR;
                    BtnVoltar_Click(sender, e);
                    HabilitarCampos(true);
                    AtribuirValoresDaLinhaDoDataGridView();
                    HabilitarBotoes(false);
                    TxtNomeFuncionario.Focus();
                }
                else
                {
                    TelaInicial(false);
                    MGMensagemErro.MensagensErro("O usuário não selecionou um registro no grid ou" +
                        " o grid está sem registros.", "20200930-01", "a");
                }
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200930-02", "E");
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            try
            {

                BtnVoltar_Click(sender, e);
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
                MGMensagemErro.MensagensErro("Não foi possível eliminar o regsito pos esta associado a outro" , "20200930-04", "E");
                /*
                   MGMensagemErro.MensagensErro("Ocorreu um erro inesperado! Comunique ao setor de TI." + "\n\n" +
                 ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200930-04", "E");
                */
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
                    " dos botões do menu.", "20200930-05", "A");
                return;
            }

            try
            {
                if (picBox.Image == null)
                {
                    if (MessageBox.Show("Não foi selecionada uma foto! Deseja escolher agora?", "Selecionar foto", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        picBox_DoubleClick(sender, e);
                        MGMensagemErro.MensagensErro("Pressione o botão salvar novamente para finalizar a operação ou.", "20201211-01", "i");
                        return;
                    }
                }

                //Validação dos campos obrigatórios
                if (!Validar(sender, e))
                {
                    return;
                }

                /*
                    criar método para converter picturebox.image para array de bytes
                    http://www.macoratti.net/19/11/c_imgarr1.htm
                */
                if (picBox.Image != null && picBox.Image != Properties.Resources.semimagem)
                {
                    Util.ReadWriteFoto rwf = new Util.ReadWriteFoto();
                    funcionarioModel.Foto = rwf.ConverteImagemParaByteArray(picBox.Image); // rwf.ConverterImagemToArray(rwf.ConverterParaBitMat(pathImage));// foto;
                    rwf = null;
                }

                funcionarioModel.Situacao_Model.IdSituacao = Convert.ToInt16(CboSituacao.SelectedValue);
                funcionarioModel.Cargo_Model.IdCargo = Convert.ToInt16(CboCargo.SelectedValue);
                funcionarioModel.DepartamentoModel.IdDepartamento = Convert.ToInt16(CboDepartamento.SelectedValue);
                funcionarioModel.Nif = TxtNif.Text.Trim();


                funcionarioModel.NomeFunc = TxtNomeFuncionario.Text.Trim();
                funcionarioModel.Email = TxtEmail.Text.Trim();
                funcionarioModel.DataContratacao = DateTime.Now;


                enderecoFunModel = new EnderecoFunModel(funcionarioModel);
                enderecoFunModel.IdEnderecoFun = idEnderecoFuncionario;
                enderecoFunModel.LogradouroFun = TxtLogradouro.Text.Trim();
                enderecoFunModel.NumLogradouroFun = TxtNumLogradouro.Text.Trim();
                enderecoFunModel.CepFun = Diversos.TextNoFormatting(MskCep);
                enderecoFunModel.Bairro_Model.IdBairro = Convert.ToInt32(CboBairro.SelectedValue);

                TelefoneFunModel telefoneFunModel = new TelefoneFunModel(funcionarioModel);

                if (LvwTel.Items.Count > 0)
                {
                    telefoneFunModel.ListTelefone.Clear();

                    // objeto Telefone
                    for (Int16 i = 0; i < LvwTel.Items.Count; i++)
                    {
                        TelefoneFunModel objTel = new TelefoneFunModel(funcionarioModel);

                        //IdTelefone
                        if (!LvwTel.Items[i].SubItems[0].Text.Trim().Length.Equals(0))
                        {
                            objTel.IdTelefoneFun = Convert.ToInt16(LvwTel.Items[i].SubItems[0].Text);
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
                        telefoneFunModel.ListTelefone.Add(objTel);
                    }
                }
                int retorno = 0;
                try
                {
                    switch (enuAcao)
                    {
                        case OPERACAO.INCLUIR:
                            {
                                retorno = funcionarioController.IncluirFuncionarioController(funcionarioModel, enderecoFunModel, telefoneFunModel);
                                break;
                            }
                        case OPERACAO.ALTERAR:
                            {
                                funcionarioModel.IdFuncionario = Convert.ToInt32(LblNumCodigo.Text);
                                enderecoFunModel.Funcionario_Model.IdFuncionario = funcionarioModel.IdFuncionario;
                                telefoneFunModel.Funcionario_Model.IdFuncionario = funcionarioModel.IdFuncionario;
                                retorno = funcionarioController.AlterarFuncionarioController(funcionarioModel, enderecoFunModel, telefoneFunModel);
                                break;
                            }
                        case OPERACAO.EXCLUIR:
                            {
                                funcionarioModel.IdFuncionario = Convert.ToInt32(LblNumCodigo.Text);
                                enderecoFunModel.Funcionario_Model.IdFuncionario = funcionarioModel.IdFuncionario;
                                telefoneFunModel.Funcionario_Model.IdFuncionario = funcionarioModel.IdFuncionario;
                                retorno = funcionarioController.ExcluirFuncionarioController(funcionarioModel.IdFuncionario);
                                break;
                            }
                    }
                    if (retorno != 0)
                    {
                        TelaInicial(true);
                        MGMensagemErro.MensagensErro("Operação efetuada com sucesso!", "20200930-06", "X");
                    }
                    else
                    {
                        MGMensagemErro.MensagensErro("Operação Não foi efetuada.\n Verifique e tente novamente.",
                            "20200930-07", "e");
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
                                    ex.Message.ToString() + "\n\n" + ex.StackTrace, "20200930-08", "E");
            }
        }

        #endregion Button Menu

        #region Button Telefone

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
                    MGMensagemErro.MensagensErro("Sr. usuário, informe o Tipo do telefone.", "20200110-3", "I");
                    CboTipoTel.Focus();
                    return;
                }

                if (strNumeroTelefone.Length == 0)
                {
                    MGMensagemErro.MensagensErro("Sr. usuário, informe o número do telefone.", "20200110-4", "I");
                    this.MskTelefone.Focus();
                    return;
                }

                if (!ValidarTelefone())
                {
                    MGMensagemErro.MensagensErro(strMsg, "20200110-5", "I");
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
                MGMensagemErro.MensagensErro(ex.Message.ToString(), "20200110-2", "E");
            }
        }

        private void BtnListaCancelarTel_Click(object sender, EventArgs e)
        {
            CboTipoTel.SelectedIndex = -1;
            MskDDD.Text = MskTelefone.Text = string.Empty;
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

        #endregion Button Telefone

        #region Button Voltar

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            //TabFuncionario.SelectedIndex = 0;================================
        }

        private void BtnVoltar_MouseMove(object sender, MouseEventArgs e)
        {
           // BtnVoltar.ForeColor = Color.FromArgb(255, 77, 58);
        }



        #endregion Button Voltar

        #endregion Button

        #region TextBox

        private void TxtNomeFuncionario_Enter(object sender, EventArgs e)
        {
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
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtNomeFuncionario_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, TxtEmail);
        }

        private void TxtNomeFuncionario_Leave(object sender, EventArgs e)
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
            PosicionarFoco(e, CboCargo);
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

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgFuncionario.DataSource != null)
            {

                this.funcionarioController.PesquisarFuncionario(DtgFuncionario, TxtPesquisar.Text.Trim());
                TotalRegistroNoDataGridView(DtgFuncionario, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "20200824-01", "x");
            }
        }

        #endregion TextBox

        #region MaskEdTextBox

        private void MskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            PosicionarFoco(e, CboBairro);
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

        #region ComboBox

        private void CboSituacao_Enter(object sender, EventArgs e)
        {
            if (Diversos.ExisteItensComboBox(CboSituacao))
            {
                if (CboSituacao.SelectedIndex == -1)
                {
                    CboSituacao.SelectedIndex = 0;
                }
            }
        }

        private void CboSituacao_KeyDown(object sender, KeyEventArgs e)
        {
            //TabFuncionario.SelectedIndex = 1;  ==================================================
            PosicionarFoco(e, TxtLogradouro);
        }

        private void CboBairro_KeyDown(object sender, KeyEventArgs e)
        {
            PosicionarFoco(e, CboTipoTel);
        }

        private void CboCargo_Enter(object sender, EventArgs e)
        {
            if (Diversos.ExisteItensComboBox(CboCargo))
            {
                if (CboCargo.SelectedIndex == -1)
                {
                    CboCargo.SelectedIndex = 0;
                }
            }
        }

        private void CboCargo_KeyDown(object sender, KeyEventArgs e)
        {
            PosicionarFoco(e, CboSituacao);
        }

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

        /* O evento SelectedIndexChanged é executado antes do evento ItemSelectionChanged quando mudamos a linha do ListView com as setas            
            private void LvwTel_SelectedIndexChanged(object sender, EventArgs e)
            {
                 ListView lv = (ListView)sender;
                    if (lv.SelectedIndices.Count > 0)
                        MessageBox.Show(lv.SelectedIndices[0].ToString());
            }   
            O evento ItemSelectionChanged é executado antes do evento SelectedIndexChanged quando clicamos na linha do ListView
         */

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
                //tipoTelefoneModel.DescTipoTelefone = LvwTel.Items[e.ItemIndex].SubItems[2].Text;

                // Codigo do tipo de telefone
                //tipoTelefoneModel.IdTipoTelefone = Convert.ToInt16(CboTipoTel.SelectedValue);

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

        private void DtgFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              AtribuirValoresDaLinhaDoDataGridView();
        }

        private void DtgFuncionario_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        #endregion DataGridView

        #region TabControl

        private void TabFuncionario_Selected(object sender, TabControlEventArgs e)
        {
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "TabPage", e.TabPage);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Action", e.Action);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "Selected Event");

            if (e.TabPageIndex == 0)
            {
                if (TxtNomeFuncionario.CanFocus)
                {
                    TxtNomeFuncionario.Focus();
                };
            }
            else if (e.TabPageIndex == 1)
            {
                TxtLogradouro.Focus();
            }
        }

        #endregion TabControl

        #region PictureBox

        private void picBox_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja selecionar outra foto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Util.ReadWriteFoto rwf = new ReadWriteFoto(picBox);
                bmp = rwf.EscolherFoto();
                rwf = null;
            }
        }

        #endregion PictureBox

        #endregion Eventos

        #region Métodos
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

                    //Inclui os itens no ListView
                    LvwTel.Items.Add(lvi);
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
            //List<FuncionarioModel> ListaFuncionario = new List<FuncionarioModel>();
            FuncionarioController funcionarioController = new FuncionarioController();

            try
            {
                DtgFuncionario.DataSource = null;
                DtgFuncionario.Rows.Clear();
                DtgFuncionario.DataSource = funcionarioController.ObterAllFuncionario();
                TotalRegistroNoDataGridView(DtgFuncionario, LblTotalRegistros);
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro("Erro: " + ex.Message.ToString(), "20201117-11", "e");
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
            return DtgFuncionario.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns>Número da linha selecionada no DataGridView.</returns>
        private int RecuperarLinhaSelecionadaDataGridView()
        {
            try
            {
                DataGridViewRow linhaAtual = DtgFuncionario.CurrentRow;

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

                LblNumCodigo.Text = DtgFuncionario.Rows[index].Cells[0].Value.ToString();
                TxtNomeFuncionario.Text = DtgFuncionario.Rows[index].Cells[1].Value.ToString();

                TxtEmail.Text = DtgFuncionario.Rows[index].Cells[4].Value.ToString();
                CboSituacao.SelectedValue = Convert.ToInt16(DtgFuncionario.Rows[index].Cells[5].Value);


                // Verifica se o valor da célula não é nulo ou vazio antes de converter
                if (!string.IsNullOrEmpty(DtgFuncionario.Rows[index].Cells[6].Value?.ToString()))
                {
                    idEnderecoFuncionario = Convert.ToInt32(DtgFuncionario.Rows[index].Cells[6].Value);
                }

                TxtLogradouro.Text = DtgFuncionario.Rows[index].Cells[7].Value.ToString();
                TxtNumLogradouro.Text = DtgFuncionario.Rows[index].Cells[8].Value.ToString();



                MskCep.Text = DtgFuncionario.Rows[index].Cells[9].Value.ToString();
                CboBairro.SelectedValue = Convert.ToInt32(DtgFuncionario.Rows[index].Cells[10].Value);

                TxtNif.Text = DtgFuncionario.Rows[index].Cells[21].Value.ToString();

                CboCargo.SelectedValue = Convert.ToInt16(DtgFuncionario.Rows[index].Cells[17].Value);
                CboDepartamento.SelectedValue = Convert.ToInt16(DtgFuncionario.Rows[index].Cells[20].Value);


                if (DtgFuncionario.Rows[index].Cells[19].Value != DBNull.Value)
                {
                    Util.ReadWriteFoto rwf = new Util.ReadWriteFoto(picBox);
                    rwf.LendoVarbinary((byte[])DtgFuncionario.Rows[index].Cells[19].Value);
                }
                else
                {
                    picBox.Image = null;
                }
                // Corrige a chamada para obter os telefones do funcionário
                TelefoneFunController telefoneFunController = new TelefoneFunController();
                telefoneFunController.ObterTelefonePorFuncionario(LvwTel, Convert.ToInt32(DtgFuncionario.Rows[index].Cells[0].Value));
            }

        }

        private void TelaInicial(Boolean bolIni)
        {
            enuAcao = OPERACAO.STANDBY;

            if (bolIni)
            {
                RefreshDataGrid(DtgFuncionario, true);

                EstilizarDataGridView.DefinirVisibilidadeDataGridView(DtgFuncionario, ListaColunaVisivel);
                EstilizarDataGridView.DefinirLargurasDataGridView(DtgFuncionario, ListaLarguraColuna);
                EstilizarDataGridView.DefinirCabecalhoDataGridView(DtgFuncionario, ListaCabecalho);
                EstilizarDataGridView.EstiloDataGridView(DtgFuncionario);

                ConfigurarListView.ConfigListView(LvwTel, NomeColunasListView(), Color.LightYellow, false);

                CarregarCboSituacao(CboSituacao);
                CarregarCboCargo(CboCargo);
                CarregarCboBairro(CboBairro);
                CarregarCboTipoTelefone(CboTipoTel);
                CarregarCboDepartamento(CboDepartamento);
            }
            HabilitarBotoes(true);
            HabilitarCampos(false);
            LimparCampos();
            // TabFuncionario.SelectedIndex = 0; ======================================
            // TabFuncionario.TabPages[0].Focus();======================================
        }

        private bool ValidarTelefone()
        {
            try
            {
                if (MskTelefone.Text.Replace("-", "").Replace("_", "").Trim().Length == 0)
                {
                    return true;
                }

                TelefoneFunModel objTel = new TelefoneFunModel(funcionarioModel);

                switch (enuTipoTel)
                {
                    case TIPOTEL.FIXORESIDENCIAL:
                    case TIPOTEL.FAXCOMERCIAL:
                    case TIPOTEL.FAXRESIDENCIAL:
                    case TIPOTEL.FIXOCOMERCIAL:
                        if (!Diversos.ValidarNumeroTelefone(MskTelefone.Text))
                        {
                            this.MskTelefone.Focus();
                            return false;
                        }
                        break;

                    case TIPOTEL.CELULARRESIDENCIAL:
                    case TIPOTEL.CELULARCOMERCIAL:
                        if (!Diversos.ValidarNumeroCelular(MskTelefone.Text))
                        {
                            this.MskTelefone.Focus();
                            return false;
                        }
                        break;
                }
                return true;
            }
            catch (Exception ex)
            {
                MGMensagemErro.MensagensErro(ex.Message.ToString(), "20200110-1", "E");
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
                    if (item.SubItems[3].Text.ToLower().Contains(MskDDD.Text.Trim().Replace("(", string.Empty).Replace(")", string.Empty)))
                    {
                        if (item.SubItems[4].Text.Replace("-", "").Replace("_", "").ToLower().Contains(iSearch))
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

        private void CarregarCboDepartamento(ComboBox cbo)
        {
            DepartamentoController departamentoController = new DepartamentoController();
            cbo.DataSource = departamentoController.ObterRegistrosDepartamentos();
            cbo.DisplayMember = "NomeDepartamento";
            cbo.ValueMember   = "IdDepartamento";
        }
        private void CarregarCboSituacao(ComboBox cbo)
        {
            SituacaoController situacaoController = new SituacaoController();
            cbo.DataSource = situacaoController.ObterRegistrosSituacao();
            cbo.DisplayMember = "DescSituacao";
            cbo.ValueMember = "IdSituacao";
        }

        private void CarregarCboCargo(ComboBox cbo)
        {
            CargoController cargoController = new CargoController();
            cbo.DataSource = cargoController.ObterRegistrosCargo();
            cbo.DisplayMember = "NomeCargo";
            cbo.ValueMember = "IdCargo";
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

        private void HabilitarBotoes(Boolean bolHabil)
        {
            BtnIncluir.Enabled = bolHabil;
            BtnAlterar.Enabled = bolHabil;
            BtnExcluir.Enabled = bolHabil;
        }

        private void HabilitarCampos(Boolean bolHabil)
        {
            Diversos.EnableDisableControles(this, this.Controls, bolHabil);
            TxtPesquisar.Enabled = true;
            picBox.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeFuncionario.Text = TxtEmail.Text = TxtLogradouro.Text =
            TxtNumLogradouro.Text = TxtNif.Text = MskCep.Text = MskDDD.Text = MskTelefone.Text =
            TxtPesquisar.Text = string.Empty;
            CboSituacao.SelectedIndex = CboCargo.SelectedIndex = CboBairro.SelectedIndex = CboTipoTel.SelectedIndex = CboDepartamento.SelectedIndex = -1;

            LvwTel.Items.Clear();
            picBox.Image = null;
            picBox.Image = Properties.Resources.semimagem;
        }

        private void PrepararCampoMaskedTextBox(MaskedTextBox msk)
        {
            msk.Text = string.Empty;
            msk.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            msk.Mask = "";
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
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private Boolean Validar(object sender, EventArgs e)
        {
            try
            {
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
            }
            catch(Exception ex)
            {
                MGMensagemErro.MensagensErro("O campo " + "Email" + " Digite um email válido.", "20201117-10", "A");
                return false;
            }

            if (TxtNomeFuncionario.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeFuncionario.Text + " é obrigatório.", "20201117-10", "a");
                TxtNomeFuncionario.Focus();
                return false;
            }

            if (CboSituacao.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblSituacao.Text + " é obrigatório.", "20200911-10", "A");
                CboSituacao.Focus();
                return false;
            }

            if (CboCargo.SelectedIndex == -1)
            {
                MGMensagemErro.MensagensErro("O campo " + LblCargo.Text + " é obrigatório.", "20200911-10", "A");
                CboCargo.Focus();
                return false;
            }
            return true;
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

        private void AlterarTamanho(ListView lvw, int[] lista, int iWidth)
        {
            if (lvw.Columns[iWidth].Width != lista[iWidth])
            {
                lvw.Columns[iWidth].Width = lista[iWidth];
            }
        }

        private void BtnProcurar_Click(object sender, EventArgs e)
        {
            Util.ReadWriteFoto rwf = new ReadWriteFoto(picBox);
            bmp = rwf.EscolherFoto();
            rwf = null;
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
                {
                    ((Button)controle).Focus();
                }
                else if (controle.GetType().Name.ToLower().Equals("radiobutton"))
                {
                    ((RadioButton)controle).Focus();
                }

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
