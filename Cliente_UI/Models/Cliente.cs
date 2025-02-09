using System.ComponentModel.DataAnnotations;

namespace Cliente_UI.Models
{
    public class Cliente
    {
        [Required(ErrorMessage = "Digite el dato requerido")]
        [RegularExpression("^(0\\d{1}-\\d{4}-\\d{4})$", ErrorMessage = "Formato requerido 0#-####-####")]
        public string Cedula { get; set; }


        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Digite su nombre y apellidos")]
        public string Nombre { get; set; }



        [RegularExpression("^\\d{4}$", ErrorMessage = "Ingrese solo su año de nacimiento")]
        [Range(minimum: 1900, maximum: 2003, ErrorMessage = "Debe ser mayor de edad y estar vivo")]
        public int Anio_Nacimiento { get; set; }




        [Required(ErrorMessage = "Digite el dato requerido")]
        [RegularExpression("^(\\d{4}-\\d{4})$", ErrorMessage = "Formato requerido ####-####")]
        public string Telefono { get; set; }




        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Digite su profesión")]
        public string Profesion { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        //[RegularExpression("^[^@]+@[^@]+.[a-zA-z][2,4]$", ErrorMessage = "Ingrese un correo válido")]
        [RegularExpression("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", ErrorMessage = "Ingrese un correo válido")]
        public string email { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        public string Lista_recomendado { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Digite su contrase")]
        public string Password { get; set; }


        public string Rol { get; set; }





    }
}
