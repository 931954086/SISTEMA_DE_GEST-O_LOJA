using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class UsuarioModel
    {
        #region Variáveis

        private int idUsuario;
        private string login;
        private string senha;
        private TipoUsuarioModel tipoUsuarioModel;
        private SituacaoModel situacaoModel;
        private DateTime DataCad;
        private FuncionarioModel funcionarioModel;
        private string email;






        #endregion Variáveis

        #region Construtor

        public UsuarioModel()
        {
            this.tipoUsuarioModel = new TipoUsuarioModel();
            this.situacaoModel    = new SituacaoModel();
            this.funcionarioModel = new FuncionarioModel();
        }

        #endregion Construtor


        #region Propriedades
        public int IdUsuario {get => idUsuario; set => idUsuario = value; }
        public string Login {  get => login; set => login = value;}
        public string Senha { get => senha;  set => senha = value; }
        public TipoUsuarioModel TipoUsuarioModel { get => tipoUsuarioModel; set => tipoUsuarioModel = value;  }
        public SituacaoModel SituacaoModel { get => situacaoModel;  set => situacaoModel = value; }
        public DateTime DataCad1 {  get => DataCad; set => DataCad = value; }
        public FuncionarioModel FuncionarioModel {  get => funcionarioModel; set => funcionarioModel = value;}
        public string Email { get => email; set => email = value; }

        public static implicit operator UsuarioModel(List<UsuarioModel> v)
        {
            throw new NotImplementedException();
        }

        #endregion Propriedades


    }
}
