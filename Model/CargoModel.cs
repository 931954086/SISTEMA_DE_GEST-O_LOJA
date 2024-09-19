using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class CargoModel
    {
        #region VARIAVEIS
        private int idCargo;
        private string nomeCargo;
        private string siglaCargo;
        #endregion VARIAVEIS

        #region CONSTRUCTOR
        public CargoModel()
        {

        }
        #endregion CONSTRUCTOR

        #region METODOS

        public int IdCargo { get => idCargo; set => idCargo = value; }
        public string NomeCargo { get => nomeCargo; set => nomeCargo = value; }
        public string SiglaCargo { get => siglaCargo; set => siglaCargo = value; }

        #endregion METODOS

    }

}
