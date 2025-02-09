using Cliente_API.Models;

namespace Cliente_API.Data
{
    public class DatosFactura
    {
        public static List<Factura> listaFactura;


        public DatosFactura()
        {
            listaFactura = new List<Factura>();

            Factura factura1 = new Factura { Factura_ID="245689", Lista_productos = "Galletas de Chocolate", Lista_tours= "paseo al restaurante san japonés", Precio_Producto_sin_iva = 20000, Precio_Producto_con_iva = 30000, Precio_tour_sin_iva = 30000, Precio_tour_con_iva = 20000, Total_sin_IVA = 20000, Total_con_IVA = 100000};
            Factura factura2 = new Factura { Factura_ID = "145689", Lista_productos = "Avena en polvo", Lista_tours = "paseo al restaurante san japonés", Precio_Producto_sin_iva = 20000, Precio_Producto_con_iva = 30000, Precio_tour_sin_iva = 30000, Precio_tour_con_iva = 20000, Total_sin_IVA = 20000, Total_con_IVA = 100000 };

            listaFactura.Add(factura1);
            listaFactura.Add(factura2);

        }
        public List<Factura> FacturaList()
        {
            return listaFactura;
        }


        public Factura SearchFactura(string Factura_ID)
        {

            foreach (Factura factura in listaFactura)
            {
                if (factura.Factura_ID == Factura_ID)
                {
                    return factura;
                }
            }
            return null;
        }

        public bool AddFactura(Factura factura)
        {
            bool agregado;
            try
            {
                listaFactura.Add(factura);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;

        }

        public void EditFactura(string Factura_id, Factura factura)
        {

            foreach (Factura factura1 in listaFactura)
            {
                if (factura1.Factura_ID == Factura_id)
                {
                    listaFactura.Remove(factura1);
                    listaFactura.Add(factura);
                    return;
                }





            }
            return;
        }

        public bool DeleteFactura(string Factura_id)
        {


            foreach (Factura factura in listaFactura)
            {
                if (factura.Factura_ID == Factura_id)
                {


                    listaFactura.Remove(factura);
                    return true;
                }
            }
            return true;
        }
    }







}
