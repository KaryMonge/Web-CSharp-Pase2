using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cliente_UI.Controllers
{
    public class ProductoController : Controller
    {


        private static List<Models.Producto> listaproductos = new List<Models.Producto>();

        private readonly IService _service;

        public ProductoController(IService serviceprod)
        {
            _service = serviceprod;
        }



        // GET: ProductController
        public async Task<ActionResult> Index()
        {

            List<Producto> productos = await _service.productList();

            return View(productos);
        }




        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(string Producto_Id)
        {
            Producto producto = await _service.Searchproduct(Producto_Id);

            return View(producto);
        }






        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Producto producto)
        {
            try
            {
                await _service.Addproduct(producto);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }


        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(string Producto_Id)
        {
            Producto producto = await _service.Searchproduct(Producto_Id);
            return View(producto);
        }


 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Producto_Id, IFormCollection collection)
        {

            Producto producto_modificado = new Producto();

            producto_modificado.Producto_Id = collection["Producto_Id"];
            producto_modificado.Producto_Descripcion = collection["Producto_Descripcion"];
            producto_modificado.Anio_ingreso = Convert.ToInt32(collection["Anio_ingreso"]);
            producto_modificado.Precio = Convert.ToSingle(collection["Precio"]);
            producto_modificado.Utilidad = Convert.ToInt32(collection["Utilidad"]);

            try
            {
                await _service.EditProducto(Producto_Id, producto_modificado);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }



        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(string Producto_Id)
        {

          // Producto prod = await _service.Searchproduct(Producto_Id);
          //return View(prod);


           await _service.DeleteProduct(Producto_Id);

           return RedirectToAction(nameof(Index));

            /*
            Producto producto = new Producto();


           producto = await _service.Searchproduct(id);


           


            return View(producto);
            */

        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string Producto_Id, IFormCollection collection)
        {
            try
            {
                // await _service.DeleteProduct(Producto_Id);
                return RedirectToAction(nameof(Index));
            }
            catch
         
            {
                return View();
            }
        }


    }
}
