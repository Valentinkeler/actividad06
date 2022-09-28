using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios
{
    internal interface Iservicio
    {
        DataTable consultarSQL(string SP);
        bool maestroDetalle(receta receta);
    }
}
