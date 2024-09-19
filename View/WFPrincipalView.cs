using FontAwesome.Sharp;
using SISTEMA_DE_GESTÃO_LOJA.Controller;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class WFPrincipalView : MetroFramework.Forms.MetroForm
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
           int nLeftRect,
           int nTopRect,
           int RightRect,
           int nBottomRect,
           int nWidthEllipse,
           int nHeightEllipse
        );
        //Fields
        Boolean boolVisillity = false;
        private IconButton currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;


        private int idFuncionario;
        private string _nomeusuario;
        private string nomeFuncionario;
        private int idTipoUsuario;
        private string login;
        private string siglaTipoUsuario;

        //Constructor


        public WFPrincipalView(int IdTipoUsuario, string Login, string SiglaTipoUsuario, string NomeFunc, int IdFuncionario)
        {
            WFVendaProdutoView wFVendaProduto = new WFVendaProdutoView(IdTipoUsuario, Login, SiglaTipoUsuario, NomeFunc, IdFuncionario);
            InitializeComponent();
            ConfigureTimerkUsuários();
            ConfigureTimerkProdutos();
            ConfigureTimerkClientes();
            ConfigureTimerkVendas();
            AtualizarProgressBar();



            // this.FormClosing += Form1_FormClosing;


            random = new Random();
            //btnCloseChildForm.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.idTipoUsuario = IdTipoUsuario;
            this.login = Login;
            this.idFuncionario = IdFuncionario;
            this.nomeFuncionario = NomeFunc;



            LblAcessoText.Text = SiglaTipoUsuario;
            LblUsuarioText.Text = NomeFunc;

            if (siglaTipoUsuario == "Ven")
            {

                IconBtnCadastroUsuario.Enabled = false;
                IconBtnLoja.Enabled = false;

                IconBtnCadastroUsuario.ForeColor = Color.White;
                IconBtnProduto.ForeColor = Color.White;

                IconBtnWindows.Focus();

            }
        }


        private void WFPrincipalView_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'estoqueDataSet.NtVenda'. Você pode movê-la ou removê-la conforme necessário.
            // this.ntVendaTableAdapter.Fill(this.estoqueDataSet.NtVenda);

            HabilitarBotoesWindows(false);
            HabilitarBotoesUsuarios(false);
            HabilitarBotoesProdutos(false);
            HabilitarBotoesLojas(false);
            GerarGrafico();
            GerarGraficoColunas();
            AtualizarProgressBar();
            //btnMaximize.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Adicione código personalizado para confirmar o fechamento ou realizar outras ações.
            DialogResult result = MessageBox.Show("Deseja realmente sair?", "Confirmação", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancela o fechamento se o usuário escolher 'No'.
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]


        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //Methods


        // =============== CIRCULOS PROGRESSBAR ===============
        public void AtualizarProgressBar()
        {
            // Contar produtos
            int totalProdutos = ContarProdutos();
            bunifuCircleProgressbarProduto.Value = totalProdutos;

            // Contar vendas
            //int totalVendas = ContarVendas();
           // bunifuCircleProgressbarVenda.Value = totalVendas;
            try
            {
                NtVendaController ntvendaController = new NtVendaController();
                int totalVendas = ntvendaController.ContarVendasController();
                // Definir a meta de vendas
                int metaVendas = 50;
                // Calcular a porcentagem
                double porcentagemVendas = (totalVendas / (double)metaVendas) * 100;
                // Ajustar o valor máximo da ProgressBar (caso necessário)
                bunifuCircleProgressbarVenda.MaxValue = 100;
                // Atualizar a Bunifu Circle Progress Bar com a porcentagem calculada
                bunifuCircleProgressbarVenda.Value = Convert.ToInt32(porcentagemVendas);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar a ProgressBar de vendas: {ex.Message}");
            }

            // Contar clientes
            int totalClientes = ContarClientes();
            bunifuCircleProgressbarCliente.Value = totalClientes;
        }



        #region Métodos Total
        // ================== ÁREA DE USUÁRIO ================
        private void ConfigureTimerkUsuários()
        {
            // Cria e configura o Timer
            Timer = new Timer();
            //Timer.Interval = 15000; // 15 segundos em milissegundos
            Timer.Interval = 1; // 15 segundos em milissegundos
            Timer.Tick += new EventHandler(OnTimerTickUsuários); // Associa o evento Tick ao método OnTimerTick
            Timer.Start(); // Inicia o Timer
        }
        private void OnTimerTickUsuários(object sender, EventArgs e)
        {
            int userCount = ContarUsuarios();
            // Aqui você pode fazer algo com a contagem de usuários, como atualizar a interface do usuário
            LblTotalNumUsuario.Text = userCount.ToString();
        }
        public int ContarUsuarios()
        {
            try
            {
                UsuarioController usurioController = new UsuarioController();
                int totalUsuarios = usurioController.ContarUsuariosController();
                return totalUsuarios;
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                MessageBox.Show($"Erro: {ex.Message}");
                return 0;
            }
        }


        // ================== ÁREA DE CLIENTES ================
        private void ConfigureTimerkClientes()
        {
            // Cria e configura o Timer
            Timer = new Timer();
            //Timer.Interval = 15000; // 15 segundos em milissegundos
            Timer.Interval = 1; // 15 segundos em milissegundos
            Timer.Tick += new EventHandler(OnTimerTickClientes); // Associa o evento Tick ao método OnTimerTick
            Timer.Start(); // Inicia o Timer
        }
        private void OnTimerTickClientes(object sender, EventArgs e)
        {
            int clienteCount = ContarClientes();
            // Aqui você pode fazer algo com a contagem de clientess, como atualizar a interface do usuário
            LblTotalNumCliente.Text = clienteCount.ToString();
        }
        public int ContarClientes()
        {
            try
            {
                ClienteController clienteController = new ClienteController();
                int totalClientes = clienteController.ContarClientesController();
                return totalClientes;
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                MessageBox.Show($"Erro: {ex.Message}");
                return 0;
            }
        }


        // ================== ÁREA DE PRODUTO ================
        private void ConfigureTimerkProdutos()
        {
            // Cria e configura o Timer
            Timer = new Timer();
            //Timer.Interval = 15000; // 15 segundos em milissegundos
            Timer.Interval = 1; // 15 segundos em milissegundos
            Timer.Tick += new EventHandler(OnTimerTickProdutos); // Associa o evento Tick ao método OnTimerTick
            Timer.Start(); // Inicia o Timer
        }
        private void OnTimerTickProdutos(object sender, EventArgs e)
        {
            int userCount = ContarProdutos();
            // Aqui você pode fazer algo com a contagem de usuários, como atualizar a interface do usuário
            LblTotalNumProduto.Text = userCount.ToString();
        }
        public int ContarProdutos()
        {
            try
            {
                ProdutoController produtoController = new ProdutoController();
                int totalProdutos = produtoController.ContarProdutosController();
                return totalProdutos;
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                MessageBox.Show($"Erro: {ex.Message}");
                return 0;
            }
        }

        // ================== ÁREA DE VENDAS ================
        private void ConfigureTimerkVendas()
        {
            // Cria e configura o Timer
            Timer = new Timer();
            //Timer.Interval = 15000; // 15 segundos em milissegundos
            Timer.Interval = 1; // 15 segundos em milissegundos
            Timer.Tick += new EventHandler(OnTimerTickVendas); // Associa o evento Tick ao método OnTimerTick
            Timer.Start(); // Inicia o Timer
        }
        private void OnTimerTickVendas(object sender, EventArgs e)
        {
            int vendaCount = ContarVendas();
            // Aqui você pode fazer algo com a contagem de usuários, como atualizar a interface do usuário
            LblTotalNumVenda.Text = vendaCount.ToString();
        }
        public int ContarVendas()
        {
            try
            {
                NtVendaController ntvendaController = new NtVendaController();
                int totalVendas = ntvendaController.ContarVendasController();
                return totalVendas;
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                MessageBox.Show($"Erro: {ex.Message}");
                return 0;
            }
        }
        #endregion Métodos



        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (IconButton)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (IconButton)btnSender;

                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //   btnCloseChildForm.Visible = true;
                    IconBtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
                    IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);

                }
            }
        }



        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(IconButton))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "Página Inicial";
            panelTitleBar.BackColor = Color.FromArgb(123, 207, 233);
            panelLogo.BackColor = Color.FromArgb(86, 144, 163);
            currentButton = null;
            // btnCloseChildForm.Visible = false;
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        #region ============= METODOS DE EXIBICOES DE BOTOES MENU =============

        private void HabilitarBotoesWindows(bool boolVisillity)
        {
            IconBtnCliente.Visible = boolVisillity;
            IconBtnFuncionario.Visible = boolVisillity;
            IconBtnFornecedor.Visible = boolVisillity;
            IconBtnCargo.Visible = boolVisillity;
            IconBtnSituacao.Visible = boolVisillity;
            IconBtnEstado.Visible = boolVisillity;
            IconBtnBairro.Visible = boolVisillity;
            IconBtnCidade.Visible = boolVisillity;
            IconBtnSalario.Visible = boolVisillity;
            IconBtnTipoTelefone.Visible = boolVisillity;
            IconBtnEmpresa.Visible = boolVisillity;
            IconBtnSocio.Visible = boolVisillity;

        }



        private void HabilitarBotoesUsuarios(bool boolVisillity)
        {
            IconBtnNovoUsuario.Visible = boolVisillity;
            IconBtnTipoUsuario.Visible = boolVisillity;
        }


        private void HabilitarBotoesProdutos(bool boolVisillity)
        {
            IconBtnNovoProduto.Visible = boolVisillity;
            IconBtnFatur.Visible = boolVisillity;
            IconBtnConsultaFatura.Visible = boolVisillity;
        }

        private void HabilitarBotoesLojas(bool boolVisillity)
        {
            IconBtnLoja.Visible = boolVisillity;
            IconBtnSubLoja.Visible = boolVisillity;
        }




        #endregion ============= METODOS DE EXIBICOES DE BOTOES MENU =============


        #region Terminar Sessão

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Hide();
            WFLoginView l = new WFLoginView();
            l.ShowDialog();
            l.Dispose();

            Application.Exit();
        }
        #endregion Terminar Sessão

        #region BOTOES


        private void IconBtnCadastroUsuario_Click(object sender, EventArgs e)
        {
            if (!boolVisillity)
            {
                HabilitarBotoesLojas(false);
                HabilitarBotoesWindows(false);
                HabilitarBotoesProdutos(false);
                HabilitarBotoesUsuarios(true);
            }
            else
            {
                HabilitarBotoesUsuarios(false);
            }
            IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);
           //BtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnProduto.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnLoja.BackColor = Color.FromArgb(31, 31, 58);
        }

        // Método para arredondar as bordas de um formulário
        private static void ArredondaBordas(Form form, int borderRadius)
        {
           // form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }

        private void IconBtnProduto_Click(object sender, EventArgs e)
        {
            if (!boolVisillity)
            {
                HabilitarBotoesLojas(false);
                HabilitarBotoesUsuarios(false);
                HabilitarBotoesWindows(false);
                HabilitarBotoesProdutos(true);
            }
            else
            {
                HabilitarBotoesProdutos(false);
            }
            IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnProduto.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnLoja.BackColor = Color.FromArgb(31, 31, 58);
        }

        private void IconBtnLoja_Click(object sender, EventArgs e)
        {
            if (!boolVisillity)
            {

                HabilitarBotoesUsuarios(false);
                HabilitarBotoesProdutos(false);
                HabilitarBotoesWindows(false);
                HabilitarBotoesLojas(true);
            }
            else
            {
                HabilitarBotoesLojas(false);
            }
            IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnProduto.BackColor = Color.FromArgb(31, 31, 58);
        }


        private void BtnWindows_Click(object sender, EventArgs e)
        {
            if (!boolVisillity)
            {
                HabilitarBotoesLojas(false);
                HabilitarBotoesUsuarios(false);
                HabilitarBotoesProdutos(false);
                HabilitarBotoesWindows(true);
            }
            else
            {
                HabilitarBotoesWindows(false);
            }
            IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnProduto.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnLoja.BackColor = Color.FromArgb(31, 31, 58);
        }





        private void BtnDashboard_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();

            HabilitarBotoesUsuarios(false);
            HabilitarBotoesWindows(false);
            HabilitarBotoesProdutos(false);
            IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnProduto.BackColor = Color.FromArgb(31, 31, 58);
        }




        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();

            HabilitarBotoesUsuarios(false);
            HabilitarBotoesWindows(false);
            HabilitarBotoesProdutos(false);
            IconBtnWindows.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnCadastroUsuario.BackColor = Color.FromArgb(31, 31, 58);
            IconBtnProduto.BackColor = Color.FromArgb(31, 31, 58);
        }


        private void IconBtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                //this.WindowState = FormWindowState.Maximized;
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void bntMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButtonMaterial_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFMaterialView(), sender);
        }


        private void IconBtnSalario_Click(object sender, EventArgs e)
        {

        }
        private void IconBtnEmpresa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFEmpresaView(), sender);
        }

        private void IconBtnCliente_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFClienteView(), sender);
        }

        //  OpenChildForm(new View.WFClienteView(), sender);

        private void IconBtnFuncionario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFFuncionarioView(), sender);
        }
        //OpenChildForm(new View.WFFuncionarioView(), sender);

        private void IconBtnFornecedor_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFFornecedorView(), sender);
        }
        // OpenChildForm(new View.WFFornecedorView(), sender);


        private void IconBtnSocio_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFSocioView(), sender);
        }
        // OpenChildForm(new View.WFSocioView(), sender);


        private void IconBtnCargo_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFCargoView(), sender);
        }
        // OpenChildForm(new View.WFCargoView(), sender);


        private void IconBtnEstado_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFEstadoView(), sender);
        }
        // OpenChildForm(new View.WFEstadoView(), sender);


        private void IconBtnCidade_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFCidadeView(), sender);
        }
        //   OpenChildForm(new View.WFCidadeView(), sender);


        private void IconBtnBairro_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFBairroView(), sender);
        }
        // OpenChildForm(new View.WFBairroView(), sender);


        private void IconBtnSituacao_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFSituacaoView(), sender);
        }
        // OpenChildForm(new View.WFSituacaoView(), sender);

        private void BtnSalario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFSalarioView(), sender);
        }
        //OpenChildForm(new View.WFSalarioView(), sender);


        private void IconBtnTipoTelefone_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFTipoTelefoneView(), sender);
        }
        // OpenChildForm(new View.WFTipoTelefoneView(), sender);


        private void IconBtnNovoUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFUsuarioView(), sender);
        }
        // OpenChildForm(new View.WFUsuarioView(), sender);


        private void IconBtnTipoUsuario_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFTipoUsuarioView(), sender);
        }
        // OpenChildForm(new View.WFTipoUsuarioView(), sender);

        private void IconBtnNovoProduto_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFProdutoView(), sender);
        }


        //OpenChildForm(new View.WFProdutoView(), sender);


        private void IconBtnFatur_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFVendaProdutoView(this.idTipoUsuario, this.login, this.siglaTipoUsuario, this.nomeFuncionario, this.idFuncionario), sender);
        }
        // OpenChildForm(new View.WFVendaProdutoView(this.idTipoUsuario, this.login, this.siglaTipoUsuario, this.nomeFuncionario, this.idFuncionario), sender);

        private void IconBtnConsultaFatura_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFConsultaNtVendaView(), sender);
        }
        // OpenChildForm(new View.WFConsultaNtVendaView(), sender);

        private void IconBtnSubLoja_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFSubLojaView(), sender);
        }
        // OpenChildForm(new View.WFSubLojaView(), sender);

        private void iconButtonAluguer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new View.WFMateriaAluguerView(this.idTipoUsuario, this.login, this.siglaTipoUsuario, this.nomeFuncionario, this.idFuncionario), sender);
        }

        private void BtnTools_Click(object sender, EventArgs e)
        {
            WFDefinicaoView form = new WFDefinicaoView();
            form.ShowDialog();
            form.Dispose();
        }


        #endregion BOTOES


        #region GRAFICOS

        #region GRAFICOS DE COLUNAS
        public void GerarGraficoColunas()
        {
            NtVendaController nvendasController = new NtVendaController();
            DataTable dtVendasPorMes = nvendasController.GraficoBarraObterDadosController();

            // Limpar gráfico
            ChartGrafic.Series.Clear();
            ChartGrafic.Titles.Clear();
            ChartGrafic.Legends.Clear();

            // Verificar se a área de gráfico já existe
            ChartArea chartArea = ChartGrafic.ChartAreas["ChartArea1"];

            if (chartArea == null)
            {
                // Se não existir, criar nova área do gráfico
                chartArea = new ChartArea("ChartArea1");
                ChartGrafic.ChartAreas.Add(chartArea);
            }

            // Configurar eixo Y
            chartArea.AxisY.Title = "Milhares de Kuanzas";
            chartArea.AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);

            // Criar série para as vendas
            Series seriesVendas = new Series();
            seriesVendas.Name = "Vendas";
            seriesVendas.ChartType = SeriesChartType.Column;

            // Definir a largura das colunas
            seriesVendas["PixelPointWidth"] = "40"; // Ajuste o valor conforme necessário

            ChartGrafic.Series.Add(seriesVendas);

            // Preencher dados no gráfico a partir do DataTable
            foreach (DataRow row in dtVendasPorMes.Rows)
            {
                string nomeMes = row["NomeMes"].ToString();
                double totalVendas = Convert.ToDouble(row["TotalVendas"]);
                ChartGrafic.Series["Vendas"].Points.AddXY(nomeMes, totalVendas);
            }

            // Criar título principal abaixo do gráfico
            Title tituloPrincipal = new Title();
            tituloPrincipal.Font = new Font("Arial", 14, FontStyle.Bold);
            tituloPrincipal.ForeColor = Color.FromArgb(51, 51, 76);
            //tituloPrincipal.Text = "Vendas do ano de " + DateTime.Now.Year.ToString();
            LblGraficoColunas.Text = "Vendas do ano de " + DateTime.Now.Year.ToString();
            tituloPrincipal.DockedToChartArea = "ChartArea1";
            tituloPrincipal.Docking = Docking.Bottom;
            ChartGrafic.Titles.Add(tituloPrincipal);

            // Configurar a legenda
            Legend legend = new Legend();
            ChartGrafic.Legends.Add(legend);
            ChartGrafic.Legends[0].Docking = Docking.Bottom;
            ChartGrafic.Legends[0].Title = "Legenda";

            // Atualizar o gráfico
            ChartGrafic.Invalidate();
        }
        #endregion GRAFICOS DE COLUNAS
        //bunifuCircleProgressbarCliente







        #region GRAFICO CIRCULAR
        private void GerarGrafico()
        {
            /*  NtVendaController nvendasController = new NtVendaController();
              // Obter os dados de vendas por produto do controlador
              DataTable dtVendasPorProduto = nvendasController.GraficoCircularObterTotalVendasController();
              // Título principal do gráfico
              Title titulo = new Title();
              titulo.Font = new Font("Arial", 14, FontStyle.Bold);
              titulo.ForeColor = Color.FromArgb(51, 51, 76);
              titulo.Text = "Vendas Anuais";
              ChartPie.Titles.Add(titulo);
              // Título secundário do gráfico
              Title titulo1 = new Title();
              titulo1.Font = new Font("Arial", 12, FontStyle.Bold);
              titulo1.ForeColor = Color.FromArgb(51, 51, 76);
              titulo1.Text = "Vendas por Produto";
              ChartPie.Titles.Add(titulo1);
              // Adicionando legenda ao gráfico
              ChartPie.Legends.Add("Legenda");
              ChartPie.Legends[0].Title = "Produtos";
              // Definindo a paleta de cores do gráfico
              ChartPie.Palette = ChartColorPalette.EarthTones;
              // Criando séries para o gráfico de pizza
              ChartPie.Series.Clear();
              ChartPie.Series.Add("Vendas");
              ChartPie.Series[0].ChartType = SeriesChartType.Pie;
              // Mostrar valores como rótulos nas fatias do gráfico
              ChartPie.Series[0]["PieLabelStyle"] = "Outside";
              // Preencher dados no gráfico a partir do DataTable
              foreach (DataRow row in dtVendasPorProduto.Rows)
              {
                  string produto = row["Produto"].ToString();
                  double totalVendas = Convert.ToDouble(row["TotalVendas"]);
                  ChartPie.Series[0].Points.AddXY(produto, totalVendas);
              }
              ChartPie.Width = 600;  // Ajuste o valor conforme necessário
              ChartPie.Height = 400; // Ajuste o valor conforme necessário
                                     // Atualizar o gráfico
              // Configurar o gráfico para mostrar apenas os valores numéricos como rótulos nas fatias
              ChartPie.Series[0].IsValueShownAsLabel = true;
              ChartPie.Invalidate();*/


            NtVendaController nvendasController = new NtVendaController();
            // Obter os dados de vendas por produto do controlador
            DataTable dtVendasPorProduto = nvendasController.GraficoCircularObterTotalVendasController();

            // Título principal do gráfico
            Title titulo = new Title();
            titulo.Font = new Font("Arial", 14, FontStyle.Bold);
            titulo.ForeColor = Color.FromArgb(51, 51, 76);
           // titulo.Text = "Produtos Mais Vendidos";
            titulo.DockedToChartArea = "ChartArea1"; // Substitua "ChartArea1" pelo nome correto da sua área de gráfico
            titulo.Docking = Docking.Bottom;
            ChartPie.Titles.Add(titulo);

            // Adicionando legenda ao gráfico
            ChartPie.Legends.Add("Legenda");
            ChartPie.Legends[0].Enabled = true; // Desabilitar a legenda se não for necessária

            // Definindo a paleta de cores do gráfico
            ChartPie.Palette = ChartColorPalette.EarthTones;

            // Criando série para o gráfico de pizza
            ChartPie.Series.Clear();
            ChartPie.Series.Add("Vendas");
            ChartPie.Series[0].ChartType = SeriesChartType.Pie;

            // Mostrar valores como rótulos nas fatias do gráfico
            ChartPie.Series[0]["PieLabelStyle"] = "Disabled"; // Desabilitar os rótulos

            // Preencher dados no gráfico a partir do DataTable
            foreach (DataRow row in dtVendasPorProduto.Rows)
            {
                string produto = row["Produto"].ToString();
                double totalVendas = Convert.ToDouble(row["TotalVendas"]);
                ChartPie.Series[0].Points.AddXY(produto, totalVendas);
            }

            ChartPie.Width = 400;  // Ajuste o valor conforme necessário
            ChartPie.Height = 400; // Ajuste o valor conforme necessário

            ChartPie.Invalidate();

            //==================================================================
            // Criar uma nova legenda (caso ainda não exista)
          /*  if (ChartPie.Legends.Count == 0)
            {
                ChartPie.Legends.Add("Legenda");
            }

            // Configurar o estilo da fonte da legenda
            ChartPie.Legends[0].Font = new Font("Arial", 12f, FontStyle.Bold); // Exemplo: Arial, tamanho 12, negrito
            ChartPie.Legends[0].ForeColor = Color.Black; // Cor da fonte da legenda

            // Habilitar a legenda se não estiver habilitada
            ChartPie.Legends[0].Enabled = true;*/

        }






        #endregion GRAFICO CIRCULAR

        #endregion GRAFICOS


    }
}