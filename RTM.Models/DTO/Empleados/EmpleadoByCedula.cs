using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Empleados
{
    public class EmpleadoByCedula
    {
        public int? EmpleadoID { get; set; }
        public string cedula { get; set; }
        public string nombreCompleto { get; set; }
    }
}
