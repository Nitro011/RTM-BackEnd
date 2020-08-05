using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class UnidadesMedidasEstilos
    {
        [Key]
        public int UnidadMedidaEstiloID { get; set; }
        public string UnidadMedidaEstilo { get; set; }
    }
}
