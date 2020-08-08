using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class BOM_BOMDetalles
    {
        [Key]
        public int BOM_BOMDetalleID { get; set; }

        [ForeignKey("BOM")]
        public int BOMID { get; set; }

        [ForeignKey("BOMDetalles")]
        public int BOMDetalleID { get; set; }

        public virtual BOM BOM { get; set; }
        public virtual BOMDetalles BOMDetalles { get; set; }
    }
}
