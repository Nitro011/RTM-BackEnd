using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class AnchosSizes
    {
        [Key]
        public int AnchoSizeID { get; set; }
        public string AnchoSize { get; set; }
    }
}
