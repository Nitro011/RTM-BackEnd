using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Estilos
{
    public class EstilosDetallesListView
    {
        public int EstiloID { get; set; }
        public int Estilo_No { get; set; }
        public string Descripcion { get; set; }
        public decimal CostoSTD { get; set; }
        public decimal Ganancia { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PattenNo { get; set; }
        public string Last { get; set; }
        public string Comentarios { get; set; }
        public string Marcas { get; set; }
        public string Division { get; set; }
        public string UnidadesMedidas { get; set; }
        public string Estados { get; set; }
        public List<string> Modelos1 { get; set; }
        public List<string> TiposEstilos1 { get; set; }
        public List<string> Categorias1 { get; set; }
        public List<string> Materiales1 { get; set; }
        public List<string> Pesos { get; set; }
        public List<string> Colores1 { get; set; }
    }
}
