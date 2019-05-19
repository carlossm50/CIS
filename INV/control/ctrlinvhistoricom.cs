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
    class ctrlinvhistoricom
    {
        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);
        public Boolean insertHistM(invhistoricom hist)
        {
            string sql = "START TRANSACTION;" +
                         "INSERT INTO cis.invhistoricom(valor_productos,valor_cxp,valor_cxc,valor_efectivo,valor_gasto,valor_invInicial,fecha_inventario,id_entidad,estado) " +
                         "VALUES (" + hist.Valor_productos + "," + hist.Valor_cxp + "," + hist.Valor_cxc + "," + hist.Valor_efectivo + "," + hist.Valor_gasto + "," + hist.Valor_invInicial + ",'" +hist.Fecha_inventario.ToString("yyyy-MM-dd") +"',"+hist.Id_entidad+",1); " +
                         "INSERT INTO invhistoricod (id_historico,id_producto,nom_producto,costo_producto,precio_producto,existencia_producto) " +
                         "SELECT last_insert_id(),id_producto,nom_producto,costo_producto,precio_producto,existencia_producto " +
                         "FROM producto WHERE id_entidad = "+hist.Id_entidad+"; " +
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
        public Boolean deleteOne(string id_historico)
        {
            string sql = "START TRANSACTION;" +
                          "DELETE FROM cis.invhistoricod" +
                          "WHERE id_historico = " + id_historico+";"+
                          "DELETE FROM cis.invhistoricom" +
                          "WHERE id_historico = " + id_historico+"; "+
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
        public DataTable selectAll(string id_entidad)
        {
            DataTable table_productos = new DataTable();

            string sql = "SELECT id_historico,valor_productos,valor_cxp,valor_cxc,valor_efectivo,valor_gasto,valor_invInicial,fecha_inventario,id_entidad FROM invhistoricom where id_entidad= " + id_entidad;
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
            finally
            {
                mysqlconexion.Close();
            }
            return table_productos;
        }
        public DataTable selectOne(string id_historico)
        {
            DataTable table_cuenta = new DataTable();
            string sql = "SELECT id_historico,valor_productos,valor_cxp,valor_cxc,valor_efectivo,valor_gasto,valor_invInicial,fecha_inventario,id_entidad FROM invhistoricom where id_historico=" + id_historico;
            return table_cuenta;
        }
        
       
        public string buscaInvInicial(string id_entidad)
        {
            string valor_invincial = "";
            MySqlCommand cmd = new MySqlCommand("SELECT entidad.valor_invInicial FROM cis.entidad " + "WHERE entidad.id_entidad = " + id_entidad, mysqlconexion);
            MySqlDataReader Registro;
            try
            {
                mysqlconexion.Open();
                Registro = cmd.ExecuteReader();
                if (Registro.HasRows)
                {
                    if (Registro.Read() == true)
                    {
                        do
                            valor_invincial = Registro.GetValue(0).ToString();
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
            return valor_invincial;
        }
        public Boolean actualizar_existencia(string id_producto, string existencia) {
            string sql = "start transaction; "+ 
                          "update producto set existencia_producto = "+ existencia +" where id_producto = "+id_producto+";"+
                          "commit;";
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
    }
}
