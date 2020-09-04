using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LaMinka.Security
{
    public class SecurityHelper
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public SecurityHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public static bool IsAllowed(string[] acceptedRoles)
        {
            bool result = false;
            foreach (var item in acceptedRoles)
            {
                if (_httpContextAccessor.HttpContext.User.IsInRole(item)) return true;
            }
            return result;
        }

        public static class Roles
        {
            public const string Admin = "Administrador";
            public const string Repartidor = "Repartidor";

        }
    }
}
