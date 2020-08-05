using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Departamentos
{
    public class DepartamentosListView
    {
        public int DepartamentoID { get; set; }
        public int? TipoDepartamentoID { get; set; }
        public string TipoDepartamento { get; set; }
        public string Departamento { get; set; }
        public string SubDepartamento { get; set; }

    }
}
