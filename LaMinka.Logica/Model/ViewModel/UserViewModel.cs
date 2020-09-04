using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace LaMinka.Logica.Model.ViewModel
{

    public class UserViewModel 
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Apellido")]
        public string LastName { get; set; }


        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }

    
        public bool EmailConfirmed { get; set; }

        [Required]
        [DisplayName("DNI")]
        public string DocumentNumber { get; set; }

        [Required]
        [DisplayName("Celular")]
        public string PhoneNumber { get; set; }


        [DisplayName("Contraseña")]
        [UIHint("Password")]
        public string Password { get; set; }

        private DateTime creationDate;

        public bool IsNew { get; set; }

        [DisplayName("Registración")]
        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }

        [DisplayName("Fecha de Nacimiento")]
        public DateTime BirthDate
        {
            get
            {
                return BirthDate;
            }
            set
            {
                BirthDate = new DateTime(value.Ticks, DateTimeKind.Utc);
            }
        }
        public bool Active { get; set; }

        [UIHint("MultiSelect")]
        [DisplayName("Roles")]
        public int[] IdRoles { get; set; }

        #region Grid Fields

        [DisplayName("Roles")]
        public string Roles { get; set; }

        #endregion

        public UserViewModel() : this(true)
        {
        }

        public UserViewModel(bool isNew = true)
        {
            IsNew = isNew;
        }

        public static UserViewModel From(User entity)
        {
            UserViewModel viewModel = new UserViewModel(isNew: false);

            viewModel.Id = entity.Id;
            viewModel.Name = entity.Name;
            viewModel.Email = entity.Email;
            viewModel.EmailConfirmed = entity.EmailConfirmed;
            viewModel.IdRoles = entity.UserRole.Select(x => x.IdRole).ToArray();
            viewModel.Roles = String.Join(" - ", (from j in entity.UserRole select j.Role.Name));
            return viewModel;
        }

        public void ToEntity(User entity)
        {
            entity.Id = this.Id;
            entity.Name = this.Name;
            entity.Email = this.Email;
            entity.EmailConfirmed = this.EmailConfirmed;


            foreach (var idRole in this.IdRoles)
            {
                UserRole userRole = new UserRole();

                userRole.IdUser = this.Id;
                userRole.IdRole = idRole;

                entity.UserRole.Add(userRole);
            }
        }
    }
}
