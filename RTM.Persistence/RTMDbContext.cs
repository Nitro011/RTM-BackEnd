﻿//using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RTM.Models;
using RTM.Models.TableDB;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTM.Persistence
{
    public class RTMDbContext : DbContext
    {

        string cn = "server=148.0.124.0;database=RayTrackingMobile;uid=AndresGc;password=Ag04071997;";



        public RTMDbContext() :
            base()
        {
        }
        public DbSet<Almacen> Almacen { get; set; }
      
        public DbSet<Departamentos> Departamentos { get; set; }

        public DbSet<Area_Produccion_Control_Piezas> Area_Produccion_Control_Piezas { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Colore> Colores { get; set; }

        public DbSet<Control_Ubicacion_Piezas> Control_Ubicacion_Piezas { get; set; }

        public DbSet<Size> Sizes { get; set; }
       
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

        public DbSet<BOM> BOMs { get; set; }
        public DbSet<OperacionesCalzados> OperacionesCalzados { get; set; }
        public DbSet<CategoriaSize> categoriaSizes { get; set; }
        public DbSet<Posiciones> Posiciones { get; set; }
        public DbSet<SubDepartamentos> SubDepartamentos { get; set; }
        public DbSet<TiposDepartamentos> TiposDepartamentos { get; set; }
        public DbSet<Estilos> Estilos { get; set; }
        public DbSet<CategoriasEstilos> CategoriasEstilos { get; set; }
        public DbSet<Divisiones> Divisiones { get; set; }
        public DbSet<UnidadesMedidasEstilos> UnidadesMedidasEstilos { get; set; }
        public DbSet<Estilos_MateriasPrimas> Estilos_MateriasPrimas { get; set; }
        public DbSet<BOMDetalles> BOMDetalles { get; set; }
        public DbSet<Constructions> Constructions { get; set; }
        public DbSet<DivisionesMateriasPrimas> DivisionesMateriasPrimas { get; set; }
        public DbSet<ITEMS> ITEMS { get; set; }
        public DbSet<AnchosSizes> AnchosSizes { get; set; }
        public DbSet<OrdenesClientes_Estilos> OrdenesClientes_Estilos { get; set; }
        public DbSet<OrdenesClientes_Sizes> OrdenesClientes_Sizes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(cn);
            optionsBuilder.EnableSensitiveDataLogging(true);
        }

    }
}
