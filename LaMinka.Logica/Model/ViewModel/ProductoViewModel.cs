using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace LaMinka.Logica.Model.ViewModel
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public static ProductoViewModel From(Producto entity)
        {
            ProductoViewModel viewModel = new ProductoViewModel();

            viewModel.Id = entity.Id;
            viewModel.Nombre = entity.Nombre;
            viewModel.Descripcion = entity.Descripcion;

            return viewModel;
        }

        public void toEntity(Producto entity, string fileName)
        {
            entity.Descripcion = this.Descripcion;
            entity.Nombre = this.Nombre;
            entity.FotoUrl = fileName;
        }
    }
}