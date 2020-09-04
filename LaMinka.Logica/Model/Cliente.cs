using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteDomicilio = new HashSet<ClienteDomicilio>();
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? IdUserAlta { get; set; }
        public int IdUserModif { get; set; }
        public int IdUserBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModif { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }
        public bool? AlertaPedidoEnCamino { get; set; }
        public bool? AlertaHabilitaPedido { get; set; }
        public bool? MismoUltimoPedido { get; set; }

        public virtual ICollection<ClienteDomicilio> ClienteDomicilio { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
