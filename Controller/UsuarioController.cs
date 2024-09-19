using SISTEMA_DE_GESTÃO_LOJA.DAO;
using SISTEMA_DE_GESTÃO_LOJA.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SISTEMA_DE_GESTÃO_LOJA.Controller
{
    public class UsuarioController
    {
            #region Variáveis

            private UsuarioDAO usuarioDAO = null;

            #endregion Variáveis

            #region Construtor

            public UsuarioController()
            {
               usuarioDAO = new UsuarioDAO();
            }

        #endregion Construtor

        #region Métodos

        

            public int IncluirUsuarioController(UsuarioModel usuarioModel)
            {
                return usuarioDAO.IncluirUsuarioDAO(usuarioModel);
            }

            public int AlterarUsuarioController(UsuarioModel usuarioModel)
            {
                return usuarioDAO.AlterarUsuarioDAO(usuarioModel);
            }

            public int ExcluirUsuarioController(int pIdUsuario)
            {
                return usuarioDAO.ExcluirUsuarioDAO(pIdUsuario);
            }



           public int ContarUsuariosController()
           {
                DataTable usuarios = usuarioDAO.ObterAllUsuarios();
                return usuarios.Rows.Count;
           }

           public DataTable ObterRegistrosUsuarios()
           {
             return usuarioDAO.ObterAllUsuarios();
           }


          /*public DataTable ObterRegistrosUsuarios(int pIdSituacao)
            {
                return usuarioDAO.ObterAllUsuarios(pIdSituacao);
            }*/

 
            public void PesquisarUsuarios(DataGridView dtg, string texto)
            {
                ((DataTable)dtg.DataSource).DefaultView.RowFilter = string.Format("NomeCidade" + " like '%{0}%'", texto.Replace("'", "''"));
            }

            public void PopularCboFuncionario(ComboBox cbo)
            {
               FuncionarioController funcionarioController = new FuncionarioController();
               funcionarioController.PreencherCboFuncionario(cbo);
            }

            public void PopularCboSituacao(ComboBox cbo)
            {
               SituacaoController situacaoController = new SituacaoController();
               situacaoController.PreencherCboSituacao(cbo);
            }

            public void PopularCboTipoUsuario(ComboBox cbo)
            {
               TipoUsuarioController tipoUsuarioController = new TipoUsuarioController();
               tipoUsuarioController.PreencherCboTipoUsuario(cbo);
            }


            public List<UsuarioModel> ValidarUsuario(UsuarioModel pUsuarioModel)
            {
               
                  List<UsuarioModel> ListaUsuario = new List<UsuarioModel>();
                  UsuarioModel usuarioModel = new UsuarioModel();
              try 
              {
                       DataTable dataTable = new DataTable();
                       dataTable = usuarioDAO.Localizar(pUsuarioModel);

                 if (dataTable.Rows.Count > 0)
                 {

                     foreach(DataRow Datarow in dataTable.Rows)
                     {
                        usuarioModel.Login = Datarow["Login"].ToString();
                        usuarioModel.Senha = Datarow["Senha"].ToString();
                        usuarioModel.TipoUsuarioModel.SiglaTipoUsuario  = Datarow["SiglaTipoUsuario"].ToString();
                        usuarioModel.FuncionarioModel.IdFuncionario = Convert.ToInt16(Datarow["IdFuncionario"].ToString());
                        usuarioModel.FuncionarioModel.NomeFunc   = Datarow["NomeFunc"].ToString();
                        usuarioModel.TipoUsuarioModel.IdTipoUsuario = Convert.ToInt16(Datarow["IdTipoUsuario"].ToString());
                        usuarioModel.SituacaoModel.IdSituacao = Convert.ToInt16(Datarow["IdSituacao"].ToString());

                         ListaUsuario.Add(usuarioModel);
                     }
                 }
                return ListaUsuario;
              }
                catch (Exception e)
              {
                MessageBox.Show("Ocorreu um erro: " + e.Message);
                return null;
              }
            }

            public List<UsuarioModel> RecuperarSenhaUsuarioController(UsuarioModel pusuario)
            {
               try
               {
                   List<UsuarioModel> ListaUsuario = new List<UsuarioModel>();
                   return ListaUsuario = usuarioDAO.RecuperarSenhaUsuarioDAO(pusuario);

               }catch (Exception ex) 
               {
                  MessageBox.Show("Ocorreu um erro: " + ex.Message);
                  return null;
               }
            }


           public void AlterarSenhaController(UsuarioModel usuario)
           {
              usuarioDAO.AlterarMinhaSenhaDAO(usuario);
           }


        #endregion Métodos






    }
    }
