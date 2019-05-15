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
    public partial class frmcntcta : Form
    {
        public frmcntcta()
        {
            InitializeComponent();
        }
        private bool validacampos() {
            foreach (Control ctrl in groupBox1.Controls) {
                //MessageBox.Show(ctrl.GetType().ToString());
                if (ctrl is TextBox && ctrl.Text == String.Empty)
                {
                    MessageBox.Show("Campo Vacio "+ctrl.Tag,"Validación",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    if (ctrl.Enabled) ctrl.Focus();
                    return false;                    
                }
            }
            if (!rbtmaestra.Checked && !rbtdetalle.Checked){
                MessageBox.Show("Debe seleccionar el tipo de cuenta." , "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string[] cuenta ;
            CUENTAS _cuanetas = new CUENTAS();
            ctrlcntcta _ctrlcta = new ctrlcntcta();
            
            if (txtcntctano.Text == String.Empty)
            {
              MessageBox.Show("Campo Vacio " + txtcntctano.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              if (txtcntctano.Enabled) txtcntctano.Focus();
              return ;                    
            }

            if (txtcntctanom.Text == String.Empty)
            {
              MessageBox.Show("Campo Vacio " + txtcntctanom.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              if (txtcntctanom.Enabled) txtcntctanom.Focus();
              return;
            }

            if (!rbtmaestra.Checked && !rbtdetalle.Checked){
                MessageBox.Show("Debe seleccionar el tipo de cuenta." , "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }            
            cuenta = txtcntctano.Text.Split('.');
            foreach (string cnt in cuenta)
            {
                if (cnt.Trim() == String.Empty)
                {
                    MessageBox.Show(" Error en la cuenta " + cnt, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            _cuanetas.Cntctano = txtcntctano.Text;
            _cuanetas.Cntctanom = txtcntctanom.Text;
            _cuanetas.Cntctama = txtcntctama.Text;
            if (rbtmaestra.Checked)
            { 
                _cuanetas.Cntctatipo = 'M';
            }
            else
            {
                if (rbtdetalle.Checked) _cuanetas.Cntctatipo = 'D';
            }
            if (_ctrlcta.insert(_cuanetas)) 
            {
                MessageBox.Show(" Información Guardada Exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
            
        }

        private void txtcntctano_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && !Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled= true; 
            }
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            frmbuscador _buscar = new frmbuscador();
            _buscar.StartPosition = FormStartPosition.CenterScreen;
            _buscar.sql = "select cntctano as codigo, cntctanom as nombre from cuenta";
            _buscar.ShowDialog();
        }
    
    }

}
