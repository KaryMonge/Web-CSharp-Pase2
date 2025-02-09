using Cliente_API.Data;
using Cliente_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cliente_API.Controllers
{
    [Route("Servicio/Tour")]
    [ApiController]
    public class TourController : ControllerBase
    {

        private static DatosTour datostour = new DatosTour();
        private readonly Proyecto3_DbContext context;  // nueva linea

        public TourController(Proyecto3_DbContext context)  //nueva linea
        {
            this.context = context;
        }


        // GET: api/<TourController>
        [HttpGet]
        public List<Tour> List()
        {
            List<Tour> list = context.Tours.ToList();   
            return list;
        }


        // GET api/<TourController>/5
        [HttpGet("{id}")]
        public Tour Buscar(string id)
        {
            Tour tour = context.Tours.Find(id);
            return tour;
        }

        // POST api/<TourController>
        [HttpPost]
        public IActionResult Agregar([FromBody] Tour tour)
        {
            context.Tours.Add(tour);
            context.SaveChanges();
            return Ok(tour);
        }


        // PUT api/<ClienteController>/5
        [HttpPut("{Tour_Id}")]
        public IActionResult Edit(string Tour_Id, [FromBody] Tour tour)
        {
            if (Tour_Id != tour.Tour_Id)
            {
                return BadRequest();
            }

            context.Entry(tour).State = EntityState.Modified;

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




        // DELETE api/<ClienteController>/5
        [HttpDelete("{Tour_Id}")]
        public void Delete(string Tour_Id)
        {

            if (context.Tours == null)
            {
                return;
            }

            Tour tour = context.Tours.Find(Tour_Id);

            if (tour == null)
            {

                return;
            }
            context.Tours.Remove(tour);
            context.SaveChanges(true);


        }










    }
}
