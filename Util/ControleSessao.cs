using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SISTEMA_DE_GESTÃO_LOJA.Util
{
    public static class ControleSessao
    {
        private static UsuarioModel usuarioLogado;

        public static UsuarioModel UsuarioLogado
        {
            get { return usuarioLogado; }
            set { usuarioLogado = value; }
        }
    }
}
