using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class SalarioModel
    {
        private int idSalario;
        private int idFuncionario;
        private decimal salarioBase;
        private decimal irt;
        private decimal iva;
        private decimal inss;
        private decimal fgts;
        private decimal salarioLiquido;
        private DateTime dataPagamento;
        private FuncionarioModel funcionarioModel;

        public SalarioModel() 
        {
            this.funcionarioModel = new FuncionarioModel();
        }

        public int IdSalario { get => idSalario; set => idSalario = value; }
        public int IdFuncionario { get => idFuncionario; set => idFuncionario = value; }
        public decimal SalarioBase { get => salarioBase; set => salarioBase = value; }
        public decimal Irt { get => irt; set => irt = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Inss { get => inss; set => inss = value; }
        public decimal Fgts { get => fgts; set => fgts = value; }
        public decimal SalarioLiquido { get => salarioLiquido; set => salarioLiquido = value; }
        public DateTime DataPagamento { get => dataPagamento; set => dataPagamento = value; }
        public FuncionarioModel FuncionarioModel { get => this.funcionarioModel; set => this.funcionarioModel = value; }
    }
}
