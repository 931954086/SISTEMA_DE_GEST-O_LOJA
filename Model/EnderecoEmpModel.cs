using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class EnderecoLojaModel
    {
        private int idEnderecoLoja;
        private string logradouroLoja;
        private string numLogradouroLoja;
        private string cepLoja;
        private BairroModel bairro_Model;
        private EmpresaModel empresaModel;

        public EnderecoLojaModel(EmpresaModel empresaModel)
        {
            this.empresaModel = empresaModel;
            this.bairro_Model = new BairroModel();
        }

        public int IdEnderecoLoja { get => idEnderecoLoja; set => idEnderecoLoja = value; }
        public string LogradouroLoja { get => logradouroLoja; set => logradouroLoja = value; }
        public string NumLogradouroLoja { get => numLogradouroLoja; set => numLogradouroLoja = value; }
        public string CepLoja { get => cepLoja; set => cepLoja = value; }
        public BairroModel Bairro_Model { get => bairro_Model; set => bairro_Model = value; }
        public EmpresaModel EmpresaModel { get => empresaModel; set => empresaModel = value; }
    }
}
