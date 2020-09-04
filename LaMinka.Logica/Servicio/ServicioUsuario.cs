using LaMinka.Logica.Data;
using LaMinka.Logica.Model;
using LaMinka.Logica.Model.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaMinka.Logica.Servicio
{
   
    public class ServicioUsuario
    {
        private readonly LaMinkaContext _context;

        public ServicioUsuario(LaMinkaContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAndPassword(string email, string password, bool getDeleted = false)
        {
            return await _context.User.FirstOrDefaultAsync(x => (!x.IsDeleted || getDeleted) && x.Email == email && x.Password == password);
        }

        public async Task<User> GetByUserAndToken(int id, string userToken, bool getDeleted = false)
        {
            return await _context.User.FirstOrDefaultAsync(x => (!x.IsDeleted || getDeleted) && x.Id == id && x.UserToken == userToken);
        }

        public async Task<User> GetByEmailAndToken(string email, string userToken, bool getDeleted = false)
        {
            return await _context.User.FirstOrDefaultAsync(x => (!x.IsDeleted || getDeleted) && x.Email == email && x.UserToken == userToken);
        }

        public async Task<User> GetByEmail(string email, bool getDeleted = false)
        {
            return await _context.User.FirstOrDefaultAsync(x => (!x.IsDeleted || getDeleted) && x.Email == email);
        }

        public async Task<User> GetActiveByEmail(string email, bool getDeleted = false)
        {
            return await _context.User.FirstOrDefaultAsync(x => (!x.IsDeleted || getDeleted) && x.Email == email && x.Active == true);
        }


        public async Task<User> GetById(int? id)
        {
            return await _context.User.FirstOrDefaultAsync(m => m.Id == id);
        }


        public async Task<UserViewModel> GetViewById(int? id)
        {
            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            UserViewModel userViewModel = UserViewModel.From(user);
            return userViewModel;
        }



        public async Task<UserEditModel> GetEditById(int? id)
        {
            var user = await _context.User.FirstOrDefaultAsync(m => m.Id == id);
            UserEditModel userEditModel = UserEditModel.From(user);
            return userEditModel;
        }

    }
}