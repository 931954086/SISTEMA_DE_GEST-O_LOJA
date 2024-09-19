using SISTEMA_DE_GESTÃO_LOJA.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;



namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class ItemVendaModel
    {
        private int idItemVenda;
        private decimal quantidadeitemvenda;
        private decimal valorUnit;
        private NtVendaModel ntVenda_Model;
        private ProdutoModel produto_Model;
        private List<ItemVendaModel> listaItensVendaModel;


        public ItemVendaModel()
        {
            this.produto_Model = new ProdutoModel();
            this.ntVenda_Model = new NtVendaModel();

        }

        public int IdItemVenda { get => idItemVenda; set => idItemVenda = value; }
        public decimal Quantidadeitemvenda { get => quantidadeitemvenda; set => quantidadeitemvenda = value; }
        public decimal Valorunit { get => valorUnit; set => valorUnit = value; }
        public NtVendaModel Ntvenda_Model { get => this.ntVenda_Model; set => this.ntVenda_Model = value; }
        public ProdutoModel Produto_Model { get => this.produto_Model; set => this.produto_Model = value; }

        public List<ItemVendaModel> ListaItensVendaModel
        {
            get
            {
                if (listaItensVendaModel == null)
                {
                    listaItensVendaModel = new List<ItemVendaModel>();
                }
                return listaItensVendaModel;
            }
            set
            {
                listaItensVendaModel = value;
            }
        }

        public string SomarSubTotalItens(ListView listView, int columnIndex)
        {
            decimal total = 0;

            // Certifique-se de que a coluna especificada existe na ListView
            if (columnIndex >= 0 && columnIndex < listView.Columns.Count)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    // Certifique-se de que há subitens suficientes no item
                    if (item.SubItems.Count > columnIndex)
                    {
                        decimal subTotal;

                        // Tente analisar o valor na coluna especificada como decimal
                        if (decimal.TryParse(item.SubItems[columnIndex].Text, out subTotal))
                        {
                            total += subTotal;
                        }
                        else
                        {
                            // Trate qualquer erro de análise aqui, se necessário
                        }
                    }
                    else
                    {
                        // Lida com o caso em que o item não tem subitens suficientes
                    }
                }
            }
            else
            {
                // Lida com o caso em que o índice da coluna está fora dos limites
            }

            // Converte o total em uma string e a retorna
            return total.ToString();
        }




    }
}

