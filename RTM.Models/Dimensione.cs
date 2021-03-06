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
    using RTM.Models.TableDB;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Size
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Size()
        {
            this.Ordenes_Clientes_Detalles_Dimensiones = new HashSet<Ordenes_Clientes_Detalles_Dimensiones>();
        }

        [Key]
        public int SizeID { get; set; }
        public string USA { get; set; }
        public string UK { get; set; }
        public string EURO { get; set; }
        public string CM { get; set; }

        [ForeignKey("CategoriaSize")]
        public int CategoriaSizeID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ordenes_Clientes_Detalles_Dimensiones> Ordenes_Clientes_Detalles_Dimensiones { get; set; }

        public virtual CategoriaSize CategoriaSize {get; set;}
    }
}
