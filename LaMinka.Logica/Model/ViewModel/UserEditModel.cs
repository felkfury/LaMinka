using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace LaMinka.Logica.Model.ViewModel
{

    public class UserEditModel
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

        
        [Required]
        [DisplayName("Celular")]
        public string PhoneNumber { get; set; }


        [DisplayName("Contraseña")]
        [UIHint("Password")]
        public string Password { get; set; }

        private DateTime creationDate;
        private DateTime birthDate;


        public DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                { this.creationDate = DateTime.Now; }
            }
        }
        ////public DateTime BrirthDate
        ////{
        ////    get
        ////    {
        ////        return birthDate;
        ////    }
        ////    set
        ////    {
        ////        { this.birthDate = DateTime.Now; }
        ////    }
        ////}





        public bool IsNew { get; set; }

        
        public bool Active { get; set; }

       

        public UserEditModel() : this(true)
        {
        }

        public UserEditModel(bool isNew = true)
        {
            IsNew = isNew;
        }

        public static UserEditModel From(User entity)
        {
            UserEditModel viewModel = new UserEditModel(isNew: false)
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                LastName = entity.LastName,
                Password = entity.Password,
                PhoneNumber = entity.PhoneNumber,
                CreationDate=(DateTime)entity.CreationDate,
                birthDate = (DateTime)entity.BirthDate,
            };
             return viewModel; 
        
        }

        public void ToEntity(User entity)
        {
            entity.Id = this.Id;
            entity.Name = this.Name;
            entity.Email = this.Email;
            entity.LastName = this.LastName;
            entity.PhoneNumber = this.PhoneNumber;
            entity.Password = this.Password;
            entity.CreationDate = this.CreationDate;
            
        }
    }
}
