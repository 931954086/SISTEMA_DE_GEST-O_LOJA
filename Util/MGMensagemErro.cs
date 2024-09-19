using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public static class MGMensagemErro
    {
        #region === Variáveis ===

        private static string mAviso;
        private static string mTipo;
        private static string UMsg = string.Empty;

        #endregion

        #region === Propriedades ===

        public static string Aviso { get; set; }

        public static string Tipo { get; set; }

        #endregion

        #region === Métodos ===

        /// <summary>
        /// Monta a mensagem que será exibida para o usuário.
        /// </summary>
        /// <param name="msg">Texto da mensagem.</param>
        /// <param name="strAviso">Número identificador da mensagem.</param>
        /// <param name="chrTipo">Identifica o ícone da mensagem: E para mensagem de erro, I para informação, X para exclamação e A para aviso.</param>
        public static void MensagensErro(string msg, string strAviso, string chrTipo)
        {
            UMsg = msg;
            Aviso = strAviso;
            Tipo = chrTipo;
            if (msg.Trim().Length != 0)
                ExibirMSG();
            else
                MessageBox.Show("Informe o texto do erro", "Aviso nº Adm2020", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }



        /// <summary>
        /// Monta a mensagem para exibir para o usuario.
        /// Último parametro do método MensagemsErro (E)rro, (I)nformação, E(x)clamação ou (A)tenção
        /// </summary>
        private static void ExibirMSG()
        {
            Cursor.Current = Cursors.Default;
            switch (Tipo.ToUpper())
            {
                case "E":
                    // Erro
                    MessageBox.Show("Erro: " + UMsg, "Erro nº " + Aviso, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    break;
                case "I":
                    // Information
                    MessageBox.Show("Atenção: " + UMsg, "Informação nº " + Aviso, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    break;
                case "X":
                    // Exclamation
                    MessageBox.Show("Atenção: " + UMsg, "Aviso nº " + Aviso, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    break;
                case "A":
                    // Aviso
                    MessageBox.Show("Atenção: " + UMsg, "Aviso nº " + Aviso, MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    break;
            }
            //Gravar arquivo de Log aqui
        }
        #endregion
    }
}
