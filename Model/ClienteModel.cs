using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class ClienteModel
    {
        #region Variáveis

        private int idcliente;
        private string nomecli;
        private string emailcli;
        private SituacaoModel situacao;
        private string nIf;

        #endregion Variáveis

        #region Construtor

        public ClienteModel()
        {
            situacao = new SituacaoModel();
        }

        #endregion Construtor

        #region Propriedades

        public int Idcliente { get => idcliente; set => idcliente = value; }
        public string Nomecli { get => nomecli; set => nomecli = value; }
        public string Emailcli { get => emailcli; set => emailcli = value; }
        public SituacaoModel Situacao_Model { get => this.situacao; set => this.situacao = value; }
        public string NIf { get => nIf; set => nIf = value; }

        #endregion Propriedades
    }
}
