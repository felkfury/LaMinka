using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaMinka.Logica.Model;
using LaMinka.Logica.Data;
using LaMinka.Logica.Servicio;
using LaMinka.Logica.Model.ViewModel;
using Microsoft.AspNetCore.Authorization;
using LaMinka.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Security.Encryption;

namespace LaMinka.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public AccountController(IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpContextAccessor = httpContextAccessor;
        //}

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginViewModel model, string returnUrl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var encryptedPassword = new EncryptionManager(CustomSettings.General.EncryptionPassword).Encrypt(model.Password);
        //        User entity = Repository.UserManager.GetByEmailAndPassword(model.Email, encryptedPassword);
        //        if (entity != null)
        //        {
        //            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.UserData, model.Email), }, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.UserData, ClaimTypes.Role);
        //            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString()));

        //            // if you want roles, just add as many as you want here (for loop maybe?)
        //            foreach (var role in entity.UserRoles)
        //            {
        //                identity.AddClaim(new Claim(ClaimTypes.Role, role.Role.Name));
        //            }
        //            // tell OWIN the identity provider, optional
        //            //identity.AddClaim(new Claim(IdentityProvider, "Simplest Auth"));

        //            Authentication.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
        //            Repository.UserAccessManager.RegisterAccessFromWeb(entity.Id);
        //            Repository.SaveChanges();

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("Password", "Los datos son incorrectos");
        //        }
        //    }

        //    return View("Login", model);
        //}

       
        public ActionResult LogOff()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        //#region Change password

        
        public ActionResult ChangePassword()
        {
            return View();
        }

        //[CustomAuthorize]
        //[System.Web.Mvc.HttpPost]
        //public ActionResult ChangePassword(ChangePasswordViewModel viewModel)
        //{
        //    var currentPassword = new EncryptionManager(CustomSettings.General.EncryptionPassword).Encrypt(viewModel.CurrentPassword);
        //    User entity = Repository.UserManager.GetById(CurrentUser.Id);

        //    if (currentPassword != entity.Password)
        //    {
        //        ModelState.AddModelError("CurrentPassword", "La contraseña actual no coincide.");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        entity.Password = new EncryptionManager(CustomSettings.General.EncryptionPassword).Encrypt(viewModel.NewPassword);
        //        Repository.UserManager.Update(entity);
        //        Repository.SaveChanges();
        //        return RedirectToAction("ChangePasswordConfirmation");
        //    }

        //    return View(viewModel);
        //}

       
        public ActionResult ChangePasswordConfirmation()
        {
            return View();
        }
    }

}