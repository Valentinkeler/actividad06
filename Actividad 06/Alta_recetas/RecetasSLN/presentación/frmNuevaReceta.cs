using RecetasSLN.datos;
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
    public partial class frmNuevaReceta : Form
    {
        private Iservicio servicio;
        private receta  receta;
        public frmNuevaReceta(factory fabrica)
        {
            servicio = fabrica.crearServicio();
            receta = new receta();
            InitializeComponent();
        }

        private void frmNuevaReceta_Load(object sender, EventArgs e)
        {
            cargarCombo();
            limpiar();
        }

        private void cargarCombo()
        {
           DataTable tabla = servicio.consultarSQL("SP_CONSULTAR_INGREDIENTES");
           cboIngredientes.DataSource = tabla;
            cboIngredientes.DisplayMember = tabla.Columns[1].ColumnName;
            cboIngredientes.ValueMember = tabla.Columns[0].ColumnName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cboIngredientes.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un ingrediente!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCantidad.Text == "" || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            foreach (DataGridViewRow row in dgvIngredientes.Rows)
            {
                if (row.Cells["colngrediente"].Value.ToString().Equals(cboIngredientes.Text))
                {
                    MessageBox.Show("INGREDIENTE: " + cboIngredientes.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            ingreciente i = (ingreciente)cboIngredientes.SelectedItem;
            int cantidad =Convert.ToInt32(txtCantidad.Text);

            detalleReceta   detalle = new  detalleReceta(i,cantidad);
            receta.agregarDetalle(detalle);

            dgvIngredientes.Rows.Add(new object[] { i.nombre, i.unidad });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            receta.nombre = txtNombre.Text;
            receta.cheff = txtCheff.Text;
            receta.tipoReceta =Convert.ToInt32(txtTipoReceta);

            foreach (DataGridViewRow row in dgvIngredientes.Rows)
            {
                if (row.Cells.Count>3)
                {
                    if (servicio.maestroDetalle(receta))
                    {
                        MessageBox.Show("receta guardad", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("ERROR. No se pudo guardar la receta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR. ha olvidado ingredientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            limpiar();
        }

        private void limpiar()
        {
            txtNombre.Text  =String.Empty;
            txtCheff.Text = String.Empty;
            txtCantidad.Text = String.Empty;
            txtTipoReceta.Text = String.Empty;
            cboIngredientes.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();
        }
    }
}
