using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
  public class OrdenCliente
    {
        public int Orden_ClienteID { get; set; }
        public int? ClienteID { get; set; }
        public string NombreCliente { get; set; }
        public string CodigoQR { get; set; }
        public int? Cantidad_Calzado_Realizar { get; set; }
        public System.DateTime Fecha_Inicio { get; set; }
        public System.DateTime Fecha_Entrega { get; set; }

        public virtual OrdenesClientesDetalles Ordenes_Clientes_Detalles { get; set; }

    }
}
