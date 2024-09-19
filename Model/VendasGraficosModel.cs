using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class VendasGraficosModel
    {
        #region Variaveis

        private string setor;
        private decimal valor;
        private short ano;

        #endregion Variaveis

        public VendasGraficosModel()
        {
          
        }

        public VendasGraficosModel(short ano, string setor, decimal valor)
        {
            this.setor = setor;
            this.valor = valor;
            this.ano = ano;
        }

        public string Setor { get => setor; set => setor = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public short Ano { get => ano; set => ano = value; }


        public List<VendasGraficosModel> VendasAnual(short ano)
        {
            var vendasSetor = new List<VendasGraficosModel>();
            vendasSetor.Add(new VendasGraficosModel(ano, "Cereas",27000));
            vendasSetor.Add(new VendasGraficosModel(ano, "Arroz", 260000));
            vendasSetor.Add(new VendasGraficosModel(ano, "Cucas", 2010000));
            vendasSetor.Add(new VendasGraficosModel(ano, "Nocal", 20000));
            vendasSetor.Add(new VendasGraficosModel(ano, "Outros", 10000));

            return vendasSetor;
        }


        public string[] GetNomeSetor(List<VendasGraficosModel> vendas)
        {
            string[] setores = new string[vendas.Count];
            for (int i = 0; i < vendas.Count; i++)
            {
                setores[i] = vendas[i].Setor;
            }
            return setores;
        }

        public decimal[] GetValorSetor(List<VendasGraficosModel> vendas)
        {
            decimal[] valores = new decimal[vendas.Count];
            for (int i = 0; i < vendas.Count; i++)
            {
                valores[i] = vendas[i].Valor;
            }
            return valores;
        }

    }
}
