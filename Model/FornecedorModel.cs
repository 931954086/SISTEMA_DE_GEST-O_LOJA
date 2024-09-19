using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class FornecedorModel
    {
        private int idFornecedor;
        private string descFor;
        private string nomeFantasia;
        private string cpf;
        private string nif;
        private string inscestadual;
        private string obs;
        private string email;
        private SituacaoModel situacaoModel;


        public FornecedorModel()
        {
             this.situacaoModel = new SituacaoModel();
        }

        public int IdFornecedor { get => idFornecedor; set => idFornecedor = value; }
        public string DescFor { get => descFor; set => descFor = value; }
        public string NomeFantasia { get => nomeFantasia; set => nomeFantasia = value; }
        public string Nif { get => nif; set => nif = value; }
        public string Inscestadual { get => inscestadual; set => inscestadual = value; }
        public string Obs { get => obs; set => obs = value; }
        public string Email { get => email; set => email = value; }
        public SituacaoModel SituacaoModel { get => this.situacaoModel; set => this.situacaoModel = value; }
    }
}
