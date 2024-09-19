using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class AgendamentoModel
    {
        #region variaveis
        private int id;
        private string numeroFatura;
        private FuncionarioModel funcionarioModel;
        private ClienteModel clienteModel;
        private SituacaoModel situacaoModel;
        private DateTime dataInicio;
        private DateTime dataFim;
        private DateTime dataCadAgendamento;
        private int      dias;
        private decimal  valorBruto;
        private decimal  valorLiquido;
        private decimal  imposto;
        private DateTime dataPagamento;  // Nullable para permitir valores nulos
        private string   clausulas;
        private decimal  caucao;
        private string   frete;
        private decimal  fretePreco;
        private decimal  desconto;
        #endregion variaveis

        #region constructor
        public AgendamentoModel()
        {
            this.funcionarioModel = new FuncionarioModel();
            this.clienteModel = new ClienteModel();
            this.situacaoModel = new SituacaoModel();
        }
        #endregion constructor

        #region propriedades
        public int Id { get => id; set => id = value; }
        public ClienteModel ClienteModel { get => this.clienteModel; set => this.clienteModel = value; }
        public FuncionarioModel FuncionarioModel { get => this.funcionarioModel; set => this.funcionarioModel = value; }
        public SituacaoModel SituacaoModel { get => this.situacaoModel; set => this.situacaoModel = value; }
        public DateTime DataInicio { get => dataInicio; set => dataInicio = value; }
        public DateTime DataFim { get => dataFim; set => dataFim = value; }
        public decimal ValorBruto { get => valorBruto; set => valorBruto = value; }
        public decimal ValorLiquido { get => valorLiquido; set => valorLiquido = value; }
        public string Clausulas { get => clausulas; set => clausulas = value; }
        public decimal Caucao { get => caucao; set => caucao = value; }
        public string Frete { get => frete; set => frete = value; }
        public decimal FretePreco { get => fretePreco; set => fretePreco = value; }
        public string NumeroFatura { get => numeroFatura; set => numeroFatura = value; }
        public DateTime DataCadAgendamento { get => dataCadAgendamento; set => dataCadAgendamento = value; }
        public decimal Imposto { get => imposto; set => imposto = value; }
        public DateTime DataPagamento { get => dataPagamento; set => dataPagamento = value; }
        public int Dias { get => dias; set => dias = value; }
        public decimal Desconto { get => desconto; set => desconto = value; }

        #endregion propriedades

        public decimal CalcularDesconto()
        {
            if (Desconto > 0)
            {
                return ValorLiquido * (Desconto / 100);
            }
            return 0;
        }
    }

}
