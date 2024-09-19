using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFEstadoView : Form
    {
        #region  Variáveis

        private enum OPERACAO { INCLUIR, ALTERAR, EXCLUIR, STANDBY }
        private OPERACAO enuAcao;

        string[] nomeColuna = { "Código", "Nome Estado", "UF" };
        bool[] colunaVisivel = { true, true, true };

        EstadoController estadoController = null;

        #endregion Variáveis

        #region Construtor

        public WFEstadoView()
        {
            InitializeComponent();
            PadraoForm.SettingsForm(this);
            this.estadoController = new EstadoController();
        }

        #endregion Construtor

        #region Eventos

        #region Form

        private void WFEstadoView_Load(object sender, EventArgs e)
        {
            TelaInicial(true);
            // Configuração da fonte para o cabeçalho
            DtgEstados.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            // Configuração da fonte para as células
            DtgEstados.DefaultCellStyle.Font = new Font("Arial", 12);
            loadtheme();
        }

        #endregion Form

        #region TextBox

        private void TxtNomeEstado_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtNomeEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                TxtUf.Focus();
            }
        }

        private void TxtNomeEstado_Leave(object sender, EventArgs e)
        {
            Diversos.PrimeiraLetraMaiuscula_Leave(sender);
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtUf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnSalvar.Focus();
            }
        }

        private void TxtUf_Leave(object sender, EventArgs e)
        {
            TxtUf.Text = TxtUf.Text.ToUpper();
            Diversos.ControlBackColorLost(sender);
        }

        private void TxtPesquisar_GotFocus(object sender, EventArgs e)
        {
            TxtPesquisar.Text = string.Empty;
            Diversos.ControlBackColorGot(sender);
        }

        private void TxtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (DtgEstados.DataSource != null)
            {

                this.estadoController.PesquisarEstados(DtgEstados, TxtPesquisar.Text.Trim());
                TotalRestrosNoDataGridView(DtgEstados, LblTotalRegistros);
            }
            else
            {
                MGMensagemErro.MensagensErro("Sem registros para pesquisar!", "20200824-01", "x");
            }
        }

        private void TxtPesquisar_Leave(object sender, EventArgs e)
        {
            Diversos.ControlBackColorLost(sender);
        }

        #endregion TextBox

        #region Botoes

        private void BtnIncluir_Click(object sender, EventArgs e)
        {
            enuAcao = OPERACAO.INCLUIR;
            HabilitarBotoes(false);
            LimparCampos();
            HabilitarCampos(false);
            TxtNomeEstado.Focus();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (TxtNomeEstado.Text.Trim().Length > 0)
            {
                enuAcao = OPERACAO.ALTERAR;
                HabilitarCampos(false);
                AtribuirValoresDaLinhaDoDataGridView();
                HabilitarBotoes(false);
                TxtNomeEstado.Focus();
            }
            else
            {
                enuAcao = OPERACAO.STANDBY;
                MGMensagemErro.MensagensErro("Selecione um registro no grid e depois pressione o botão Alterar.", "20200824-02", "a");
            }
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            if (TxtNomeEstado.Text.Trim().Length > 0)
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
                enuAcao = OPERACAO.STANDBY;
                MGMensagemErro.MensagensErro("Selecione um registro no grid e depois pressione o botão Excluir.", "20200721-03", "a");
            }
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            //Validando a ação do usuário (Incluir, Alterar ou Excluir)
            if (enuAcao == OPERACAO.STANDBY)
            {
                MGMensagemErro.MensagensErro("Primeiro selecione a ação que deseja realizar pressionando um dos botões do menu.",
                    "20200720-06", "A");
                return;
            }

            //Validação dos campos obrigatórios
            if (!Validar())
            {
                return;
            }
            EstadoModel estadoModel = new EstadoModel();

            estadoModel.NomeEstado = TxtNomeEstado.Text.Trim();
            estadoModel.Uf = TxtUf.Text.Trim();

            int retorno = 0;
            switch (enuAcao)
            {
                case OPERACAO.INCLUIR:
                    {
                        retorno = this.estadoController.IncluirEstadoController(estadoModel);
                        break;
                    }
                case OPERACAO.ALTERAR:
                    {
                        estadoModel.IdEstado = Convert.ToInt32(LblNumCodigo.Text);
                        retorno = this.estadoController.AlterarEstadoController(estadoModel);
                        break;
                    }
                case OPERACAO.EXCLUIR:
                    {
                        estadoModel.IdEstado = Convert.ToInt32(LblNumCodigo.Text);
                        retorno = this.estadoController.ExcluirEstadoController(estadoModel.IdEstado);
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            TelaInicial(false);
        }


         // =================== METODO NÃO IMPLEMENTADO  ======================
         #region BOTAO IMPRIMIR TELA ESTADO
        /*  private void BtnImpremir_Click(object sender, EventArgs e)
         {
          #region Botoes
            WFRelEstado frm = new WFRelEstado();
            frm.ShowDialog();
            frm.Dispose();
        }*/
      #endregion BOTAO IMPRIMIR TELA ESTADO


        #endregion Botoes

        // Acrescentar os eventos

        #region DataGridView

        private void DtgEstados_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                AtribuirValoresDaLinhaDoDataGridView();
            }
        }

        private void DtgEstados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AtribuirValoresDaLinhaDoDataGridView();
        }

        #endregion DataGridView

        #endregion Eventos

        #region Métodos

        /// <summary>
        /// Validação dos campos obrigatórios.
        /// </summary>
        /// <returns>Verdadeiro se todos os campos obrigatórios foram preenchidos.</returns>
        private Boolean Validar()
        {
            if (TxtNomeEstado.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblNomeEstado.Text + " é obrigatório.", "20200820-02", "a");
                TxtNomeEstado.Focus();
                return false;
            }

            if (TxtUf.Text.Trim().Length == 0)
            {
                MGMensagemErro.MensagensErro("O campo " + LblUf.Text + " é obrigatório.", "20200820-02", "a");
                TxtUf.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Obtém o valor da célula
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>Valor contido na célula selecionada.</returns>
        private string RecuperarValorDaCelulaSelecionada(object sender, DataGridViewCellEventArgs e)
        {
            return DtgEstados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        /// <summary>
        /// Recupera o número da linha selecionada no DataGridView.
        /// </summary>
        /// <returns>Número da linha selecionada no DataGridView.</returns>
        private int RecupararLinhaSelecionadaDataGridView()
        {
            DataGridViewRow linhaAtual = DtgEstados.CurrentRow;
            int numeroLinha = linhaAtual.Index;
            return numeroLinha;
        }

        // alteração aqui

        /// <summary>
        /// Atribui aos campos os valores das células da linha selecionada
        /// </summary>
        private void AtribuirValoresDaLinhaDoDataGridView()
        {
            int index = RecupararLinhaSelecionadaDataGridView();
            // configurando valor da primeira coluna, índice 0
            LblNumCodigo.Text = DtgEstados.Rows[index].Cells[0].Value.ToString();
            TxtNomeEstado.Text = DtgEstados.Rows[index].Cells[1].Value.ToString();
            TxtUf.Text = DtgEstados.Rows[index].Cells[2].Value.ToString();
        }

        private void TelaInicial(Boolean bolIni)
        {
            enuAcao = OPERACAO.STANDBY;
            HabilitarBotoes(true);
            HabilitarCampos(true);
            LimparCampos();

            if (bolIni)
            {
                RefreshDataGrid(DtgEstados, true);
                EstilizarDataGridView.EstiloTituloColuna(DtgEstados, nomeColuna, colunaVisivel);
            }
        }

        private void RefreshDataGrid(DataGridView dtg, Boolean bolRefresh)
        {
            if (bolRefresh) { PreencherDataGridView(dtg); }
        }

        private void PreencherDataGridView(DataGridView dtg)
        {
            List<EstadoModel> listaEstados = new List<EstadoModel>();
            //EstadoController estadoController = new EstadoController();
            try
            {
                dtg.DataSource = null;
                dtg.Rows.Clear();
                dtg.DataSource = this.estadoController.ObterRegistrosEstado();
                TotalRestrosNoDataGridView(dtg, LblTotalRegistros);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void TotalRestrosNoDataGridView(DataGridView dtg, Label lbl)
        {
            lbl.Text = "Total de Registros: " + (dtg.Rows.Count).ToString();
        }

        private void HabilitarCampos(Boolean bolHabil)
        {
            TxtNomeEstado.ReadOnly = bolHabil;
            TxtUf.ReadOnly = bolHabil;
        }

        private void HabilitarBotoes(Boolean bolHabil)
        {
            BtnIncluir.Enabled = bolHabil;
            BtnAlterar.Enabled = bolHabil;
            BtnExcluir.Enabled = bolHabil;
        }

        private void LimparCampos()
        {
            LblNumCodigo.Text = TxtNomeEstado.Text = TxtUf.Text = TxtPesquisar.Text = string.Empty;
        }
		
		
	#region ===== METODO PROVEDORES DE CORES DO FORM MAIN MENU ========
        private void loadtheme()
        {
            foreach(Control btns in this.Controls)
            {
                if(btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor =ThemeColor.SecondaryColor;

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
