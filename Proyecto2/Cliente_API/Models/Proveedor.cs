using System.ComponentModel.DataAnnotations;

namespace Cliente_API.Models
{
    public class Proveedor
    {
        [Key]
        public string Ced_juridica { get; set; }


        public string Descripcion_proveedor { get; set; }





    }
}
