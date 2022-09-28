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
        DataTable consultarSQL();
        bool MaestroDetalle(receta receta);
        List<receta> consultaParametro(int  tipoReceta,string   nombre);
        int proxReceta();
    }
}
