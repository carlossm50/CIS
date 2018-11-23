using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contabilidad.controler
{
    class ctrlcntrub : ctrlconection
    {
        public Boolean insert()
        {
            string sql = "INSERT INTO cis.rubro (cntrubid,cntrubnom,rUBROSID) "+
                              "VALUES (cntrubid,cntrubnom,rUBROSID)";

            return true;
        }
        public Boolean update()
        {
            string sql = "UPDATE cis.rubro "+
                            "SET cntrubid = cntrubid,cntrubnom = cntrubnom,rUBROSID = rUBROSID "+ 
                          "WHERE rUBROSID = expr;";
            return true;
        }
        public Boolean deleteOne()
        {
            string sql = "DDELETE FROM cis.rubro "+
	                            "WHERE where_expression ";
            return true;
        }
        public Boolean selectAll()
        {
            string sql = "SELECT rubro.cntrubid,rubro.cntrubnom,rubro.rUBROSID "+ 
                           "FROM cis.rubro";
            return true;
        }
        public Boolean selectOne()
        {
            string sql = "SELECT rubro.cntrubid,rubro.cntrubnom,rubro.rUBROSID " +
                           "FROM cis.rubro where 1 = 1";
            return true;
        }
    }
}
