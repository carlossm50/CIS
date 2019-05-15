using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contabilidad.controler;
namespace Contabilidad
{
    public partial class frmcnttrn : Form
    {
        public frmcnttrn()
        {
            InitializeComponent();
        }
        private bool validacampos()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {

                if (ctrl is TextBox && ctrl.Text == String.Empty && ctrl.Name != "txtcntfecha" && ctrl.Name != "txtcnttrnid")
                {
                    MessageBox.Show("Campo Vacio " + ctrl.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (ctrl.Enabled) ctrl.Focus();
                    return false;
                }
                if (ctrl is ComboBox && ctrl.Text == String.Empty)
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
            TRANSACCION _transaccion = new TRANSACCION();
            ctrlcnttrn ctrltrn = new ctrlcnttrn();
            string[] tipotransaccion;
            if (validacampos())
            {                
                _transaccion.Cnttrnconc = txttrnconcepto.Text;
                _transaccion.Cnttrnvalor = Decimal.Parse(txttrnvalor.Text);
                _transaccion.Cnttrnfecha = DateTime.Now;
                tipotransaccion = cbmtrnTipo.Text.Split('-');
                _transaccion.Cnttiptrnid = int.Parse(tipotransaccion[0]);
                if (ctrltrn.insert(_transaccion))
                {
                    MessageBox.Show("Información guardada satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
                
            }
        }

        private void txtcnttrnid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        private void txttrnvalor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar !='.')
               e.Handled = true;            
        }

        private void frmcnttrn_Load(object sender, EventArgs e)
        {
            List<string> Lista = new List<string>();
            ctrlcnttrn ctrltrn = new ctrlcnttrn();
            Lista = ctrltrn.BucarCBO("select cnttiptrnid,cnttiptrnnombre from tipotransaccion;");
            foreach (string s in Lista)
            {
                cbmtrnTipo.Items.Add(s);
            }
        }
    }
}
