using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contabilidad.model;
using Contabilidad.controler;
namespace Contabilidad.view
{
    public partial class frmcntciclo : Form
    {
         DataTable tblperiodo = new DataTable();
            
        public frmcntciclo()
        {
            InitializeComponent();
        }

        private void btnGenPeri_Click(object sender, EventArgs e)
        {

            if (txtEntNo.Text == "") {
                MessageBox.Show("Debe indidcar el año del ciclo contable");
                txtEntNo.Focus();
                return;
            }
            int anio = 0;
            DateTime date;
            try { anio = System.Convert.ToInt16(txtEntNo.Text); }
            catch{
                MessageBox.Show("Error en el año!");
                txtEntNo.Focus();
                return;
            }

            tblperiodo.Rows.Clear();

            for (var x = 1; x <= 12; x++) {
                DataRow row;
                row = tblperiodo.NewRow();
                date = new DateTime(anio, x, 1);
                row["anociclo"] = anio;
                row["periodo"] = date.ToString("MMMM").ToUpper();
                row["estado"] = "CERRADO";
                tblperiodo.Rows.Add(row);
            }

        }

        private void frmcntciclo_Load(object sender, EventArgs e)
        {

            tblperiodo.Columns.Add("anociclo");
            tblperiodo.Columns.Add("periodo");
            tblperiodo.Columns.Add("estado");
            dtgPeriodos.DataSource = tblperiodo;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            CICLO ciclo = new CICLO();
            ciclo.Anio   = txtEntNo.Text;
            ciclo.Estado = "G";
            ctrlcntciclo ctlciclo = new ctrlcntciclo();

            if (ctlciclo.Insert(ciclo, tblperiodo))
            {
                MessageBox.Show("Informacion guarada");
            }
            else {
                MessageBox.Show("Error al guardar");
            }


        }
    }
}
