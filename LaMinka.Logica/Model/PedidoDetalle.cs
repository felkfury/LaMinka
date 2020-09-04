using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class PedidoDetalle
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int IdProductoValor { get; set; }

        public virtual Pedido IdPedidoNavigation { get; set; }
    }
}
