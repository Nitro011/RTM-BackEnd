using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class OperacionesCalzados
    {
        [Key]
        public int OperacionesCalzadosID { get; set; }
        public string PartNo { get; set; }
        public int CantidadOperaciones { get; set; }
        public string Descripcion { get; set; }
        public decimal CostoOperacional { get; set; }
    }
}
