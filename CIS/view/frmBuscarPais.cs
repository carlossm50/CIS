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
    public partial class frmBuscarPais : Form
    {
        public DataView DatView = new DataView();
        public DataGridViewRow Filas = new DataGridViewRow();
        public string Description;
        public string Code;
        public int LookupOk;  //PARA SABER SI SE ELIGIO ALGUN DATO EN EL LOOKUP    

        public frmBuscarPais()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Filas in dtgPais.SelectedRows)
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

        private void dtgPais_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Filas = dtgPais.CurrentRow;

            Code = Filas.Cells[0].Value.ToString();
            Description = Filas.Cells[1].Value.ToString();
            LookupOk = 1;
            this.Close(); 
        }

        private void frmBuscarPais_Load(object sender, EventArgs e)
        {
            Datos.Conectar();
            DatView = Datos.Lookup("SELECT grlpai_codigo Codigo, grlpai_nombre Descripción , grlpai_abrev FROM cgrlpaim order by grlpai_codigo");
            dtgPais .DataSource = DatView;
            Datos.Desconectar();
            LookupOk = 0;
        }
    }
}
