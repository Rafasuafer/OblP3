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

        public bool Add(Proyecto unP)
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
