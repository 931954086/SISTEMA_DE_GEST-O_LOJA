using SISTEMA_DE_GESTÃO_LOJA.AcessoDB;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SISTEMA_DE_GESTÃO_LOJA.DAO
{
    public class UsuarioDAO
    {

        #region Variáveis

        private SqlConnection conn = null;
        private AcessoBanco conexao = null;
        private int retorno = 0;

        #endregion Variáveis

        #region Construtor

        public UsuarioDAO()
        {
            conexao = new AcessoBanco();
            this.conn = conexao.ConectarBD();
        }

        #endregion Construtor

        #region Métodos



        public int IncluirUsuarioDAO(UsuarioModel pUsuarioModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspUsuarioIncluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@login", pUsuarioModel.Login);
                    comando.Parameters.AddWithValue("@senha", pUsuarioModel.Senha);
                    comando.Parameters.AddWithValue("@email", pUsuarioModel.Email);
                    comando.Parameters.AddWithValue("@idfuncionario", pUsuarioModel.FuncionarioModel.IdFuncionario);
                    comando.Parameters.AddWithValue("@idtipousuario", pUsuarioModel.TipoUsuarioModel.IdTipoUsuario);
                    comando.Parameters.AddWithValue("@idsituacao", pUsuarioModel.SituacaoModel.IdSituacao);
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



        public int AlterarUsuarioDAO(UsuarioModel pUsuarioModel)
        {
            int retorno = 0;
            try
            {
                using (SqlCommand comando = new SqlCommand("uspUsuarioAlterar", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@login", pUsuarioModel.Login);
                    comando.Parameters.AddWithValue("@senha", pUsuarioModel.Senha);
                    comando.Parameters.AddWithValue("@email", pUsuarioModel.Email);
                    comando.Parameters.AddWithValue("@idfuncionario", pUsuarioModel.FuncionarioModel.IdFuncionario);
                    comando.Parameters.AddWithValue("@idtipousuario", pUsuarioModel.TipoUsuarioModel.IdTipoUsuario);
                    comando.Parameters.AddWithValue("@idsituacao", pUsuarioModel.SituacaoModel.IdSituacao);
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


        // ========== ALTERA A SITUACAO DO USUARIO INVES DE EXCLUIR ==========
        public int ExcluirUsuarioDAO(int pIdUsuario)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand("uspUsuarioExcluir", this.conn))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@idusuario", pIdUsuario);
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


      /*  public DataTable ObterAllUsuarios(int pIdSituacao)
        {
             try
             {
                return conexao.ExecDataTable("uspUsuarioTodosUsuarios", "@idsituacao", pIdSituacao);
             }
             catch (Exception)
             {
                 throw;
             }

        }*/

        public DataTable ObterAllUsuarios()
        {
            try
            {
                return conexao.ExecDataTable("uspUsuarioTodosOsUsuarios", this.conn);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public int ContarUsuarios()
        {
            try
            {
                DataTable usuarios = conexao.ExecDataTable("uspUsuarioTodosOsUsuarios", this.conn);
                return usuarios.Rows.Count;
            }
            catch (Exception ex)
            {
                // Trate a exceção conforme necessário
                MessageBox.Show($"Erro: {ex.Message}");
                return 0;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUsuarioModel"></param>
        /// <returns></returns>
        public DataTable Localizar(UsuarioModel pUsuarioModel)
        {
            DataTable dt = new DataTable();
            using (SqlCommand comando = new SqlCommand("uspUsuarioLocalizar", this.conn))
            {
                try
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Clear();
                    comando.Prepare();
                    comando.Parameters.AddWithValue("@login", pUsuarioModel.Login);
                    comando.Parameters.AddWithValue("@senha", pUsuarioModel.Senha);

                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    adapter.Fill(dt);   

                }
                catch (InvalidOperationException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    throw;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    throw;
                }
            }
            return dt;
        }



        public List<UsuarioModel> RecuperarSenhaUsuarioDAO(UsuarioModel usuario)
        {
            List<UsuarioModel> usuariosRecuperados = new List<UsuarioModel>();

            try
            {
                this.conn.Open(); // Abre a conexão com o banco de dados.
                SqlCommand comando = new SqlCommand("SELECT Login, Senha FROM Usuario WHERE email = @Email", this.conn);
                comando.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar) { Value = usuario.Email });

                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    UsuarioModel usuarioRecuperado = new UsuarioModel();
                    usuarioRecuperado.Login = dr["Login"].ToString();
                    usuarioRecuperado.Senha = dr["Senha"].ToString();
                    usuariosRecuperados.Add(usuarioRecuperado);
                }

                return usuariosRecuperados;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
                return null;
            }
            finally
            {
                this.conn.Close(); // Certifique-se de fechar a conexão com o banco de dados, seja qual for o resultado.
            }
        }
        #endregion Métodos






        public void AlterarMinhaSenhaDAO(UsuarioModel usuario)
        {
            this.conn.Open(); // Abre a conexão com o banco de dados.
            string updateQuery = "UPDATE Usuario SET Senha = @NovaSenha WHERE Login = @NomeUsuario";

            try
            {
                using (SqlCommand command = new SqlCommand(updateQuery, this.conn))
                {
                    command.Parameters.AddWithValue("@NovaSenha", usuario.Senha);
                    command.Parameters.AddWithValue("@NomeUsuario", usuario.Login);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Senha alterada com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Nenhum registro encontrado para o nome de usuário especificado.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro: " + ex.Message);
            }
            finally
            {
                this.conn.Close(); // Certifique-se de fechar a conexão com o banco de dados, seja qual for o resultado.
            }

        }


        /*    public void AlterarMinhaSenhaDAO(UsuarioModel usuario)
      {

          this.conn.Open(); // Abre a conexão com o banco de dados.

          string updateQuery = "UPDATE Usuarios SET Senha = @NovaSenha, Foto = @NovaFoto WHERE NomeUsuario = @NomeUsuario";

          using (SqlCommand command = new SqlCommand(updateQuery, this.conn))
          {
              command.Parameters.AddWithValue("@NovaSenha", usuario.Senha);
              command.Parameters.AddWithValue("@NomeUsuario", usuario.Login);
              // Converta a imagem para bytes e adicione como parâmetro
              command.Parameters.AddWithValue("@NovaFoto", usuario.FuncionarioModel.Foto);

              int rowsAffected = command.ExecuteNonQuery();

              if (rowsAffected > 0)
              {
                  Console.WriteLine("Senha e foto alteradas com sucesso!");
              }
              else
              {
                  Console.WriteLine("Nenhum registro encontrado para o nome de usuário especificado.");
              }
          }

      }
  */




    }
}
