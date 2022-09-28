using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.datos
{
    internal class parametros
    {
        public string Clave { get; set; }
        public object valor { get; set; }
        public parametros(string Clave, object valor)
        {
            Clave = Clave;
            valor = valor;
        }
    }
}
