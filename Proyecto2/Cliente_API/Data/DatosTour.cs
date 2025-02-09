using Cliente_API.Models;

namespace Cliente_API.Data
{
    public class DatosTour
    {


        public static List<Tour> listatour;
        public DatosTour()
        {
            listatour = new List<Tour>();

            Tour tour1 = new Tour { Tour_Id ="12345678", Tour_Descripcion= "paseo al restaurante san japonés", Dias_disponibles =" lunes a vienes", Tour_Imagen ="", Precio =50000};
            Tour tour2 = new Tour { Tour_Id = "9876543", Tour_Descripcion = "paseo en lancha ", Dias_disponibles = " lunes a vienes", Tour_Imagen = "", Precio = 10000 };

            listatour.Add(tour1);
            listatour.Add(tour2);

        }

        public List<Tour> TourList()
        {


            return listatour;
        }




        public Tour SearchTour(string id)
        {

            foreach (Tour tour in listatour)
            {
                if (tour.Tour_Id == id)
                {
                    return tour;
                }
            }
            return null;
        }



        public bool AddTour(Tour tour)
        {
            bool agregado;
            try
            {
                listatour.Add(tour);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;

        }

        public bool DeleteTour(string Tour_Id)
        {


            foreach (Tour tour in listatour)
            {
                if (tour.Tour_Id == Tour_Id)
                {


                    listatour.Remove(tour);
                    return true;
                }
            }
            return true;
        }
        public void EditTour(string Tour_Id, Tour tour)
        {


            foreach (Tour tour1 in listatour)
            {
                if (tour1.Tour_Id == Tour_Id)
                {
                    listatour.Remove(tour1);
                    listatour.Add(tour);
                    return;
                }
            }
            return;
        }


    }
}
