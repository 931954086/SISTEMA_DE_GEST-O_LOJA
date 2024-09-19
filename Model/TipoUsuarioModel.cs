namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class TipoUsuarioModel
    {
        #region Variáveis
           private int idTipoUsuario;
           private string nomeTipoUsuario;
           private string siglaTipoUsuario;
        #endregion Variáveis

        #region Construtor
        public TipoUsuarioModel()
        {
     
        }
        #endregion Construtor


        #region Propriedades
        public int IdTipoUsuario { get => idTipoUsuario; set => idTipoUsuario = value; }
        public string NomeTipoUsuario { get => nomeTipoUsuario; set => nomeTipoUsuario = value; }
        public string SiglaTipoUsuario { get => siglaTipoUsuario; set => siglaTipoUsuario = value; }
        #endregion Propriedades
    }
}
