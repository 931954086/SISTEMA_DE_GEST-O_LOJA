using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class ItemVendaDAO
    {

        #region Variáveis

        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        public ItemVendaDAO()
        {
        }

        #endregion Variáveis

        #region Construtor

        public ItemVendaDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        #endregion Construtor

        #region Métodos

        public int IncluirItemVendaDAO(ItemVendaModel pItemVendaModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspIncluirItemVendaProduto", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < pItemVendaModel.ListaItensVendaModel.Count; i++)
                    {
                       // MessageBox.Show(Convert.ToString(pItemVendaModel.Ntvenda_Model.Idntvenda));
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@quantidadeitemvenda", pItemVendaModel.ListaItensVendaModel[i].Quantidadeitemvenda);
                        comando.Parameters.AddWithValue("@valorunit", pItemVendaModel.ListaItensVendaModel[i].Valorunit);
                        comando.Parameters.AddWithValue("@idntvenda", pItemVendaModel.Ntvenda_Model.Idntvenda);
                        comando.Parameters.AddWithValue("@idproduto", pItemVendaModel.ListaItensVendaModel[i].Produto_Model.Idproduto);

                        comando.ExecuteNonQuery();

                       //retorno = comando.ExecuteNonQuery();
                    }

                    for (int i = 0; i < pItemVendaModel.ListaItensVendaModel.Count; i++)
                    {
                        pItemVendaModel.Quantidadeitemvenda = Convert.ToInt16(pItemVendaModel.ListaItensVendaModel[i].Quantidadeitemvenda);
                        pItemVendaModel.Produto_Model.Idproduto = Convert.ToInt16(pItemVendaModel.ListaItensVendaModel[i].Produto_Model.Idproduto);
                        AtualizarEstoque(pItemVendaModel, this.tran);
                    }

                }
            }
            catch (Exception)
            {
                retorno = 0;
                throw;
            }
            return retorno;
        }



     
        public void AtualizarEstoque(ItemVendaModel pItemVendaModel, SqlTransaction tran)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = tran.Connection;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspVendaSubtraiEstoque";
                cmd.Parameters.Clear();
                try
                {
                    cmd.Parameters.AddWithValue("@idproduto", pItemVendaModel.Produto_Model.Idproduto);
                    cmd.Parameters.AddWithValue("@qtdinformada", Convert.ToDecimal(pItemVendaModel.Quantidadeitemvenda));

                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    retorno = 0;
                    throw;
                }
                catch (Exception ex)
                {
                    retorno = 0;
                    throw;
                }
            }
        }

        public int AlterarItemVendaDAO(ItemVendaModel pItemVendaModel)
        {
            throw new NotImplementedException();
        }



        /*
       public int AlterarItemVendaDAO(TelefoneCliModel pTelefoneCliModel)
     {
      Boolean bAchou = false;
     try
      {
       if (conexao == null)
       {
           conexao = new AcessoBanco();
       }
       DataTable dt = new DataTable();

       // Recupera todos os telefones cadastrado do cliente
       dt = conexao.ExecDataTable("uspTelefoneCliLocalizar", "@idcliente", pTelefoneCliModel.Cliente.Idcliente);

       if (dt.Rows.Count > pTelefoneCliModel.ListTelefone.Count)
       {
           // excluir
           for (int j = 0; j < dt.Rows.Count; j++)
           {
               for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
               {
                   if (dt.Rows[j]["IdTelefoneCli"].ToString() == pTelefoneCliModel.ListTelefone[i].IdTelefoneCli.ToString())
                   {
                       bAchou = true;

                       // alterar
                       using (SqlCommand comando = new SqlCommand("uspTelefoneCliAlterar", this.conn, this.tran))
                       {
                           comando.CommandType = CommandType.StoredProcedure;

                           Alterar(pTelefoneCliModel, comando, i);
                       }
                       break;
                   }
                   else
                   {
                       bAchou = false;
                   }
               }
               if (!bAchou)
               {
                   // excluir
                   ExcluirTelefoneCliPorIdItemVendaDAO(Convert.ToInt16(dt.Rows[j]["IdTelefoneCli"]));
               }
           }
       }
       else if (dt.Rows.Count < pTelefoneCliModel.ListTelefone.Count)
       {
           // Incluir - Essa lógica funciona porque quando adiciona um telefone na lista ele preenche sempre linha mais em baixo
           // do último registro do ListView.
           for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
           {
               for (int j = 0; j < dt.Rows.Count; j++)
               {
                   if (dt.Rows[j]["IdTelefoneCli"].ToString() == pTelefoneCliModel.ListTelefone[i].IdTelefoneCli.ToString())
                   {
                       bAchou = true;
                       break;
                   }
                   else
                   {
                       bAchou = false;
                   }
               }
               if (!bAchou)
               {
                   using (SqlCommand comando = new SqlCommand("uspTelefoneCliIncluir", this.conn, this.tran))
                   {
                       comando.CommandType = CommandType.StoredProcedure;
                       comando.Parameters.Clear();
                       comando.Parameters.AddWithValue("@ddd", pTelefoneCliModel.ListTelefone[i].DDD);
                       comando.Parameters.AddWithValue("@numerotelefone", pTelefoneCliModel.ListTelefone[i].NumeroTelefone);
                       comando.Parameters.AddWithValue("@idtipoTelefone", pTelefoneCliModel.ListTelefone[i].TipoTelefone.IdTipoTelefone);
                       comando.Parameters.AddWithValue("@idcliente", pTelefoneCliModel.ListTelefone[i].Cliente.Idcliente);

                       comando.ExecuteNonQuery();
                   }
               }
               else
               {
                   using (SqlCommand comando = new SqlCommand("uspTelefoneCliAlterar", this.conn, this.tran))
                   {
                       comando.CommandType = CommandType.StoredProcedure;

                       Alterar(pTelefoneCliModel, comando, i);
                   }
               }
           }
       }
       else
       {
           // alterar
           using (SqlCommand comando = new SqlCommand("uspTelefoneCliAlterar", this.conn, this.tran))
           {
               comando.CommandType = CommandType.StoredProcedure;

               for (int i = 0; i < pTelefoneCliModel.ListTelefone.Count; i++)
               {
                   Alterar(pTelefoneCliModel, comando, i);
               }
           }
       }
   }
   catch (Exception)
   {
       retorno = 0;
       throw;
   }
   return retorno;
}





private void Alterar(TelefoneCliModel pTelCliModel, SqlCommand cmd, int indice)
{
   try
   {
       cmd.Parameters.Clear();
       cmd.Prepare();
       cmd.Parameters.AddWithValue("@idtelefonecli", pTelCliModel.ListTelefone[indice].IdTelefoneCli);
       cmd.Parameters.AddWithValue("@ddd", pTelCliModel.ListTelefone[indice].DDD);
       cmd.Parameters.AddWithValue("@numerotelefone", pTelCliModel.ListTelefone[indice].NumeroTelefone);
       cmd.Parameters.AddWithValue("@idtipoTelefone", pTelCliModel.ListTelefone[indice].TipoTelefone.IdTipoTelefone);
       cmd.Parameters.AddWithValue("@idcliente", pTelCliModel.ListTelefone[indice].Cliente.Idcliente);

       cmd.ExecuteNonQuery();
   }
   catch (Exception)
   {
       throw;
   }
}

public int ExcluirTelefoneCliPorIdItemVendaDAO(int pIdCli)
{
   try
   {
       using (SqlCommand comando = new SqlCommand("uspTelefoneCliExcluir", this.conn, this.tran))
       {
           comando.Parameters.Clear();
           comando.CommandType = CommandType.StoredProcedure;
           comando.Parameters.AddWithValue("@idcliente", pIdCli);

           comando.ExecuteNonQuery();
       }
   }
   catch (Exception ex)
   {
       System.Windows.Forms.MessageBox.Show(ex.Message);
       retorno = 0;
       throw;
   }
   return retorno;
}

public int ExcluirTelefoneCliPorIdTelefoneDAO(int pId)
{
   try
   {
       using (SqlCommand comando = new SqlCommand("uspTelefoneCliExcluirPorIdTelefone", this.conn, this.tran))
       {
           comando.CommandType = CommandType.StoredProcedure;
           comando.Parameters.AddWithValue("@idtelefonecli", pId);

           comando.ExecuteNonQuery();
       }
   }
   catch (Exception ex)
   {
       System.Windows.Forms.MessageBox.Show(ex.Message);
       retorno = 0;
       throw;
   }
   return retorno;
}

/// <summary>
/// Recuperar todos os telefones do cliente.
/// </summary>
/// <param name="pIdCliente">Identificador do cliente.</param>
/// <returns>IDataReader</returns>
public DataTable ObterTelefoneCliPorId(int pIdCliente)
{
   try
   {
       return conexao.ExecDataTable("uspTelefoneCliLocalizar", "@idcliente", pIdCliente);
   }
   catch (Exception)
   {
       throw;
   }
}*/


        #endregion Métodos
    }
}
