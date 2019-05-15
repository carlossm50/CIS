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
            entidad.Nom_entidad = txtnombre.Text;
            entidad.Ref_entidad = txtreferencia.Text;
            entidad.Valor_invInicial = Int32.Parse(txtinvInicial.Text);

            if (ctrlentidad.insert(entidad))
            {
                MessageBox.Show(" Información Guardada Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show(" La información no pudo ser Guardada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
