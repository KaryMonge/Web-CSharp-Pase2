using Cliente_UI.Models;
using Newtonsoft.Json;
using System.Text;

namespace Cliente_UI.Data
{
    public class Service_Cliente : IService
    {
        private string _baseurl;

        public Service_Cliente()
        {
            _baseurl = "http://localhost:5298";
        }


        public async Task<List<Cliente>> ClientList()
        {
            List<Cliente> lista = new List<Cliente>();

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseurl);

            var respuesta = await cliente.GetAsync("ServiceCliente/Cliente");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Cliente>>(json_respuesta);
                lista = resultado;
            }

            return lista;
        }






        public async Task<bool> AddClient(Cliente cliente)
        {

            bool resp = false;
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"ServiceCliente/Cliente", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }






        public async Task<Cliente> SearchClient(string cedula)
        {

            Cliente cliente_get = null;

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var respuesta = await client.GetAsync($"ServiceCliente/Cliente/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                cliente_get = resultado;
            }

            return cliente_get;
        }




        public async Task<bool> DeleteClient(string cedula)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            await client.DeleteAsync($"ServiceCliente/Cliente/{cedula}");

            /*
            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                
            }
            */
            return true;
        }

        public async Task<bool> EditClient(string cedula, Cliente cliente)
        {
            
            bool resp = false;
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"ServiceCliente/Cliente/{cedula}", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
            /*
            var client = new HttpClient();
            client.BaseAddress = new Uri(_baseurl);
            await client.DeleteAsync($"ServiceCliente/Cliente/{cedula}");

            bool resp = false;

            var content = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"ServiceCliente/Cliente", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;*/
            
        }



        //---------------------------------------------------------------------------------------------------------------------------
        public async Task<List<Producto>> productList()
        {
            List<Producto> lista = new List<Producto>();

            var producto = new HttpClient();
            producto.BaseAddress = new Uri(_baseurl);

            var respuesta = await producto.GetAsync("Servicio/Producto");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Producto>>(json_respuesta);
                lista = resultado;
            }

            return lista;
        }



        public async Task<Producto> Searchproduct(string id)
        {
            Producto product_get = null;

            var prod = new HttpClient();
            prod.BaseAddress = new Uri(_baseurl);

            var respuesta = await prod.GetAsync($"Servicio/Producto/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Producto>(json_respuesta);
                product_get = resultado;
            }

            return product_get;
        }
        
       

        public async Task<bool> Addproduct(Producto producto)
        {
            bool resp = false;
            var prod = new HttpClient();
            prod.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await prod.PostAsync($"Servicio/Producto", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }


        public async Task<bool> DeleteProduct(string id)
        {

            var prod = new HttpClient();
            prod.BaseAddress = new Uri(_baseurl);
            await prod.DeleteAsync($"Servicio/Producto/{id}");

            /*
            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                
            }
            */
            return true;
        }


        /*

                public Task<bool> Deleteproduct(Producto producto)
                {
                    throw new NotImplementedException();
                }

                */


        public async Task<bool> EditProducto(string id, Producto producto)
        {

            bool resp = false;
            var product = new HttpClient();
            product.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await product.PutAsync($"Servicio/Producto/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }

        //---------------------------------------------------------------------------------------------------------------------------------






        public async Task<List<Proveedor>> ProveeList()
        {
            List<Proveedor> list = new List<Proveedor>();

            var proveedor = new HttpClient();
            proveedor.BaseAddress = new Uri(_baseurl);

            var resp = await proveedor.GetAsync("Servicio/Proveedor");

            if (resp.IsSuccessStatusCode)
            {
                var json_respuesta = await resp.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Proveedor>>(json_respuesta);
                list = result;
            }

            return list;
        }







        public async Task<Proveedor> Searchprovee(string cedula)
        {



            Proveedor proveedor_get = null;

            var provee = new HttpClient();
            provee.BaseAddress = new Uri(_baseurl);

            var respuesta = await provee.GetAsync($"Servicio/Proveedor/{cedula}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Proveedor>(json_respuesta);
                proveedor_get = result;
            }

            return proveedor_get;
        }



        public async Task<bool> Addproveedor(Proveedor proveedor)
        {
            bool resp = false;
            var prove = new HttpClient();
            prove.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await prove.PostAsync($"Servicio/Proveedor", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }


        public async Task<bool> Deleteproveedor(string id)
        {
            var provee = new HttpClient();
            provee.BaseAddress = new Uri(_baseurl);
            await provee.DeleteAsync($"Servicio/Proveedor/{id}");

            return true;
            //throw new NotImplementedException();
        }


        public async Task<bool> EditProveedor(string id, Proveedor proveedor)
        {

            bool resp = false;
            var prov = new HttpClient();
            prov.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(proveedor), Encoding.UTF8, "application/json");
            var response = await prov.PutAsync($"Servicio/Proveedor/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }



        //----------------------------------------------------------------------------------------------------------------------------------------









        public async Task<List<Tour>> tourList()
        {
            List<Tour> list = new List<Tour>();

            var tour = new HttpClient();
                tour.BaseAddress = new Uri(_baseurl);

            var resp = await tour.GetAsync("Servicio/tour");

            if (resp.IsSuccessStatusCode)
            {
                var json_resp= await resp.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Tour>>(json_resp);
                list = result;
            }

            return list;
        }






        public async Task<Tour> Searchtour(string id)
        {
            Tour tour_get = null;

            var totu = new HttpClient();
            totu.BaseAddress = new Uri(_baseurl);

            var respuesta = await totu.GetAsync($"Servicio/Tour/{id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Tour>(json_respuesta);
                tour_get = resultado;
            }

            return tour_get;
        }




        public async Task<bool> Addtour(Tour tour)
        {
            bool resp = false;
            var totu = new HttpClient();
            totu.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(tour), Encoding.UTF8, "application/json");
            var response = await totu.PostAsync($"Servicio/tour", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }







        public async Task<bool> Deletetour(string Tour_Id)
        {
            
            var tour = new HttpClient();
            tour.BaseAddress = new Uri(_baseurl);
            await tour.DeleteAsync($"Servicio/Tour/{Tour_Id}");

            /*
            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Cliente>(json_respuesta);
                
            }
            */
            return true;
        }


        public async Task<bool> EditTour(string Tour_Id, Tour tour)
        {

            bool resp = false;
            var tou = new HttpClient();
            tou.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(tour), Encoding.UTF8, "application/json");
            var response = await tou.PutAsync($"Servicio/Tour/{Tour_Id}", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------




        public async Task<List<Factura>> FacturaList()
        {
            List<Factura> list = new List<Factura>();

            var factura = new HttpClient();
            factura.BaseAddress = new Uri(_baseurl);

            var respuesta = await factura.GetAsync("Servicio/Factura");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respu = await respuesta.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Factura>>(json_respu);
                list = result;
            }

            return list;
        }




        public async Task<Factura> SearchFactura(string Factura_Id)
        {
            Factura fac_get = null;

            var factura = new HttpClient();
            factura.BaseAddress = new Uri(_baseurl);

            var respuesta = await factura.GetAsync($"Servicio/Factura/{Factura_Id}");

            if (respuesta.IsSuccessStatusCode)
            {
                var json_respuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<Factura>(json_respuesta);
                fac_get = resultado;
            }

            return fac_get;
        }





        public async Task<bool> Addfactura(Factura factura)
        {
            bool resp = false;
            var fac = new HttpClient();
            fac.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            var response = await fac.PostAsync($"Servicio/Factura", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;
        }






        public async Task<bool> DeleteFactura(string Factura_ID)
        {
            var fac = new HttpClient();
            fac.BaseAddress = new Uri(_baseurl);
            await fac.DeleteAsync($"Servicio/Factura/{Factura_ID}");
            return true;

        }


        public async Task<bool> EditFactura(string Factura_Id, Factura factura)
        {

            bool resp = false;
            var fac = new HttpClient();
            fac.BaseAddress = new Uri(_baseurl);

            var content = new StringContent(JsonConvert.SerializeObject(factura), Encoding.UTF8, "application/json");
            var response = await fac.PutAsync($"Servicio/Factura/{Factura_Id}", content);

            if (response.IsSuccessStatusCode)
            {
                resp = true;
            }
            return resp;

        }



    }
}
