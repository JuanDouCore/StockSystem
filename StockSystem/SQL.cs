using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockSystem
{
    class SQL
    {
        public static bool connectedSql;

        static MySqlConnection connectionSql = new MySqlConnection("server=db4free.net;port=3306;user id=usuariostock;password=hola12345;database=stocksystem;");

        public static void connectSql()
        {
            try
            {
                connectionSql.Open();
                connectedSql = true;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connectedSql = false;
            }
        }

        public static bool checkUser(string username, string password)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM usuarios WHERE username='" + username + "';");
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
