using System.ComponentModel.DataAnnotations;

namespace Cliente_API.Models
{
    public class Tour
    {
        public string Tour_Id { get; set; }

        public string Tour_Descripcion { get; set; }


        public string Tour_Imagen { get; set; }

        public string Dias_disponibles { get; set; }

        public float Precio { get; set; }



    }




}
