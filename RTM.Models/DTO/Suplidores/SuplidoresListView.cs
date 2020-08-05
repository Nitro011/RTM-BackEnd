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
        public int SuplidorID { get; set; }
        public string Empresa { get; set; }
        public string Nombre_Suplidor { get; set; }
        public string No_Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
    }
}
