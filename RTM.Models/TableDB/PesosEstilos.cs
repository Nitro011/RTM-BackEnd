using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class PesosEstilos
    {
        [Key]
        public int PesoEstiloID { get; set; }
        public string PesoEstilo { get; set; }
    }
}
