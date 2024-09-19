using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class ItemAgendamentoModel
    {
        private int idItemAgendamento;
        private decimal quantidadeItemAgendamento;
        private decimal valorUnit;
        private AgendamentoModel agendamentoModel;
        private MaterialModel materialModel;
        private List<ItemAgendamentoModel> listaItensAgendamentoModel;

        public ItemAgendamentoModel()
        {
            this.agendamentoModel = new AgendamentoModel();
            this.materialModel = new MaterialModel();
            listaItensAgendamentoModel = new List<ItemAgendamentoModel>();
        }

        public int IdItemAgendamento { get => idItemAgendamento; set => idItemAgendamento = value; }
        public decimal QuantidadeItemAgendamento { get => quantidadeItemAgendamento; set => quantidadeItemAgendamento = value; }
        public decimal ValorUnit { get => valorUnit; set => valorUnit = value; }
        public AgendamentoModel AgendamentoModel { get => this.agendamentoModel; set => this.agendamentoModel = value; }
        public MaterialModel MaterialModel { get => this.materialModel; set => this.materialModel = value; }
        public List<ItemAgendamentoModel> ListaItensAgendamentoModel
        {
            get
            {
                if (listaItensAgendamentoModel == null)
                {
                    listaItensAgendamentoModel = new List<ItemAgendamentoModel>();
                }
                return listaItensAgendamentoModel;
            }
            set
            {
                listaItensAgendamentoModel = value;
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
