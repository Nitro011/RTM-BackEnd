using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.SubDepartamentos
{
    public class SubDepartamentosListView
    {
        public int SubDepartamentoID { get; set; }
        public int? DepartamentoID { get; set; }
        public string Departamento { get; set; }
        public string SubDepartamento { get; set; }
    }
}
