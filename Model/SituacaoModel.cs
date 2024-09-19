using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class SituacaoModel
    {
        #region Variáveis

        private int idSituacao;
        private string descSituacao;

        #endregion Variáveis

        #region Propriedades

        public int IdSituacao { get => idSituacao; set => idSituacao = value; }
        public string DescSituacao { get => descSituacao; set => descSituacao = value; }

        #endregion Propriedades
    }
}
