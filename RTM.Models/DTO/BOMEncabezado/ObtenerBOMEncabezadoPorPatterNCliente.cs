using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.BOMEncabezado
{
    public class ObtenerBOMEncabezadoPorPatterNCliente
    {
        public int BOMID { get; set; }
        public string PatterN { get; set; }
        public string Cliente { get; set; }
    }
}
