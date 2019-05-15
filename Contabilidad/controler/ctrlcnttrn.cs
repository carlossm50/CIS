using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using Contabilidad.controler;
using System.Windows.Forms;
using System.Configuration;
namespace Contabilidad.controler
{
    class ctrlcnttrn : ctrlconection
    {
        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);
        public Boolean insert(TRANSACCION _transaccion)
        {
            string sql = "INSERT INTO cis.transaccion (cnttrnvalor,cnttrnconc,cnttiptrnid,cnttrnfecha) " +
                               "VALUES (" + _transaccion.Cnttrnvalor + ",'" + _transaccion.Cnttrnconc + "'," + _transaccion.Cnttiptrnid + ",'" + _transaccion.Cnttrnfecha.ToString("yyyy-MM-dd") + "')";

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
            string sql = "UPDATE cis.transaccion "+
                            "SET cnttrnid = cnttrnid,cnttrnvalor = cnttrnvalor,cnttrnconc = cnttrnconc,cnttiptrnid = cnttiptrnid,tRANSACCIONID = tRANSACCIONID,tIPOTRANSACCIONID = tIPOTRANSACCIONID "+
                          "WHERE tRANSACCIONID = expr";
            return true;
        }
        public Boolean deleteOne()
        {
            string sql = "DELETE FROM cis.transaccion "+
                               "WHERE where_expression ";
            return true;
        }
        public Boolean selectAll()
        {
            string sql = "SELECT transaccion.cnttrnid,transaccion.cnttrnvalor,transaccion.cnttrnconc,transaccion.cnttiptrnid,transaccion.tRANSACCIONID,transaccion.tIPOTRANSACCIONID "+
                          "FROM cis.transaccion";
            return true;
        }
        public Boolean selectOne()
        {
            string sql = "SELECT transaccion.cnttrnid,transaccion.cnttrnvalor,transaccion.cnttrnconc,transaccion.cnttiptrnid,transaccion.tRANSACCIONID,transaccion.tIPOTRANSACCIONID " +
                          "FROM cis.transaccion WHERE 1=1";
            return true;
        }
        public List<string> BucarCBO(string sql)
        {
            List<string> Lista = new List<string>();
            string valor = String.Empty;
            MySqlCommand cmd = new MySqlCommand(sql, mysqlconexion);
            //SqlDataAdapter Adactador = new SqlDataAdapter(cmd);
            MySqlDataReader Registro;
            try
            {
                mysqlconexion.Open();
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    //while (Registro.Read() )
                    {
                        Lista.Add("");

                        do

                            Lista.Add(Registro.GetValue(0).ToString() + "-" + Registro.GetValue(1).ToString());
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
    }
}
