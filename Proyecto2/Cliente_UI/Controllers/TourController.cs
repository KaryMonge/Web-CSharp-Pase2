using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Cliente_UI.Controllers
{
    public class TourController : Controller
    {

        private static List<Models.Tour> listatours= new List<Models.Tour>();
        


        private readonly IService _service;

        public TourController(IService servicetotu)
        {
            _service = servicetotu;
        }






        // GET: TourController
        public async Task<ActionResult> Index()
        {
            List<Tour> totu = await _service.tourList();

            return View(totu);
        }


        public string generar_id()
        {
            Random tour_id_random = new Random();
            string tour_id_s = Convert.ToString(tour_id_random.Next(1, 999999999));
            return tour_id_s;
        }






        public List<Tour> Day_list()
        {
            List<Tour> days = new List<Tour>();


            days.Add(new Tour() { Dias_disponibles = "Lunes a Viernes" });
            days.Add(new Tour() { Dias_disponibles = "Sábado y domingo" });
            days.Add(new Tour() { Dias_disponibles = "Solo Sábado" });
            days.Add(new Tour() { Dias_disponibles = "Solo Domingo" });


            return days;

        }


        //los metodos asincronicos se utilizan para enviar request y no quedar esperando
        //esta función llena una lista con todos los [proveedores que están en la base de datos
        public async Task<ActionResult<List<Proveedor>>> ListaProveedor_DD()
        {
            List<Proveedor> prove = await _service.ProveeList(); // aqui recibo lo que haya en lista de proveedores en un task

            return prove;
        }


        //recorre la lista y los va a gregando al view 
        public List<Tour> Lista_Proveedores()
        {
            List<Tour> proveedores_tour = new List<Tour>();

            List<Proveedor> todoproveedor = ListaProveedor_DD().Result.Value;// aqui se obtiene lo que se recibe en un task

            foreach (Models.Proveedor proveedor in todoproveedor)// aqui recorro todo Proveedor
            {
                proveedores_tour.Add(new Tour() { Ced_juridica = proveedor.Ced_juridica });

            }
            return proveedores_tour;
        }



        public string AsignarPrimerProveedor()
        {
            //se recorre la lista de proveedors y se retorna el provedoor en la posición cero.
            List<Proveedor> todoproveedor = ListaProveedor_DD().Result.Value;
            return todoproveedor[0].Ced_juridica;

        }



        // GET: TourController/Create
        public async Task<ActionResult> Create()
        {

            Tour tour = new Tour();

            tour.Tour_Id = generar_id();

            ViewBag.Week_list = Day_list();
         

            //Llenado del listado de proveedores
            ViewBag.Ced_juridica = Lista_Proveedores();

            //Se obtiene el primer Proveedor y se asigna como el proveedor del tour
            tour.Ced_juridica = AsignarPrimerProveedor();


            return View(tour);
        }





        // POST: TourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tour tour)
        {
            try
            {
                await _service.Addtour(tour);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }






        // GET: TourController/Details/5
        public async Task<ActionResult> Details(string Tour_Id)
        {
            Tour tour = await _service.Searchtour(Tour_Id);

            return View(tour);
        }




        // GET: TourController/Edit/5
        public async Task<ActionResult> Edit(string Tour_Id)
        {
            Tour tour = await _service.Searchtour(Tour_Id);

            // Llenado del listado de proveedores
            ViewBag.Ced_juridica = Lista_Proveedores();
            ViewBag.Week_list = Day_list();

            return View(tour);

        }


        // POST: TourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Tour_Id, IFormCollection collection)
        {
            Tour tour_modificado = new Tour();


            tour_modificado.Tour_Id = collection["Tour_Id"];
            tour_modificado.Tour_Descripcion = collection["Tour_Descripcion"];
            tour_modificado.Tour_Imagen = collection["Tour_Imagen"];
            tour_modificado.Ced_juridica = collection["Ced_juridica"];
            tour_modificado.Dias_disponibles = collection["Dias_disponibles"];
            tour_modificado.Precio = Convert.ToSingle(collection["Precio"], CultureInfo.CreateSpecificCulture("en-US"));

            try
            {
                await _service.EditTour(Tour_Id, tour_modificado);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }

        }



        // GET: TourController/Delete/5
        public async Task<ActionResult> Delete(string Tour_Id)
        {
            //Tour tour = await _service.Searchtour(Tour_Id);
            //return View(tour);


            await _service.Deletetour(Tour_Id);

            return RedirectToAction(nameof(Index));


        }


        // POST: TourController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string Tour_Id, IFormCollection collection)
        {
            try
            {
                //await _service.Deletetour(Tour_Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }





    }
}
