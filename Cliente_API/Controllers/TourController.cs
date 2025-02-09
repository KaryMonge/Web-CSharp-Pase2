using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Tour")]
    [ApiController]
    public class TourController : ControllerBase
    {

        private static DatosTour datostour = new DatosTour();


        // GET: api/<TourController>
        [HttpGet]
        public List<Tour> List()
        {
            List<Tour> list = datostour.TourList();    
            return list;
        }


        // GET api/<TourController>/5
        [HttpGet("{id}")]
        public Tour Buscar(string id)
        {
            Tour tour = datostour.SearchTour(id);
            return tour;
        }



        // POST api/<TourController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Tour tour)
        {
            datostour.AddTour(tour);
            return Ok(tour);
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{Tour_Id}")]
        public IActionResult Edit(string Tour_Id, [FromBody] Tour tour)
        {
            datostour.EditTour(Tour_Id, tour);
            return Ok(tour);
        }



        // DELETE api/<ClienteController>/5
        [HttpDelete("{Tour_Id}")]
        public void Delete(string Tour_Id)
        {
            bool retorno = datostour.DeleteTour(Tour_Id);

        }

    }
}
