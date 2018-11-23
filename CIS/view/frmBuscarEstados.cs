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
    public partial class frmBuscarEstado : Form
    {

        public DataView DatView = new DataView();
        public DataGridViewRow Filas = new DataGridViewRow();
        public string Description;
        public string Code;
        public int LookupOk;  //PARA SABER SI SE ELIGIO ALGUN DATO EN EL LOOKUP    
       
        public frmBuscarEstado()
        {
            InitializeComponent();
        }

        private void frmBuscarEstados_Load(object sender, EventArgs e)
        {
            Datos.Conectar();
            DatView = Datos.Lookup("SELECT grlsts_codigo Codigo, grlsts_descrip Descripción" +
                                   "  FROM cgrlstsm " +
                                   " WHERE grltbl_codigo = 'cinvartm'");
            dtgEstados.DataSource = DatView;
            Datos.Desconectar();
            LookupOk = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e) 
        { 
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Filas = dtgEstados.CurrentRow;

            Code = Filas.Cells[0].Value.ToString();
            Description = Filas.Cells[1].Value.ToString();
            LookupOk = 1;

            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DatView.RowFilter = string.Format("Descripción LIKE '%{0}%'", txtDescripcion.Text); 
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            DatView.RowFilter = string.Format("convert(Codigo, 'System.String') LIKE '%{0}%'", txtCodigo.Text); 
        }
         

        private void txtCodigo_Click(object sender, EventArgs e)
        {

            txtDescripcion.Text = "";
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Datos.SoloNumEnteros(e);
        }

        private void dtgEstados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            Filas = dtgEstados.CurrentRow;

            Code = Filas.Cells[0].Value.ToString();  
            Description = Filas.Cells[1].Value.ToString();
            LookupOk = 1;

            this.Close(); 
        }

        private void txtDescripcion_Click_1(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
        }

        private void frmBuscarEstado_Load(object sender, EventArgs e)
        {
            Datos.Conectar();
            DatView = Datos.Lookup("SELECT grlsts_codigo Codigo, grlsts_descrip Descripción" +
                                   "  FROM cgrlstsm " +
                                   " WHERE grltbl_codigo = 'cinvartm'");
            dtgEstados.DataSource = DatView;
            Datos.Desconectar();
            LookupOk = 0;
        } 
         
    }
}
