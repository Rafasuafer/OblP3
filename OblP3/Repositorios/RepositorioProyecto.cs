using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Repositorios
{
    public class RepositorioProyecto: IProyecto<Proyecto>
    {
        public List<Proyecto> Proyectos;

        /*public bool Add(Proyecto unP)
        {

            if (!unP.Validar()) return false;
            // Conexion unaCon = new Conexion();
            SqlConnection cn = unaCon.CrearConexion();
            SqlCommand cmd = new SqlCommand("INSERT INTO Proyecto VALUES (@Titulo, @Descripcion, @MontoSolicitado, @CantidadCuotas)", cn);
            cmd.Parameters.Add(new SqlParameter("@Titulo", unP.Titulo));
            cmd.Parameters.Add(new SqlParameter("@Descripcion", unP.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@MontoSolicitado", unP.MontoSolicitado));
            cmd.Parameters.Add(new SqlParameter("@CantidadCuotas", unP.CantidadCuotas));
            try
            {
                if (unaCon.AbrirConexion(cn))
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                unaCon.CerrarConexion(cn);
            }
        }*/

        public bool Add(Proyecto unP)
        {
            //Tendría todo el código de ADO.NET para hacer el INSERT  a través de comandos.

            if (unP == null || !unP.Validar())
                return false;

            Conexion unaCon = new Conexion();
            SqlConnection cn = unaCon.CrearConexion();
            SqlCommand cmd = new SqlCommand("INSERT INTO Proyecto VALUES (@Titulo, @Descripcion, @Monto, @Cuotas, @Tasa, @Fecha )", cn);
            cmd.Parameters.Add(new SqlParameter("@Titulo", unP.Titulo));
            cmd.Parameters.Add(new SqlParameter("@Descripcion", unP.Descripcion));
            cmd.Parameters.Add(new SqlParameter("@Monto", unP.MontoSolicitado));
            cmd.Parameters.Add(new SqlParameter("@CantidadCuotas", unP.CantidadCuotas));
            cmd.Parameters.Add(new SqlParameter("@Tasa", unP.Tasa));
            cmd.Parameters.Add(new SqlParameter("@Fecha", unP.Fecha));


            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            SqlTransaction trn = null;
            try
            {
                if (unaCon.AbrirConexion(cn))
                {
                    //Inicia la transacción
                    trn = cn.BeginTransaction();
                    //Asignarle la transacción a cada uno de los comandos
                    //que querés que sean transaccionales:
                    cmd.Transaction = trn;
                    int idAsignado = (int)cmd.ExecuteScalar();
                    if (unP is Personal)
                    {
                        Personal p = (Personal)unP;
                        cmd2.CommandText = "INSERT INTO ProductoImportado VALUES (@Explicacion)";
                        cmd2.Parameters.Add(new SqlParameter("@Explicacion", p.Explicacion));
                        

                    }
                    else if (unP is Cooperativo)
                    {
                        Cooperativo c = (Cooperativo)unP;
                        cmd2.CommandText = "INSERT INTO ProductoNacional VALUES (@Integrantes)";
                        cmd2.Parameters.Add(new SqlParameter("@Integrantes", c.Ingtegrantes));
                 
                    }
                    else
                    {
                        return false;
                    }
                    //Asignarle la transacción al segundo comando
                    cmd2.Transaction = trn;

                    cmd2.ExecuteNonQuery();
                    //Si llegué ácá se pudieron ejecutar todas las operaciones
                    //xq sino hubiera saltado x el catch, así que hacemos el commit:
                    trn.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                trn.Rollback();
                return false;
            }
            finally
            {
                unaCon.CerrarConexion(cn);
            }



        }


        public IEnumerable<Proyecto> FindAll()
        {
            Conexion unaCon = new Conexion();
            SqlConnection cn = unaCon.CrearConexion();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Proyecto", cn);
            try
            {
                if (unaCon.AbrirConexion(cn))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Proyecto> listaProy = new List<Proyecto>();
                    while (dr.Read())
                    {
                        listaProy.Add(new Proyecto
                        {
                            Id = (int)dr["Id"],
                            Titulo = dr["Descripcion"].ToString(),
                            Descripcion = dr["Nombre"].ToString()
                        });
                    }
                    return listaProy;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                unaCon.CerrarConexion(cn);
            }
        }

        public Proyecto GetTbyId(object clave)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Proyecto unT)
        {
            throw new NotImplementedException();
        }

        public bool Update(Proyecto unT)
        {
            throw new NotImplementedException();
        }
    }
}
