using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class BOMDetalles
    {
        [Key]
        public int BOMDetalleID { get; set; }
        public string PartNo { get; set; }
        public string DIE { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Usage { get; set; }
        public decimal Cost { get; set; }
        public decimal Ext { get; set; }
    }
}
