using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos_Modelos
    {
        [Key]
        public int Estilo_ModeloID { get; set; }

        [ForeignKey("Estilos")]
        public int? EstiloID { get; set; }

        [ForeignKey("Modelo")]
        public int? ModeloID { get; set; }
        public virtual Estilos Estilos { get; set; }
        public virtual Modelo Modelo { get; set; }
    }
}
