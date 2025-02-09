using System.ComponentModel.DataAnnotations;

namespace Cliente_UI.Models
{
    public class Proveedor
    {


        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Digite su cédula jurídica")]
        public string Ced_juridica { get; set; }



        [Required(ErrorMessage = "Digite el dato requerido")]
        [StringLength(150, MinimumLength = 10, ErrorMessage = "Digite la descripción")]
        public string Descripcion_proveedor { get; set; }
        


        public static implicit operator Proveedor(Cliente v)
        {
            throw new NotImplementedException();
        }
    }
}
