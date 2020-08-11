using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class BOM
    {
        [Key]
        public int BOMID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PatterN { get; set; }

        [ForeignKey("Constructions")]
        public int ConstructionID { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteID { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Constructions Constructions { get; set; }
    }
}
