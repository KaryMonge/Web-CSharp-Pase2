using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Factura")]
    [ApiController]
    public class FacturaController : ControllerBase
    {

        private static DatosFactura datosfactura = new DatosFactura();

        // GET: api/<ClienteController>

        [HttpGet]
        public List<Factura> List()
        {
            List<Factura> lista = datosfactura.FacturaList();
            return lista;
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{Factura_Id}")]
        public void Delete(string Factura_Id)
        {
            bool retorno = datosfactura.DeleteFactura(Factura_Id);


        }


        // GET api/<ClienteController>/5
        [HttpGet("{Factura_Id}")]
        public Factura Buscar(string Factura_Id)
        {
            Factura factura = datosfactura.SearchFactura(Factura_Id);
            return factura;
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Factura factura)
        {
            datosfactura.AddFactura(factura);
            return Ok(factura);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{Factura_Id}")]
        public IActionResult Edit(string Factura_Id, [FromBody] Factura factura)
        {
            datosfactura.EditFactura(Factura_Id, factura);
            return Ok(factura);
        }

    }
}
