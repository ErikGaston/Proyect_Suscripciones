using System;

namespace Clases_Negocio
{
    public class Suscriptor
    {
        public int IdSuscriptor { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public Int64 NumeroDocumento { get; set; }
        public String TipoDocumento { get; set; }
        public String Direccion { get; set; }
        public Int64 Telefono { get; set; }
        public String Email { get; set; }
        public String NombreUsuario { get; set; }
        public String Password { get; set; }
    }
}
