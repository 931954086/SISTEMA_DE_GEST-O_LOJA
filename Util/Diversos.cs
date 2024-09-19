using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public static class Diversos
    {
        /// <summary>
        /// Mascarar campo MaskedTextBox
        /// </summary>
        /// <param name="mask">CPF ou CNPJ.</param>
        /// <param name="cpf">Boolean true para CPF.</param>
        public static void MascararCpfCnpj(MaskedTextBox mask, Boolean cpf)
        {
            mask.Text = string.Empty;
            mask.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            mask.Mask = "";
            if (cpf)
            {
                mask.Mask = "000,000,000-00";
            }
            else
            {
                mask.Mask = "00,000,000/0000-00";
            }
        }

        /// <summary>
        /// Retira a mascara de formatação do componente mascedtextbox
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static string TextNoFormatting(MaskedTextBox mask)
        {
            mask.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            String retString = mask.Text;
            mask.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            return retString;
        }

        public static void ControlBackColorGot(object sender, Color? c = null)
        {
            try
            {
                switch (sender.GetType().Name.ToUpper())
                {
                    case "TEXTBOX":
                        TextBox x = ((TextBox)sender);
                        x.BackColor = c ?? Color.LightCyan;
                        break;
                    case "MASKEDTEXTBOX":
                        MaskedTextBox m = ((MaskedTextBox)sender);
                        m.BackColor = c ?? Color.LightCyan;
                        break;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ControlBackColorLost(object sender, Color? c = null)
        {
            try
            {
                switch (sender.GetType().Name.ToUpper())
                {
                    case "TEXTBOX":
                        TextBox x = ((TextBox)sender);
                        x.BackColor = c ?? Color.White;
                        break;
                    case "MASKEDTEXTBOX":
                        MaskedTextBox m = ((MaskedTextBox)sender);
                        m.BackColor = c ?? Color.White;
                        break;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void PrimeiraLetraMaiuscula_Leave(object sender)
        {
            switch (sender.GetType().Name.ToUpper())
            {
                case "TEXTBOX":
                    {
                        ((TextBox)sender).Text = Diversos.PrimeirasMaiusculas(((TextBox)sender).Text.Trim());
                        break;
                    }
                case "MASKEDTEXTBOX":
                    {
                        ((MaskedTextBox)sender).Text = Diversos.PrimeirasMaiusculas(((TextBox)sender).Text.Trim());
                        break;
                    }
            }
        }

        public static string PrimeirasMaiusculas(string campo)
        {
            //Todo o campo para minúsculo
            campo = campo.ToLower();

            // E retorna a primeira letra de cada palavra para maiúlculo
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            //return cultureInfo.TextInfo.ToTitleCase(campo);

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(campo.ToLower());
        }

        /// <summary>
        /// Altera somente a primeira letra do texto passado no parametro input.
        /// </summary>
        /// <param name="input">Texto a alterar.</param>
        /// <returns>Somente a primeira letra do texto (com mais de uma letra) é alterada para maiúscula.</returns>
        public static string FirstCharToUpper(this string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                return input.Length > 1 ? char.ToUpper(input[0]) + input.Substring(1) : input.ToUpper();
            }
            return string.Empty;
        }

        public static string PrimeiraLetraMaiusculaNomesProprios(this string text)
        {
            char[] delimiterChars = { ' ', ',', ':', '\t', '<', '>' };
            string[] words = text.Split(delimiterChars);
            string txt = string.Empty;

            foreach (var word in words)
            {
                txt += word.Trim().Length > 2 ? char.ToUpper(word[0]) + word.Substring(1) + " " : word.ToLower() + " ";
            }
            return txt.Trim();
        }

        /// <summary>
        /// Controla o Número de Telefone Fixo ou Fax
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>Retorna True caso o número estiver correto.</returns>
        public static bool ValidarNumeroTelefone(string strNumero)
        {
            try
            {
                strNumero = (strNumero.Replace("-", "").Replace("_", "")).Trim();
                if (strNumero.Substring(0, 1) == "9" || strNumero.Substring(0, 1) == "8" ||
                    strNumero.Substring(0, 1) == "7" || strNumero.Substring(0, 1) == "6")
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ValidarNumeroCelular(string strNumero)
        {
            try
            {
                strNumero = (strNumero.Replace("-", "").Replace("_", "")).Trim();
                if (strNumero.Substring(0, 1) != "9" && strNumero.Substring(0, 1) != "8" &&
                    strNumero.Substring(0, 1) != "7" && strNumero.Substring(0, 1) != "6")
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Formatação do campo TextBox com duas casas decimais
        /// </summary>
        /// <param name="strValor">Valor a formatar.</param>
        /// <returns>Valor formatado com duas casas decimais.</returns>
        public static string FormataStringDecimal2(string strValor)
        {
            try
            {
                if (strValor.Length == 0)
                {
                    strValor = "0";
                    return Decimal.Parse(strValor).ToString("N2");
                }
                else
                {
                    return Decimal.Parse(strValor).ToString("N2");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string FormataStringInt2(string strValor)
        {
            try
            {
                if (string.IsNullOrEmpty(strValor))
                {
                    strValor = "0";
                    return int.Parse(strValor).ToString("N0");
                }
                else
                {
                    return int.Parse(strValor).ToString("N0");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Foramatação de valores decimais para TextBox.
        /// </summary>
        /// <param name="strValor">Valor informado para formatação.</param>
        /// <param name="numero">Número de casas decimais. Padrão igual a 2 casas decimais.</param>
        /// <returns>Valor formatado com o número de casas decimais.</returns>
        public static string FormataStringDecimal(string strValor, int numero = 2)
        {
            string casas = "N" + numero.ToString();
            if (strValor.Length == 0)
            {
                strValor = "0";
                return Decimal.Parse(strValor).ToString(casas);
            }
            else
            {
                return Decimal.Parse(strValor).ToString(casas);
            }
        }

        /// <summary>
        /// Verifica se a tecla digitado no controle TextBox foi um número, uma vírgula, a tecla backspace ou a tecla del.
        /// </summary>
        /// <param name="sender">Objeto</param>
        /// <param name="e">KeyPressEventArgs do TextBox</param>
        /// <returns></returns>
        public static Boolean PermiteSoNumeros(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(Convert.ToChar(e.KeyChar)) && e.KeyChar != 8 && e.KeyChar != 44)
                {
                    e.Handled = true;
                }
                else if (e.KeyChar == 44)
                {
                    TextBox txt = (TextBox)sender;
                    if (txt.Text.Contains(","))
                    {
                        e.Handled = true;
                    }
                }
                return e.Handled;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ConverteVirgulaToPonto(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 44) //virgula
            {
                TextBox txt = (TextBox)sender;
                if (txt.Text.Contains(","))
                {
                    txt.Text = ".";
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// Posiciona o cursor a direita do campo. Utillizar no evento Click do TextBox ou MaskEdTextbox.
        /// </summary>
        /// <param name="sender">Objeto.</param>
        /// <param name="e">EventArgs</param>
        public static void PosicionaCursorADireita(object sender, EventArgs e)
        {
            try
            {
                switch (sender.GetType().Name.ToUpper())
                {
                    case "TEXTBOX":
                        TextBox x = ((TextBox)sender);
                        x.SelectionStart = x.Text.Length + 1;
                        break;
                    case "MASKEDTEXTBOX":
                        MaskedTextBox m = ((MaskedTextBox)sender);
                        m.SelectionStart = m.Text.Length + 1;
                        break;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Habilita ou desabilita controles TextBox, MaskedTextBox ou ComboBox. Método recursivo.
        /// </summary>
        /// <param name="Owner">Objeto Form.</param>
        /// <param name="Controles">Coleção de controles do formulário.</param>
        /// <param name="bolhabil">Boolean.</param>
        public static void EnableDisableControles(Form Owner, Control.ControlCollection Controles, Boolean bolhabil)
        {
            foreach (Control ctrl in Controles)
            {
                if (ctrl is Panel || ctrl is GroupBox ||
                    ctrl is TabControl || ctrl is SplitContainer) //Se o controle é um Container, Chamar a Função Recursivamente
                {
                    EnableDisableControles(Owner, ctrl.Controls, bolhabil);
                }
                else if (ctrl is TextBox || ctrl is MaskedTextBox || ctrl is ComboBox)
                {
                    ctrl.Enabled = bolhabil;
                }
            }
        }

        /// <summary>
        /// Verifica se a ComboBox tem elementos.
        /// </summary>
        /// <param name="cbo">ComboBox</param>
        /// <returns>Verdadeiro se existir.</returns>
        public static Boolean ExisteItensComboBox(System.Windows.Forms.ComboBox cbo)
        {
            try
            {
                if (cbo.Items.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Usar os métodos dessa classe dentro do evento KeyPress do TextBox.
        /// </summary>
        public static class ValidacaoTextBox
        {
            public static void SoNumeros(KeyPressEventArgs e)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

            public static void ValidarNumerosDecimail(TextBox sender, KeyPressEventArgs e)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (e.KeyChar.ToString().Equals(","))
                {
                    if (e.KeyChar == 44)
                    {
                        if (sender.Text.Contains(",") || sender.Text.Contains("."))
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
                else if (e.KeyChar.ToString().Equals("."))
                {
                    if (e.KeyChar == 46)
                    {
                        if (sender.Text.Contains(".") || sender.Text.Contains(","))
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }

            public static void SoLetras(KeyPressEventArgs e)
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
    }
}
