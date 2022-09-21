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
namespace Contabilidad
{
    public partial class frmcntent : Form
    {
        DataTable tbl_asiento = new DataTable();
        BindingSource BsCuenta = new BindingSource();
        public frmcntent()
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
            foreach (Control ctrl in groupBox2.Controls)
            {

                if (ctrl is TextBox && ctrl.Text == String.Empty)
                {
                    MessageBox.Show("Campo Vacio " + ctrl.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (ctrl.Enabled) ctrl.Focus();
                    return false;
                }
            }
            if (!rbtdebito.Checked && !rbtcredito.Checked)
            {
                MessageBox.Show("Debe seleccionar el tipo de acción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validaciones de entradas

            if (txtConceptoEnt.Text == "")
            {
                MessageBox.Show("Debe indicar el concepto de la entrada de diario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConceptoEnt.Focus();
                return;
            }
            if (txtCtaEntValor.Text == "")
            {
                MessageBox.Show("Debe indicar el valor de la entrada de diario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCtaEntValor.Focus();
                return;
            }
            if (txtFecha.Text == "")
            {
                MessageBox.Show("Debe indicar la fecha de la entrada de diario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFecha.Focus();
                return;
            }

            if (tbl_asiento.Rows.Count == 0) {
                MessageBox.Show("No se han definido asientos contables para la entrada de diario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCtaNo.Focus();
                return;
            }

            //Validacion de cuentas contables 
            //Para registrar la entrada de diario es necesario que el monto del credito sea igual al montro del debito.
            //Cuando eso sucede se dice la el asiciento contable está valaceado.
            double deb = 0;
            double cre = 0;
            foreach (DataRow row in tbl_asiento.Rows)
            {
                if (row["cntctaOrigen"].ToString() == "-1")
                {
                    cre += System.Convert.ToDouble((row["cntctamonto"]));
                }
                else { deb += System.Convert.ToDouble((row["cntctamonto"])); }
            }

            
            if (deb != cre) MessageBox.Show("Las cuentas no estan valanceadas.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            //Registro de la entrada de diario y el asiento contable.
            ENTRADA_DIARIO entrada = new ENTRADA_DIARIO();
            try{entrada.Fecha = System.Convert.ToDateTime(txtFecha.Text);}
            catch{
                MessageBox.Show("Error en la fecha!");
                return;
            }
            try {entrada.ValorEntrada = System.Convert.ToDouble(txtCtaMonto.Text);}
            catch {
                MessageBox.Show("Valor de entrada no valido!");
                return;
            }
            entrada.ConcepEntrada = txtConceptoEnt.Text;

            ctrlcntent ctrlEntrada = new ctrlcntent();
            if (ctrlEntrada.insert(entrada, tbl_asiento))
                MessageBox.Show("Informacion guardada con exito!");
            else MessageBox.Show("Error al guardada!");


        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
          
        }

        private void btnBusCta_Click(object sender, EventArgs e)
        {
            frmbuscador _buscar = new frmbuscador();
            _buscar.StartPosition = FormStartPosition.CenterScreen;
            _buscar.sql = "select cntctano as codigo, cntctanom as nombre from cuenta where cntctatipo = 'D'";
            _buscar.ShowDialog();
            txtCtaNo.Text = _buscar.codigo;
            txtCtaNom.Text = _buscar.nombre;
        }

        private void btnConAgregar_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = tbl_asiento.NewRow();
            row["cntctano"] = txtCtaNo.Text;
            row["cntctanom"] = txtCtaNom.Text;
            row["cntctamonto"] = txtCtaMonto.Text;
            row["cntctaOrigen"] = rbtcredito.Checked ? -1 : 1;
            tbl_asiento.Rows.Add(row);
        }

        private void frmcntent_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToString("dd/MM/yyyy");
            tbl_asiento.Columns.Add("cntctano");
            tbl_asiento.Columns.Add("cntctanom");
            tbl_asiento.Columns.Add("cntctamonto");
            tbl_asiento.Columns.Add("cntctaOrigen");
            BsCuenta.DataSource = tbl_asiento;
            //txtCtaNo.DataBindings.Clear();
            //txtCtaNom.DataBindings.Clear();
            //txtCtaMonto.DataBindings.Clear();

            BsCuenta.MoveFirst();
            //txtCtaNom.DataBindings.Add("Text", BsCuenta, "cntctanom");
            //txtCtaNo.DataBindings.Add("Text", BsCuenta, "cntctano");
            //txtCtaMonto.DataBindings.Add("Text", BsCuenta, "cntctamonto");
            dtgTipos.DataSource = BsCuenta;
        }

        private void btnConAceptar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnConBorrar_Click(object sender, EventArgs e)
        {
            DataRow row;
            row = tbl_asiento.Rows[BsCuenta.Position];
            row.Delete();
        }
    }
}
