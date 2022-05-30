using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AironAir_Kapitaalbeheer.Classes
{
    internal class DBCon
    {
        public MySqlConnection conn = new MySqlConnection();
        private string connStr = "server=localhost;user=root;database=aironair-kapitaalbeheer;password=;SSL Mode=None";

        public DBCon()
        {
                conn.ConnectionString = connStr;
        }
    }
}
