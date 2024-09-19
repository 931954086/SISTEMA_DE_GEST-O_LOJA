using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public static class EstilizarDataGridView
    {
        /// <summary>
        /// Define a propriedade Width da coluna do DataGridView.
        /// </summary>
        /// <param name="dtg">Objeto DataGridView</param>
        /// <param name="larguraColuna">Valor da largura da coluna.</param>
        /// <param name="nameHeader">Array com o nome dos campos da consulta respectivos as colunas do DataGridView.</param>
        public static void LarguraColuna(DataGridView dtg, int[] larguraColuna, string[] nameHeader)
        {
            int index = 0;
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                if (Array.Exists(nameHeader, element => element == coluna.Name))
                {
                    coluna.Width = larguraColuna[index];
                }
                else
                {
                    coluna.Width = 0;
                }
                index++;
            }
        }

        /// <summary>
        /// Define a largura das colunas do DataGridView. Deve ser chamada após a definição das colunas.
        /// </summary>
        /// <param name="dtg">Objeto DataGridView.</param>
        /// <param name="larguraColuna">Array de inteiros com o valor da largura das colunas do DataGridView.</param>
        public static void LarguraColuna(DataGridView dtg, int[] larguraColuna)
        {
            int index = 0;
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                if (index <= larguraColuna.Length - 1)
                {
                    coluna.Width = larguraColuna[index];
                }
                index++;
            }
        }

        /// <summary>
        /// Define quais colunas serão visíveis na tela.
        /// </summary>
        /// <param name="dtg">DataGridView</param>
        /// <param name="nameHeader">Array com o nome dos campos do resultado da consulta de preenchimento
        /// do DataGridView.</param>
        public static void ColunaVisivel(DataGridView dtg, string[] nameHeader)
        {
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                if (Array.Exists(nameHeader, element => element == coluna.Name))
                {
                    coluna.Visible = true;
                }
                else
                {
                    coluna.Visible = false;
                }
            }
        }

        public static void DefinirVisibilidadeDataGridView(DataGridView dtg, List<string> ListaColunasVisiveis)
        {
            //define quais são as colunas visíveis
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                if (ListaColunasVisiveis.Contains(coluna.Name))
                {
                    coluna.Visible = true;
                }
                else
                {
                    coluna.Visible = false;
                }
            }
        }

        public static void DefinirCabecalhoDataGridView(DataGridView dtg, List<string> ListaCabecalho)
        {
            int index = 0;
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                if (coluna.Visible)
                {
                    coluna.HeaderText = ListaCabecalho[index];


                }
                index++;
            }
        }

        private static int CalcularPercentagem(DataGridView dtg, int percentagem)
        {
            // 20 é a largura em pixels da barra de rolagem vertical
            return (percentagem * (dtg.Width - 20)) / 100;
        }

        public static void DefinirLargurasDataGridView(DataGridView dtg, List<int> ListaLarguras)
        {
            int index = 0;
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                if (coluna.Visible)
                {
                    coluna.Width = CalcularPercentagem(dtg, ListaLarguras[index]);
                    index++;
                }
            }
        }

        /// <summary>
        /// Configuração das propriedades de estilo do DataGridView.
        /// </summary>
        /// <param name="dtg">DataGridView</param>
        /// <param name="nameHeader">Array com os nome das colunas do DataGridView que vão aparecer na tela.</param>
        /// <param name="colVisivel">Array que define as colunas que vão aparecer na tela para o usuário.</param>
        public static void EstiloTituloColuna(DataGridView dtg, string[] nameHeader, bool[] colVisivel = null)
        {
            //Propriedades alteradas do datagrid
            dtg.BorderStyle = BorderStyle.None;
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtg.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtg.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtg.BackgroundColor = Color.White;

            dtg.EnableHeadersVisualStyles = false;
            dtg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.MultiSelect = false;


            int numcol = nameHeader.Length;
            for (int i = 0; i < numcol - 1; i++)
            {

                dtg.Columns[i].HeaderText = nameHeader[i];
                dtg.Columns[i].ReadOnly = true;

                if (colVisivel != null)
                {
                    dtg.Columns[i].Visible = colVisivel[i];
                }
                // Alinha Celula
                if (i == 0)
                {
                    dtg.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                    dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        public static void EstiloTituloColuna(DataGridView dtg, List<string> ListaCabecalho, List<string> ListaColunasVisiveis)
        {
            //Propriedades alteradas do datagrid
            dtg.BorderStyle = BorderStyle.None;
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtg.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtg.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtg.BackgroundColor = Color.White;

            dtg.EnableHeadersVisualStyles = false;
            dtg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.MultiSelect = false;

            //int numcol = nameHeader.Length;
            //for (int i = 0; i < numcol - 1; i++)
            //{
            //    dtg.Columns[i].HeaderText = nameHeader[i];
            //    dtg.Columns[i].ReadOnly = true;

            //    if (colVisivel != null)
            //    {
            //        dtg.Columns[i].Visible = colVisivel[i];
            //    }
            //    // Alinha Celula
            //    if (i == 0)
            //    {
            //        dtg.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    }
            //    else
            //        dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //}
        }

        public static void EstiloDataGridView(DataGridView dtg) ///, string[] nameHeader, bool[] colVisivel = null)
        {
            //Propriedades alteradas do datagrid
            dtg.BorderStyle = BorderStyle.None;
            dtg.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dtg.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dtg.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dtg.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dtg.BackgroundColor = Color.White;

            dtg.EnableHeadersVisualStyles = false;
            dtg.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dtg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dtg.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.MultiSelect = false;
            //dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            int i = 0;
            foreach (DataGridViewColumn coluna in dtg.Columns)
            {
                dtg.Columns[i].ReadOnly = true;
                if (i == 0)
                {
                    dtg.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else
                {
                    dtg.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
                i++;
            }
        }
    }
}
