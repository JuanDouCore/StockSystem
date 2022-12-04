using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    internal class Producto
    {
        string marca { get; set; }
        string modelo { get; set; }
        string descripcion { get; set; }
        int codigo { get; set; }
        int stock { get; set; }
        int vendidos { get; set; }
        double precio { get; set; }

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
    }


}
