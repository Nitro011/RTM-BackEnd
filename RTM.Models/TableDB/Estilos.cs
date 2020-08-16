using RTM.Models.DTO.TiposCalzados;
using RTM.Models.DTO.TiposMateriales;
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

        [ForeignKey("Marcas")]
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

        [ForeignKey("CategoriasEstilos")]
        public int? CategoriaEstiloID { get; set; }

        [ForeignKey("Colores")]
        public int? ColorID { get; set; }

        [ForeignKey("Modelos")]
        public int? ModeloID { get; set; }

        [ForeignKey("Tipo_Calzados")]
        public int? Tipo_CalzadoID { get; set; }

        public string Comentarios { get; set; }
        public string PesoEstilos { get; set; }
        public string ImageURL { get; set; } 
        public List<Estilos_MateriasPrimas> Materias { get; set; }
        public virtual Marca Marcas { get; set; }
        public virtual Divisiones Divisiones { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual UnidadesMedidasEstilos UnidadesMedidasEstilos { get; set; }
        public virtual CategoriasEstilos CategoriasEstilos { get; set; }
        public virtual Colore Colores { get; set; }
        public virtual Modelo Modelos { get; set; }
        public virtual Tipo_Calzados Tipo_Calzados { get; set; }

    }
}
