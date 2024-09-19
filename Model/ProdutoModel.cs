using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class ProdutoModel
    {
        #region Variáveis

        private int idproduto;
        private string descproduto;
        private decimal precoproduto;
        private decimal quantidadeeestoque;
        private decimal qteminimaestoque;
        private string codigobarra;
        private byte[] foto;
        private string descricaoproduto;
        private SituacaoModel situacaoModel;
        private List<ProdutoModel> listaProdutoModel;

        #endregion Variáveis

        #region Construtor

        public ProdutoModel()
        {
            situacaoModel = new SituacaoModel();
        }

        #endregion Construtor

        #region Propriedades

        public int Idproduto { get => idproduto; set => idproduto = value; }
        public string Descproduto { get => descproduto; set => descproduto = value; }
        public decimal Precoproduto { get => precoproduto; set => precoproduto = value; }
        public decimal Quantidadeeestoque { get => quantidadeeestoque; set => quantidadeeestoque = value; }
        public decimal Qteminimaestoque { get => qteminimaestoque; set => qteminimaestoque = value; }
        public string Codigobarra { get => codigobarra; set => codigobarra = value; }
        public SituacaoModel Situacao_Model { get => situacaoModel; set => situacaoModel = value; }
        public List<ProdutoModel> ListaProdutoModel { get => listaProdutoModel; set => listaProdutoModel = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public string Descricaoproduto { get => descricaoproduto; set => descricaoproduto = value; }

        #endregion Propriedades
    }
}
