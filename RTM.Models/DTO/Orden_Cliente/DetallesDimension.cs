using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
   public class DetallesDimension
    {
        public int Orden_Cliente_Detalle_DimensionID { get; set; }

        public int? Orden_Cliente_DetalleID { get; set; }

        public int? DimensionID { get; set; }

        public int? Longitud { get; set; }
        public int? Anchura { get; set; }
        public int? Altura { get; set; }

    }
}
