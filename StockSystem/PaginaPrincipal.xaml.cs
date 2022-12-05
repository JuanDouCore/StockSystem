﻿using System;
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
        public PaginaPrincipal()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Title = "StockSystem | PANEL";
        }


        private void botonCargarProducto_Click(object sender, RoutedEventArgs e)
        {
            //verificador si el codigo ingresado esta vacio o no es un numero
            if (inputIngresarCodigo.Text == "" || checkIfCodeIsNumber()) {
                MessageBox.Show("POR FAVOR INGRESE UN CODIGO VALIDO.");
                inputIngresarCodigo.Text = ""; 
                return; 
            }

            //resto del codigo
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
    }
}
