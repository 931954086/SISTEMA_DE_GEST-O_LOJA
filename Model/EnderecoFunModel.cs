using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class EnderecoFunModel
    {
        private int idEnderecoFun;
        private string numLogradouroFun;
        private string logradouroFun;
        private string cepFun;
        private BairroModel bairro_Model;
        private FuncionarioModel funcionario_Model;

        public EnderecoFunModel(FuncionarioModel funcionarioModel)
        {
             this.funcionario_Model = funcionarioModel;
             this.bairro_Model = new BairroModel();
        }

            public int IdEnderecoFun { get => idEnderecoFun; set => idEnderecoFun = value; }
            public string NumLogradouroFun { get => numLogradouroFun; set => numLogradouroFun = value; }
            public string LogradouroFun { get => logradouroFun; set => logradouroFun = value; }
            public string CepFun { get => cepFun; set => cepFun = value; }
            public FuncionarioModel Funcionario_Model { get => this.funcionario_Model; set => this.funcionario_Model = value; }
            public BairroModel Bairro_Model { get => this.bairro_Model; set => this.bairro_Model = value; }
        
    }
}
