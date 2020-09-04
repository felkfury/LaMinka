using LaMinka.Logica.Model.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaMinka.Logica.Model
{
    public partial class User : SecurityUser
    {
        public User()
        {
            PaquetePedidoReparto = new HashSet<PaquetePedidoReparto>();
            UserRole = new HashSet<UserRole>();
        }
        
        
        public string Name { get; set; }

        public string LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string UserToken { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsDeleted { get; set; }
        public string ZonaPoligono { get; set; }

        public virtual ICollection<PaquetePedidoReparto> PaquetePedidoReparto { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }


        #region Binding

        // public static void Bind(DbModelBuilder modelBuilder)
        // {
        //    modelBuilder.Entity<User>()
        //         .HasMany(e => e.UserAccess)
        //         .WithRequired(e => e.User)
        //         .HasForeignKey(e => e.IdUser)
        //         .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<User>()
        //       .HasMany(e => e.UserAreas)
        //       .WithRequired(e => e.User)
        //       .HasForeignKey(e => e.IdUser)
        //       .WillCascadeOnDelete(false);

        //     modelBuilder.Entity<User>()
        //        .HasMany(e => e.UserRoles)
        //        .WithRequired(e => e.User)
        //        .HasForeignKey(e => e.IdUser)
        //        .WillCascadeOnDelete(false);

        //}

        #endregion
    }
}
