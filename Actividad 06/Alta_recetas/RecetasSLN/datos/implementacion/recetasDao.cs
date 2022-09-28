using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    internal class recetasDao:IrecetasDao
    {
        public List<receta> consultaParametro(int tipoReceta, string nombre)
        {
            List<receta> recetas = new List<receta>();
            List<parametros>  parametros=new List<parametros>();
            parametros.Add(new parametros("@tipoReceta", tipoReceta));
            parametros.Add(new parametros("@nombre", nombre));

            DataTable tabla = HelperDao.obtenerInstancia().consultaParametro("SP_consultar_receta", parametros);

            foreach (DataRow row in tabla.Rows)
            {
                receta oReceta = new receta();
                oReceta.recetaNro =Convert.ToInt32(row["id_receta"]);
                oReceta.nombre = row["nombre"].ToString();
                oReceta.cheff = row["cheff"].ToString();
                oReceta.tipoReceta = Convert.ToInt32(row["tipo_receta"]);
                recetas.Add(oReceta);
            }

            return recetas;
        }

        public  DataTable consultarSQL()
        {
            return HelperDao.obtenerInstancia().consultarSQL("SP_CONSULTAR_INGREDIENTES");     
        }

        public bool MaestroDetalle(receta receta)
        {
            bool ok = true;
            SqlConnection cnn = HelperDao.obtenerInstancia().ObtenerConexion();
            SqlTransaction t = null;
            SqlCommand cmd = new SqlCommand();
            try
            {

                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandText = "SP_INSERTAR_RECETA";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tipo_receta", receta.tipoReceta);
                cmd.Parameters.AddWithValue("@nombre", receta.nombre);
                cmd.Parameters.AddWithValue("@cheff", receta.cheff);

                cmd.ExecuteNonQuery();

                SqlCommand cmdDetalle;
                int idIngrediente = 1;
                foreach (detalleReceta item in receta.detallesReceta)
                {
                    cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetalle.CommandType = CommandType.StoredProcedure;
                    cmdDetalle.Parameters.AddWithValue("@id_receta", );
                    cmdDetalle.Parameters.AddWithValue("@id_ingrediente", idIngrediente);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.cantidad);
                    cmdDetalle.ExecuteNonQuery();

                    idIngrediente++;
                }
                t.Commit();
            }

            catch (Exception)
            {
                if (t != null)
                    t.Rollback();
                ok = false;
            }

            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return ok;
        }

        public int proxReceta()
        {
            return HelperDao.obtenerInstancia().proximaReceta("ProximaReceta");
        }
    }
}
