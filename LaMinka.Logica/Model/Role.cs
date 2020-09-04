 
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaMinka.Logica.Model
{
    public class Role  
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        #region Binding

        //public static void Bind(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Role>()
        //      .HasMany(e => e.UserRoles)
        //      .WithRequired(e => e.Role)
        //      .HasForeignKey(e => e.IdRole)
        //      .WillCascadeOnDelete(false);
        //}

        #endregion

    }
}
