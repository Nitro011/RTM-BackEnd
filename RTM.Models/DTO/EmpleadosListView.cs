using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO
{
   public class EmpleadosListView
    {

        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Puesto { get; set; }
        public string Posicion { get; set; }
        public string FechaIngreso { get; set; }

    }
}
