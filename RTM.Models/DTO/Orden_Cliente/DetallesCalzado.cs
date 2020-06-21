using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
    public class DetallesCalzado
    {
        public int Orden_Cliente_Detalle_Tipo_CalzadoID { get; set; }

        public int? Orden_Cliente_DetalleID { get; set; }

        public int? Tipo_CalzadoID { get; set; }

        public string Calzado { get; set; }
    }
}
