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

    public partial class Tipo_Calzados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_Calzados()
        {
            this.Ordenes_Clientes_Detalles_Tipos_Calzados = new HashSet<Ordenes_Clientes_Detalles_Tipos_Calzados>();
        }
        [Key]
        public int Tipo_CalzadoID { get; set; }
        public string Tipo_Calzado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordenes_Clientes_Detalles_Tipos_Calzados> Ordenes_Clientes_Detalles_Tipos_Calzados { get; set; }
    }
}
