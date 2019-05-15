using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class frmcntrub : Form
    {
        public frmcntrub()
        {
            InitializeComponent();
        }
        private bool validacampos()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {

                if (ctrl is TextBox && ctrl.Text == String.Empty)
                {
                    MessageBox.Show("Campo Vacio " + ctrl.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (ctrl.Enabled) ctrl.Focus();
                    return false;
                }
            }
           
            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (validacampos()) {
                MessageBox.Show("Información guardada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
