using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Divisiones
    {
        [Key]
        public int DivisionID { get; set; }
        public string Division { get; set; }
    }
}
