﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Models.DTO.Empleados
{
    public class EmpleadoByNombreCompleto_Cedula_CodigoEmpleado
    {
        public int Id { get; set; }
        public int? RolID { get; set; }
        public int? AreaProduccionID { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string nombreCompleto { get; set; }
        public bool? Sexo { get; set; }
        public string Cedula { get; set; }
        public System.DateTime? Fecha_Nacimiento { get; set; }
        public int? Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public System.DateTime? FechaIngreso { get; set; }
        public string Rol { get; set; }
        public string Puesto { get; set; }
        public string Posicion { get; set; }
    }
}
