using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
   public class DetallesColores
    {
        public int Orden_Cliente_Detalle_ColorID { get; set; }
        public int? Orden_Cliente_DetalleID { get; set; }
        public int? ColorID { get; set; }
        public string Color { get; set; }
    }
}
