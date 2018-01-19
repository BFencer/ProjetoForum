using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using System.Text;


namespace Forum.Models
{
    public class DAOUsuario
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader dtReader = null;
        StringBuilder sbSQL = new StringBuilder();
        string conexao = @"Data Source =.\SqlExpress;Initial Catalog=Forum;user id = sa; pwd=senai@123";

        public List<Usuario> Listar()
        {
            var Usuarios = new List<Usuario>();
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = conexao;
                cn.Open();

                cmd = new SqlCommand();
                cmd.Connection = cn;
                sbSQL.Remove(0, sbSQL.Length);
                sbSQL.Append("Select *     ");
                sbSQL.Append("from Usuario ");
                cmd.CommandText = sbSQL.ToString();
                cmd.CommandType = CommandType.Text;
                dtReader = cmd.ExecuteReader();

                while(dtReader.Read()){
                    Usuarios.Add(new Usuario(){
                        Id = dtReader.GetInt32(0),
                        Nome = dtReader.GetString(1),
                        Login = dtReader.GetString(2),
                        Senha = dtReader.GetString(3),
                        DataCadastro = dtReader.GetDateTime(4)
                    });
                }
            }
            catch(SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            return Usuarios;
        }

        public bool Cadastrar(Usuario user)
        {
            bool resultado = false;
            try
            {

                cn = new SqlConnection();
                cn.ConnectionString = conexao;
                cn.Open();

                cmd = new SqlCommand();
                cmd.Connection = cn;
                sbSQL.Remove(0, sbSQL.Length);
                sbSQL.Append("insert into Usuario(   ");
                sbSQL.Append("nome,                  ");
                sbSQL.Append("login,                 ");
                sbSQL.Append("senha)                 ");
                sbSQL.Append("values                 ");
                sbSQL.Append("(@nome,                ");
                sbSQL.Append("@login,                ");
                sbSQL.Append("@senha)                ");
                cmd.CommandText = sbSQL.ToString();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@nome",user.Nome);
                cmd.Parameters.AddWithValue("@login",user.Login);
                cmd.Parameters.AddWithValue("@senha",user.Senha);
                
                if(cmd.ExecuteNonQuery() > 0)
                {
                    resultado = true;
                }else{
                    resultado = false;
                }

            }
            catch(SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            
            return resultado;
        }

    }
}