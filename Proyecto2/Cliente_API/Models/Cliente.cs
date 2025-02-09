using System.ComponentModel.DataAnnotations;

namespace Cliente_API.Models
{
    public class Cliente
    {


        [Key]
        public string Cedula { get; set; }


        public string Nombre { get; set; }



        public int Anio_Nacimiento { get; set; }


        public string Telefono { get; set; }



        public string Profesion { get; set; }




        public string email { get; set; }

        public string Lista_recomendado { get; set; }

        public string Password { get; set; }


        public string Rol { get; set; }





    }

}
