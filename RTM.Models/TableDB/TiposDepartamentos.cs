using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class TiposDepartamentos
    {
        [Key]
        public int TipoDepartamentoID { get; set; }
        public string TipoDepartamento { get; set; }
    }
}
