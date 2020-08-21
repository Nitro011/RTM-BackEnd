using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class OrdenesClientes_Estilos
    {
        [Key]
        public int OrdenesCliente_EstiloID { get; set; }
        
        [ForeignKey("Ordenes_Clientes")]
        public int Orden_ClienteID { get; set; }

        [ForeignKey("Estilos")]
        public int EstiloID { get; set; }

        public virtual Ordenes_Clientes Ordenes_Clientes { get; set; }
        public virtual Estilos Estilos { get; set; }
    }
}
