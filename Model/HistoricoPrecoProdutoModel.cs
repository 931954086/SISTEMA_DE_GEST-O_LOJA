using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class HistoricoPrecoProdutoModel
    {

        private ProdutoModel produto_Model;

        public HistoricoPrecoProdutoModel()
        {
            this.produto_Model = new ProdutoModel();
        }

        public ProdutoModel Produto_model { get => this.produto_Model; set => this.produto_Model = value; }

    }
}


