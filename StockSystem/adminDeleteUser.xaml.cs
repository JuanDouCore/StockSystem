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
    /// Lógica de interacción para adminDeleteUser.xaml
    /// </summary>
    public partial class adminDeleteUser : Window
    {
        public adminDeleteUser()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "ELIMINAR USUARIO";
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(userLabel.Text == "")
            {
                MessageBox.Show("POR FAVOR INGRESE UN USUARIO");
                return;
            }

            if(SQL.existeUser(userLabel.Text))
            {
                SQL.eliminearUsuario(userLabel.Text);
                MessageBox.Show("USUARIO ELIMINADO CORRECTAMENTE");
                this.Close();
            } else
            {
                MessageBox.Show("NO EXISTE NINGÚN USUARIO CON ESTE NOMBRE");
                userLabel.Text = "";
            }
        }
    }
}
