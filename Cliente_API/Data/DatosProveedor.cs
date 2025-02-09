using Cliente_API.Models;

namespace Cliente_API.Data
{
    public class DatosProveedor
    {

        public static List<Proveedor> listaproovedores;
        public DatosProveedor()
        {
            listaproovedores = new List<Proveedor>();

            Proveedor proveedor1 = new Proveedor { Ced_juridica = "05-25135468", Descripcion_proveedor = " El señor aquel que vende tacos par allá donde las vacas"  };
            Proveedor proveedor2 = new Proveedor { Ced_juridica = "061-6489238", Descripcion_proveedor = " Don pedro el que no me quiere pagar lo fiado" };

            listaproovedores.Add(proveedor1);
            listaproovedores.Add(proveedor2);

        }

        public List<Proveedor> ProovedorList()
        {


            return listaproovedores;
        }

        public Proveedor SearchProveedor(string id)
        {

            foreach (Proveedor proveedor in listaproovedores)
            {
                if (proveedor.Ced_juridica == id)
                {
                    return proveedor;
                }
            }
            return null;
        }


        public bool AddProveedor(Proveedor producto)
        {
            bool agregado;
            try
            {
                listaproovedores.Add(producto);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;


        }

        public bool Deleteproovedor(string id)
        {


            foreach (Proveedor proovedor in listaproovedores)
            {
                if (proovedor.Ced_juridica == id)
                {


                    listaproovedores.Remove(proovedor);
                    return true;
                }
            }
            return true;
        }

        public void EditProveedor(string id, Proveedor proveedor)
        {


            foreach (Proveedor proveedor1 in listaproovedores)
            {
                if (proveedor1.Ced_juridica == id)
                {
                    listaproovedores.Remove(proveedor1);
                    listaproovedores.Add(proveedor);
                    return;
                }
            }
            return;
        }












    }
}
