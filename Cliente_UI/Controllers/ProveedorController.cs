using Cliente_UI.Data;
using Cliente_UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cliente_UI.Controllers
{
    public class ProveedorController : Controller
    {



        private static List<Models.Proveedor> listaproovdores = new List<Models.Proveedor>();

        private readonly IService _service;

        public ProveedorController(IService serviceprovee)
        {
            _service = serviceprovee;
        }






        // GET: ProveedorController
        public async Task<ActionResult> Index()
        {
            List<Proveedor> proovedor = await _service.ProveeList();

            return View(proovedor);
        }



        // GET: ProveedorController/Details/5
        public async Task<ActionResult> Details(string Ced_juridica)
        {
            Proveedor proveedor = await _service.Searchprovee(Ced_juridica);

            return View(proveedor);
        }






        // GET: ProveedorController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }




        // POST: ProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>  Create(Proveedor provedor)
        {
            try
            {
                await _service.Addproveedor(provedor);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        
        }



        // GET: ProveedorController/Edit/5
        public async Task<ActionResult> Edit(string Ced_juridica)
        {
            Proveedor proveedor = await _service.Searchprovee(Ced_juridica);
            return View(proveedor);
        }



        // POST: ProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string Ced_juridica, IFormCollection collection)
        {

            Proveedor proveedor_modificado = new Proveedor();

            proveedor_modificado.Ced_juridica = collection["Ced_juridica"];
            proveedor_modificado.Descripcion_proveedor = collection["Descripcion_proveedor"];

            try
            {
                await _service.EditProveedor(Ced_juridica, proveedor_modificado);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }




        // GET: ProveedorController/Delete/5
        public async Task<ActionResult> Delete(string Ced_juridica)
        {

            //Proveedor provee = await _service.SearchClient(Ced_juridica);
            //return View(provee);


            await _service.Deleteproveedor(Ced_juridica);

            return RedirectToAction(nameof(Index));


           //return View();


        }

        // POST: ProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string Ced_juridica, IFormCollection collection)
        {
            try
            {
                //wait _service.Deleteproveedor(Ced_juridica);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }




        private List<Models.Proveedor> GetProovList()
        {
            return listaproovdores;
        }

        private Models.Proveedor SearchProov_Id(string Ced_juridica)
        {

            List<Models.Proveedor> List;
            List = GetProovList();

            foreach (Models.Proveedor prov in List)
            {
                if (prov.Ced_juridica == Ced_juridica)
                    return prov;
            }

            return null;

        }

        private void Addproveedor(Proveedor proveedor)
        {

            List<Models.Proveedor> List;
            List = GetProovList();
            List.Add(proveedor);

        }





    }
}
