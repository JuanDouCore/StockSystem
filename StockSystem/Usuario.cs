using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem
{
    internal class Usuario
    {

        public string username { get; set; }
        public string password { get; set; }
        public bool puedeCrear { get; }
        public bool puedeEditar { get; }
        public bool puedeEliminar { get; }

        public Usuario(string username, string password, bool puedeCrear, bool puedeEditar, bool puedeEliminar)
        {
            this.username = username;   
            this.password = password;   
            this.puedeCrear= puedeCrear;
            this.puedeEditar = puedeEditar;
            this.puedeEliminar= puedeEliminar;
        }
    }
}
