using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class CargoDAO
    {

        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public CargoDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor


        public int IncluirCargoDAO(CargoModel pCargoModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspCargoIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nomecargo", pCargoModel.NomeCargo);
                    comando.Parameters.AddWithValue("@siglacargo", pCargoModel.SiglaCargo);
                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }




        public int AlterarCargoDAO(CargoModel pCargoModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspCargoAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idcargo", pCargoModel.IdCargo);
                    comando.Parameters.AddWithValue("@nomecargo", pCargoModel.NomeCargo);
                    comando.Parameters.AddWithValue("@siglacargo", pCargoModel.SiglaCargo);
                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }





        public int ExcluirCargoDAO(int pIdCargo)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspCargoExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idcargo", pIdCargo);
                    conexao.AbrirConexao();
                    retorno = comando.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexao.FecharConexao();
            }
            return retorno;
        }



        public DataTable ObterAllCargos()
        {
            try
            {
                return conexao.ExecDataTable("uspCargoTodosCargos", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
