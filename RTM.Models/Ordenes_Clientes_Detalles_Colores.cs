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

    public partial class Ordenes_Clientes_Detalles_Colores
    {
        [Key]
        public int Orden_Cliente_Detalle_ColorID { get; set; }
        public int? Orden_Cliente_DetalleID { get; set; }
        public int? ColorID { get; set; }
    
        public virtual Colore Colore { get; set; }
        public virtual Ordenes_Clientes_Detalles Ordenes_Clientes_Detalles { get; set; }
    }
}
