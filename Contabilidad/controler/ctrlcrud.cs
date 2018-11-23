using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Contabilidad.controler
{
    class ctrlcrud : ctrlconection
    {
        public ctrlcrud() { 
        
        }
        public string Insertar(string insert)
        {
            try
            {
                string Sql = insert;
                this.mysqlconexion.Open();
                MySqlCommand cmd = new MySqlCommand(Sql, this.mysqlconexion);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return "Registro Insertado Satisfactoriamente";
                }
                else
                {
                    return "No se pudo realizar esta acción";
                }
            }
            catch (Exception Ex)
            {
                this.mysqlconexion.Close();
                return Ex.ToString();
            }
            finally {
                this.mysqlconexion.Close();
            }
        }  
        public string Modificar(string update)
        {
            try
            {
                string Sql = update;
                MySqlCommand cmd = new MySqlCommand(Sql, this.mysqlconexion);

                if (cmd.ExecuteNonQuery() > 0)
                {

                    return "Registro Actualizado Satisfactoriamente";
                }
                else
                {
                    return "No se pudo realizar esta acción";
                }
            }
            catch (Exception Ex)
            {
                this.mysqlconexion.Close();
                return Ex.ToString();
            }
            finally  {
                this.mysqlconexion.Close();
            }
        }
        public  DataTable Consultar(string select)
        {
            string sql = select;
            MySqlCommand cmd = new MySqlCommand(sql, this.mysqlconexion);
            MySqlDataAdapter Adactador = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();

            try
            {
                Adactador.Fill(tbl);               
            }
            catch (Exception Ex)
            {
                this.mysqlconexion.Close();
                return tbl;
            }
            finally
            {
                this.mysqlconexion.Close();
            }
            return tbl;
        }
    }
}
