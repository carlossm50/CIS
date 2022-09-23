using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Contabilidad.model;
namespace Contabilidad.controler
{
    public class ctrlcntciclo
    {
        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);
        public ctrlcntciclo() { 
        
        }
        public bool Insert(CICLO ciclo, DataTable tbl) {
            string periodo = "";
            string estado = "";
            foreach(DataRow row in tbl.Rows){
                estado = row["estado"].ToString()=="CERRADO"?"C":"A";
                periodo += "insert into tblperiodo(anociclo, periodo, estado) values(" + row["anociclo"].ToString() + ",'" + row["periodo"].ToString() + "','" + estado + "');";
            }

            //periodo = periodo.Substring(0,periodo.Length - 1);

            string sql = "START TRANSACTION; " +
            "insert into tblcntciclo (aniociclo,estado) values (" + ciclo.Anio.ToString() + ",'G') ;" +
            periodo + 
            "COMMIT;";

            MySqlCommand cmd = new MySqlCommand(sql, mysqlconexion);
            try
            {
                this.mysqlconexion.Open();
                if (mysqlconexion.State == ConnectionState.Open)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else return false;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally
            {
                this.mysqlconexion.Close();
            }

        }
    }
}
