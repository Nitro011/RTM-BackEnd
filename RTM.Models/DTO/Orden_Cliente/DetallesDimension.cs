using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Orden_Cliente
{
    /// <summary>
    /// Esta clase esta referenciada a Size
    /// </summary>
    
   public class DetallesDimension
    {
        
        public int Orden_Cliente_Detalle_DimensionID { get; set; }

        public int? Orden_Cliente_DetalleID { get; set; }

        public int? SizeID { get; set; }
        public string USA { get; set; }
        public string UK { get; set; }
        public string EURO { get; set; }
        public string CM { get; set; }
        public string CategoriaSize { get; set; }


    }
}
