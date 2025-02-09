using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClienteAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnioNacimiento = table.Column<int>(name: "Anio_Nacimiento", type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Listarecomendado = table.Column<string>(name: "Lista_recomendado", type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    FacturaID = table.Column<string>(name: "Factura_ID", type: "nvarchar(450)", nullable: false),
                    Listatours = table.Column<string>(name: "Lista_tours", type: "nvarchar(max)", nullable: false),
                    Listaproductos = table.Column<string>(name: "Lista_productos", type: "nvarchar(max)", nullable: false),
                    Preciotoursiniva = table.Column<float>(name: "Precio_tour_sin_iva", type: "real", nullable: false),
                    PrecioProductosiniva = table.Column<float>(name: "Precio_Producto_sin_iva", type: "real", nullable: false),
                    Preciotourconiva = table.Column<float>(name: "Precio_tour_con_iva", type: "real", nullable: false),
                    PrecioProductoconiva = table.Column<float>(name: "Precio_Producto_con_iva", type: "real", nullable: false),
                    TotalsinIVA = table.Column<float>(name: "Total_sin_IVA", type: "real", nullable: false),
                    TotalconIVA = table.Column<float>(name: "Total_con_IVA", type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.FacturaID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<string>(name: "Producto_Id", type: "nvarchar(450)", nullable: false),
                    ProductoDescripcion = table.Column<string>(name: "Producto_Descripcion", type: "nvarchar(max)", nullable: false),
                    Cedjuridica = table.Column<string>(name: "Ced_juridica", type: "nvarchar(max)", nullable: false),
                    Anioingreso = table.Column<int>(name: "Anio_ingreso", type: "int", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false),
                    Utilidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Provedores",
                columns: table => new
                {
                    Cedjuridica = table.Column<string>(name: "Ced_juridica", type: "nvarchar(450)", nullable: false),
                    Descripcionproveedor = table.Column<string>(name: "Descripcion_proveedor", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provedores", x => x.Cedjuridica);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourId = table.Column<string>(name: "Tour_Id", type: "nvarchar(450)", nullable: false),
                    TourDescripcion = table.Column<string>(name: "Tour_Descripcion", type: "nvarchar(max)", nullable: false),
                    TourImagen = table.Column<string>(name: "Tour_Imagen", type: "nvarchar(max)", nullable: false),
                    Cedjuridica = table.Column<string>(name: "Ced_juridica", type: "nvarchar(max)", nullable: false),
                    Diasdisponibles = table.Column<string>(name: "Dias_disponibles", type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Provedores");

            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
