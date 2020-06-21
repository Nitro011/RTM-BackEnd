using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
   public class DetallesModelos
    {
        public int Orden_Cliente_Detalle_ModeloID { get; set; }

        public int? Orden_Cliente_DetalleID { get; set; }
        public int? ModeloID { get; set; }

        public string Modelo { get; set; }
    }
}
