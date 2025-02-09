
using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private static DatosProducto datosproducto= new DatosProducto();

       
        [HttpGet]
        public List<Producto> Lista()
        {
            List<Producto> lista = datosproducto.ProductList();
            return lista;

        }


        // GET: api/<ProductoController>
        [HttpGet("{id}")]
        public Producto Buscar(string id)
        {
            Producto producto = datosproducto.SearchProduct(id);
            return producto;


        }


        [HttpPost]
        public IActionResult Agregar([FromBody] Producto producto)
        {
            datosproducto.AddProducto(producto);
            return Ok(producto);
        }



        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Producto producto)
        {
            datosproducto.EditProducto(id, producto);
            return Ok(producto);
        }



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            bool retorno = datosproducto.DeleteProducto(id);
         
        }
    }
}
