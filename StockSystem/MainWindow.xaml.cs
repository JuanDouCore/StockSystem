using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
            Instance = this;


            //instancia de conexion sql
            SQL.connectSql();
            if (!SQL.connectedSql)
            {
                MessageBox.Show("AVISO\nLA CONEXION A LA BASE DE DATOS FALLO.");
            }

            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem v0.1";

            Thread checkSql = new Thread(SQL.checkStatusDatabase);
            checkSql.Start();
        }

        public static MainWindow Instance { get; private set; }


        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (userLabel.Text == "" && passwordLabel.Password == "")
            {
                MessageBox.Show("POR FAVOR INGRESE DATOS");
                return;
            }

            if (userLabel.Text == "" || passwordLabel.Password == "")
            {
                userLabel.Text = "";
                passwordLabel.Password = "";
                MessageBox.Show("POR FAVOR VERIFIQUE LOS DATOS INGRESADOS");
                return;
            }

            string user = userLabel.Text;
            string password = passwordLabel.Password;

            if (SQL.checkUser(user, password))
            {
                PaginaPrincipal ventanaPrincipal = new PaginaPrincipal(user);
                this.Close();
                ventanaPrincipal.Show();
            }
            else { MessageBox.Show("Usuario o contraseña incorrectos"); }

            userLabel.Text = "";
            passwordLabel.Password = "";
        }

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            LoginAdmin loginAdminWindow = new LoginAdmin();
            loginAdminWindow.ShowDialog();
        }
    }
}
