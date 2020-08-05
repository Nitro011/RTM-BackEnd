using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos
    {
        [Key]
        public int EstiloID { get; set; }

        [ForeignKey("Marca")]
        public int? MarcaID { get; set; }

        public int Estilo_No { get; set; }

        [ForeignKey("Divisiones")]
        public int? DivisionID { get; set; }
        public string Descripcion { get; set; }
        public decimal CostoSTD { get; set; }
        public decimal Ganancia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PattenNo { get; set; }
        
        [ForeignKey("Estado")]
        public int? EstadoID { get; set; }
        public string Last { get; set; }

        [ForeignKey("UnidadesMedidasEstilos")]
        public int? UnidadMedidaEstiloID { get; set; }

        public string Comentarios { get; set; }


        public virtual Marca Marca { get; set; }
        public virtual Divisiones Divisiones { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual UnidadesMedidasEstilos UnidadesMedidasEstilos { get; set; }

    }
}
