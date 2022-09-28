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

        public  DataTable consultarSQL(string SP)
        {
            return Dao.consultarSQL(SP);
        }
        public  bool maestroDetalle(receta receta)
        {
            return Dao.MaestroDetalle(receta);
        }
    }
}
