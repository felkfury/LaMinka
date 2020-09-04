using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMinka.Models
{
    [Table("User")]
    public class UsersModel
    {
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "Apellido Requerido")]
        public string Apellido { get; set; }
       
        [Required(ErrorMessage = "Mail Requerido")]
        public string Mail { get; set; }
        

        [Required(ErrorMessage = "Rol Requerido")]
        public string Rol { get; set; }
        

    }
    
}
