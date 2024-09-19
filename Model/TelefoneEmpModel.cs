using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class TelefoneEmpModel
    {

        #region Variáveis

        private int idTelefoneEmpre;
        private string ddd;
        private int numeroTelefone;
        private TipoTelefoneModel tipoTelefoneModel;
        private EmpresaModel empresaModel;
        private List<TelefoneEmpModel> listaTelefoneEmpModel;
        #endregion Variáveis

        #region Construtor

        public TelefoneEmpModel(EmpresaModel pEmpresaModel)
        {
            if (pEmpresaModel == null)
            {
                pEmpresaModel = new EmpresaModel(); ;
            }
            this.empresaModel = pEmpresaModel;
            this.tipoTelefoneModel = new TipoTelefoneModel();
        }

        #endregion Construtor

        #region Propriedades
        public int IdTelefoneEmpre { get => idTelefoneEmpre; set => idTelefoneEmpre = value; }
        public string DDD { get => ddd; set => ddd = value; }
        public int NumeroTelefone { get => numeroTelefone; set => numeroTelefone = value; }
        public TipoTelefoneModel TipoTelefoneModel { get => tipoTelefoneModel; set => tipoTelefoneModel = value; }
        public EmpresaModel EmpresaModel { get => empresaModel; set => empresaModel = value; }
        public List<TelefoneEmpModel> ListaTelefoneEmpModel { get => listaTelefoneEmpModel; set => listaTelefoneEmpModel = value; }
    
        public List<TelefoneEmpModel> ListTelefone
        {
            get
            {
                if (listaTelefoneEmpModel == null)
                {
                    listaTelefoneEmpModel = new List<TelefoneEmpModel>();
                }
                return listaTelefoneEmpModel;
            }
            set
            {
                listaTelefoneEmpModel = value;
            }
        }

        #endregion Propriedades

        #region Métodos
        #endregion Métodos
    }
}
