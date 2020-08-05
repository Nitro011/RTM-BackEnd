using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.TableDB
{
    public class Posiciones
    {
        [Key]
        public int PosicionID { get; set; }
        public string Posicion { get; set; }

    }
}
