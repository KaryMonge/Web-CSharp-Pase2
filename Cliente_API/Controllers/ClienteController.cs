using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("ServiceCliente/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private static DatosCliente datosCliente = new DatosCliente();

        // GET: api/<ClienteController>
 
        [HttpGet]
        public List<Cliente> List()
        {
            List<Cliente> lista = datosCliente.ClientList();
            return lista;
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{cedula}")]
        public void Delete(string cedula)
        {
            bool retorno = datosCliente.DeleteClient(cedula);
            

        }

        // GET api/<ClienteController>/5
        [HttpGet("{cedula}")]
        public Cliente Buscar(string cedula)
        {
            Cliente cliente = datosCliente.SearchClient(cedula);
            return cliente;
        }


        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Cliente cliente)
        {
            datosCliente.AddClient(cliente);
            return Ok(cliente);
        }



        // PUT api/<ClienteController>/5
        [HttpPut("{cedula}")]
        public IActionResult Edit(string cedula, [FromBody]Cliente cliente)
        {
            datosCliente.EditClient(cedula, cliente);
            return Ok(cliente);
        }
    }
}
