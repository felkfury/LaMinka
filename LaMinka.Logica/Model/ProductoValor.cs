using System;
using System.ComponentModel.DataAnnotations;

namespace LaMinka.Logica.Model
{
    public partial class ProductoValor
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string Cantidad { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Currency)]
        public decimal Importe { get; set; }

        public int? IdUserAlta { get; set; }
        public int IdUserModif { get; set; }
        public int IdUserBaja { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModif { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool Activo { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
    }
}