using RecetasSLN.dominio;
using RecetasSLN.servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {
        Iservicio servicio;


        public FrmConsultarRecetas(factory fabrica)
        {
            servicio = fabrica.crearServicio();
            InitializeComponent();
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvRecetas.Rows.Clear();
            List<receta> lstRecetas = servicio.consultaParametro(cboTipoReceta.TabIndex, txtNombre.Text);

            foreach (receta item in lstRecetas)
            {
                dgvRecetas.Rows.Add(new object[] { item.nombre,item.tipoReceta,item.cheff});
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
