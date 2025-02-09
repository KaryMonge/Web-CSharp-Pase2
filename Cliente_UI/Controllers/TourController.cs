using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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


        // GET: TourController/Create
        public async Task<ActionResult> Create()
        {

            Tour tour = new Tour();

            ViewBag.Week_list = Day_list();
            tour.Tour_Id = generar_id();


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
            tour_modificado.Dias_disponibles = collection["Dias_disponibles"];
            tour_modificado.Precio = Convert.ToSingle(collection["Precio"]);

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





        private List<Models.Tour> GetTourList()
        {
            return listatours;
        }

        private Models.Tour SearcTourId(string id)
        {

            List<Models.Tour> List;
            List = GetTourList();

            foreach (Models.Tour totu in List)
            {
                if (totu.Tour_Id == id)
                    return totu;
            }

            return null;

        }

        private void AddTour(Tour tour)
        {

            List<Models.Tour> laLista;
            laLista = GetTourList();
            laLista.Add(tour);

        }







    }
}
