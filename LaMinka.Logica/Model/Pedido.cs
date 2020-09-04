using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class Pedido
    {
        public Pedido()
        {
            PaquetePedidoReparto = new HashSet<PaquetePedidoReparto>();
            PedidoDetalle = new HashSet<PedidoDetalle>();
        }

        public int Id { get; set; }
        public int IdPaquetePedido { get; set; }
        public int IdCliente { get; set; }
        public int IdClienteDomicilio { get; set; }
        public DateTime FechaPedido { get; set; }
        public int? IdUserAlta { get; set; }
        public int IdUserModif { get; set; }
        public int IdUserBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModif { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }

        public virtual ClienteDomicilio IdClienteDomicilioNavigation { get; set; }
        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual PaquetePedido IdPaquetePedidoNavigation { get; set; }
        public virtual ICollection<PaquetePedidoReparto> PaquetePedidoReparto { get; set; }
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
