using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class DevolucaoModel
    {
        #region    VARIAVEIS 
        private int idDevolucao;
        private AluguerModel aluguerModel;
        private DateTime dataDevolucao;
        private string estadoMateriaL;
        private string observacoes;
        #endregion VARIAVEIS 

        #region    CONSTRUCTOR
        public DevolucaoModel()
        {
            this.aluguerModel = new AluguerModel();
        }
        #endregion CONSTRUCTOR

      #region    METODOS
        public int IdDevolucao { get => idDevolucao; set => idDevolucao = value; }
        public DateTime DataDevolucao { get => dataDevolucao; set => dataDevolucao = value; }
        public string EstadoMateriaL { get => estadoMateriaL; set => estadoMateriaL = value; }
        public string Observacoes { get => observacoes; set => observacoes = value; }
        public AluguerModel AluguerModel { get => aluguerModel; set => aluguerModel = value; }
      #endregion METODOS

    }
}
