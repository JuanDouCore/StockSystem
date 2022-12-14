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
    /// Lógica de interacción para VentanaEditarProducto.xaml
    /// </summary>
    public partial class VentanaEditarProducto : Window
    {
        int codigo;
        public VentanaEditarProducto(int codigo)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.codigo = codigo;
            Producto productosSeleccionados = SQL.leerProduct(codigo);
            
            botonMarcaEditar.Text = productosSeleccionados.marca;
            botonModeloEditar.Text = productosSeleccionados.modelo;
            botonDescripcionEditar.Text = productosSeleccionados.descripcion;
            botonCodigoEditar.Text = productosSeleccionados.codigo.ToString();
            botonStockEditar.Text = productosSeleccionados.stock.ToString();
            botonCantVendidosEditar.Text = productosSeleccionados.vendidos.ToString();
            botonPrecioEditar.Text = productosSeleccionados.precio.ToString();
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (botonMarcaEditar.Text == "" || botonModeloEditar.Text == "" || botonCodigoEditar.Text == "" || botonStockEditar.Text == "" || botonCantVendidosEditar.Text == "" || botonPrecioEditar.Text == "" || botonDescripcionEditar.Text == ""){

                MessageBox.Show("Todos los campos deben estar llenos");
                return;

            }
            string marca = botonMarcaEditar.Text;
            string modelo = botonModeloEditar.Text;
            string descripcion = botonDescripcionEditar.Text;
            int codigo;
            int stock;
            int vendidos;
            double precio;
            try
            {
                codigo = Convert.ToInt32(botonCodigoEditar.Text);
                stock = Convert.ToInt32(botonStockEditar.Text);
                vendidos = Convert.ToInt32(botonCantVendidosEditar.Text);
                precio = Convert.ToDouble(botonPrecioEditar.Text);

            }catch(Exception ex)
            {
                MessageBox.Show("Verificar que todos los datos ingresados sean correctos");
                return;
            }

            Producto productoFinal = new Producto(marca, modelo, descripcion, codigo, stock, vendidos, precio);

            SQL.updateProduct(productoFinal);
            MessageBox.Show("Se modifico correctamente");
            this.Close();

                
            
        }
    }
}
