using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.servicios
{
    public abstract class factory
    {
        public abstract Iservicio crearServicio();
    }
}
