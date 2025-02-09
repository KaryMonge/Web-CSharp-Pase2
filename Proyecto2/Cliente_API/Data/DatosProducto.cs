using Cliente_API.Models;

namespace Cliente_API.Data
{
    public class DatosProducto
    {


        public static List<Producto> listaproductos;

        public DatosProducto()
        {
            listaproductos = new List<Producto>();

            Producto productos1 = new Producto { Producto_Id = "1111111", Producto_Descripcion = "Galletas de Chocolate", Anio_ingreso = 2022 , Precio= 2500 , Utilidad= 80 };
            Producto productos2 = new Producto { Producto_Id = "2222222", Producto_Descripcion = "AVENA en polvo", Anio_ingreso = 2022, Precio = 2200, Utilidad = 70 };

            listaproductos.Add(productos1);
            listaproductos.Add(productos2);

        }   

        public List<Producto> ProductList()
        {


            return listaproductos;
        }

        public Producto SearchProduct(string id)
        {

            foreach (Producto producto in listaproductos) 
            {
                if (producto.Producto_Id == id) 
                {
                    return producto;
                }
            }
            return null;
        }


        public bool AddProducto(Producto producto)
        {
            bool agregado;
            try
            {
                listaproductos.Add(producto);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;

        }

        public bool DeleteProducto(string id)
        {


            foreach (Producto producto in listaproductos)
            {
                if (producto.Producto_Id== id)
                {


                    listaproductos.Remove(producto);
                    return true;
                }
            }
            return true;
        }
        
        public void EditProducto(string id, Producto producto)
        {


            foreach (Producto producto1 in listaproductos)
            {
                if (producto1.Producto_Id == id)
                {
                    listaproductos.Remove(producto1);
                    listaproductos.Add(producto);
                    return;
                }
            }
            return;
        }






    }










}
