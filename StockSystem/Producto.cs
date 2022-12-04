using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    internal class Producto
    {
        public string marca { get; set; }
        public string modelo { get; set; }
        public string descripcion { get; set; }
        public int codigo { get; set; }
        public int stock { get; set; }
        public int vendidos { get; set; }
        public double precio { get; set; }

        public Producto(string marca, string modelo, string descripcion, int codigo, int stock, double precio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.stock = stock;
            this.vendidos = 0;
            this.precio = precio;
        }

        public Producto(string marca, string modelo, string descripcion, int codigo, int vendidos, int stock, double precio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.descripcion = descripcion;
            this.codigo = codigo;
            this.stock = stock;
            this.vendidos = vendidos;
            this.precio = precio;
        }
    }


}
