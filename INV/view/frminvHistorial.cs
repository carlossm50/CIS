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
    public partial class frminvHistorial : Form
    {
        public invhistoricom historicom = new invhistoricom();
        public invhistoricod historicod = new invhistoricod();
        public string entidad;
        public frminvHistorial()
        {
            InitializeComponent();            
        }
        

        private void frminvHistorial_Load(object sender, EventArgs e)
        {
            txtentidad.Text = entidad;
            txtfecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            historicom.Fecha_inventario = DateTime.Today;
        }

       

        private void btngenerar_Click(object sender, EventArgs e)
        {
            ctrlinvhistoricom historico = new ctrlinvhistoricom();
            if (historico.insertHistM(historicom)) {
                MessageBox.Show("El proceso ha finalizado exitosamente.", "Información", MessageBoxButtons.OK);
                this.Close();
            }


        }

    }
}
