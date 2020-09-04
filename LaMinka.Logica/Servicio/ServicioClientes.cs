using LaMinka.Logica.Data;
using LaMinka.Logica.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LaMinka.Logica.Servicio
{
    public class ServicioClientes
    {
        private readonly LaMinkaContext _context;

        public ServicioClientes(LaMinkaContext context)
        {
            _context = context;
        }

        public async Task<Cliente> GetByEmailAndPassword(string email, string password)
        {
            return await _context.Cliente.FirstOrDefaultAsync(x => x.Activo == true && x.Email == email && x.Password == password);
        }

        //public async Task<User> GetByUserAndToken(int id, string userToken, bool getDeleted = false)
        //{
        //    return await _context.Cliente.FirstOrDefaultAsync(x => (!x.Activo) && x.Id == id && x.UserToken == userToken);
        //}

        //public async Task<User> GetByEmailAndToken(string email, string userToken, bool getDeleted = false)
        //{
        //    return await _context.Cliente.FirstOrDefaultAsync(x => (!x.IsDeleted || getDeleted) && x.Email == email && x.UserToken == userToken);
        //}

        public async Task<Cliente> GetByEmail(string email)
        {
            return await _context.Cliente.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Cliente> GetActiveByEmail(string email)
        {
            return await _context.Cliente.FirstOrDefaultAsync(x => x.Email == email && x.Activo == true);
        }

        public async Task<Cliente> GetById(int? id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(m => m.Id == id);
        }

        //public async Task<UserViewModel> GetViewById(int? id)
        //{
        //    var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
        //    UserViewModel userViewModel = UserViewModel.From(user);
        //    return userViewModel;
        //}
    }
}