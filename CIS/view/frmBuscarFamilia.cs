﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CIS
{
    public partial class frmBuscarFamilia : Form
    {
        public DataView DatView = new DataView();
        public DataGridViewRow Filas = new DataGridViewRow();
        public string Description;
        public string Code;
        public int LookupOk;  //PARA SABER SI SE ELIGIO ALGUN DATO EN EL LOOKUP  

        public frmBuscarFamilia()
        {
            InitializeComponent();
        }

        private void frmBuscarFamilia_Load(object sender, EventArgs e)
        {
            Datos.Conectar();
            DatView = Datos.Lookup("SELECT invfam_codigo Codigo, invfam_descrip Descripción" +
                                   "  FROM cinvfamm " +
                                   " WHERE grlsts_codigo = 1 ");
            dtgFamilias.DataSource = DatView;
            Datos.Desconectar();
            LookupOk = 0;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Filas = dtgFamilias.CurrentRow;

            Code = Filas.Cells[0].Value.ToString();
            Description = Filas.Cells[1].Value.ToString();
            LookupOk = 1;

            this.Close();

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            DatView.RowFilter = string.Format("Descripción LIKE '%{0}%'", txtDescripcion.Text); 
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            DatView.RowFilter = string.Format("Codigo LIKE '%{0}%'", txtCodigo.Text);
        }

        private void txtCodigo_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
        }

        private void txtDescripcion_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
        }

        private void dtgFamilias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Filas = dtgFamilias.CurrentRow;

            Code = Filas.Cells[0].Value.ToString();
            Description = Filas.Cells[1].Value.ToString();
            LookupOk = 1;

            this.Close(); 
        }
    }
}
