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

    public partial class Suplidore
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Suplidore()
        {
            this.Suplidor_Materia_Prima = new HashSet<Suplidor_Materia_Prima>();
        }
        [Key]
        public int SuplidorID { get; set; }
        public string Empresa { get; set; }
        public string Nombre_Suplidor { get; set; }
        public string No_Telefono { get; set; }
        public string Correo_Electronico { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }

    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Suplidor_Materia_Prima> Suplidor_Materia_Prima { get; set; }
    }
}
