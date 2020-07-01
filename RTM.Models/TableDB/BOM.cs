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
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string PatternName { get; set; }
        public string Stock { get; set; }
        public int Pattn { get; set; }
        public string Construction { get; set; }

        [ForeignKey("Colore")]
        public int? ColorID { get; set; }
        public string Last { get; set; }

        [ForeignKey("Size")]
        public int? SizeID { get; set; }
        public string Customer { get; set; }
        public string PartNo { get; set; }
        public int DIE { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Usage { get; set; }
        public decimal Cost { get; set; }
        public virtual Colore Colore { get; set; }
        public virtual Size Size { get; set; }
    }
}
