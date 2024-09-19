using System.Collections.Generic;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class TelefoneForModel
    {
        #region Variáveis

        private int idTelefoneFor;
        private string ddd;
        private int numeroTelefone;
        private TipoTelefoneModel tipoTelefoneModel;
        private FornecedorModel fornecedorModel;
        private List<TelefoneForModel> listaTelefoneForModel;

        #endregion Variáveis

        #region Construtor

        public TelefoneForModel(FornecedorModel pFornecedorModel)
        {
            if (pFornecedorModel == null)
            {
                pFornecedorModel = new FornecedorModel(); ;
            }
            this.fornecedorModel = pFornecedorModel;

            this.tipoTelefoneModel = new TipoTelefoneModel();
        }

        #endregion Construtor

        #region Propriedades

        public int IdTelefoneFor { get => idTelefoneFor; set => idTelefoneFor = value; }
        public string DDD { get => ddd; set => ddd = value; }
        public int NumeroTelefone { get => numeroTelefone; set => numeroTelefone = value; }
        public TipoTelefoneModel TipoTelefone { get => this.tipoTelefoneModel; set => this.tipoTelefoneModel = value; }
        public FornecedorModel Fornecedor_Model { get => this.fornecedorModel; set => this.fornecedorModel = value; }

        public List<TelefoneForModel> ListTelefone
        {
            get
            {
                if (listaTelefoneForModel == null)
                {
                    listaTelefoneForModel = new List<TelefoneForModel>();
                }
                return listaTelefoneForModel;
            }
            set
            {
                listaTelefoneForModel = value;
            }
        }
        #endregion Propriedades

        #region Métodos
        #endregion Métodos
    }
}
