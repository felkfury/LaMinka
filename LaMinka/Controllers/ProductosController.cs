using LaMinka.Logica.Data;
using LaMinka.Logica.Model;
using LaMinka.Logica.Model.ViewModel;
using LaMinka.Logica.Servicio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LaMinka
{
    public class ProductosController : Controller
    {
        private readonly LaMinkaContext _context;
        private readonly ServicioProducto _servicioProducto;
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public ProductosController(LaMinkaContext context, ServicioProducto servicioProdcuto, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _servicioProducto = servicioProdcuto;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producto.Where(i => i.Activo == true).ToListAsync());
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<string> SaveImage(IFormFile file)
        {
            string fileName = Guid.NewGuid().ToString();
            string extension = System.IO.Path.GetExtension(file.FileName);

            using (var fileStream = new System.IO.FileStream(System.IO.Path.Combine(_hostingEnvironment.WebRootPath + "/img", fileName + extension), System.IO.FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return fileName + extension;
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Descripcion,FotoUrl")] Producto producto)

        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    producto.FotoUrl = SaveImage(file).Result;
                }

                await _servicioProducto.Upsert(producto);

                return RedirectToAction("Edit", new { id = producto.Id });
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _servicioProducto.GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        public async Task<IActionResult> CreateProductoValor(int id, string Cantidad, int Importe)
        {
            await _servicioProducto.AddProductoValor(id, Cantidad, Importe);

            return RedirectToAction("Edit", "Productos", new { id = id }, "values");
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FotoUrl,IdUserAlta,FechaAlta")] Producto producto)
        {
            if (id != producto.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    producto.FotoUrl = SaveImage(file).Result;
                }

                await _servicioProducto.Upsert(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public async Task<IActionResult> DeleteProductoValor(int id, int idValor)
        {
            await _servicioProducto.DeleteProductoValor(idValor);

            return RedirectToAction("Edit", "Productos", new { id = id }, "values");
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var producto = await _servicioProducto.GetById(id);

            if (producto == null)
                return NotFound();

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _servicioProducto.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }
    }
}