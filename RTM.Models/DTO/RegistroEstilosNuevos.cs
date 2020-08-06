using RTM.Models.TableDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO
{
    public class RegistroEstilosNuevos
    {
        public int EstiloID { get; set; }

        public int? MarcaID { get; set; }

        public int? Estilo_No { get; set; }

        public int? DivisionID { get; set; }
        public string Descripcion { get; set; }
        public decimal? CostoSTD { get; set; }
        public decimal? Ganancia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PattenNo { get; set; }

        public int? EstadoID { get; set; }
        public string Last { get; set; }

        public int? UnidadMedidaEstiloID { get; set; }

        public string Comentarios { get; set; }


        public List<Estilos_Colores> Colores { get; set; }
        public List<Estilos_Modelos> Modelos { get; set; }
        public List<Estilos_TiposEstilos> TiposEstilos { get; set; }
        public List<Estilos_CategoriasEstilos> CategoriasEstilos { get; set; }
        public List<Estilos_MateriasPrimas> Materias { get; set; }
        public List<Estilos_PesosEstilos> PesosEstilos { get; set; }

    }
}
