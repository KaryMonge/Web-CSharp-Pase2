using System.ComponentModel.DataAnnotations;


namespace Cliente_API.Models
{
    public class Factura
    {
        [Key]
        public string Factura_ID { get; set; }


        public string Lista_tours { get; set; }


        public string Lista_productos { get; set; } //Lista_productosProducto_ID

        public float Precio_tour_sin_iva { get; set; }

        public float Precio_Producto_sin_iva { get; set; }
        public float Precio_tour_con_iva { get; set; }

        public float Precio_Producto_con_iva { get; set; }

        public float Total_sin_IVA { get; set; }

        public float Total_con_IVA { get; set; }
    }






}
