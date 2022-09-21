using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Contabilidad.controler;
using Contabilidad.model;
namespace Contabilidad
{
    public partial class frmcntcta : Form
    {
        /// <summary>
        /// La ventana de registro de cuentas tiene dos funcionalidades, la primera es para el registro de las cuentas contables 
        /// y la segunda para la busqueda de las cuenbtas contables. La variable stadoVentana se utiliza para identificar la funcionalidad que se 
        /// está usando en un momento determinado. Representa el valor de la funcionalidad que se está usando (N-Nada, R-Registro, B-Busqueda).
        /// Si inicializa con el valor N-Nada
        /// </summary>
        char stadoVentana = 'N';
        BindingSource Bscuentas = new BindingSource();
        DataRowView row;
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
            ctrlcntcta _ctrlcta = new ctrlcntcta();
            if (stadoVentana == 'R') {
                if (validarEntradas())
                {
                    CUENTAS _cuanetas = new CUENTAS();
                    
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
                    else
                    {
                        MessageBox.Show(" Error al Guardar .", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;

                    }
                }
                else return;
                
            }
            else if (stadoVentana == 'B') {
              
                MessageBox.Show(" Mode busqueda activado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                Bscuentas.DataSource = _ctrlcta.selectAll();
               
                
                txtcntctano.DataBindings.Clear();
               txtcntctanom.DataBindings.Clear();
               txtcntctama.DataBindings.Clear();
               textBox1.DataBindings.Clear(); 
               Bscuentas.MoveFirst();
               txtcntctano.DataBindings.Add("Text", Bscuentas, "cntctano");
               txtcntctanom.DataBindings.Add("Text", Bscuentas, "cntctanom");
               txtcntctama.DataBindings.Add("Text", Bscuentas, "cntctama");
               row = (DataRowView)Bscuentas.Current;
               if (row[2].ToString() == "M")
               {
                   rbtmaestra.Checked = true;
               }
               else { rbtdetalle.Checked = true; }
            }
            btnBuscar.Enabled = true;
            btnPrimero.Enabled = true;
            btnAtras.Enabled = true;
            btnSiguiente.Enabled = true;
            btnUltimo.Enabled = true;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAceptar.Enabled = false;
            btnImprimir.Enabled = false;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled = false;
            btnSalir.Enabled = true;
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
            _buscar.sql = "select cntctano as codigo, cntctanom as nombre from cuenta where cntctatipo = 'M'";
            _buscar.ShowDialog();
            txtcntctama.Text    = _buscar.codigo;
            textBox1.Text       = _buscar.nombre;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            stadoVentana = 'R';
            btnBuscar.Enabled   = false;
            btnPrimero.Enabled  = false;
            btnAtras.Enabled    = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled   = false;
            btnNuevo.Enabled    = false;
            btnEditar.Enabled   = false;
            btnCancelar.Enabled = true;
            btnAceptar.Enabled  = true;
            btnImprimir.Enabled = false;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled    = false;
            btnSalir.Enabled    = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            stadoVentana = 'B';
            btnBuscar.Enabled   = false;
            btnPrimero.Enabled  = false;
            btnAtras.Enabled    = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled   = false;
            btnNuevo.Enabled    = false;
            btnEditar.Enabled   = false;
            btnCancelar.Enabled = true;
            btnAceptar.Enabled  = true;
            btnImprimir.Enabled = false;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled    = false;
            btnSalir.Enabled    = true;
        }
        private bool validarEntradas() {

            string[] cuenta;
            if (txtcntctano.Text == String.Empty)
            {
                MessageBox.Show("Campo Vacio " + txtcntctano.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtcntctano.Enabled) txtcntctano.Focus();
                return false;
            }

            if (txtcntctanom.Text == String.Empty)
            {
                MessageBox.Show("Campo Vacio " + txtcntctanom.Tag, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtcntctanom.Enabled) txtcntctanom.Focus();
                return false;
            }

            if (!rbtmaestra.Checked && !rbtdetalle.Checked)
            {
                MessageBox.Show("Debe seleccionar el tipo de cuenta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            cuenta = txtcntctano.Text.Split('.');
            foreach (string cnt in cuenta)
            {
                if (cnt.Trim() == String.Empty)
                {
                    MessageBox.Show(" Error en la cuenta " + cnt, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }            
            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            stadoVentana = 'N';
            btnBuscar.Enabled = true;
            btnPrimero.Enabled = false;
            btnAtras.Enabled = false;
            btnSiguiente.Enabled = false;
            btnUltimo.Enabled = false;
            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnCancelar.Enabled = false;
            btnAceptar.Enabled = false;
            btnImprimir.Enabled = false;
            btnAdjuntar.Enabled = false;
            btnNotas.Enabled = false;
            btnSalir.Enabled = true;
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            Bscuentas.MoveFirst();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            Bscuentas.MovePrevious();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Bscuentas.MoveNext();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            Bscuentas.MoveLast();
        }
    
    }

}
