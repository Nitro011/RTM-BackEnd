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

    public partial class Control_Ubicacion_Piezas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Control_Ubicacion_Piezas()
        {
            this.Metricas_Eficiencias = new HashSet<Metricas_Eficiencias>();
        }
        [Key]
        public int Control_Ubicacion_PiezaID { get; set; }
      
        [ForeignKey("Ordenes_Clientes")]
        public int? Orden_ClienteID { get; set; }

        [ForeignKey("SubDepartamentos")]
        public int? SubDepartamentoID { get; set; }

        [ForeignKey("Estado")]
        public int? EstadoID { get; set; }
        public System.DateTime? Tiempo_Inicio { get; set; }
        public System.DateTime? Tiempo_Finalizacion { get; set; }
        public int? Cantidad_Piezas_Realizadas { get; set; }
    
        public virtual SubDepartamentos SubDepartamentos { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Ordenes_Clientes Ordenes_Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Metricas_Eficiencias> Metricas_Eficiencias { get; set; }
    }
}
