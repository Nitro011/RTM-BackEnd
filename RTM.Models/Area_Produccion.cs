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

    public partial class Area_Produccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Area_Produccion()
        {
            this.Area_Produccion_Control_Piezas = new HashSet<Area_Produccion_Control_Piezas>();
            this.Area_Produccion_Materias_Primas = new HashSet<Area_Produccion_Materias_Primas>();
            this.Control_Ubicacion_Piezas = new HashSet<Control_Ubicacion_Piezas>();
        }

        [Key]
        public int Area_ProduccionID { get; set; }
        public int? UsuarioID { get; set; }
        public string Nombre_Area_Produccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area_Produccion_Control_Piezas> Area_Produccion_Control_Piezas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Area_Produccion_Materias_Primas> Area_Produccion_Materias_Primas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control_Ubicacion_Piezas> Control_Ubicacion_Piezas { get; set; }
    }
}
