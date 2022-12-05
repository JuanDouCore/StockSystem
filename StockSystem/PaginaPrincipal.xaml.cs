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
    /// Lógica de interacción para PaginaPrincipal.xaml
    /// </summary>
    public partial class PaginaPrincipal : Window
    {

        Usuario usuarioActual = null;
        public PaginaPrincipal(string username)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem | PANEL";

            //leer usuario actual
            this.usuarioActual = SQL.leerUsuario(username);
            usuarioText.Text = username;   

            //setear permisos
            if (!usuarioActual.puedeCrear) botonCargarProducto.IsEnabled = false;
            if (!usuarioActual.puedeEditar) botonEditarProducto.IsEnabled = false;
            if (!usuarioActual.puedeEliminar) eliminarButton.IsEnabled = false;
        }


        private void botonCargarProducto_Click(object sender, RoutedEventArgs e)
        {
            

            //verificador si el codigo ingresado esta vacio o no es un numero
            if (inputIngresarCodigo.Text == "" || checkIfCodeIsNumber()) {
                MessageBox.Show("POR FAVOR INGRESE UN CODIGO VALIDO.");
                inputIngresarCodigo.Text = ""; 
                return; 
            }
            int codigoCarga = Convert.ToInt32(inputIngresarCodigo.Text);

            //resto del codigo
            if (!SQL.checkProduct(codigoCarga))
            {
                VentanaCargar ventanaCarga = new VentanaCargar(codigoCarga);
                ventanaCarga.ShowDialog();
            }
            else
            {
                MessageBox.Show("YA HAY UN PRODUCTO EXISTENTE\nCON ESE CODIGO");
                inputIngresarCodigo.Text = "";
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            //verificador si el codigo ingresado esta vacio o no es un numero
            if (inputIngresarCodigo.Text == "" || checkIfCodeIsNumber())
            {
                MessageBox.Show("POR FAVOR INGRESE UN CODIGO VALIDO.");
                inputIngresarCodigo.Text = "";
                return;
            }

            //resto del codigo
            int codigoCarga = Convert.ToInt32(inputIngresarCodigo.Text);

            if (SQL.checkProduct(codigoCarga))
            {


            }
            else
            {
                MessageBox.Show("el mono");
            }


        }

        private void botonEditarProducto_Click(object sender, RoutedEventArgs e)
        {
            //verificador si el codigo ingresado esta vacio o no es un numero
            if (inputIngresarCodigo.Text == "" || checkIfCodeIsNumber())
            {
                MessageBox.Show("POR FAVOR INGRESE UN CODIGO VALIDO.");
                inputIngresarCodigo.Text = "";
                return;
            }

            int codigoCarga = Convert.ToInt32(inputIngresarCodigo.Text);

            if (SQL.checkProduct(codigoCarga))
            {
                VentanaEditarProducto ventanaEditarProduct = new VentanaEditarProducto(codigoCarga);
                ventanaEditarProduct.ShowDialog();
            }
            else
            {
                MessageBox.Show("el mono");
            }

            //resto del codigo
        }

        private void botonCargarVenta_Click(object sender, RoutedEventArgs e)
        {

            //verificador si el codigo ingresado esta vacio o no es un numero
            if (inputIngresarCodigo.Text == "" || checkIfCodeIsNumber())
            {
                MessageBox.Show("POR FAVOR INGRESE UN CODIGO VALIDO.");
                inputIngresarCodigo.Text = "";
                return;
            }


            //resto del codigo

        }

        private bool checkIfCodeIsNumber()
        {
            try
            {
                int a = Convert.ToInt32(inputIngresarCodigo.Text); 
                return false;
            } catch { 
                return true;
            }
        }

        private void botonListarProductos_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
