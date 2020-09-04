using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaMinka.Web.Cliente.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        // GET: api/<PedidosController>
        [HttpGet]
        [Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "pedido1", "pedido2" };
        }

       

        // POST api/<PedidosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PedidosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PedidosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
