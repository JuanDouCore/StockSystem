using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace StockSystem
{
    class SQL
    {
        public static bool connectedSql;
        public static bool isConnected;

        static MySqlConnection connectionSql = new MySqlConnection("server=db4free.net;port=3306;user id=usuariostock;password=hola12345;database=stocksystem;");

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


        public static void checkStatusDatabase() {
            while (true)
            {
                if (connectionSql.State != System.Data.ConnectionState.Open) {
                    MessageBox.Show("HA OCURRIDO UN ERROR EN LA CONEXION DE DATOS.");
                    MainWindow.Instance.Close();
                    break;
                }
                Thread.Sleep(60000);
            }

        }

        public static bool checkUser(string username, string password)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM usuarios WHERE user='" + username + "';", connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            if(mySqlDataReader.HasRows && mySqlDataReader.Read()) { 
                if(mySqlDataReader.GetString("password") == password) {
                    mySqlDataReader.Close();
                    return true;
                } else { mySqlDataReader.Close(); return false; }
            }
        
            mySqlDataReader.Close();
            return false;
        }

        public static bool checkProduct(int codigo)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM productos WHERE codigo=" + codigo + ";", connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            if (mySqlDataReader.HasRows && mySqlDataReader.Read()) { mySqlDataReader.Close(); return true; }

            mySqlDataReader.Close();
            return false;
        }

        public static Producto leerProduct(int codigo)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM productos WHERE codigo=" + codigo + ";", connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                string marca = mySqlDataReader.GetString("marca");
                string modelo = mySqlDataReader.GetString("modelo");
                string descripcion = mySqlDataReader.GetString("descripcion");
                int stock = mySqlDataReader.GetInt32("stock");
                int vendidos = mySqlDataReader.GetInt32("vendidos");
                double precio = mySqlDataReader.GetDouble("precio");


                mySqlDataReader.Close();
                return new Producto(marca, modelo, descripcion, codigo, vendidos, stock, precio);
            
            }

            mySqlDataReader.Close();
            return null;
        }

        public static void cargarProduct(Producto producto)
        {
            MySqlCommand consultaSql = new MySqlCommand("INSERT INTO productos(codigo, marca, modelo, descripcion, vendidos, stock, precio) VALUES (@codigo, @marca, @modelo, @descripcion, @vendidos, @stock, @precio);", connectionSql);

            consultaSql.Parameters.Add(new MySqlParameter("@codigo", producto.codigo));
            consultaSql.Parameters.Add(new MySqlParameter("@marca", producto.marca));
            consultaSql.Parameters.Add(new MySqlParameter("@modelo", producto.modelo));
            consultaSql.Parameters.Add(new MySqlParameter("@descripcion", producto.descripcion));
            consultaSql.Parameters.Add(new MySqlParameter("@vendidos", producto.vendidos));
            consultaSql.Parameters.Add(new MySqlParameter("@stock", producto.stock));
            consultaSql.Parameters.Add(new MySqlParameter("@precio", producto.precio));

            consultaSql.ExecuteNonQuery();
        }

        public static void updateProduct(Producto producto)
        {
            MySqlCommand consultaSql = new MySqlCommand("UPDATE productos SET codigo=@codigo,marca=@marca,modelo=@modelo,descripcion=@descripcion,vendidos=@vendidos,stock=@stock,precio=@precio WHERE codigo=" + producto.codigo + ";", connectionSql);

            consultaSql.Parameters.Add(new MySqlParameter("@codigo", producto.codigo));
            consultaSql.Parameters.Add(new MySqlParameter("@marca", producto.marca));
            consultaSql.Parameters.Add(new MySqlParameter("@modelo", producto.modelo));
            consultaSql.Parameters.Add(new MySqlParameter("@descripcion", producto.descripcion));
            consultaSql.Parameters.Add(new MySqlParameter("@vendidos", producto.vendidos));
            consultaSql.Parameters.Add(new MySqlParameter("@stock", producto.stock));
            consultaSql.Parameters.Add(new MySqlParameter("@precio", producto.precio));

            consultaSql.ExecuteNonQuery();
        }

        public static void deleteProduct(int codigo)
        {
            MySqlCommand consultaSql = new MySqlCommand("DELETE FROM productos WHERE codigo=" + codigo + ";", connectionSql);
            consultaSql.ExecuteNonQuery();
        }

        public static List<Producto> listarProductos()
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM productos;", connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            List<Producto> productos = new List<Producto>();

            while (mySqlDataReader.Read())
            {
                string marca = mySqlDataReader.GetString("marca");
                string modelo = mySqlDataReader.GetString("modelo");
                string descripcion = mySqlDataReader.GetString("descripcion");
                int codigo = mySqlDataReader.GetInt32("codigo");
                int stock = mySqlDataReader.GetInt32("stock");
                int vendidos = mySqlDataReader.GetInt32("vendidos");
                double precio = mySqlDataReader.GetDouble("precio");

                productos.Add(new Producto(marca, modelo, descripcion, codigo, vendidos, stock, precio));
            }

            mySqlDataReader.Close();
            return productos;
        }

        // USERS MANEGMENT SECTION
        public static void crearUsuario(Usuario usuario)
        {
            MySqlCommand consultaSql = new MySqlCommand("INSERT INTO usuarios(user, password, canCreate, canEdit, canDelete) VALUES (@user, @password, @canCreate, @canEdit, @canDelete);", connectionSql);
            consultaSql.Parameters.Add(new MySqlParameter("@user", usuario.username));
            consultaSql.Parameters.Add(new MySqlParameter("@password", usuario.password));
            consultaSql.Parameters.Add(new MySqlParameter("@canCreate", usuario.puedeCrear));
            consultaSql.Parameters.Add(new MySqlParameter("@canEdit", usuario.puedeEditar));
            consultaSql.Parameters.Add(new MySqlParameter("@canDelete", usuario.puedeEliminar));
            consultaSql.ExecuteNonQuery();
        }

        public static bool existeUser(string username)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM usuarios WHERE user='" + username + "';", connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            if (mySqlDataReader.HasRows && mySqlDataReader.Read())
            {
                    mySqlDataReader.Close();
                    return true;
            }

            mySqlDataReader.Close();
            return false;
        }

        public static void eliminearUsuario(string usuario)
        {
            MySqlCommand consultaSql = new MySqlCommand("DELETE FROM usuarios WHERE user='" + usuario + "';", connectionSql);
            consultaSql.ExecuteNonQuery();
        }

        public static Usuario leerUsuario(string username)
        {
            MySqlCommand consultaSql = new MySqlCommand("SELECT * FROM usuarios WHERE user='" + username + "';", connectionSql);
            MySqlDataReader mySqlDataReader = consultaSql.ExecuteReader();

            if (mySqlDataReader.Read())
            {
                username = mySqlDataReader.GetString("user");
                string password = mySqlDataReader.GetString("password");
                bool canCreate = mySqlDataReader.GetBoolean("canCreate");
                bool canEdit = mySqlDataReader.GetBoolean("canEdit");
                bool canDelete = mySqlDataReader.GetBoolean("canDelete");


                mySqlDataReader.Close();
                return new Usuario(username, password, canCreate, canEdit, canDelete);
                
            }

            mySqlDataReader.Close();
            return null;
        }
    }
}
