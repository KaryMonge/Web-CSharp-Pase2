using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        private static DatosProveedor datosproveedor = new DatosProveedor();
        private readonly Proyecto3_DbContext context;  // nueva linea


        public ProveedorController(Proyecto3_DbContext context)  //nueva linea
        {
            this.context = context;
        }


        [HttpGet]
        public List<Proveedor> Lista()
        {
            List<Proveedor> lista = context.Provedores.ToList();
            return lista;
        }


        // GET: api/<ProveedorController>
        [HttpGet("{cedula}")]
        public Proveedor Buscar(string cedula)
        {
            Proveedor proveedor = context.Provedores.Find(cedula);
            return proveedor;
        }



        // POST api/<ProveedorController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Proveedor proveedor)
        {
            context.Provedores.Add(proveedor);
            context.SaveChanges();
            return Ok(proveedor);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{Ced_juridica}")]
        public IActionResult Edit(string Ced_juridica, [FromBody] Proveedor proveedor)
        {
            if (Ced_juridica != proveedor.Ced_juridica)
            {
                return BadRequest();
            }

            context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                {
                    throw ex;
                }
            }

            return NoContent();
        }




        // DELETE api/<ProveedorController>/5
        [HttpDelete("{Ced_juridica}")]
        public void Delete(string Ced_juridica)
        {
            if (context.Provedores == null)
            {
                return;
            }

            Proveedor proveedor = context.Provedores.Find(Ced_juridica);

            if (proveedor == null)
            {

                return;
            }
            context.Provedores.Remove(proveedor);
            context.SaveChanges(true);


        }



    }
}
