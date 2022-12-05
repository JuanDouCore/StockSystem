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
    /// Lógica de interacción para adminCrearUser.xaml
    /// </summary>
    public partial class adminCrearUser : Window
    {
        public adminCrearUser()
        {
            InitializeComponent();
            this.Title = "CREAR USUARIO";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void crearButton_Click(object sender, RoutedEventArgs e)
        {
            if (userLabel.Text == "" || passwordLabel.Text == "") 
            {
                MessageBox.Show("POR FAVOR COMPLETE TODOS LOS CAMPOS");
                return;
            }
            
            string user = userLabel.Text;
            string password = passwordLabel.Text;
            bool create = checkCrear.IsChecked.GetValueOrDefault();
            bool edit = checkEditar.IsChecked.GetValueOrDefault();  
            bool delete = checkDelete.IsChecked.GetValueOrDefault();

            SQL.crearUsuario(new Usuario(user, password, create, edit, delete));
            MessageBox.Show("USUARIO CREADO EXITOSAMENTE");
            this.Close();
        }
    }
}
