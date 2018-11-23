using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.controler
{
    class ctrlcfgAsitrn : ctrlconection
    {
        public Boolean insert()
        {
            string sql = "INSERT INTO cis.trnasiento (cnttrnid,cntctano,cntasivalor,cntasiop,tRANSACCION_ASIENTOID,cUENTASID,tRANSACCIONID) "+
                              "VALUES (cnttrnid,cntctano,cntasivalor,cntasiop,tRANSACCION_ASIENTOID,cUENTASID,tRANSACCIONID)";

            return true;
        }
        public Boolean update()
        {
            string sql = "UPDATE cis.trnasiento "+
                            "SET cnttrnid = cnttrnid,cntctano = cntctano,cntasivalor = cntasivalor,cntasiop = cntasiop,tRANSACCION_ASIENTOID = tRANSACCION_ASIENTOID,cUENTASID = cUENTASID,tRANSACCIONID = tRANSACCIONID "+
                          "WHERE tRANSACCION_ASIENTOID = expr";
            return true;
        }
        public Boolean deleteOne()
        {
            string sql = "DELETE FROM cis.trnasiento "+
                               "WHERE where_expression";
            return true;
        }
        public Boolean selectAll()
        {
            string sql = "SELECT trnasiento.cnttrnid,trnasiento.cntctano,trnasiento.cntasivalor,trnasiento.cntasiop,trnasiento.tRANSACCION_ASIENTOID,trnasiento.cUENTASID,trnasiento.tRANSACCIONID "+
                           "FROM cis.trnasiento";
            return true;
        }
        public Boolean selectOne()
        {
            string sql = "SELECT trnasiento.cnttrnid,trnasiento.cntctano,trnasiento.cntasivalor,trnasiento.cntasiop,trnasiento.tRANSACCION_ASIENTOID,trnasiento.cUENTASID,trnasiento.tRANSACCIONID " +
                           "FROM cis.trnasiento where 1 = 1";
            return true;
        }
    }
}
