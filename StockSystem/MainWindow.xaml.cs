using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StockSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            //instancia de conexion sql
            SQL.connectSql();
            if(!SQL.connectedSql)
            {
                MessageBox.Show("AVISO\nLA CONEXION A LA BASE DE DATOS FALLO.");
            }
            //

            InitializeComponent();
        }




        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (userLabel.Text == "" && passwordLabel.Password == "")
              {
                 MessageBox.Show("POR FAVOR INGRESE DATOS");
                 return;
              }

            if (userLabel.Text == "" || passwordLabel.Password == "")
            {
                MessageBox.Show("POR FAVOR VERIIQUE LOS DATOS INGRESADOS");
                return;
            }

            

            string user = userLabel.Text;
            string password = passwordLabel.Password;



            //codigo para hacer consuta en mysql
            if (SQL.checkUser(user,password))
            {
                MessageBox.Show("momo la dinastia");
            }

        }
    }
}
