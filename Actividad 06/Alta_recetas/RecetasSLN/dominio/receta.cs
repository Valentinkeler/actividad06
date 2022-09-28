using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class receta
    {
        public int recetaNro { get; set; }
        public string nombre { get; set; }
        public int tipoReceta { get; set; }
        public string cheff { get; set; }
        public List<detalleReceta> detallesReceta { get; set; }

        public receta()
        {
            detallesReceta = new List<detalleReceta>();
        }

        public  void agregarDetalle(detalleReceta   detalle)
        {
            detallesReceta.Add(detalle);
        }
        public void quitarDetalle(int indice)
        {
            detallesReceta.RemoveAt(indice);
        }

    }
}
