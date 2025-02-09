using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Cliente_UI.Controllers
{

    public class FacturaController : Controller
    {

        private static List<Models.Factura> listaproductos = new List<Models.Factura>();

        private readonly IService _service;

        public FacturaController(IService servicefac)
        {
            _service = servicefac;
        }



        // GET: FacturaController
        public async Task<ActionResult> Index()
        {
            List<Factura> facturas = await _service.FacturaList();

            return View(facturas);
        }


        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(string Factura_Id)
        {
            Factura factura = await _service.SearchFactura(Factura_Id);

            return View(factura);
        }


        /*
        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }*/



        public string generar_id()
        {
            Random factura_id_random = new Random();
            string factura_id_s = Convert.ToString(factura_id_random.Next(1, 999999999));
            return factura_id_s;
        }



        public List<Factura> Lista_Productos()
        {
            List<Factura> productos_factura = new List<Factura>();
            //List<Producto> productos = new List<Producto>();
            //List<Models.Producto> List;
            //List = ProductoController.get_product_list();
            List<Models.Producto> listaproductos1 = new List<Models.Producto>();


            foreach (Producto producto in listaproductos1)
            {

               productos_factura.Add(new Factura() { Lista_productos = producto.Producto_Id});
               
            }
            return productos_factura;
        }




        public List<Factura> Lista_Tours()
        {
            List<Factura> tours_factura = new List<Factura>();

            
            tours_factura.Add(new Factura() { Lista_tours = " " });
            tours_factura.Add(new Factura() { Lista_productos = " " });
            return tours_factura;

        }




        // GET: FacturaController/Create
        public async Task<ActionResult> Create()
        {
            Factura factura = new Factura();

            ViewBag.Lista_Productos = Lista_Productos();
            ViewBag.Lista_Tours = Lista_Tours();

            factura.Factura_ID = generar_id();


            return View(factura);
        }



        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Factura factura)
        {
            try
            {
                await _service.Addfactura(factura);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }






        // GET: FacturaController/Edit/5
        public async Task<ActionResult> Edit(string Factura_Id)
        {
            Factura factura = await _service.SearchFactura(Factura_Id);
            return View(factura);

        }
        

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Factura_Id, IFormCollection collection)
        {
            Factura factura_modificada = new Factura();

            factura_modificada.Factura_ID = collection["Factura_ID"];
            factura_modificada.Lista_tours = collection["Lista_tours"];
            factura_modificada.Lista_productos = collection["Lista_productos"];
            factura_modificada.Precio_tour_sin_iva = Convert.ToSingle(collection["Precio_tour_sin_iva"]);
            factura_modificada.Precio_tour_con_iva = Convert.ToSingle(collection["Precio_tour_con_iva"]);
            factura_modificada.Precio_Producto_sin_iva = Convert.ToSingle(collection["Precio_Producto_sin_iva"]);
            factura_modificada.Precio_Producto_con_iva = Convert.ToSingle(collection["Precio_Producto_con_iva"]);
            factura_modificada.Total_sin_IVA = Convert.ToSingle(collection["Total_sin_IVA"]);
            factura_modificada.Total_con_IVA = Convert.ToSingle(collection["Total_con_IVA"]);

            try
            {
                await _service.EditFactura(Factura_Id, factura_modificada);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }


        }



        // GET: FacturaController/Delete/5
        public async Task<ActionResult> Delete(string Factura_Id)
        {

            //Factura factura = await _service.SearchFactura(Factura_Id);
            //return View(factura);


            await _service.DeleteFactura(Factura_Id);

            return RedirectToAction(nameof(Index));


        }



        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string Factura_Id, Factura factura)
        {
            try
            {
                //await _service.DeleteFactura(Factura_Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
