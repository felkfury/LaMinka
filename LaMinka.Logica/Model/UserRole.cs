using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaMinka.Logica.Model
{
    public class UserRole  
    {
        public UserRole()
        {
        }

        public int Id { get; set; }

        public int IdUser { get; set; }

        public int IdRole { get; set; }

        public virtual User User { get; set; }

        public virtual Role Role { get; set; }

        #region Binding



        #endregion
    }
}
