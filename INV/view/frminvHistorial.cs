using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INV.model;

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
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
