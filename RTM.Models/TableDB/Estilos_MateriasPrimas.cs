using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos_MateriasPrimas
    {
        [Key]
        public int Estilo_MateriaPrimaID { get; set; }

        [ForeignKey("Estilos")]
        public int? EstiloID { get; set; }

        [ForeignKey("Materias_Primas")]
        public int? Materia_PrimaID { get; set; }

        public virtual Estilos Estilos { get; set; }
        public virtual Materias_Primas  Materias_Primas { get; set; }
    }
}
