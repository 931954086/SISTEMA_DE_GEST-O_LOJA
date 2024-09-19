using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class ItemAluguerDAO
    {
        #region Variáveis

        private SqlConnection conn = null;
        private SqlTransaction tran = null;
        private AcessoBanco conexao = null;
        private int retorno = 1;

        public ItemAluguerDAO()
        {
        }

        #endregion Variáveis

        #region Construtor

        public ItemAluguerDAO(SqlConnection pCon, SqlTransaction transacao)
        {
            this.conn = pCon;
            this.tran = transacao;
        }

        #endregion Construtor

        #region Métodos

        public int IncluirItemAluguerDAO(ItemAluguerModel itemAluguerModel)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspIncluirItemAluguer", this.conn, this.tran))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    for (int i = 0; i < itemAluguerModel.ListaItensAluguerModel.Count; i++)
                    {
                        // MessageBox.Show(Convert.ToString(pItemVendaModel.Ntvenda_Model.Idntvenda));
                        comando.Parameters.Clear();
                        comando.Parameters.AddWithValue("@quantidadeitemaluguer", itemAluguerModel.ListaItensAluguerModel[i].QuantidadeItemAluguer);
                        comando.Parameters.AddWithValue("@valorunit", itemAluguerModel.ListaItensAluguerModel[i].ValorUnit);
                        comando.Parameters.AddWithValue("@idaluguer", itemAluguerModel.AluguerModel.Id);
                        comando.Parameters.AddWithValue("@idmaterial",itemAluguerModel.ListaItensAluguerModel[i].MaterialModel.IdMaterial);

                        comando.ExecuteNonQuery();
                    }

                    for (int i = 0; i < itemAluguerModel.ListaItensAluguerModel.Count; i++)
                    {
                        itemAluguerModel.QuantidadeItemAluguer = Convert.ToInt16(itemAluguerModel.ListaItensAluguerModel[i].QuantidadeItemAluguer);
                        itemAluguerModel.MaterialModel.IdMaterial = Convert.ToInt16(itemAluguerModel.ListaItensAluguerModel[i].MaterialModel.IdMaterial);
                        AtualizarEstoque(itemAluguerModel, this.tran);
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


        public void AtualizarEstoque(ItemAluguerModel itemAluguerModel, SqlTransaction tran)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = tran.Connection;
                cmd.Transaction = tran;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "uspAluguerSubtraiEstoque";
                cmd.Parameters.Clear();
                try
                {
                    cmd.Parameters.AddWithValue("@idmaterial", itemAluguerModel.MaterialModel.IdMaterial);
                    cmd.Parameters.AddWithValue("@qtdinformada", Convert.ToDecimal(itemAluguerModel.QuantidadeItemAluguer));

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
        #endregion Métodos

    }
}
