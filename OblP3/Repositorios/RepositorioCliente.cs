using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;


namespace Repositorios
{
    class RepositorioCliente
    {
        public bool Add(Cliente unC)
        {
            if (unC == null || !Cliente.Validar(unC))
                return false;

            SqlConnection cn = new Conexion().CrearConexion();
            SqlCommand cmdCli = new SqlCommand(@"INSERT INTO Cliente VALUES
											( @Ci, @Password, @Rol, @Nombre, @Celular, @Email, @FechaNacimiento)", cn);
            
            cmdCli.Parameters.AddWithValue("@Ci", unC.Ci);
            cmdCli.Parameters.AddWithValue("@Password", unC.Password);
            cmdCli.Parameters.AddWithValue("@Rol", unC.Rol);
            cmdCli.Parameters.AddWithValue("@Nombre", unC.Nombre);
            cmdCli.Parameters.AddWithValue("@Celular", unC.Celular);
            cmdCli.Parameters.AddWithValue("@Email", unC.Email);
            cmdCli.Parameters.AddWithValue("@FechaNacimiento", unC.FechaNacimiento);

            SqlTransaction trn = null;

            try
            {
                if (new Conexion().AbrirConexion(cn))
                {
                    trn = cn.BeginTransaction();
                    cmdCli.Transaction = trn;
                    int filas = cmdCli.ExecuteNonQuery();

                                    }
                return false;
            }
            catch (SqlException ex)
            {
                trn.Rollback();
                return false;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                return false;
            }
            finally
            {
                new Conexion().CerrarConexion(cn);
            }

        }

    }
}
