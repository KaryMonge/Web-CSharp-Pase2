using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Cliente_UI.Controllers
{

   
    public class ClienteController : Controller
    {

        

        private static List<Models.Cliente> listaclientes = new List<Models.Cliente>();


        private readonly IService _servic_client;

        public ClienteController(IService servicioCliente)
        {
            _servic_client = servicioCliente;
        }




        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            List<Cliente> clientes = await _servic_client.ClientList();

            return View(clientes);
        }


        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(string cedula)
        {
            Cliente cliente = await _servic_client.SearchClient(cedula);

            return View(cliente);
        }





        public List<Cliente> Recom()
        {
            List<Cliente> recom = new List<Cliente>();


            recom.Add(new Cliente() { Lista_recomendado = "Recomendado por un amigo(a)" });
            recom.Add(new Cliente() { Lista_recomendado = "Por redes sociales" });
            recom.Add(new Cliente() { Lista_recomendado = "Ya la conocía" });

            return recom;

        }





        // GET: ClienteController/Create
        public ActionResult Create()
        {

            Cliente combo = new Cliente();

            ViewBag.Lista_recomen = Recom();



            return View();
        }






        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            try
            {
                await _servic_client.AddClient(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }





        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(string cedula)
        {

            Cliente cliente = await _servic_client.SearchClient(cedula);
            ViewBag.Lista_recomen = Recom();

            return View(cliente);

        }




        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string cedula, IFormCollection collection)
        {

            Cliente cliente_modificado = new Cliente();

            cliente_modificado.Cedula = collection["Cedula"];
            cliente_modificado.Nombre = collection["Nombre"];
            cliente_modificado.Anio_Nacimiento = Convert.ToInt32(collection["Anio_Nacimiento"]);
            cliente_modificado.Telefono = collection["Telefono"];
            cliente_modificado.Profesion = collection["Profesion"];
            cliente_modificado.email = collection["email"];
            cliente_modificado.Lista_recomendado = collection["Lista_recomendado"];
            cliente_modificado.Password = collection["Password"];
            cliente_modificado.Rol = collection["Rol"];

            try
            {
                await _servic_client.EditClient(cedula, cliente_modificado);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }





        // GET: FacturaController/Delete/5
        public async Task<ActionResult> Delete(string Cedula)
        {

           //Cliente cliente = await _servic_client.SearchClient(cedula);
           //return View(cliente);


            await _servic_client.DeleteClient(Cedula);

            return RedirectToAction(nameof(Index));
            



        }



        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string cedula, Cliente cliente)   
        {
            try
            {
                //await _servic_client.DeleteClient(cedula);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }






        private List<Models.Cliente> GetClientes()
        {
                return listaclientes;
        }

        private Models.Cliente SearchclientID(string cedula)
        {

            List<Models.Cliente> List;
            List = GetClientes();

            foreach (Models.Cliente cliente in List)
            {
                if (cliente.Cedula == cedula)
                    return cliente;
            }

            return null;

        }


        

        /*
        private void AddClient(Cliente cliente)
        {

            List<Models.Cliente> List;
            List = GetClientes();
            List.Add(cliente);

        }*/


        private void RemoveClient(Cliente cliente)
        {

            List<Models.Cliente> List;
            List = GetClientes();
            List.Remove(cliente);

        }

    }
}
