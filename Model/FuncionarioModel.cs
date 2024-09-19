using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class FuncionarioModel
    {
        #region Variáveis

        private int idFuncionario;
        private string nomeFunc;
        private string nif;
        private byte[] foto;
        private CargoModel cargoModel;
        private SituacaoModel situacaoModel;
        private DepartamentoModel departamentoModel;
        private string email;
        private DateTime dataContratacao;

        #endregion Variáveis

        #region Construtor

        public FuncionarioModel()
        {
            this.cargoModel = new CargoModel();
            this.situacaoModel = new SituacaoModel();
            this.departamentoModel = new DepartamentoModel();
        }

        #endregion Construtor

        #region Propriedades

        public int IdFuncionario { get => idFuncionario; set => idFuncionario = value; }
        public string NomeFunc { get => nomeFunc; set => nomeFunc = value; }
        public string Nif { get => nif; set => nif = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public CargoModel Cargo_Model { get => cargoModel; set => cargoModel = value; }
        public SituacaoModel Situacao_Model { get => situacaoModel; set => situacaoModel = value; }
        public string Email { get => email; set => email = value; }
        public DateTime DataContratacao { get => dataContratacao; set => dataContratacao = value; }
        public DepartamentoModel DepartamentoModel { get => this.departamentoModel; set => this.departamentoModel = value; }

        #endregion Propriedades
    }


}
