using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class EstadoModel
    {
        #region Variáveis

        private int idEstado;
        private string nomeEstado;
        private string uf;
        private string nomeRelatorio;

        #endregion Variáveis

        #region Propriedades

        public int IdEstado { get => idEstado; set => idEstado = value; }
        public string NomeEstado { get => nomeEstado; set => nomeEstado = value; }
        public string Uf { get => uf; set => uf = value; }
        public string NomeRelatorio { get => nomeRelatorio; set => nomeRelatorio = value; }

        #endregion Propriedades
    }
}
