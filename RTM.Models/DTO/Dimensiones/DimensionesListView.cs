using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Dimensiones
{
    public class DimensionesListView
    {
        public int DimensionID { get; set; }
        public int? Longitud { get; set; }
        public int? Anchura { get; set; }
        public int? Altura { get; set; }
    }
}
