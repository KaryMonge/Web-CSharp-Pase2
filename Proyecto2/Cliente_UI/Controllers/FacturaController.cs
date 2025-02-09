using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Cliente_UI.Controllers
{

    public class FacturaController : Controller
    {

        private readonly IService _service;


      // private static List<Models.Tour> listatours = new List<Models.Tour>();
       // private static List<Models.Producto> listaproductos = new List<Models.Producto>();


        public FacturaController(IService servicefac)
        {
            _service = servicefac;
        }

        //----------------------------------------------------------------------------------------

        // GET: FacturaController
        public async Task<ActionResult> Index()
        {
            List<Factura> facturas = await _service.FacturaList();

            return View(facturas);
        }

        //----------------------------------------------------------------------------------------

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(string Factura_Id)
        {
            Factura factura = await _service.SearchFactura(Factura_Id);

            return View(factura);
        }

        //------------------------------------------------------------------------------------------

        public string generar_id()
        {
            Random factura_id_random = new Random();
            string factura_id_s = Convert.ToString(factura_id_random.Next(1, 999999999));
            return factura_id_s;
        }


        public async Task<ActionResult<List<Tour>>> ListaTours_DD()
        {
            List<Tour> totu = await _service.tourList();

            return totu;
        }




        public List<Factura> Lista_Tours()
        {
            List<Factura> tours_factura = new List<Factura>();

            List<Tour> todotour = ListaTours_DD().Result.Value;

            foreach (Models.Tour tour in todotour)
            {
                tours_factura.Add(new Factura() { Lista_tours = tour.Tour_Id});

            }
            return tours_factura;
        }


        public string AsignarPrimerTour()
        {

            List<Tour> todotour = ListaTours_DD().Result.Value;
            return todotour[0].Tour_Id;

        }



        public async Task<ActionResult<Tour>> ListaTours_Precio(string Tour_Id)
        {
            Tour tour = await _service.Searchtour(Tour_Id);

            return tour;
        }



        public float ObtenerPrecioTour(string Tour_id)
        {
            Tour tour = ListaTours_Precio(Tour_id).Result.Value;
            
            return tour.Precio;
        }


        public async Task<ActionResult<List<Producto>>> ListaProductos_DD()
        {
            List<Producto> todoproducto = await _service.productList();

            return todoproducto;
        }


        public List<Factura> Lista_Productos()
        {
            List<Factura> tours_factura = new List<Factura>();

            List<Producto> todoproducto = ListaProductos_DD().Result.Value;

            foreach (Models.Producto producto in todoproducto)
            {
                tours_factura.Add(new Factura() { Lista_productos = producto.Producto_Id });
            }
            return tours_factura;
        }

        public string AsignarPrimerProducto()
        {

            List<Producto> todoproducto = ListaProductos_DD().Result.Value;
            return todoproducto[0].Producto_Id;

        }



        public async Task<ActionResult<Producto>> ListaProductos_Precio(string Producto_Id)
        {
            Producto producto = await _service.Searchproduct(Producto_Id);

            return producto;
        }



        public float ObtenerPrecioProducto(string Producto_id)
        {
            Producto producto = ListaProductos_Precio(Producto_id).Result.Value;

            return producto.Precio;
        }






        // GET: FacturaController/Create
        public async Task<ActionResult> Create()
        {
            Factura factura = new Factura();

            factura.Factura_ID = generar_id();

            //Llenado del listado de Tours
            ViewBag.Lista_Tours = Lista_Tours();

            //Llenado del listado de Productos
            ViewBag.Lista_Productos = Lista_Productos();
                       
            //Se obtiene el primer tour y se asigna como el tour de la factura
            factura.Lista_tours = AsignarPrimerTour();

            //Se obtiene el precio del primer tour
            factura.Precio_tour_sin_iva = ObtenerPrecioTour(factura.Lista_tours);
            factura.Precio_tour_con_iva = (float)(factura.Precio_tour_sin_iva * 1.13);

            //Se obtiene el primer producto y se asigna como el producto de la factura
            factura.Lista_productos = AsignarPrimerProducto();

            //Se obtiene el precio del primer producto
            factura.Precio_Producto_sin_iva = ObtenerPrecioProducto(factura.Lista_productos);
            factura.Precio_Producto_con_iva = (float)(factura.Precio_Producto_sin_iva * 1.13);

            //cálculo de totales
            factura.Total_sin_IVA = factura.Precio_tour_sin_iva + factura.Precio_Producto_sin_iva;
            factura.Total_con_IVA = factura.Precio_tour_con_iva + factura.Precio_Producto_con_iva;

            return View(factura);

        }



        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Factura factura)
        {

            //Se obtiene el precio del tour que esté seleccionado al cerrar la factura
            factura.Precio_tour_sin_iva = ObtenerPrecioTour(factura.Lista_tours);
            factura.Precio_tour_con_iva = (float)(factura.Precio_tour_sin_iva * 1.13);


            //Se obtiene el precio del  producto que esté seleccionado al cerrar la factura
            factura.Precio_Producto_sin_iva = ObtenerPrecioProducto(factura.Lista_productos);
            factura.Precio_Producto_con_iva = (float)(factura.Precio_Producto_sin_iva * 1.13);

            //cálculo de totales
            factura.Total_sin_IVA = factura.Precio_tour_sin_iva + factura.Precio_Producto_sin_iva;
            factura.Total_con_IVA = factura.Precio_tour_con_iva + factura.Precio_Producto_con_iva;


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


            ViewBag.Lista_Productos = Lista_Productos();
            ViewBag.Lista_Tours = Lista_Tours();

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

            //Se obtiene el precio del tour que esté seleccionado al cerrar la factura
            factura_modificada.Precio_tour_sin_iva = ObtenerPrecioTour(factura_modificada.Lista_tours);
            factura_modificada.Precio_tour_con_iva = (float)(factura_modificada.Precio_tour_sin_iva * 1.13);

            //Se obtiene el precio del  producto que esté seleccionado al cerrar la factura
            factura_modificada.Precio_Producto_sin_iva = ObtenerPrecioProducto(factura_modificada.Lista_productos);
            factura_modificada.Precio_Producto_con_iva = (float)(factura_modificada.Precio_Producto_sin_iva * 1.13);

            //cálculo de totales
            factura_modificada.Total_sin_IVA = factura_modificada.Precio_tour_sin_iva + factura_modificada.Precio_Producto_sin_iva;
            factura_modificada.Total_con_IVA = factura_modificada.Precio_tour_con_iva + factura_modificada.Precio_Producto_con_iva;

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
