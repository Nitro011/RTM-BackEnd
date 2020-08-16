using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class ITEMS
    {
        [Key]
        public int ITEMID { get; set; }
        public string nombreITEMS { get; set; }
    }
}
