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
        string conexao = @"Data Source =.\SqlExpress;Initial Catalog=projetocidades;user id = sa; pwd=senai@123";

        public List<Usuario> ListarUsuarios()
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

        
    }
}