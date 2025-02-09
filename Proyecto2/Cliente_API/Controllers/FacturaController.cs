using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Factura")]
    [ApiController]
    public class FacturaController : ControllerBase
    {



        private readonly Proyecto3_DbContext context;  // nueva linea


        public FacturaController(Proyecto3_DbContext context)  //nueva linea
        {
            this.context = context;
        }


        [HttpGet]
        public List<Factura> List()
        {
            List<Factura> lista = context.Facturas.ToList();
            return lista;
        }





        // GET api/<ClienteController>/5
        [HttpGet("{Factura_Id}")]
        public Factura Buscar(string Factura_Id)
        {
            Factura factura = context.Facturas.Find(Factura_Id);
            return factura;
        }




        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Factura factura)
        {
            context.Facturas.Add(factura);
            context.SaveChanges();
            return Ok(factura);
        }



        // PUT api/<ClienteController>/5
        [HttpPut("{Factura_Id}")]
        public IActionResult Edit(string Factura_Id, [FromBody] Factura factura)
        {
            if (Factura_Id != factura.Factura_ID)
            {
                return BadRequest();
            }

            context.Entry(factura).State = EntityState.Modified;

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



        // DELETE api/<ClienteController>/5
        [HttpDelete("{Factura_Id}")]
        public void Delete(string Factura_Id)
        {
            if (context.Facturas == null)
            {
                return;
            }

            Factura factura = context.Facturas.Find(Factura_Id);

            if (factura == null)
            {

                return;
            }
            context.Facturas.Remove(factura);
            context.SaveChanges(true);

        }

    }
}
