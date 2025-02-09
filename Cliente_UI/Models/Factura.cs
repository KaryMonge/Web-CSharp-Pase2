namespace Cliente_UI.Models
{
    public class Factura
    {

        public string Factura_ID { get; set; }


        public string Lista_tours { get; set; }


        public string Lista_productos { get; set; }

        public float Precio_tour_sin_iva { get; set; }

        public float Precio_Producto_sin_iva { get; set; }
        public float Precio_tour_con_iva { get; set; }

        public float Precio_Producto_con_iva { get; set; }

        public float Total_sin_IVA { get; set; }

        public float Total_con_IVA { get; set; }



    }
}
