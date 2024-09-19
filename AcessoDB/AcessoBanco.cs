using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SISTEMA_DE_GESTÃO_LOJA.AcessoDB
{
    public class AcessoBanco
    {

        #region Variáveis

        private SqlConnection conectar = null;
        private string strConn = String.Empty;
        private SqlTransaction tran = null;
        private SqlDataAdapter da;
        private SqlCommand sqlComando = null;
        private int intTimeOut = 30;

        #endregion Variáveis

        #region Construtor

        /// <summary>
        /// Construtor da class AcessoBanco
        /// </summary>
        public AcessoBanco() { }

        #endregion Costrutor

        #region Métodos

        public string ObterStringConexao()
        {
            if (strConn.Trim().Length == 0)
            {
                strConn =  ConfigurationManager.ConnectionStrings["StrConn"].ToString();
            }
            return strConn;
        }

        /// <summary>
        /// Método que cria uma conexão com o banco de dados.
        /// </summary>
        /// <returns>SqlConnetion</returns>
        public SqlConnection ConectarBD()
        {
            try
            {
                if (strConn.Trim().Length == 0)
                {
                    strConn = ObterStringConexao(); 
                }
                conectar = new SqlConnection(strConn);
                return conectar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Abre a conexão com o  banco de dados.
        /// </summary>
        /// <returns>SqlConnection com a conexão aberta.</returns>
        public SqlConnection AbrirConexao()
        {
            if (conectar.State == ConnectionState.Closed)
            {
                conectar.Open();
            }
            return conectar;
        }

        /// <summary>
        /// Método que fecha uma conexão aberta com o banco de dados.
        /// </summary>
        public void FecharConexao()
        {
            if (conectar.State == ConnectionState.Open)
            {
                conectar.Close();
            }
        }


        /// <summary>
        /// Método que inicia uma transação
        /// </summary>
        /// <param name="cmd">SqlCommand</param>
        /// <returns>SqlTransaction</returns>
        public SqlTransaction IniciarSqlTransaction(SqlCommand cmd)
        {
            //Começa uma transação local

            this.tran = conectar.BeginTransaction("TransacaoSimples");
            cmd.Connection = conectar;
            cmd.Transaction = this.tran;
            return this.tran;
        }


        /// <summary>
        /// Inicia uma transação
        /// </summary>
        /// <param name="connection">SqlConection</param>
        /// <returns></returns>
        public SqlTransaction IniciarSqlTransaction(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                this.tran = connection.BeginTransaction("Retorna SqlTransaction");
            else
            {
                connection = AbrirConexao();
                this.tran = connection.BeginTransaction("Retorna SqlTransaction");
            }

            return this.tran;
        }






        public SqlCommand CriarSqlCommand()
        {
            return (sqlComando = this.conectar.CreateCommand());
        }

        /// <summary>
        /// Método que commita uma transação feita com sucesso ou executa uma rollback caso contrário.
        /// </summary>
        /// <param name="ret">Boolean</param>
        public void FinalizarTransacao(Boolean ret)
        {
            if (ret)
            {
                tran.Commit();
            }
            else
            {
                tran.Rollback();
            }
        }

        /// <summary>
        /// Executa a consulta com Stored Procedure.
        /// </summary>
        /// <param name="pNomeStoredProcedure">Nome da stored procedure de consulta.</param>
        /// <returns>Retorna um DataTable com os respectivos registros da consulta.</returns>
        public DataTable ExecDataTable(string pNomeStoredProcedure)
        {
            DataTable dt = new DataTable();
            using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure, conectar))
            {
                comando.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(comando);
                try
                {
                    da.Fill(dt);
                }
                catch (InvalidOperationException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return dt;
        }

        public DataTable ExecDataTable(string pNomeStoredProcedure, SqlConnection conn)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(pNomeStoredProcedure, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Executa uma consulta expecífica pelo identificador.
        /// </summary>
        /// <param name="pNomeStoredProcedure">Nome da stored procedure.</param>
        /// <param name="pNomeParametro">Nome do parametro que a stored procedure está esperando.</param>
        /// <param name="pId">Valor do identificador.</param>
        /// <returns>DataTable</returns>
        public DataTable ExecDataTable(string pNomeStoredProcedure, string pNomeParametro, int pId)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure, ConectarBD()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue(pNomeParametro, pId);

                    da = new SqlDataAdapter(comando);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public DataTable ExecDataTable(string pNomeStoredProcedure, string pNomeParametro, string pStr)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure, ConectarBD()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue(pNomeParametro, pStr);

                    da = new SqlDataAdapter(comando);
                    da.Fill(dt);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public SqlDataReader ExecDataReader(string pNomeStoredeProcedure, SqlConnection conn)
        {
            SqlDataReader dr = null;
            using (SqlCommand comando = new SqlCommand(pNomeStoredeProcedure))
            {
                try
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    comando.Connection = conn;
                    dr = comando.ExecuteReader();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    FecharConexao();
                }
            }
            return dr;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNomeStoredProcedure">Nome da stored procedure.</param>
        /// <param name="pNomeParametro">Nome do parametro que a stored procedure está esperando.</param>
        /// <param name="pId">Valor do id.</param>
        /// <returns></returns>
        public SqlDataReader ExecDataReader(string pNomeStoredProcedure, string pNomeParametro, int pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure, conectar))
                {
                    AbrirConexao();
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue(pNomeParametro, pId);

                    SqlDataReader dr = comando.ExecuteReader();
                    FecharConexao();
                    return dr;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SqlDataReader ExecDataReader(string pNomeStoredProcedure)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure, conectar))
                {
                    AbrirConexao();
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = comando.ExecuteReader();
                    return dr;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // ++++++++++++++++++++++++ CRIA DATASET ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /// <summary>
        /// Cria um DataSet.
        /// </summary>
        /// <param name="strSQL">String sql query.</param>
        /// <returns>DataSet</returns>
        public DataSet ExecDataSetQuery(string strSQL)
        {
            da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            try
            {
                sqlComando = new SqlCommand(strSQL, ConectarBD());
                sqlComando.CommandType = CommandType.Text;
                sqlComando.CommandText = strSQL;
                sqlComando.CommandTimeout = intTimeOut;

                da.SelectCommand = sqlComando;

                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Cria um DataSet
        /// </summary>
        /// <param name="pNomeStoredProcedure">Nome da stored procedure.</param>
        /// <returns>DataSet</returns>

        public DataSet ExecDataSet(string pNomeStoredProcedure)
        {
            try
            {
                da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                sqlComando = new SqlCommand(pNomeStoredProcedure, ConectarBD());
                sqlComando.CommandType = CommandType.StoredProcedure;
                sqlComando.CommandText = pNomeStoredProcedure;

                da.SelectCommand = sqlComando;

                da.Fill(ds);

                return ds;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pNomeStoredProcedure">Nome da stored procedure.</param>
        /// <param name="pNomeParametro">Nome do parametro que a stored procedure está recebendo.</param>
        /// <param name="pId">Valor atribuido ao pNomeParemetro.</param>
        /// <returns>DataSet</returns>

        public DataSet ExecDataSet(string pNomeStoredProcedure, string pNomeParametro, string pId)
        {
            try
            {
                using (SqlCommand comando = new SqlCommand(pNomeStoredProcedure, conectar))
                {
                    DataSet ds = new DataSet();
                    da = new SqlDataAdapter();

                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue(pNomeParametro, pId);

                    da.SelectCommand = comando;

                    da.Fill(ds);

                    return ds;
                }
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ++++++++++++++++++++++++ END DATASET +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        public void ZerarValorId(string nomeTabela, int valorId, SqlCommand comando)
        {
            try
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nometabela", nomeTabela);
                comando.Parameters.AddWithValue("@valorid", valorId);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         * 
         * Você pode fazer isso mais ou menos da mesma maneira que faz agora - formatando um insertem um loop, 
         * mas em vez de usar uma inserção por par novo / antigo, use uma instrução para todos os pares. 
         * Você deve usar nomes de colunas explicitamente para evitar depender da ordem das colunas na 
         * tabela (uma grande proibição na produção) e para evitar a criação do segundo parâmetro em um loop, 
         * mesmo que você sempre envie um NULLpara ele.

            var cmdText = new StringBuilder("INSERT INTO ThreadCleanup (id,oldMessage,newMessage) VALUES ");
            var args = new List<Tuple<long,string,string>>();

            foreach (ThreadPost post in ThreadPosts) {
                 int cnt = args.Count();
                 if (cnt != 0) {
                     cmdText.Append(",");
                 }
                 cmdText.AppendFormat("(@id{0}, @old{0}, @new{0})", cnt);
                 args.Add(new Tuple<long,string,string>(post.ID, post.Message, Clean(post.Message)));
            }

            Neste ponto, você tem uma string SQL semelhante a esta:

            INSERT INTO ThreadCleanup (id,oldMessage,newMessage) VALUES
            (@id0, @old0, @new0), (@id1, @old1, @new1), (@id2, @old2, @new2), ...

            Você também tem uma lista de Tuple<long,string,string>para cada um dos parâmetros, então você pode fazer isso:

            if (args.Count != 0) {
                using (SqlConnection con = new SqlConnection(CONNSTR)) {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction(IsolationLevel.ReadUncommitted);
                    try {
                        using (SqlCommand cmd = new SqlCommand(cmdText, con, tran)) {
                           for (var i = 0 ; i != args.Count ; i++) {
                               cmd.Parameters.AddWithValue("@id"+i, args[i].Item1);
                               cmd.Parameters.AddWithValue("@old"+i, args[i].Item2);
                               cmd.Parameters.AddWithValue("@new"+i, args[i].Item3);
                           }
                           cmd.ExecuteNonQuery(); // updated records
                        }
                        tran.Commit();
                    } catch (SqlException ex) {
                        tran.Rollback();
                    }
                    con.Close();
                }
            }

            A vantagem de fazer isso de uma vez é que você faz uma única viagem de ida e volta para o seu banco de dados, 
            não importa quantos registros você deve inserir. Fora isso, a solução segue o mesmo padrão da atual, 
            então o desempenho deve ser comparável.
         */

        #endregion Métodos
    }
}
