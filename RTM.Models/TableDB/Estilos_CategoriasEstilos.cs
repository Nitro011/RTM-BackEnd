using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos_CategoriasEstilos
    {
        [Key]
        public int Estilo_CategoriaID { get; set; }

        [ForeignKey("Estilos")]
        public int? EstiloID { get; set; }

        [ForeignKey("CategoriasEstilos")]
        public int? CategoriaEstiloID { get; set; }

        public virtual Estilos Estilos {get;set;}
        public virtual CategoriasEstilos CategoriasEstilos { get; set; }
    }
}
