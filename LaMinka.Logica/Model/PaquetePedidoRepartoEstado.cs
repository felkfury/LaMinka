using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class PaquetePedidoRepartoEstado
    {
        public PaquetePedidoRepartoEstado()
        {
            PaquetePedidoReparto = new HashSet<PaquetePedidoReparto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<PaquetePedidoReparto> PaquetePedidoReparto { get; set; }
    }
}
