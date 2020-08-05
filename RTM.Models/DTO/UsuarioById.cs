using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO
{
    public class UsuarioById
    {
        public int? EmpleadoID { get; set; }
        public string NombresApellidos { get; set; }
        public string Sexo { get; set; }
        public string Cedula { get; set; }
        public System.DateTime? Fecha_Nacimiento { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Departamento { get; set; }
        public string SubDepartamento { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }

    }
}
