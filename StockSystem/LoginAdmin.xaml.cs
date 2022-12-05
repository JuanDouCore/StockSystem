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
using System.Windows.Shapes;

namespace StockSystem
{
    /// <summary>
    /// Lógica de interacción para LoginAdmin.xaml
    /// </summary>
    public partial class LoginAdmin : Window
    {

        private int codeAdmin = 123456;

        public LoginAdmin()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem | ADMIN LOGIN";
        }

        private void closingWindowEvent(object sender, EventArgs e)
        {
            MainWindow.Instance.IsEnabled = true;
        }

        public bool checkLogin()
        {
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(codeAdmin == Convert.ToInt32(codigoIngresado.Text))
                {
                    AdminPanel adminPanelWindow = new AdminPanel();
                    adminPanelWindow.Show();


                    this.Close();
                    MainWindow.Instance.Close();


                } else
                {
                    MessageBox.Show("CLAVE DE ACCESO INVALIDA.");
                    this.Close();
                }
            } catch {
                MessageBox.Show("CLAVE DE ACCESO INVALIDA.");
                this.Close();
            }
        }
    }
}
