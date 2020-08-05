using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class SubDepartamentos
    {
        [Key]
        public int SubDepartamentoID { get; set; }

        [ForeignKey("Departamentos")]
        public int? DepartamentoID { get; set; }
        public string SubDepartamento { get; set; }

        public virtual Departamentos Departamentos { get; set; }
    }
}
