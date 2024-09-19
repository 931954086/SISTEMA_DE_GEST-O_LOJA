using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class TelefoneFunModel
    {
        #region Variáveis

        private int idTelefoneFun;
        private string ddd;
        private int numeroTelefone;
        private TipoTelefoneModel tipoTelefoneModel;
        private FuncionarioModel funcionarioModel;
        private List<TelefoneFunModel> listaTelefoneFunModel;

        #endregion Variáveis

        #region Construtor

        public TelefoneFunModel(FuncionarioModel pFuncionarioModel)
        {
            if (pFuncionarioModel == null)
            {
                pFuncionarioModel = new FuncionarioModel(); ;
            }
            this.funcionarioModel = pFuncionarioModel;

            this.tipoTelefoneModel = new TipoTelefoneModel();
        }

        #endregion Construtor

        #region Propriedades

        public int IdTelefoneFun { get => idTelefoneFun; set => idTelefoneFun = value; }
        public string DDD { get => ddd; set => ddd = value; }
        public int NumeroTelefone { get => numeroTelefone; set => numeroTelefone = value; }
        public TipoTelefoneModel TipoTelefone { get => this.tipoTelefoneModel; set => this.tipoTelefoneModel = value; }
        public FuncionarioModel Funcionario_Model { get => this.funcionarioModel; set => this.funcionarioModel = value; }

        public List<TelefoneFunModel> ListTelefone
        {
            get
            {
                if (listaTelefoneFunModel == null)
                {
                    listaTelefoneFunModel = new List<TelefoneFunModel>();
                }
                return listaTelefoneFunModel;
            }
            set
            {
                listaTelefoneFunModel = value;
            }
        }
        #endregion Propriedades

        #region Métodos
        #endregion Métodos
    }
}
