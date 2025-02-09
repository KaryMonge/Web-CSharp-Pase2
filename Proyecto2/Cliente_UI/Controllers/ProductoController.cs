using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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




        public string generar_id()
        {
            Random factura_id_random = new Random();
            string factura_id_s = Convert.ToString(factura_id_random.Next(1, 999999999));
            return factura_id_s;
        }


        //los metodos asincronicos se utilizan para enviar request y no quedar esperando
        //esta función llena una lista con todos los [proveedores que están en la base de datos
        public async Task<ActionResult<List<Proveedor>>> ListaProveedor_DD()
        {
            List<Proveedor> prove = await _service.ProveeList(); // aqui recibo lo que haya en lista de proveedores en un task

            return prove;
        }


        //recorre la lista y los va a gregando al view 
        public List<Producto> Lista_Proveedores()
        {
            List<Producto> proveedores_producto = new List<Producto>();

            List<Proveedor> todoproveedor = ListaProveedor_DD().Result.Value;// aqui se obtiene lo que se recibe en un task

            foreach (Models.Proveedor proveedor in todoproveedor)// aqui recorro todo Proveedor
            {
                proveedores_producto.Add(new Producto() { Ced_juridica = proveedor.Ced_juridica });

            }
            return proveedores_producto;
        }



        public string AsignarPrimerProveedor()
        {
            //se recorre la lista de proveedors y se retorna el provedoor en la posición cero.
            List<Proveedor> todoproveedor = ListaProveedor_DD().Result.Value;
            return todoproveedor[0].Ced_juridica;

        }




        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {

            Producto producto = new Producto();

          producto.Producto_Id = generar_id();

            //Llenado del listado de proveedores
            ViewBag.Ced_juridica = Lista_Proveedores();

            //Se obtiene el primer Proveedor y se asigna como el proveedor del tour
            producto.Ced_juridica = AsignarPrimerProveedor();

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

            // Llenado del listado de proveedores
            ViewBag.Ced_juridica = Lista_Proveedores();

            return View(producto);
        }


 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Producto_Id, IFormCollection collection)
        {

            Producto producto_modificado = new Producto();

            producto_modificado.Producto_Id = collection["Producto_Id"];
            producto_modificado.Producto_Descripcion = collection["Producto_Descripcion"];
            producto_modificado.Ced_juridica = collection["Ced_juridica"];
            producto_modificado.Anio_ingreso = Convert.ToInt32(collection["Anio_ingreso"]);
            producto_modificado.Precio = Convert.ToSingle(collection["Precio"], CultureInfo.CreateSpecificCulture("en-US"));
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
