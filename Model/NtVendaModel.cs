using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class NtVendaModel : VisualizarRelatorioModel
    {
        #region Variáveis

        private int idntvenda;
        private string numerofatura;
        private DateTime dtpagamento;
        private DateTime dtvenda;
        private decimal valorbrutovenda;
        private decimal descontovenda;
        private decimal imposto;
        private decimal valorliqVenda;
        private ClienteModel clientemodel;
        private FuncionarioModel funcionariomodel;
        private SituacaoModel situacaomodel;

        #endregion Variáveis

        #region Construtor
        public NtVendaModel()
        {
            clientemodel = new ClienteModel();
            funcionariomodel = new FuncionarioModel();
            situacaomodel = new SituacaoModel();
        }

        #endregion Construtor

        #region Propriedades

        public int Idntvenda { get => idntvenda; set => idntvenda = value; }
        public string Numerofatura { get => numerofatura; set => numerofatura = value; }
        public DateTime Dtpagamento { get => dtpagamento; set => dtpagamento = value; }
        public decimal Valorbrutovenda { get => valorbrutovenda; set => valorbrutovenda = value; }
        public decimal Descontovenda { get => descontovenda; set => descontovenda = value; }
        public decimal ValorliqVenda { get => valorliqVenda; set => valorliqVenda = value; }
        public decimal Imposto { get => imposto; set => imposto = value; }
        public ClienteModel Cliente_Model { get => clientemodel; set => clientemodel = value; }
        public FuncionarioModel Funcionario_Model { get => funcionariomodel; set => funcionariomodel = value; }
        public SituacaoModel Situacao_Model { get => situacaomodel; set => situacaomodel = value; }
        public DateTime Dtvenda { get => dtvenda; set => dtvenda = value; }

        #endregion Propriedades

        #region Métodos

        public string CalcularDesconto()
        {
            try
            {
                return (ValorliqVenda * (Descontovenda / 100)).ToString("N");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion Métodos
    }
}

