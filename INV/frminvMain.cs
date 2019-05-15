using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using INV.control;
using INV.model;

namespace INV
{
    public partial class frminvMain : Form
    {
        BindingSource Bsproductos = new BindingSource();
        DataTable table_productos = new DataTable(); 
        public frminvMain()
        {
            InitializeComponent();
        }

        private void frminvMain_Load(object sender, EventArgs e)
        {
            alternarcolorGrid();
            List<string> Lista = new List<string>();
            ctrlentidad ctrltrn = new ctrlentidad();
            Lista = ctrltrn.selectAll();
            foreach (string s in Lista)
            {
                cbxentidad.Items.Add(s);
            }
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            frminvEntrada _nuevaentrada = new frminvEntrada();
            _nuevaentrada.StartPosition = FormStartPosition.CenterScreen;
            _nuevaentrada.ShowDialog();
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            string[] cbxtex = cbxentidad.Text.Split('-');
            frminvSalida _nuevasalida = new frminvSalida();
            _nuevasalida.StartPosition = FormStartPosition.CenterScreen;
            if (cbxentidad.Text.Trim() != String.Empty)
            {
                _nuevasalida.id_entidad = Int32.Parse(cbxtex[0]);
                _nuevasalida.ShowDialog();
            }
            else {
                MessageBox.Show("Debe seleccionar la entidad.", "Información", MessageBoxButtons.OK);
            }
            
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {            
            frminvHistorial _historial = new frminvHistorial();
            _historial.StartPosition = FormStartPosition.CenterScreen;
            invhistoricom historicom ;
            double totalproductos = 0;
            string[] cbxtex = cbxentidad.Text.Split('-');

            if (btnsync.Enabled) {
                MessageBox.Show("Hay cambios pendientes por actualizar.\n Actualice antes de continuar con el proceso.", "Información", MessageBoxButtons.OK);  
                return;
            }

            if (cbxentidad.Text.Trim() != String.Empty)
            {
                historicom = new invhistoricom();
                _historial.historicom.Id_entidad = Int32.Parse(cbxtex[0]);
                _historial.historicom.Valor_cxp = Double.Parse(txtcxp.Text);
                _historial.historicom.Valor_cxc = Double.Parse(txtcxc.Text);
                _historial.historicom.Valor_efectivo = Double.Parse(txtefectivo.Text);

                _historial.historicom.Valor_gasto = Double.Parse(txtgasto.Text);
                _historial.historicom.Valor_invInicial = Double.Parse(txtinvinicial.Text);
                _historial.entidad = cbxentidad.Text.Split('-')[1];
                if (dtgInvMain.RowCount > 0)
                {
                    
                    foreach (DataGridViewRow Filas in dtgInvMain.Rows)
                    {
                        if (Filas.Cells[3].Value != null)
                            totalproductos += Double.Parse(Filas.Cells[3].Value.ToString());

                    }
                    _historial.historicom.Valor_productos = totalproductos;
                    
                    //MessageBox.Show(totalproductos.ToString(), "", MessageBoxButtons.OK);
                    //return;
                }
                else {
                    MessageBox.Show("No hay productos disponible en este momento.\n Cargue o defina productos para la entidad seleccionada.", "Información", MessageBoxButtons.OK);  
                    return;
                }               
                
                _historial.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debe seleccionar la entidad.", "Información", MessageBoxButtons.OK);
            }
        }
        public void alternarcolorGrid()
        {
            dtgInvMain.RowsDefaultCellStyle.BackColor = Color.LightBlue;
            dtgInvMain.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        private void btnNewOk_Click(object sender, EventArgs e)
        {
            if (btnNewOk.Tag.ToString() == "0")
            {
                btnNewOk.Image = Image.FromFile(ConfigurationManager.AppSettings["imagenes"].ToString() + @"\outline_check.png");
                btnNewOk.Tag = "1";
            }
            else {
                btnNewOk.Image = Image.FromFile(ConfigurationManager.AppSettings["imagenes"].ToString() + @"\add1.png");
                btnNewOk.Tag = "0";
            }
            
        }

      

        private void btnBuscaEntidad_Click(object sender, EventArgs e)
        {
            string[] cbxtext;
            ctrlproducto ctrlprod = new ctrlproducto();
            ctrlinvhistoricom historicom = new ctrlinvhistoricom();
            
            if (cbxentidad.Text.Trim() != String.Empty)
            {
                //Cargar los productos de la entidad seleccionada.
                cbxtext = cbxentidad.Text.Split('-');
                table_productos = ctrlprod.selectAll(cbxtext[0]);
                if (table_productos.Rows.Count > 0)
                {
                    
                    dtgInvMain.DataSource = table_productos;
                    Bsproductos.DataSource = table_productos;
                    
                        txtidproducto.DataBindings.Clear();  txtidproducto.DataBindings.Add("Text", Bsproductos, "id_producto");
                        txtdescripcion.DataBindings.Clear(); txtdescripcion.DataBindings.Add("Text", Bsproductos, "nom_producto");
                        txtcosto.DataBindings.Clear();       txtcosto.DataBindings.Add("Text", Bsproductos, "costo_producto");
                        txtprecio.DataBindings.Clear();      txtprecio.DataBindings.Add("Text", Bsproductos, "precio_producto");
                        txtexistencia.DataBindings.Clear();  txtexistencia.DataBindings.Add("Text", Bsproductos, "existencia_producto");
                }
                else {
                    MessageBox.Show("No hay productos definidos para esta entidad.", "Información", MessageBoxButtons.OK);                    
                }
                //Buscar el inventario inicial de la entidad seleccionada.                
                txtinvinicial.Text = historicom.buscaInvInicial(cbxtext[0]);
                actualizarvalorproductos();
                btnsync.Enabled = false;
            }
            else {
                MessageBox.Show("Debe seleccionar la entidad.", "Información", MessageBoxButtons.OK);

            }
        }

        private void dtgInvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            if (dtgInvMain.CurrentRow != null)
            {                
                Bsproductos.Position = e.RowIndex;
            }

        }

        private void btnsync_Click(object sender, EventArgs e)
        {
            btnsync.Enabled = false;
            actualizarvalorproductos();
           
        }

        private void txtexistencia_TextChanged(object sender, EventArgs e)
        {
            btnsync.Enabled = true;
        }

        private void txtexistencia_Validating(object sender, CancelEventArgs e)
        {
            if (txtexistencia.Text.Trim() == String.Empty)
                e.Cancel=true;
        }

        private void txtgasto_Validating(object sender, CancelEventArgs e)
        {
            if (txtgasto.Text.Trim() == String.Empty) {
                e.Cancel = true;
            }
        }

        private void txtefectivo_Validating(object sender, CancelEventArgs e)
        {
            if (txtefectivo.Text.Trim() == String.Empty)
            {
                e.Cancel = true;
            }
        }

        private void txtcxc_Validating(object sender, CancelEventArgs e)
        {
            if (txtcxc.Text.Trim() == String.Empty)
            {
                e.Cancel = true;
            }
        }

        private void txtcxp_Validating(object sender, CancelEventArgs e)
        {
            if (txtcxp.Text.Trim() == String.Empty)
            {
                e.Cancel = true;
            }
        }

        private void txtinvinicial_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void txtexistencia_Validated(object sender, EventArgs e)
        {
            dtgInvMain.Refresh();
        }
        private void actualizarvalorproductos() {
            double totalProd = 0;
            if (dtgInvMain.RowCount > 0)
            {

                foreach (DataGridViewRow Filas in dtgInvMain.Rows)
                {
                    if (Filas.Cells[3].Value != null && Filas.Cells[4].Value != null)
                        totalProd += Double.Parse(Filas.Cells[3].Value.ToString()) * Int32.Parse(Filas.Cells[4].Value.ToString());

                }
                txttotalprod.Text = Math.Round(totalProd, 2).ToString();

                //MessageBox.Show(totalproductos.ToString(), "", MessageBoxButtons.OK);
                //return;
            }
        }
    }
}
