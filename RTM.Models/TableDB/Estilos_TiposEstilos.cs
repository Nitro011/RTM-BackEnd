using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos_TiposEstilos
    {
        [Key]
        public int Estilo_TiposEstiloID { get; set; }

        [ForeignKey("Estilos")]
        public int? EstiloID { get; set; }

        [ForeignKey("Tipo_Calzados")]
        public int? Tipo_CalzadoID { get; set; }
        public virtual Estilos Estilos { get; set; }
        public virtual Tipo_Calzados Tipo_Calzados { get; set; }
    }
}
