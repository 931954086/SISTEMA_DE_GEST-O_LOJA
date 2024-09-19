using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class TelefoneCliModel
    {
        #region Variáveis

        private int idTelefoneCli;
        private string ddd;
        private int numeroTelefone;
        private TipoTelefoneModel tipoTelefoneModel;
        private ClienteModel clienteModel;
        private List<TelefoneCliModel> listaTelefoneCliModel;

        #endregion Variáveis

        #region Construtor

        public TelefoneCliModel(ClienteModel pClienteModel)
        {
            if (pClienteModel == null)
            {
                pClienteModel = new ClienteModel(); ;
            }
            this.clienteModel = pClienteModel;

            this.tipoTelefoneModel = new TipoTelefoneModel();
        }

        #endregion Construtor

        #region Propriedades

        public int IdTelefoneCli { get => idTelefoneCli; set => idTelefoneCli = value; }
        public string DDD { get => ddd; set => ddd = value; }
        public int NumeroTelefone { get => numeroTelefone; set => numeroTelefone = value; }
        public TipoTelefoneModel TipoTelefone { get => this.tipoTelefoneModel; set => this.tipoTelefoneModel = value; }
        public ClienteModel Cliente { get => this.clienteModel; set => this.clienteModel = value; }

        public List<TelefoneCliModel> ListTelefone
        {
            get
            {
                if (listaTelefoneCliModel == null)
                {
                    listaTelefoneCliModel = new List<TelefoneCliModel>();
                }
                return listaTelefoneCliModel;
            }
            set
            {
                listaTelefoneCliModel = value;
            }
        }
        #endregion Propriedades

        #region Métodos
        #endregion Métodos
    }
}
