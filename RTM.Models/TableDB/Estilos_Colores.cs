using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Estilos_Colores
    {
        [Key]
        public int Estilo_ColorID { get; set; }

        [ForeignKey("Estilos")]
        public int EstiloID { get; set; }

        [ForeignKey("Colore")]
        public int ColorID { get; set; }
        public virtual Estilos Estilos { get; set; }
        public virtual Colore Colore { get; set; }
    }
}
