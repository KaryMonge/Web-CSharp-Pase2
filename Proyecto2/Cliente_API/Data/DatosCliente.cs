using Cliente_API.Models;

namespace Cliente_API.Data
{
    public class DatosCliente
    {

        public static List<Cliente> listaClientes;

        public DatosCliente()
        {
            listaClientes = new List<Cliente>();

            Cliente cliente1 = new Cliente { Cedula = "01-1111-1111", Nombre = "Administrador", Password = "01-1111-1111" };
            Cliente cliente2 = new Cliente { Cedula = "02-2222-2222", Nombre = "Usuario", Password = "02-2222-2222" };

            listaClientes.Add(cliente1);
            listaClientes.Add(cliente2);

        }
        public List<Cliente> ClientList()
        {


            return listaClientes;
        }


        public Cliente SearchClient(string cedula)
        {

            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.Cedula == cedula)
                {
                    return cliente;
                }
            }
            return null;
        }

        public bool AddClient(Cliente cliente)
        {
            bool agregado;
            try
            {
                listaClientes.Add(cliente);
                agregado = true;
            }
            catch (Exception)
            {
                agregado = false;
            }

            return agregado;

        }

        public void EditClient(string cedula, Cliente cliente)
        {


            foreach (Cliente cliente1 in listaClientes)
            {
                if (cliente1.Cedula == cedula)
                {
                    listaClientes.Remove(cliente1);
                    listaClientes.Add(cliente);
                    return;
                }
            }
            return;
        }

        public bool DeleteClient(string Cedula)
        {


            foreach (Cliente cliente in listaClientes)
            {
                if (cliente.Cedula == Cedula)
                {


                    listaClientes.Remove(cliente);
                    return true;
                }
            }
            return true;
        }
    }
}
