using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class CidadeModel
    {
        private int idCidade;
        private string nomeCidade;
        private EstadoModel estadoModel;

        public CidadeModel()
        {
            this.estadoModel = new EstadoModel();
        }

        public int IdCidade { get => idCidade; set => idCidade = value; }
        public string NomeCidade { get => nomeCidade; set => nomeCidade = value; }
        public EstadoModel EstadoModel { get => this.estadoModel; set => this.estadoModel = value; }
    }
}
