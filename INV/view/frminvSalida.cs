using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INV.control;
using INV.model;
namespace INV
{
    public partial class frminvSalida : Form
    {
        public int id_entidad=0;
        public frminvSalida()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            producto _producto = new producto();
            ctrlproducto ctrlproducto = new ctrlproducto();

            _producto.Nom_producto = txtnomProducto.Text;
            _producto.Costo_producto = Double.Parse(txtcosto.Text);
            _producto.Precio_producto= Double.Parse(txtprecio.Text);
            _producto.Existencia_producto = Int32.Parse(txtexistencia.Text);
            _producto.Id_entidad = id_entidad;
            if (ctrlproducto.insert(_producto))
            {
                MessageBox.Show(" Información Guardada Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" La información no pudo ser Guardada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
