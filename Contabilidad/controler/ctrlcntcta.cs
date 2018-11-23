using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;
using Contabilidad.Properties;
using System.Configuration;
namespace Contabilidad.controler
{
   
    class ctrlcntcta : ctrlconection 
    {

        MySqlConnection mysqlconexion=new MySqlConnection();

        public ctrlcntcta(){
            
        }

        public Boolean insert(CUENTAS cta) {

            this.mysqlconexion.Open();

            string sql = "START TRANSACTION;"+
                "INSERT INTO cis.cuenta (cntctano,cntctanom,cntctatipo,cUENTASID,cntctama) " +
                            "VALUES ("+cta.Cntctano+","+cta.Cntctanom+","+cta.Cntctatipo+","+cta.Cntctama+");"+
                            "ROLLBACK;";
            if (mysqlconexion.State == ConnectionState.Open)
            {
                this.mysqlconexion.Close();
                return true;
            }
            else return false;   
        }
        public Boolean update(CUENTAS cta)
        {
            string sql = "UPDATE cis.cuenta "+
                            "SET cntctano = "+cta.Cntctano+", cntctanom ="+ cta.Cntctanom+", cntctatipo ="+ cta.Cntctatipo+", cntctama = "+cta.Cntctama +
                          "WHERE cntctano = "+cta.Cntctano;
            return true;
        }
        public Boolean deleteOne(CUENTAS cta)
        {
            string sql = "DELETE FROM cis.cuenta"+
                          "WHERE where_expression ";
            return true;
        }
        public DataTable selectAll()
        {
            DataTable table_cuentas = new DataTable();
            string sql = "SELECT cuenta.cntctano,cuenta.cntctanom,cuenta.cntctatipo,cuenta.cUENTASID,cuenta.cntctama " +
                           "FROM cis.cuenta";
            return table_cuentas;
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
