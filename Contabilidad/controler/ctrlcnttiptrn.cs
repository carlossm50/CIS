using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.controler
{
    class ctrlcnttiptrn : ctrlconection
    {
        public Boolean insert()
        {
            string sql = "INSERT INTO cis.tipotransaccion (cnttiptrnid,cnttiptrnnombre,tIPOTRANSACCIONID) "+
                              "VALUES (cnttiptrnid,cnttiptrnnombre,tIPOTRANSACCIONID)";

            return true;
        }
        public Boolean update()
        {
            string sql = "UPDATE cis.tipotransaccion "+
                            "SET cnttiptrnid = cnttiptrnid,cnttiptrnnombre = cnttiptrnnombre,tIPOTRANSACCIONID = tIPOTRANSACCIONID "+
                          "WHERE tIPOTRANSACCIONID = expr";
            return true;
        }
        public Boolean deleteOne()
        {
            string sql = "DELETE FROM cis.tipotransaccion "+ 
                               "WHERE where_expression";
            return true;
        }
        public Boolean selectAll()
        {
            string sql = "SELECT tipotransaccion.cnttiptrnid,tipotransaccion.cnttiptrnnombre,tipotransaccion.tIPOTRANSACCIONID "+
                           "FROM cis.tipotransaccion";
            return true;
        }
        public Boolean selectOne()
        {
            string sql = "SELECT tipotransaccion.cnttiptrnid,tipotransaccion.cnttiptrnnombre,tipotransaccion.tIPOTRANSACCIONID "+
                           "FROM cis.tipotransaccion WHERE 1 = 1";
            return true;
        }
    }
}
