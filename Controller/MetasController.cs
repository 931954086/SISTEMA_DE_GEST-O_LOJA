using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class MetasController
    {
        private readonly MetasDAO metasDAO; // Interface para acesso aos dados

        public MetasController()
        {
           
        }

        public List<MetasModel> ObterMetas(int ano, int mes)
        {
            return metasDAO.ObterMetasDAO(ano, mes);
        }

        public void InserirMeta(MetasModel meta)
        {
            metasDAO.InserirMetaDAO(meta);
        }

        public void AtualizarMeta(MetasModel meta)
        {
            metasDAO.AtualizarMetaDAO(meta);
        }

        public void ExcluirMeta(int id)
        {
            metasDAO.ExcluirMetaDAO(id);
        }
    }


    //==================== INTERFACE DE METAS =======================================
    /*
        List<MetaVendas> ObterMetas(int ano, int mes);
    void InserirMeta(MetaVendas meta);
    void AtualizarMeta(MetaVendas meta);
    void ExcluirMeta(int id);
     public class MinhaAplicacao
    {
    private MetasController metasController;

    public MinhaAplicacao()
    {
        IMetasDao metasDao = new MetasDao(); // Instância do DAO, você pode usar injeção de dependência aqui
        metasController = new MetasController(metasDao);
    }
    public void ExemploUsoMetas()
    {
        // Exemplo de uso para obter metas de vendas para julho de 2024
        List<MetaVendas> metas = metasController.ObterMetas(2024, 7);
        foreach (var meta in metas)
        {
            Console.WriteLine($"Meta de vendas: {meta.MetaValor}");
        }
        // Outras operações como inserir, atualizar ou excluir metas
    }
}
*/

}
