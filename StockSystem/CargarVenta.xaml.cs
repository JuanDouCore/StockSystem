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
    /// Lógica de interacción para CargarVenta.xaml
    /// </summary>
    public partial class CargarVenta : Window
    {
        int codigoProducto;
        double cantidad = 0;
        Producto productoactual;
        public CargarVenta(int codigoProducto)
        {
            InitializeComponent();
            this.codigoProducto = codigoProducto;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem | Cargar Venta";
            productoactual = SQL.leerProduct(codigoProducto);
            cargarVentaProducto.Text = productoactual.marca + " " + productoactual.modelo;
            cargarVentaProducto.IsEnabled = false;
            cargarVentaTotal.IsEnabled = false;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cargarVentaCliente.Text == "" || cargarVentaCantidad.Text == "")
            {
                MessageBox.Show("Especifique nombre de cliente y cantidad");
                return;
            }

            if (productoactual.stock >= cantidad)
            {
                productoactual.vendidos += Convert.ToInt32(cantidad);
                productoactual.stock -= Convert.ToInt32(cantidad);

                SQL.updateProduct(productoactual);
                MessageBox.Show("VENTA EXITOSA");
                this.Close();
            } else {
                cantidad = 0;
                MessageBox.Show("NO HAY STOCK SUFICIENTE PARA REALIZAR ESTA VENTA.");
                cargarVentaCantidad.Text = "";
                cargarVentaTotal.Text = "";
            }
        }

        private void cargarVentaCantidad_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cargarVentaCantidad.Text != "") 
                try
                {
                    cantidad += Convert.ToDouble(cargarVentaCantidad.Text);
                    cargarVentaTotal.Text = "$" + (cantidad * productoactual.precio).ToString();
                }
                catch
                {
                    cargarVentaCantidad.Text = "";
                }
        }
    }
}
