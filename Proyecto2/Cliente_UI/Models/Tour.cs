using System.ComponentModel.DataAnnotations;

namespace Cliente_UI.Models
{
    public class Tour
    {
        public string Tour_Id { get; set; }


        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Digite la descripción")]
        public string Tour_Descripcion { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Tour_Imagen { get; set; }


        public string Ced_juridica { get; set; }




        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Dias_disponibles { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [Range(0, 100000, ErrorMessage = "Precio 0 < y < 100,000")]
        public float Precio { get; set; }


    }
}
