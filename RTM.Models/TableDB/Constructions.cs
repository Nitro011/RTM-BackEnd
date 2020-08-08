using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Constructions
    {
        [Key]
        public int ConstructionID { get; set; }
        public string Construction { get; set; }
    }
}
