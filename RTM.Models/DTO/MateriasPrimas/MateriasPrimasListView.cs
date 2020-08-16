using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.MateriasPrimas
{
    public class MateriasPrimasListView
    {
        public int Materia_PrimaID { get; set; }
        public int? Tipo_MaterialID { get; set; }
        public string PartNo { get; set; }
        public string Descripcion { get; set; }
        public decimal Cost { get; set; }
        public string Unit { get; set; }
        public string TipoMaterial { get; set; }
    }
}
