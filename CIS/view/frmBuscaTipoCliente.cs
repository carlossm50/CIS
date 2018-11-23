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
    public partial class frmBuscaTipoCliente : Form
    {
        public DataView DatView = new DataView();
        public DataGridViewRow Filas = new DataGridViewRow();
        public string Description;
        public string Code;
        public int LookupOk;  //PARA SABER SI SE ELIGIO ALGUN DATO EN EL LOOKUP    
       
        public frmBuscaTipoCliente()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            foreach (  DataGridViewRow Filas  in dtgTipocliente.SelectedRows)
            {
                 Code = Filas.Cells[0].Value.ToString();
                 Description = Filas.Cells[1].Value.ToString();
                 LookupOk = 1;
            }

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            DatView.RowFilter = string.Format("convert(Codigo, 'System.String') LIKE '%{0}%'", txtCodigo.Text); 
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Datos.SoloNumEnteros(e);
        }

        private void txtCodigo_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
        }

        private void dtgTipocliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Filas = dtgTipocliente.CurrentRow;

            Code = Filas.Cells[0].Value.ToString();
            Description = Filas.Cells[1].Value.ToString();
            LookupOk = 1;
            this.Close(); 
        }

        private void frmBuscaTipoCliente_Load(object sender, EventArgs e)
        {
            Datos.Conectar();
            DatView = Datos.Lookup("SELECT cxctcli_codigo Codigo, cxctcli_nombre Descripción, cxctcli_sec FROM ccxctclim");
            dtgTipocliente.DataSource = DatView;
            Datos.Desconectar();
            LookupOk = 0;
            
            /* CODIGO DE PRUEBA, PARA CONOCIMIENTO PARA VER QUE SI SE PUEDE ENLAZAR UN LIST A UN DATAGRIDVIEW
            List<lookUp> lista = new List<lookUp>();
            lista.Add(new lookUp { Codigo = "CL", Descripción = "Joder" });
            lista.Add(new lookUp { Codigo = "CL", Descripción = "Finir" });
            dtgTipocliente.DataSource =  lista;
            */
        }
    }
}
public class lookUp 
{
    public string  Codigo { get; set; }
    public string Descripción { get; set; }
}