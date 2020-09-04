using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class PaquetePedido
    {
        public PaquetePedido()
        {
            PaquetePedidoProducto = new HashSet<PaquetePedidoProducto>();
            PaquetePedidoReparto = new HashSet<PaquetePedidoReparto>();
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public DateTime FechaEntrega { get; set; }
        public bool Estado { get; set; }
        public int? IdUserAlta { get; set; }
        public int IdUserModif { get; set; }
        public int IdUserBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModif { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<PaquetePedidoProducto> PaquetePedidoProducto { get; set; }
        public virtual ICollection<PaquetePedidoReparto> PaquetePedidoReparto { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
