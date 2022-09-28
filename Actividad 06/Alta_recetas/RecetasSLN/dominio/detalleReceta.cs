using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class detalleReceta
    {
        public ingreciente ingrediente { get; set; }
        public int cantidad { get; set; }

        public detalleReceta(ingreciente  ingreciente,int cantidad)
        {
            ingreciente = ingreciente;
            cantidad = cantidad;
        }
    }
}
