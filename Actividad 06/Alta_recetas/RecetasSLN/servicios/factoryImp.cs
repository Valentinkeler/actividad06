using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios
{
    internal class factoryImp:factory
    {
        public override Iservicio crearServicio()
        {
            return new servicio();
        }
    }
}
