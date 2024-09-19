using Bunifu.Framework.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Model
{
    public class MetasModel
    {

            public int Id { get; set; }
            public DateTime AnoMes { get; set; } // Representa o ano e mês combinados
            public int MetaClientes { get; set; }
            public decimal MetaVendas { get; set; }
            public int MetaProdutos { get; set; }
    }
}
