using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
   public class OrdenesClientesDetalles
    {
        public int Orden_Cliente_DetalleID { get; set; }
        public int? Orden_ClienteID { get; set; }
        public int? MarcaID { get; set; }
        public string Marcar { get; set; }

        public  List<DetallesColores> Ordenes_Clientes_Detalles_Colores { get; set; }
        public  List<DetallesDimension> Ordenes_Clientes_Detalles_Dimensiones { get; set; }
        public  List<DetallesModelos> Ordenes_Clientes_Detalles_Modelos { get; set; }
        public  List<DetallesCalzado> Ordenes_Clientes_Detalles_Tipos_Calzados { get; set; }
    }
}
