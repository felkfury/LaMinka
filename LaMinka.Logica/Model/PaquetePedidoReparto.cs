using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class PaquetePedidoReparto
    {
        public int Id { get; set; }
        public int IdPaquetePedido { get; set; }
        public int IdRepartidor { get; set; }
        public int IdPedido { get; set; }
        public int IdEstado { get; set; }
        public int Posición { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string Comentarios { get; set; }

        public virtual PaquetePedidoRepartoEstado IdEstadoNavigation { get; set; }
        public virtual PaquetePedido IdPaquetePedidoNavigation { get; set; }
        public virtual Pedido IdPedidoNavigation { get; set; }
        public virtual User IdRepartidorNavigation { get; set; }
    }
}
