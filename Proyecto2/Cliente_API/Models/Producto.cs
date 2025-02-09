using System.ComponentModel.DataAnnotations;

namespace Cliente_API.Models
{
    public class Producto
    {
        [Key]
        public string Producto_Id { get; set; }


   

        public string Producto_Descripcion { get; set; }

        public string Ced_juridica { get; set; }

        public int Anio_ingreso { get; set; }



        public float Precio { get; set; }



        public int Utilidad { get; set; }





    }
}
