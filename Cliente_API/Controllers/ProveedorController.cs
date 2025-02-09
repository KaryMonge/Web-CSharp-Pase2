using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Proveedor")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {

        private static DatosProveedor datosproveedor = new DatosProveedor();

        [HttpGet]
        public List<Proveedor> Lista()
        {
            List<Proveedor> lista = datosproveedor.ProovedorList();
            return lista;
        }



        // GET: api/<ProveedorController>
        [HttpGet("{cedula}")]
        public Proveedor Buscar(string cedula)
        {
            Proveedor proveedor = datosproveedor.SearchProveedor(cedula);
            return proveedor;
        }


        // POST api/<ProveedorController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Proveedor proveedor)
        {
            datosproveedor.AddProveedor(proveedor);
            return Ok(proveedor);
        }



        // PUT api/<ClienteController>/5
        [HttpPut("{Ced_juridica}")]
        public IActionResult Edit(string Ced_juridica, [FromBody] Proveedor proveedor)
        {
            datosproveedor.EditProveedor(Ced_juridica, proveedor);
            return Ok(proveedor);
        }


        // DELETE api/<ProveedorController>/5
        [HttpDelete("{Ced_juridica}")]
        public void Delete(string Ced_juridica)
        {

            bool retorno = datosproveedor.Deleteproovedor(Ced_juridica);

        }



    }
}
