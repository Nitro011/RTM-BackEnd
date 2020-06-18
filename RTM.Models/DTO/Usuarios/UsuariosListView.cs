using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Usuarios
{
    public class UsuariosListView
    {
        public int? UsuarioID { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Rol { get; set; }
    }
}
