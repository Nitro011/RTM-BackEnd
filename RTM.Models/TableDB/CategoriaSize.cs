using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class CategoriaSize
    {
        [Key]
        public int CategoriaSizeID { get; set; }

        public string Clasificaciones { get; set; }

 }
}
