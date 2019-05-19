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

            if (txtnomProducto.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debe completar el nombre del producto.", "Información", MessageBoxButtons.OK);
                txtnomProducto.Focus();
                return;
            }
            if (txtcosto.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debe completar el costo del producto.", "Información", MessageBoxButtons.OK);
                txtcosto.Focus();
                return;
            }
            if (txtprecio.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debe completar el precio del producto.", "Información", MessageBoxButtons.OK);
                txtprecio.Focus();
                return;
            }
            if (txtexistencia.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debe completar la existencia del producto.", "Información", MessageBoxButtons.OK);
                txtexistencia.Focus();
                return;
            }
            _producto.Nom_producto = txtnomProducto.Text;
            _producto.Costo_producto = Double.Parse(txtcosto.Text);
            _producto.Precio_producto= Double.Parse(txtprecio.Text);
            _producto.Existencia_producto = Int32.Parse(txtexistencia.Text);
            _producto.Id_entidad = id_entidad;
            if (ctrlproducto.insert(_producto))
            {
                MessageBox.Show(" Información Guardada Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(" La información no pudo ser Guardada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtcosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.' && !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtcosto.Text.IndexOf('.') >= 0)
            {
                e.Handled = true;
            }
        }

        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.' && !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtprecio.Text.IndexOf('.') >= 0)
            {
                e.Handled = true;
            }
        }

        private void txtexistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.' && !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtexistencia.Text.IndexOf('.') >= 0)
            {
                e.Handled = true;
            }
        }
    }
}
