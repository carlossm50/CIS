using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace INV.view
{
      
    public partial class invetarioRPT : Form
    {
        public int historico = 0;
        public invetarioRPT()
        {
            InitializeComponent();
        }

        private void invetarioRPT_Load(object sender, EventArgs e)
        {
            CrystalReport11.SetParameterValue("idhistorico", historico);
            crystalReportViewer1.ReportSource = CrystalReport11;
            crystalReportViewer1.Refresh();
        }
    }
}
