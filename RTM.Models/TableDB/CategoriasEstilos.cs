using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class CategoriasEstilos
    {
        [Key]
        public int CategoriaEstiloID { get; set; }
        public string CategoriaEstilo { get; set; }
    }
}
