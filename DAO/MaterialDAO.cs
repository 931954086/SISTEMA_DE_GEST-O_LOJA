using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class MaterialDAO
    {

        #region Variáveis
        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;
        #endregion Variáveis


        #region Construtor
        public MaterialDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }
        #endregion Construtor

        #region Métodos
    
        public int IncluirMaterialDAO(MaterialModel materialModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspMaterialIncluir", this.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nome",          materialModel.NomeMaterial);
                    cmd.Parameters.AddWithValue("@cor",           materialModel.CorMaterial);
                    cmd.Parameters.AddWithValue("@modelo",        materialModel.ModeloMaterial);
                    cmd.Parameters.AddWithValue("@descricao",     materialModel.DescricaoMaterial);
                    cmd.Parameters.AddWithValue("@qtddisponivel", materialModel.QtdDisponivelMaterial);
                    cmd.Parameters.AddWithValue("@qtdtotal",      materialModel.QtdTotal);
                    cmd.Parameters.AddWithValue("@preco", materialModel.Preco);
                    cmd.Parameters.AddWithValue("@codigobarra", materialModel.CodigoBarra);
                    cmd.Parameters.AddWithValue("@qtdmin", materialModel.Qtdmin);
                    conexao.AbrirConexao();
                    retorno = cmd.ExecuteNonQuery();
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



        public int AlterarMaterialDAO(MaterialModel materialModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspMaterialAlterar", this.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idmaterial",             materialModel.IdMaterial);
                    cmd.Parameters.AddWithValue("@nome",   materialModel.NomeMaterial);
                    cmd.Parameters.AddWithValue("@cor",    materialModel.CorMaterial);
                    cmd.Parameters.AddWithValue("@modelo", materialModel.ModeloMaterial);
                    cmd.Parameters.AddWithValue("@descricao",      materialModel.DescricaoMaterial);
                    cmd.Parameters.AddWithValue("@qtddisponivel",  materialModel.QtdDisponivelMaterial);
                    cmd.Parameters.AddWithValue("@qtdtotal", materialModel.QtdTotal);
                    cmd.Parameters.AddWithValue("@preco",    materialModel.Preco);
                    cmd.Parameters.AddWithValue("@codigobarra", materialModel.CodigoBarra);
                    cmd.Parameters.AddWithValue("@qtdmin", materialModel.Qtdmin);

                    conexao.AbrirConexao();
                    retorno = cmd.ExecuteNonQuery();
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


        public int ExcluirMaterialDAO(int pIdMaterial)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("uspMaterialExcluir", this.conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idmaterial", pIdMaterial);

                    conexao.AbrirConexao();
                    retorno = cmd.ExecuteNonQuery();
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


        public DataTable ObterAllMaterias()
        {
            try
            {
                return conexao.ExecDataTable("uspMaterialLocalizar", conexao.ConectarBD());
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Métodos
       
    }
}
