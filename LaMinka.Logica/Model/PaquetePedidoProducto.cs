using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class PaquetePedidoProducto
    {
        public int Id { get; set; }
        public int IdPaquetePedido { get; set; }
        public int IdProducto { get; set; }

        public virtual PaquetePedido IdPaquetePedidoNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
    }
}
