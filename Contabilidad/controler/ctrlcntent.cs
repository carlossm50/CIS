using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using Contabilidad.model;
using System.Windows.Forms;
namespace Contabilidad.controler
{
    class ctrlcntent : ctrlconection
    {
        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);

        public ctrlcntent() { 
        
        }
        public Boolean insert(ENTRADA_DIARIO ent, DataTable tblEnt)
        {
            string sqlDetall = "";


            foreach (DataRow row in tblEnt.Rows){
                sqlDetall += "(last_insert_id(),'" + row["cntctano"].ToString() + "'," + row["cntctamonto"].ToString() + "," + row["cntctaOrigen"].ToString() + "),";
            
            }
            sqlDetall = sqlDetall.Substring(0, sqlDetall.Length - 1);
 
            string sql = "START TRANSACTION;"+
                        "INSERT INTO tblcntent (`concepEnt`,`valorEnt`,`fechaEnt`,`estado`) " +
                        "VALUES ('"+ent.ConcepEntrada+"', "+ent.ValorEntrada.ToString()+", '"+ent.Fecha.ToString("yyyy-MM-dd")+"','A') ; "+
                        "INSERT INTO tblcntasi (`noEntrada`,`cntctano`,`asiValor`,`origen`) VALUES " +
                        sqlDetall+";"+
                        " COMMIT;";
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
        public Boolean update()
        {
            string sql = "UPDATE cis.entrada " +
                            "SET  " +
                          "WHERE cUENTASID = expr";
            return true;
        }
        public Boolean deleteOne()
        {
            string sql = "DELETE FROM cis.entrada" +
                          "WHERE where_expression ";
            return true;
        }
        public Boolean selectAll()
        {
            string sql = "SELECT * " +
                           "FROM cis.entrada";
            return true;
        }
        public Boolean selectOne()
        {
            string sql = "SELECT * " +
                        "FROM cis.entrada where 1 = 1";
            return true;
        }
    }
}
