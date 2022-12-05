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
    /// Interaction logic for VentanaCargar.xaml
    /// </summary>
    public partial class VentanaCargar : Window
    {
        int codigo;
        public VentanaCargar(int codigo)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.codigo = codigo;
            CargaProductoCodigo.Text = codigo.ToString();
            CargaProductoCodigo.IsEnabled = false;
        }

        private void CargaProductoDescripcion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CargaProductoNombre.Text == "" || CargaProductoModelo.Text == "" || CargaProductoStock.Text == "" || CargaProductoPrecio.Text == "" || CargaProductoDescripcion.Text == "")
            {
                MessageBox.Show("EL PRODUCTO DEBE TENER TODOS LOS DATOS. POR FAVOR\nRELLENELOS");
                return;
            }
            string modelo = CargaProductoModelo.Text;
            string marca = CargaProductoNombre.Text;
            int codigo = Convert.ToInt32(CargaProductoCodigo.Text);
            int stock = Convert.ToInt32(CargaProductoStock.Text);
            double precio = Convert.ToDouble(CargaProductoPrecio.Text);
            string descripcion = CargaProductoDescripcion.Text;

            Producto ProductoSql = new Producto(marca, modelo, descripcion, codigo, stock, precio);
            SQL.cargarProduct(ProductoSql);

            MessageBox.Show("NUEVO PRODUCTO CREADO CON EXITO");
            this.Close();
        }

        
    }
}
