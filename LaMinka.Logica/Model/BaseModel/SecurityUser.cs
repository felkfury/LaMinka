using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LaMinka.Logica.Model.BaseModel
{
   public class SecurityUser
    {
        public int Id { get; set; }

        [NotMapped]
        public string UserName
        {
            get
            {
                return Email;
            }
            set
            {
                UserName = value;
            }
        }

        public string Password { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool Active { get; set; }

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(dynamic manager, dynamic user)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}
    }
}
