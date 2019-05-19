using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INV.model;
using INV.control;
namespace INV
{
    public partial class frminvEntrada : Form
    {
        public frminvEntrada()
        {
            InitializeComponent();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            ctrlentidad ctrlentidad = new ctrlentidad();
            entidad entidad = new entidad();

            if (txtnombre.Text.Trim() == String.Empty) {
                MessageBox.Show("Debe completar el nombre de la entidad.","Información",MessageBoxButtons.OK);
                txtnombre.Focus();
                return;
            }
            
            if (txtinvInicial.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Debe completar el inventario inicial.", "Información", MessageBoxButtons.OK);
                txtinvInicial.Focus();
                return;
            }

            entidad.Nom_entidad = txtnombre.Text;
            entidad.Ref_entidad = txtreferencia.Text;
            entidad.Valor_invInicial = Int32.Parse(txtinvInicial.Text);

            if (ctrlentidad.insert(entidad))
            {
                MessageBox.Show(" Información Guardada Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else {
                MessageBox.Show(" La información no pudo ser Guardada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtinvInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '.' && !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtinvInicial.Text.IndexOf('.') >= 0)
            {
                e.Handled = true;
            }
        }
    }
}
