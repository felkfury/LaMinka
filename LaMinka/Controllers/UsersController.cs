using LaMinka.Logica.Data;
using LaMinka.Logica.Model;
using LaMinka.Logica.Model.ViewModel;
using LaMinka.Logica.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LaMinka.Controllers
{
    public class UsersController : Controller
    {
        private readonly LaMinkaContext _context;
        private readonly ServicioUsuario _servicioUsuario;

        public UsersController(LaMinkaContext context, ServicioUsuario servicioUsuario)
        {
            _context = context;
            _servicioUsuario = servicioUsuario;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,LastName,DocumentNumber,PhoneNumber,UserToken,CreationDate,BirthDate,IsDeleted,Id,Password,Email,EmailConfirmed,Active")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _servicioUsuario.GetEditById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditModel userEditModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    User entity = await _servicioUsuario.GetById(userEditModel.Id);

                    if (entity == null)
                    {
                        return View(userEditModel);
                    }

                    userEditModel.ToEntity(entity);
                    _context.Update(entity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(userEditModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userEditModel);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _context.User.Remove(user);

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Delete Successful" });
        }

        //// POST: Users/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[HttpDelete]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var user = await _context.User.FindAsync(id);
        //    _context.User.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}