using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public class PadraoForm
    {
        public static void SettingsForm(Form form)
        {
            form.BackColor = Color.White;
            form.KeyPreview = true;
            form.MaximizeBox = false;
            form.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// Configuração do Botão Minimizar do formulário. Permitir somente para o formulário principal.
        /// Não esquecer de informar na propriedade TAG do form colocando o valor 0 (zero) maiúscula ou minúscula.
        /// </summary>
        /// <param name="form">Passar o parametro com a palavra reservada this.</param>
        public static void BotaoMinimizarForm(Form form)
        {
            if (form.Tag.ToString() != "0")
            {
                form.MinimizeBox = false;
            }
        }
    }
}
