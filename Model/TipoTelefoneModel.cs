using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class TipoTelefoneModel
    {
        #region Variáveis

        private int idTipoTelefone;
        private string descTipoTelefone;

        #endregion Variáveis

        #region Propriedades

        public int IdTipoTelefone { get => idTipoTelefone; set => idTipoTelefone = value; }
        public string DescTipoTelefone { get => descTipoTelefone; set => descTipoTelefone = value; }

        #endregion Propriedades
    }
}
