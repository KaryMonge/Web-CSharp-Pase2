using System.ComponentModel.DataAnnotations;

namespace Cliente_UI.Models
{
    public class Producto
    {
        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Producto_Id { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Digite una descripción válida")]
        public string Producto_Descripcion { get; set; }

        public string Ced_juridica { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [Range(minimum: 1900, maximum: 2022, ErrorMessage = "Ingrese un dato válido entre 1900 y 2022")]
        public int Anio_ingreso { get; set; }


        public float Precio { get; set; }


        [Required(ErrorMessage = "Digite el dato requerido")]
        [Range(0, 100, ErrorMessage = "Porcentaje de 0 a 100")]
        public int Utilidad { get; set; }



    }
}
