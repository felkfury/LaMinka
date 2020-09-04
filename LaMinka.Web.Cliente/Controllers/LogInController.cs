using LaMinka.Web.Cliente.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LaMinka.Logica.Servicio;
using System.Threading.Tasks;

namespace LaMinka.Web.Cliente.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LogInController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ServicioClientes _servicioCliente;

        public LogInController(IConfiguration config, ServicioClientes servicioClientes)
        {
            _config = config;
            _servicioCliente = servicioClientes;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LaMinka.Logica.Model.Cliente login)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);

                response = Ok(new { token = tokenString, user = user });
            }

            return response;
        }

        private string GenerateJSONWebToken(LaMinka.Logica.Model.Cliente userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userInfo.Email) });

            var token = new JwtSecurityTokenHandler().CreateJwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
             subject: claimsIdentity,
             notBefore: DateTime.UtcNow,
             expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(120)),
             signingCredentials: credentials);

            Console.WriteLine(token);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<LaMinka.Logica.Model.Cliente> AuthenticateUser(LaMinka.Logica.Model.Cliente login)
        {
            var cliente = await _servicioCliente.GetByEmailAndPassword(login.Email, login.Password);

            if (cliente != null)
            {
                return cliente;
            }
            else return null;
        }
    }
}