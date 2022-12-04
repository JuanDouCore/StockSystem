using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    class SQL
    {
        public static bool connectedSql;

        static MySqlConnection connectionSql = new MySqlConnection("server=sql.freedb.tech;port=3306;user id=freedb_usario;password=hmm$Q5DGg*!PgJv;database=freedb_stocksystem;");

        public static void connectSql()
        {
            try
            {
                connectionSql.Open();
                connectedSql = true;
            } catch (Exception ex)
            {
                connectedSql = false;
            }
        }

        public static bool checkUser(string username, string password)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM usuarios WHERE user='" + username + "';",connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            if(mySqlDataReader.HasRows && mySqlDataReader.Read()) { 
                if(mySqlDataReader.GetString("password") == password) {
                    return true;
                } else { return false; }
            }
        
            mySqlDataReader.Close();
            return false;
        }
    }
}
