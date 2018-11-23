using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.controler
{
    class ctrlcnttrn : ctrlconection
    {
        public Boolean insert()
        {
            string sql = "INSERT INTO cis.transaccion (cnttrnid,cnttrnvalor,cnttrnconc,cnttiptrnid,tRANSACCIONID,tIPOTRANSACCIONID) "+
	                           "VALUES (cnttrnid,cnttrnvalor,cnttrnconc,cnttiptrnid,tRANSACCIONID,tIPOTRANSACCIONID)";

            return true;
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
    }
}
