//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Persistence
{
    public class RTMDbContext : DbContext
    {

        string cn = "server=148.101.43.9;database=RayTrackingMobile;uid=Arquimedes;password=123456;";



        public RTMDbContext() :
            base()
        {
        }
        public DbSet<Almacen> Almacen { get; set; }
      
        public DbSet<Area_Produccion> Area_Produccion { get; set; }

        public DbSet<Area_Produccion_Control_Piezas> Area_Produccion_Control_Piezas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Colore> Colores { get; set; }

        public DbSet<Control_Ubicacion_Piezas> Control_Ubicacion_Piezas { get; set; }

        public DbSet<Dimensione> Dimensiones { get; set; }
       
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Estado> Estados { get; set; }

        public DbSet<Estados_Usuarios_Almacen> Estados_Usuarios_Almacen { get; set; }

        public DbSet<Marca> Marcas { get; set; }

        public DbSet<Materias_Primas> Materias_Primas { get; set; }
      
        public DbSet<Metricas_Eficiencias> Metricas_Eficiencias { get; set; }

        public DbSet<Modelo> Modelos { get; set; }

        public DbSet<Ordenes_Clientes> Ordenes_Clientes { get; set; }

        public DbSet<Ordenes_Clientes_Detalles> Ordenes_Clientes_Detalles { get; set; }

        public DbSet<Ordenes_Clientes_Detalles_Colores> Ordenes_Clientes_Detalles_Colores { get; set; }

        public DbSet<Ordenes_Clientes_Detalles_Dimensiones> Ordenes_Clientes_Detalles_Dimensiones { get; set; }

        public DbSet<Ordenes_Clientes_Detalles_Modelos> Ordenes_Clientes_Detalles_Modelos { get; set; }
       
        public DbSet<Ordenes_Clientes_Detalles_Tipos_Calzados> Ordenes_Clientes_Detalles_Tipos_Calzados { get; set; }
      
        public DbSet<Role> Roles { get; set; }
     
        public DbSet<Suplidor_Materia_Prima> suplidor_Materia_Prima { get; set; }
      
        public DbSet<Suplidore> Suplidores { get; set; }
      
        public DbSet<Tipo_Calzados> Tipo_Calzados { get; set; }

        public DbSet<Tipo_Material> Tipo_Material { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Usuarios_Almacen> Usuarios_Almacen { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(cn);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

    }
}
