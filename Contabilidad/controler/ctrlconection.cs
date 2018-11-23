using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Contabilidad.Properties;
using System.Configuration;
using System.Data;

namespace Contabilidad.controler
{
    abstract class ctrlconection
    {

        public MySqlConnection mysqlconexion = new MySqlConnection();

        public ctrlconection() {
            mysqlconexion.ConnectionString = Settings.Default.cntstting; 
        }

        
    }
}
