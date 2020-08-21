using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class OrdenesClientes_Sizes
    {
        [Key]
        public int OrdenesCliente_SizeID { get; set; }

        [ForeignKey("Ordenes_Clientes")]
        public int Orden_ClienteID { get; set; }

        [ForeignKey("Sizes")]
        public int SizeID { get; set; }

        public virtual Ordenes_Clientes Ordenes_Clientes { get; set; }
        public virtual Size Sizes { get; set; }
    }
}
