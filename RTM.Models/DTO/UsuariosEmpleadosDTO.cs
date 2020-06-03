using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO
{
    public class UsuariosEmpleadosDTO
    {

        public int RolID { get; set; }
        public bool LockoutEnabled { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? EmpleadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public bool Sexo { get; set; }
        public string Cedula { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }


    }
}
