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
    /// Lógica de interacción para AgregarStock.xaml
    /// </summary>
    public partial class AgregarStock : Window
    {
        Producto productoEleg = null;
        int cantAuxAgregar = 0;
        int codigoProducto;
        public AgregarStock(int codigoProducto)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem | Agregar Stock";
            this.codigoProducto = codigoProducto;
            productoEleg = SQL.leerProduct(codigoProducto);

            nombreProducto.Text = productoEleg.marca+" "+productoEleg.modelo;
        }
        
        private void cantidadAgregar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cantidadAgregar.Text != ""){

            
            try
            {
                cantAuxAgregar += Convert.ToInt32(cantidadAgregar.Text);
                
            }
            catch {
                MessageBox.Show("Por favor ingrese una suma correcta");
                cantidadAgregar.Text = ""; 
            }
            }
        }

        private void buttonAgregar_Click(object sender, RoutedEventArgs e)
        {
            
            if(cantidadAgregar.Text==""){
                MessageBox.Show("Por favor ingrese una cantidad correcta");
                return;
            }
            productoEleg.stock += cantAuxAgregar;
            SQL.updateProduct(productoEleg);
            MessageBox.Show("Stock agregado correctamente, ahora\n el producto tiene: " + productoEleg.stock + " unidades");
            this.Close();
        }
    }
}
