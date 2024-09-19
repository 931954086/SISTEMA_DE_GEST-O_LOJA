using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class ItemAluguerModel
    {
        private int idItemAluguer;
        private decimal quantidadeItemAluguer;
        private decimal valorUnit;
        private AluguerModel  aluguerModel;
        private MaterialModel materialModel;
        private List<ItemAluguerModel> listaItensAluguerModel;

        public ItemAluguerModel()
        {
            this.aluguerModel = new AluguerModel();
            this.materialModel = new MaterialModel();
        }

        public int IdItemAluguer { get => idItemAluguer; set => idItemAluguer = value; }
        public decimal QuantidadeItemAluguer { get => quantidadeItemAluguer; set => quantidadeItemAluguer = value; }
        public decimal ValorUnit { get => valorUnit; set => valorUnit = value; }
        public AluguerModel  AluguerModel { get => this.aluguerModel; set => this.aluguerModel = value; }
        public MaterialModel MaterialModel { get => this.materialModel; set => this.materialModel = value; }
        public List<ItemAluguerModel> ListaItensAluguerModel
        {
            get
            {
                if (listaItensAluguerModel == null)
                {
                    listaItensAluguerModel = new List<ItemAluguerModel>();
                }
                return listaItensAluguerModel;
            }
            set
            {
                listaItensAluguerModel = value;
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
                        if (decimal.TryParse(item.SubItems[columnIndex].Text, out decimal subTotal))
                        {
                            total += subTotal;
                        }
                        else
                        {
                            // Trate qualquer erro de análise aqui
                            throw new FormatException($"O valor '{item.SubItems[columnIndex].Text}' não pôde ser convertido para decimal.");
                        }
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("O item não contém subitens suficientes.");
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(columnIndex), "O índice da coluna está fora dos limites.");
            }
            return total.ToString("F2"); // Retorna o total com duas casas decimais
        }


    }
}
