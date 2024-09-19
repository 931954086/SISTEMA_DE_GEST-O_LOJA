using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class BairroModel
    {
        private int idBairro;
        private string nomeBairro;
        private CidadeModel cidadeModel;

       

        public BairroModel()
        {
            this.cidadeModel = new CidadeModel();
        }

        public int IdBairro { get => idBairro; set => idBairro = value; }
        public string NomeBairro { get => nomeBairro; set => nomeBairro = value; }
        public CidadeModel Cidade_Model { get => this.cidadeModel; set => this.cidadeModel = value; }
    }
}
