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
    }
}

