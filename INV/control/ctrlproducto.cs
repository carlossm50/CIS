using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Windows.Forms;
using INV.model;
namespace INV.control
{
    class ctrlproducto
    {

        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);


        public Boolean insert(producto prod)
        {

            string sql = "START TRANSACTION;" +
               "INSERT INTO cis.producto (nom_producto,costo_producto,precio_producto,existencia_producto,id_entidad) " +
                           "VALUES ('" + prod.Nom_producto + "'," + prod.Costo_producto + "," + prod.Precio_producto + "," + prod.Existencia_producto + ","+prod.Id_entidad + ");" +
                           "COMMIT;";

            
            MySqlCommand cmd = new MySqlCommand(sql, mysqlconexion);
            try
            {
                this.mysqlconexion.Open();
                if (mysqlconexion.State == ConnectionState.Open)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                       // MessageBox.Show(cmd.CommandText, "", MessageBoxButtons.OK);

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
        public Boolean update(producto prod)
        {
            string sql = "UPDATE cis.producto " +
                            "SET nom_producto = " + prod.Nom_producto + ", costo_producto =" + prod.Costo_producto + ", precio_producto =" + prod.Precio_producto + ", existencia_producto = " + prod.Existencia_producto +
                          "WHERE id_producto = " + prod.Id_producto;
            return true;
        }
        public Boolean deleteOne(producto prod)
        {
            string sql = "DELETE FROM cis.cuenta" +
                          "WHERE where_expression ";
            return true;
        }
        public DataTable selectAll( string id_entidad)
        {
            DataTable table_productos = new DataTable();

            string sql = "SELECT id_producto, nom_producto,costo_producto,precio_producto,existencia_producto FROM producto where id_entidad = "+id_entidad;
            MySqlCommand cmd = new MySqlCommand(sql, mysqlconexion);
            MySqlDataAdapter adt = new MySqlDataAdapter(cmd);
            try
            {
                mysqlconexion.Open();
                adt.Fill(table_productos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);                
            }
            finally {
                mysqlconexion.Close();
            }
            return table_productos;            
        }
        public DataTable selectOne()
        {
            DataTable table_cuenta = new DataTable();
            string sql = "SELECT cuenta.cntctano,cuenta.cntctanom,cuenta.cntctatipo,cuenta.cUENTASID,cuenta.cntctama " +
                        "FROM cis.cuenta where cuenta.cntctano = 1";
            return table_cuenta;
        }
    }
}
