using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    class HelperDao
    {
        private static HelperDao instancia;
        private SqlConnection conexion;

        private HelperDao()
        {
            conexion = new SqlConnection(Properties.Resources.coneccionString);
        }

        public static HelperDao obtenerInstancia()
        {
            if (instancia == null)
                instancia = new HelperDao();
            return instancia;
        }

        public DataTable consultarSQL(string SP)
        {           
            SqlCommand cmd = new SqlCommand(SP,conexion);
            conexion.Open();
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            conexion.Close();
            return tabla;
        }
        public SqlConnection ObtenerConexion()
        {
            return this.conexion;
        }
        public  DataTable consultaParametro(string  SP,List<parametros> parametro)
        {
            SqlCommand comando = new SqlCommand(SP,conexion);
            conexion.Open();
            comando.CommandType= CommandType.StoredProcedure;

            if (parametro==null)
            {
                foreach (parametros oparametro in parametro)
                {
                    comando.Parameters.AddWithValue(oparametro.Clave, oparametro.valor);
                }
            }
            DataTable tabla = new DataTable();
            tabla.Load(comando.ExecuteReader());

            conexion.Close();

            return  tabla;
        }
        public int proximaReceta(string SP)
        {
            SqlCommand comando = new SqlCommand(SP, conexion);
            conexion.Open();
            comando.CommandType = CommandType.StoredProcedure;

            int prox = comando.ExecuteNonQuery();

            conexion.Close();
            return prox;
        }

    }
}

