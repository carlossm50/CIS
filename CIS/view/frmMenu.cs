using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CIS
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void formularioXToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // frmArticulos frmArticulos = new frmArticulos();
            /*frmClientes frmArticulos = new frmClientes();
            frmArticulos.MdiParent = this;
            frmArticulos.StartPosition = FormStartPosition.CenterScreen;
            frmArticulos.Show();*/
            frmClientes frmClientes = new frmClientes();
            frmClientes.MdiParent = this;
            frmClientes.StartPosition = FormStartPosition.CenterScreen;
            frmClientes.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void leyendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLeyenda frmLeyenda = new frmLeyenda();
            frmLeyenda.MdiParent = this;
            frmLeyenda.StartPosition = FormStartPosition.CenterScreen;
            frmLeyenda.Show();
        }

        private void articuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulos frmArticulos = new frmArticulos();
            frmArticulos.MdiParent = this;
            frmArticulos.StartPosition = FormStartPosition.CenterScreen;
            frmArticulos.Show();

        }
    }
}
