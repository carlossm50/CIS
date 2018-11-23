using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.controler
{
    class ctrlcntent : ctrlconection
    {
        public ctrlcntent() { 
        
        }
        public Boolean insert()
        {
            string sql = "INSERT INTO cis.cuenta (cntctano,cntctanom,cntctatipo,cUENTASID,cntctama) " +
                              "VALUES (cntctano,cntctanom,cntctatipo,cUENTASID,cntctama)";

            return true;
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
