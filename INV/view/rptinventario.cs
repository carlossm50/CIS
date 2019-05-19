using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace INV.view
{
    public partial class rptinventario : Form
    {
        MySqlConnection mysqlconexion = new MySqlConnection("DataSource=127.0.0.1;Database=cis; Uid=root;Pwd=casm09;");
        
        public rptinventario()
        {
            InitializeComponent();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            invetarioRPT formrept = new invetarioRPT();
            formrept.historico = Int32.Parse(cbxinventario.Text.Split('-')[0]);
            formrept.Show();
        }
        public List<string> selectAll()
        {
            List<string> Lista = new List<string>();
            string valor = String.Empty;
            MySqlCommand cmd = new MySqlCommand(" select invhistoricom.id_historico, entidad.nom_entidad , invhistoricom.fecha_inventario from  invhistoricom inner join entidad on invhistoricom.id_entidad = entidad.id_entidad " +
                                                 "where estado = 1;", mysqlconexion);
            MySqlDataReader Registro;
            try
            {
                mysqlconexion.Open();
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    {
                        Lista.Add("");

                        do

                            Lista.Add(Registro.GetValue(0).ToString() + "-" + Registro.GetValue(1).ToString() + " " + Registro.GetValue(2).ToString());
                        while (Registro.Read());
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
            finally
            {
                mysqlconexion.Close();
            }
            return Lista;
        }

        private void rptinventario_Load(object sender, EventArgs e)
        {
            List<string> Lista = new List<string>();

            Lista = selectAll();
            foreach (string s in Lista)
            {
                cbxinventario.Items.Add(s);
            }
        }
    }
}
