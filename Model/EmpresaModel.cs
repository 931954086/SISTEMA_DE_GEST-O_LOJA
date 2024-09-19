using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class EmpresaModel
    {
        #region Variáveis

        private int idEmpresa;
        private string nomeEmpresa;
        private string nif;
        private DateTime fundacao;
        private string site;
        private string email;
        #endregion Variáveis

        #region Construtor

        public EmpresaModel()
        {
        }

        public int IdEmpresa { get => idEmpresa; set => idEmpresa = value; }
        public string NomeEmpresa { get => nomeEmpresa; set => nomeEmpresa = value; }
        public string Nif { get => nif; set => nif = value; }
        public DateTime Fundacao { get => fundacao; set => fundacao = value; }
        public string Site { get => site; set => site = value; }
        public string Email { get => email; set => email = value; }

        #endregion Construtor
    }
}
