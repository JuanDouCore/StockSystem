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
    /// Lógica de interacción para AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem | ADMINISTRADOR";
        }

        private void cargarUserButton_Click(object sender, RoutedEventArgs e)
        {
            adminCrearUser adminCrearUserWindow = new adminCrearUser();
            adminCrearUserWindow.ShowDialog();
        }

        private void deleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            adminDeleteUser adminDeleteUserWindow = new adminDeleteUser();
            adminDeleteUserWindow.ShowDialog();
        }
    }
}
