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
    class ctrlentidad
    {
        

        MySqlConnection mysqlconexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["cntString"].ConnectionString);


        public Boolean insert(entidad ent)
        {
            string sql = "START TRANSACTION;" +
                "INSERT INTO cis.entidad (nom_entidad,ref_entidad,valor_invInicial) " +
                            "VALUES ('" + ent.Nom_entidad + "','" + ent.Ref_entidad + "'," + ent.Valor_invInicial + ");" +
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
            catch(Exception e){
                MessageBox.Show("Error: "+e.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            finally{
                this.mysqlconexion.Close();
            }

        }
        public Boolean update(entidad ent)
        {
            string sql = "UPDATE cis.entidad " +
                            "SET nom_entidad = '" + ent.Nom_entidad + "', ref_entidad ='" + ent.Ref_entidad + "'"+
                          "WHERE id_entidad = " + ent.Id_entidad;
            return true;
        }
       
        public DataTable selectOne()
        {
            DataTable table_cuenta = new DataTable();
            string sql = "SELECT entidad.id_entidad,entidad.nom_entidad,entidad.ref_entidad,entidad.valor_invInicial FROM cis.entidad " +
                        "WHERE entidad.id_entidad = 1";
            return table_cuenta;
        }
       
        public List<string> selectAll()
        {
            List<string> Lista = new List<string>();
            string valor = String.Empty;
            MySqlCommand cmd = new MySqlCommand("SELECT entidad.id_entidad,entidad.nom_entidad,entidad.ref_entidad,entidad.valor_invInicial FROM cis.entidad;", mysqlconexion);          
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
