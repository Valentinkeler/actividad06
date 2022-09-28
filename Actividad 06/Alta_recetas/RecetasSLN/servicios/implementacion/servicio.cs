using RecetasSLN.datos;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios
{
    internal class servicio:Iservicio
    {
        private IrecetasDao Dao;
        public servicio()
        {
            Dao = new recetasDao();
        }

        public List<receta> consultaParametro(int tipoReceta, string nombre)
        {
            return Dao.consultaParametro(tipoReceta, nombre);
        }

        public  DataTable consultarSQL()
        {
            return Dao.consultarSQL();
        }
        public  bool maestroDetalle(receta receta)
        {
            return Dao.MaestroDetalle(receta);
        }

        public int proxReceta()
        {
            return Dao.proxReceta();
        }
    }
}
