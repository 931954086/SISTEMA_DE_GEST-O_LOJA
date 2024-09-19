using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.View
{
    public partial class ProgessBarView : Form
    {
        private int i = 0;
      

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


        public ProgessBarView()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            circularProgressBar1.Value = 0;
            // Define o intervalo do timer e o inicia
            timer1.Interval = 100; // Define um intervalo de 100 milissegundos
            timer1.Start(); // Inicia o timer
            this.Load += new System.EventHandler(this.ProgessBar_Load);
        }

        private void ProgessBar_Load(object sender, EventArgs e)
        {
            // Define o intervalo do timer e o inicia
            timer1.Interval = 100; // Define um intervalo de 100 milissegundos
            timer1.Start(); // Inicia o timer
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Variável de incremento, ajuste conforme necessário
            int increment = 1;

            // Se o valor do progress bar for menor que 100, incrementa
            if (circularProgressBar1.Value < 100)
            {
                circularProgressBar1.Value += increment;

                // Atualiza os três pontos na label conforme o valor do progress bar
                SetLabelDots(circularProgressBar1.Value);

                // Atualiza o texto do progress bar para mostrar o progresso em %
                circularProgressBar1.Text = circularProgressBar1.Value.ToString() + "%";
            }
            else if (circularProgressBar1.Value >= 100)
            {
                timer1.Enabled = false;  // Desabilita o timer
                timer1.Dispose();        // Libera os recursos do timer

                WFLoginView view = new WFLoginView();  // Cria a nova view de login
                ArredondaBordas(view, 10);
                view.Show();  // Abre a nova view
               //this.Close();  // Fecha apenas a ProgressBarView
                this.Hide();
            }
        }

        // Método para atualizar a label com os pontos
        private void SetLabelDots(int value)
        {
            int dotsCount = (value % 4) + 1; // Gera o número de pontos com base no valor
            string dots = new string('.', dotsCount); // Cria a string de pontos

            // Atualiza a label de forma thread-safe
            if (LbelTresPontos.InvokeRequired)
            {
                LbelTresPontos.Invoke((MethodInvoker)delegate { LbelTresPontos.Text = dots; });
            }
            else
            {
                LbelTresPontos.Text = dots;
            }
        }


        // Método para arredondar as bordas de um formulário
        private static void ArredondaBordas(Form form, int borderRadius)
        {
            form.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, form.Width, form.Height, borderRadius, borderRadius));
        }


    }
}
