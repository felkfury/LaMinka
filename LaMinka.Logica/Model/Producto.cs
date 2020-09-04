using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LaMinka.Logica.Model
{
    public partial class Producto
    {
        public Producto()
        {
            PaquetePedidoProducto = new HashSet<PaquetePedidoProducto>();
            ProductoValor = new HashSet<ProductoValor>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Descripcion { get; set; }

        [DisplayName("Foto")]
        public string FotoUrl { get; set; }

        public int? IdUserAlta { get; set; }
        public int IdUserModif { get; set; }
        public int IdUserBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModif { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<PaquetePedidoProducto> PaquetePedidoProducto { get; set; }
        public virtual ICollection<ProductoValor> ProductoValor { get; set; }
    }
}