using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class frmbuscador : Form
    {
        public string sql;
        public string codigo = "";
        public string nombre = "";

        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);

        public frmbuscador()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtgTipos.Rows.Count > 0)
            {
                codigo = dtgTipos.SelectedRows[0].Cells[0].Value.ToString();
                nombre = dtgTipos.SelectedRows[0].Cells[1].Value.ToString();
                this.Close();
            }
            else {
                MessageBox.Show("No existen registros con esa condición"); 
            }
            
        }

        private void frmbuscador_Load(object sender, EventArgs e)
        {
           
            MySqlCommand cmd = new MySqlCommand(sql, mysqlconexion);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            try
            {
                this.mysqlconexion.Open();
                
                adt.Fill(tbl);

                if (mysqlconexion.State == ConnectionState.Open)
                {
                    if (tbl.Rows.Count == 0)
                    {
                        MessageBox.Show("No existen registros con esa condición");
                    }
                    else {
                        dtgTipos.DataSource = tbl;
                    }
                   
                }
                
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }
            finally
            {
                this.mysqlconexion.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
