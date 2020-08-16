using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class DivisionesMateriasPrimas
    {
        [Key]
        public int DivisionMateriaPrimaID { get; set; }
        public string Division { get; set; }
    }
}
