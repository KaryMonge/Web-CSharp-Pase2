
using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        private static DatosProducto datosproducto= new DatosProducto();

        private readonly Proyecto3_DbContext context;  // nueva linea

        public ProductoController(Proyecto3_DbContext context)  //nueva linea
        {
            this.context = context;
        }

        /*
        [HttpGet]
        public List<Producto> Lista()
        {
            List<Producto> lista = datosproducto.ProductList();
            return lista;

        }*/



        [HttpGet]
        public List<Producto> Lista()
        {
            List<Producto> lista = context.Productos.ToList();
            return lista;

        }


        /*
                // GET: api/<ProductoController>
                [HttpGet("{id}")]
                public Producto Buscar(string id)
                {
                    Producto producto = datosproducto.SearchProduct(id);
                    return producto;


                }*/


        // GET: api/<ProductoController>
        [HttpGet("{id}")]
        public Producto Buscar(string id)
        {
            Producto producto = context.Productos.Find(id);
            return producto;

        }




        /*
        [HttpPost]
        public IActionResult Agregar([FromBody] Producto producto)
        {
            datosproducto.AddProducto(producto);
            return Ok(producto);
        }
        */


        [HttpPost]
        public IActionResult Agregar([FromBody] Producto producto)
        {
            context.Productos.Add(producto);
            context.SaveChanges();
            return Ok(producto);
        }

        /*

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Producto producto)
        {
            datosproducto.EditProducto(id, producto);
            return Ok(producto);
        }*/

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Edit(string id, [FromBody] Producto producto)
        {

            if (id != producto.Producto_Id)
            {
                return BadRequest();
            }

            context.Entry(producto).State = EntityState.Modified;

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



        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            if (context.Productos == null)
            {
                return;
            }

            Producto Producto = context.Productos.Find(id);

            if (Producto == null)
            {

                return;
            }
            context.Productos.Remove(Producto);
            context.SaveChanges(true);


        }




    }
}
