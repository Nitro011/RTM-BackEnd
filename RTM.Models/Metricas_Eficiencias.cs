//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RTM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Metricas_Eficiencias
    {
        [Key]
        public int Metrica_EficienciaID { get; set; }
        [ForeignKey("Control_Ubicacion_Piezas")]
        public int? Control_Ubicacion_PiezaID { get; set; }
        public int? Resultado_Metricas_Eficiencia { get; set; }
    
        public virtual Control_Ubicacion_Piezas Control_Ubicacion_Piezas { get; set; }
    }
}
