using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    internal interface IrecetasDao
    {
        DataTable consultarSQL(string SP);
        bool MaestroDetalle(receta receta);
    }
}
