using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos_PesosEstilos
    {
        [Key]
        public int Estilo_PesoEstiloID { get; set; }

        [ForeignKey("Estilos")]
        public int? EstiloID { get; set; }

        [ForeignKey("PesosEstilos")]
        public int? PesoEstiloID { get; set; }

        public virtual Estilos Estilos { get; set; }
        public virtual PesosEstilos PesosEstilos { get; set; }
    }
}
