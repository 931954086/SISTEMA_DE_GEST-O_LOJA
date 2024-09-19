using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public static class ConfigurarListView
    {
        /// <summary>
        /// Configuração padrão do ListView
        /// Passar Tamanho e nome da coluna juntos
        /// Ex: "160-Nome" (Tamanho e nome do campo) no arraylist
        /// </summary>
        /// <param name="lvw">Objeto ListView.</param>
        /// <param name="arrList">ArrayList com a largura e o nome do cabeçalho da Coluna.</param>
        /// <param name="corFundo">Cor do fundo do Listview.</param>
        /// <param name="bolchkBox">Booleana que indica se o listiview vai conter o chdckBox.</param>
        public static void ConfigListView(ListView lvw, ArrayList arrList, Color corFundo, bool bolchkBox)
        {
            //Configura propriedades do ListView
            lvw.Clear();
            lvw.View = System.Windows.Forms.View.Details;
            lvw.LabelEdit = false;
            lvw.AllowColumnReorder = false;
            lvw.CheckBoxes = bolchkBox;
            lvw.FullRowSelect = true;
            lvw.GridLines = true;
            lvw.Sorting = SortOrder.None;
            lvw.BackColor = corFundo;
            lvw.MultiSelect = false;
            lvw.Activation = ItemActivation.Standard;
            lvw.ShowItemToolTips = true;

            string strNome = null;
            string[] strArr = null;

            if (arrList != null)
            {
                //Cria colunas com Nome e Largura
                for (Int16 I = 0; I <= arrList.Count - 1; I++)
                {
                    ColumnHeader Coluna = new ColumnHeader();

                    strNome = arrList[I].ToString();
                    char[] splitchar = { '-' };

                    strArr = strNome.Split(splitchar);

                    Coluna.Text = strArr[1];
                    Coluna.Width = Convert.ToInt32(strArr[0]);

                    lvw.Columns.Add(Coluna.Text, Coluna.Width, HorizontalAlignment.Left);
                }
            }
        }

        /// <summary>
        /// Colorir linhas intercaladas
        /// </summary>
        /// <param name="LV">Controle ListView.</param>
        public static void ColorirLinhasListView(ListView LV, Color pCor)
        {
            int i = 0;

            while (i < LV.Items.Count)
            {
                if (i % 2 == 0)
                {
                    LV.Items[i].BackColor = pCor;
                }
                i += 1;
            }
        }

        /// <summary>
        /// Verifica se existe o valor em uma coluna do ListView
        /// </summary>
        /// <param name="lvi">Propriedade Name do c.ontrole ListView</param>
        /// <param name="coluna">Índice da coluna do ListView.</param>
        /// <param name="valor">Valor procurado na coluna indicada.</param>
        /// <returns>Boolean.</returns>
        public static Boolean LocalizarValorEmUmaColuna(ListView lvi, int coluna, int valor)
        {
            foreach (ListViewItem item in lvi.Items)
            {
                if (item.SubItems[coluna].Text.ToLower().Contains(valor.ToString().ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Remove as linhas com checkbox marcado
        /// </summary>
        /// <param name="lvw">ListBox</param>
        public static void RemoverLinhaCheckBox(ListView lvw)
        {
            lvw.BeginUpdate();
            for (Int32 i = 0; i < lvw.Items.Count; i++)
            {
                if (lvw.Items[i].Checked == true)
                    lvw.Items.RemoveAt(i);
            }
            lvw.EndUpdate();
            lvw.Refresh();
        }
    }
}
