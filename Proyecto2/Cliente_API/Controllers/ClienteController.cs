using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("ServiceCliente/Cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private static DatosCliente datosCliente = new DatosCliente();

        private readonly   Proyecto3_DbContext context;  // nueva linea

        public ClienteController(Proyecto3_DbContext context)  //nueva linea
        {
            this.context = context;
        }




        [HttpGet]
        public List<Cliente> List()
        {
            List<Cliente> lista = context.Clientes.ToList();
            return lista;
        }



        // GET api/<ClienteController>/5
        [HttpGet("{cedula}")]
        public Cliente Buscar(string cedula)
        {
            Cliente cliente = context.Clientes.Find(cedula);
            return cliente;
        }


  


        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Cliente cliente)
        {
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return Ok(cliente);
        }




        // PUT api/<ClienteController>
        [HttpPut("{cedula}")]
        public IActionResult Edit(string cedula, [FromBody] Cliente cliente)
        {

            if(cedula != cliente.Cedula)
            {
                return BadRequest();
            }
            context.Entry(cliente).State = EntityState.Modified;

            try
            {
                context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                {
                    throw ex;
                }

            }
            return NoContent();

        }



        // DELETE api/<ClienteController>/5
        [HttpDelete("{cedula}")]
        public void Delete(string cedula)
        {
            if(context.Clientes == null)
            {
                return;
            }

            Cliente cliente = context.Clientes.Find(cedula);

            if(cliente == null){

                return;
            }
            context.Clientes.Remove(cliente);   
            context.SaveChanges(true);


        }

    }
}
