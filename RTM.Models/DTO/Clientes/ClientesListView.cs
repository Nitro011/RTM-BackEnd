using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Clientes
{
    public class ClientesListView
    {
        public int ClienteID { get; set; }
        public string Nombre_Cliente { get; set; }
        public string Correo_Electronico { get; set; }
        public string No_Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
