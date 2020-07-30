using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.OperacionesCalzados
{
    public class OperacionesCalzadosListView
    {
        public int OperacionesCalzadosID { get; set; }
        public string PartNo { get; set; }
        public int CantidadOperaciones { get; set; }
        public string Descripcion { get; set; }
        public decimal CostoOperacional { get; set; }
    }
}
