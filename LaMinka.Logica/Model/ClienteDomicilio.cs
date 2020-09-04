using System;
using System.Collections.Generic;

namespace LaMinka.Logica.Model
{
    public partial class ClienteDomicilio
    {
        public ClienteDomicilio()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public bool EsPrincipal { get; set; }
        public string PreguntarPor { get; set; }
        public string Caracteristicas { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Depto { get; set; }
        public string EntreCalle { get; set; }
        public string EntreCalle2 { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }
        public string Localidad { get; set; }
        public int? IdUserAlta { get; set; }
        public int IdUserModif { get; set; }
        public int IdUserBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModif { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
