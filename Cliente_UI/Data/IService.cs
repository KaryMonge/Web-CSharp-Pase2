using Cliente_UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cliente_UI.Data
{
    public interface IService
    {

        public Task<List<Cliente>> ClientList();

        public Task<Cliente> SearchClient(string cedula);

        public Task<bool> AddClient(Cliente cliente);

        public Task<bool> DeleteClient(string cedula);

        public Task<bool> EditClient(string cedula, Cliente cliente);









        public Task<List<Producto>> productList();

        public Task<Producto> Searchproduct(string id);
        public Task<bool> Addproduct(Producto producto);

        public Task<bool> DeleteProduct(string id);

        public Task<bool> EditProducto(string id, Producto producto);





        public Task<List<Proveedor>> ProveeList();

        public Task<Proveedor> Searchprovee(string cedula);

        public Task<bool> Addproveedor(Proveedor proveedor);

        public Task<bool> Deleteproveedor(string id);

        public Task<bool> EditProveedor(string id, Proveedor proveedor);





        public Task<List<Tour>> tourList();

        public Task<Tour> Searchtour(string id);

        public Task<bool> Addtour(Tour tour);

        public Task<bool> Deletetour(string Tour_Id);

        public Task<bool> EditTour(string Tour_Id, Tour tour);





        public Task<List<Factura>> FacturaList();


        public Task<Factura> SearchFactura(string Factura_Id);

        public Task<bool> Addfactura(Factura factura);

        public Task<bool> DeleteFactura(string Factura_ID);

        public Task<bool> EditFactura(string Factura_Id, Factura factura);



    }

}
