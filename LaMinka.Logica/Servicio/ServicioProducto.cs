using LaMinka.Logica.Data;
using LaMinka.Logica.Model;
using LaMinka.Logica.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LaMinka.Logica.Servicio
{
    public class ServicioProducto
    {
        private readonly LaMinkaContext _context;

        public ServicioProducto(LaMinkaContext context)
        {
            _context = context;
        }

        public async Task<Producto> GetById(int? id)
        {
            return await _context.Producto.Include(i => i.ProductoValor).Where(i => i.Activo == true).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Producto> DeleteById(int? id)
        {
            var producto = await _context.Producto.FindAsync(id);

            producto.IdUserBaja = 1;

            producto.Activo = false;
            producto.FechaBaja = DateTime.Now;
            try
            {
                _context.Producto.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return (producto);
        }

        public async Task<Producto> AddProductoValor(int id, string cantidad, int importe)
        {
            var producto = await GetById(id);

            ProductoValor pv = new ProductoValor();

            //hardcoded until login//
            pv.IdUserAlta = 1;

            pv.FechaAlta = DateTime.Now;
            pv.Activo = true;

            pv.Importe = importe;
            pv.Cantidad = cantidad;
            pv.IdProducto = producto.Id;

            producto.ProductoValor.Add(pv);

            try
            {
                _context.Update(producto);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return producto;
        }

        public async Task<Producto> Upsert(Producto producto)
        {
            producto.Activo = true;
            if (producto.Id == 0)
            {
                //hardcoded until login//
                producto.IdUserAlta = 1;

                producto.FechaAlta = DateTime.Now;
                producto.Activo = true;
                _context.Add(producto);
            }
            else
            {
                //hardcoded until login//
                producto.IdUserModif = 1;
                //Not verifying if there was any changes
                producto.FechaModif = DateTime.Now;

                try
                {
                    _context.Update(producto);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<ProductoValor> DeleteProductoValor(int? idValor)
        {
            var productoValor = await _context.ProductoValor.FirstOrDefaultAsync((m => m.Id == idValor));
            productoValor.Activo = false;
            productoValor.FechaBaja = DateTime.Now;
            productoValor.IdUserBaja = 1;
            try
            {
                _context.ProductoValor.Update(productoValor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return (productoValor);
        }

        public async Task<ProductoViewModel> GetViewById(int? id)
        {
            var prod = await _context.Producto.FirstOrDefaultAsync(m => m.Id == id);
            ProductoViewModel productoViewModel = ProductoViewModel.From(prod);
            return productoViewModel;
        }
    }
}