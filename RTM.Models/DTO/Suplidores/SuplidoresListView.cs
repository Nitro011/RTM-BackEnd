using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTM.Models.DTO.Suplidores;

namespace RTM.Models.DTO.Suplidores
{
    public  class SuplidoresListView
    {
        public int ID { get; set; }
        public string Empresa { get; set; }
        public string Nombre_Suplidor { get; set; }
        public string No_Telefono { get; set; }
    }
}
