using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.BOMEncabezado
{
    public class BOMEncabezadoListView
    {
        public int BOMID { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PatterN { get; set; }
        public string Modelo { get; set; }
        public string Cliente { get; set; }
    }
}
