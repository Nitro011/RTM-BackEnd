﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RTM.Persistence;

namespace RTM.Persistence.Migrations
{
    [DbContext(typeof(RTMDbContext))]
    partial class RTMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RTM.Models.Almacen", b =>
                {
                    b.Property<int>("AlmacenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Existencia")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Almacen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlmacenID");

                    b.ToTable("Almacen");
                });

            modelBuilder.Entity("RTM.Models.AreaProduccion", b =>
                {
                    b.Property<int>("AreaProduccionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreAreaProduccion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaProduccionID");

                    b.ToTable("AreaProduccion");
                });

            modelBuilder.Entity("RTM.Models.Area_Produccion_Control_Piezas", b =>
                {
                    b.Property<int>("Area_Produccion_Control_PiezasID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaProduccionID")
                        .HasColumnType("int");

                    b.Property<int?>("Area_ProduccionID")
                        .HasColumnType("int");

                    b.Property<int?>("Control_Ubicacion_PiezaID")
                        .HasColumnType("int");

                    b.HasKey("Area_Produccion_Control_PiezasID");

                    b.HasIndex("AreaProduccionID");

                    b.ToTable("Area_Produccion_Control_Piezas");
                });

            modelBuilder.Entity("RTM.Models.Area_Produccion_Materias_Primas", b =>
                {
                    b.Property<int>("Area_Produccion_Materia_PrimaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaProduccionID")
                        .HasColumnType("int");

                    b.Property<int?>("CantidadSaliente")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaDeSalida")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Materia_PrimaID")
                        .HasColumnType("int");

                    b.Property<int?>("Materias_PrimasMateria_PrimaID")
                        .HasColumnType("int");

                    b.HasKey("Area_Produccion_Materia_PrimaID");

                    b.HasIndex("AreaProduccionID");

                    b.HasIndex("Materias_PrimasMateria_PrimaID");

                    b.ToTable("Area_Produccion_Materias_Primas");
                });

            modelBuilder.Entity("RTM.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo_Electronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("No_Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Cliente")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("RTM.Models.Colore", b =>
                {
                    b.Property<int>("ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ColorID");

                    b.ToTable("Colores");
                });

            modelBuilder.Entity("RTM.Models.Control_Ubicacion_Piezas", b =>
                {
                    b.Property<int>("Control_Ubicacion_PiezaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaProduccionID")
                        .HasColumnType("int");

                    b.Property<int?>("Cantidad_Piezas_Realizadas")
                        .HasColumnType("int");

                    b.Property<int?>("EstadoID")
                        .HasColumnType("int");

                    b.Property<int?>("Orden_ClienteID")
                        .HasColumnType("int");

                    b.Property<int?>("Ordenes_ClientesOrden_ClienteID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Tiempo_Finalizacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Tiempo_Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Control_Ubicacion_PiezaID");

                    b.HasIndex("AreaProduccionID");

                    b.HasIndex("EstadoID");

                    b.HasIndex("Ordenes_ClientesOrden_ClienteID");

                    b.ToTable("Control_Ubicacion_Piezas");
                });

            modelBuilder.Entity("RTM.Models.Dimensione", b =>
                {
                    b.Property<int>("DimensionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Altura")
                        .HasColumnType("int");

                    b.Property<int?>("Anchura")
                        .HasColumnType("int");

                    b.Property<int?>("Longitud")
                        .HasColumnType("int");

                    b.HasKey("DimensionID");

                    b.ToTable("Dimensiones");
                });

            modelBuilder.Entity("RTM.Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Edad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha_Nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Sexo")
                        .HasColumnType("bit");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpleadoID");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("RTM.Models.Estado", b =>
                {
                    b.Property<int>("EstadoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado1")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoID");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("RTM.Models.Estados_Usuarios_Almacen", b =>
                {
                    b.Property<int>("Estado_Usuario_AlmacenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Estado_Usuario_AlmacenID");

                    b.ToTable("Estados_Usuarios_Almacen");
                });

            modelBuilder.Entity("RTM.Models.Marca", b =>
                {
                    b.Property<int>("MarcaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Marca1")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MarcaID");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("RTM.Models.Materias_Primas", b =>
                {
                    b.Property<int>("Materia_PrimaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre_Materia_Prima")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Tipo_MaterialID")
                        .HasColumnType("int");

                    b.HasKey("Materia_PrimaID");

                    b.HasIndex("Tipo_MaterialID");

                    b.ToTable("Materias_Primas");
                });

            modelBuilder.Entity("RTM.Models.Metricas_Eficiencias", b =>
                {
                    b.Property<int>("Metrica_EficienciaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Control_Ubicacion_PiezaID")
                        .HasColumnType("int");

                    b.Property<int?>("Control_Ubicacion_PiezasControl_Ubicacion_PiezaID")
                        .HasColumnType("int");

                    b.Property<int?>("Resultado_Metricas_Eficiencia")
                        .HasColumnType("int");

                    b.HasKey("Metrica_EficienciaID");

                    b.HasIndex("Control_Ubicacion_PiezasControl_Ubicacion_PiezaID");

                    b.ToTable("Metricas_Eficiencias");
                });

            modelBuilder.Entity("RTM.Models.Modelo", b =>
                {
                    b.Property<int>("ModeloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Modelo1")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModeloID");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes", b =>
                {
                    b.Property<int>("Orden_ClienteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Cantidad_Calzado_Realizar")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteID")
                        .HasColumnType("int");

                    b.Property<string>("CodigoQR")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Fecha_Inicio")
                        .HasColumnType("datetime2");

                    b.HasKey("Orden_ClienteID");

                    b.HasIndex("ClienteID");

                    b.ToTable("Ordenes_Clientes");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles", b =>
                {
                    b.Property<int>("Orden_Cliente_DetalleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MarcaID")
                        .HasColumnType("int");

                    b.Property<int?>("Orden_ClienteID")
                        .HasColumnType("int");

                    b.Property<int?>("Ordenes_ClientesOrden_ClienteID")
                        .HasColumnType("int");

                    b.HasKey("Orden_Cliente_DetalleID");

                    b.HasIndex("MarcaID");

                    b.HasIndex("Ordenes_ClientesOrden_ClienteID");

                    b.ToTable("Ordenes_Clientes_Detalles");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Colores", b =>
                {
                    b.Property<int>("Orden_Cliente_Detalle_ColorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ColorID")
                        .HasColumnType("int");

                    b.Property<int?>("ColoreColorID")
                        .HasColumnType("int");

                    b.Property<int?>("Orden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.Property<int?>("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.HasKey("Orden_Cliente_Detalle_ColorID");

                    b.HasIndex("ColoreColorID");

                    b.HasIndex("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

                    b.ToTable("Ordenes_Clientes_Detalles_Colores");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Dimensiones", b =>
                {
                    b.Property<int>("Orden_Cliente_Detalle_DimensionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DimensionID")
                        .HasColumnType("int");

                    b.Property<int?>("DimensioneDimensionID")
                        .HasColumnType("int");

                    b.Property<int?>("Orden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.Property<int?>("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.HasKey("Orden_Cliente_Detalle_DimensionID");

                    b.HasIndex("DimensioneDimensionID");

                    b.HasIndex("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

                    b.ToTable("Ordenes_Clientes_Detalles_Dimensiones");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Modelos", b =>
                {
                    b.Property<int>("Orden_Cliente_Detalle_ModeloID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ModeloID")
                        .HasColumnType("int");

                    b.Property<int?>("Orden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.Property<int?>("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.HasKey("Orden_Cliente_Detalle_ModeloID");

                    b.HasIndex("ModeloID");

                    b.HasIndex("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

                    b.ToTable("Ordenes_Clientes_Detalles_Modelos");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Tipos_Calzados", b =>
                {
                    b.Property<int>("Orden_Cliente_Detalle_Tipo_CalzadoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Orden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.Property<int?>("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID")
                        .HasColumnType("int");

                    b.Property<int?>("Tipo_CalzadoID")
                        .HasColumnType("int");

                    b.Property<int?>("Tipo_CalzadosTipo_CalzadoID")
                        .HasColumnType("int");

                    b.HasKey("Orden_Cliente_Detalle_Tipo_CalzadoID");

                    b.HasIndex("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

                    b.HasIndex("Tipo_CalzadosTipo_CalzadoID");

                    b.ToTable("Ordenes_Clientes_Detalles_Tipos_Calzados");
                });

            modelBuilder.Entity("RTM.Models.Role", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo_Usuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RTM.Models.Suplidor_Materia_Prima", b =>
                {
                    b.Property<int>("Suplidor_Materia_PrimaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlmacenID")
                        .HasColumnType("int");

                    b.Property<int?>("Cantidad")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Fecha_Entrega")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Materia_PrimaID")
                        .HasColumnType("int");

                    b.Property<int?>("Materias_PrimasMateria_PrimaID")
                        .HasColumnType("int");

                    b.Property<int?>("SuplidorID")
                        .HasColumnType("int");

                    b.Property<int?>("SuplidoreSuplidorID")
                        .HasColumnType("int");

                    b.HasKey("Suplidor_Materia_PrimaID");

                    b.HasIndex("AlmacenID");

                    b.HasIndex("Materias_PrimasMateria_PrimaID");

                    b.HasIndex("SuplidoreSuplidorID");

                    b.ToTable("suplidor_Materia_Prima");
                });

            modelBuilder.Entity("RTM.Models.Suplidore", b =>
                {
                    b.Property<int>("SuplidorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo_Electronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("No_Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre_Suplidor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SuplidorID");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("RTM.Models.Tipo_Calzados", b =>
                {
                    b.Property<int>("Tipo_CalzadoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo_Calzado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tipo_CalzadoID");

                    b.ToTable("Tipo_Calzados");
                });

            modelBuilder.Entity("RTM.Models.Tipo_Material", b =>
                {
                    b.Property<int>("Tipo_MaterialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre_Material")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Tipo_MaterialID");

                    b.ToTable("Tipo_Material");
                });

            modelBuilder.Entity("RTM.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaProduccionID")
                        .HasColumnType("int");

                    b.Property<string>("Contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmpleadoID")
                        .HasColumnType("int");

                    b.Property<string>("NombreDeUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RolID")
                        .HasColumnType("int");

                    b.HasKey("UsuarioID");

                    b.HasIndex("AreaProduccionID");

                    b.HasIndex("EmpleadoID");

                    b.HasIndex("RolID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("RTM.Models.Usuarios_Almacen", b =>
                {
                    b.Property<int>("Usuario_AlmacenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AlmacenID")
                        .HasColumnType("int");

                    b.Property<int?>("Estado_Usuario_AlmacenID")
                        .HasColumnType("int");

                    b.Property<int?>("Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioID")
                        .HasColumnType("int");

                    b.HasKey("Usuario_AlmacenID");

                    b.HasIndex("AlmacenID");

                    b.HasIndex("Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Usuarios_Almacen");
                });

            modelBuilder.Entity("RTM.Models.Area_Produccion_Control_Piezas", b =>
                {
                    b.HasOne("RTM.Models.AreaProduccion", "AreaProduccion")
                        .WithMany()
                        .HasForeignKey("AreaProduccionID");
                });

            modelBuilder.Entity("RTM.Models.Area_Produccion_Materias_Primas", b =>
                {
                    b.HasOne("RTM.Models.AreaProduccion", "AreaProduccion")
                        .WithMany()
                        .HasForeignKey("AreaProduccionID");

                    b.HasOne("RTM.Models.Materias_Primas", "Materias_Primas")
                        .WithMany("Area_Produccion_Materias_Primas")
                        .HasForeignKey("Materias_PrimasMateria_PrimaID");
                });

            modelBuilder.Entity("RTM.Models.Control_Ubicacion_Piezas", b =>
                {
                    b.HasOne("RTM.Models.AreaProduccion", "AreaProduccion")
                        .WithMany()
                        .HasForeignKey("AreaProduccionID");

                    b.HasOne("RTM.Models.Estado", "Estado")
                        .WithMany("Control_Ubicacion_Piezas")
                        .HasForeignKey("EstadoID");

                    b.HasOne("RTM.Models.Ordenes_Clientes", "Ordenes_Clientes")
                        .WithMany("Control_Ubicacion_Piezas")
                        .HasForeignKey("Ordenes_ClientesOrden_ClienteID");
                });

            modelBuilder.Entity("RTM.Models.Materias_Primas", b =>
                {
                    b.HasOne("RTM.Models.Tipo_Material", "Tipo_Material")
                        .WithMany("Materias_Primas")
                        .HasForeignKey("Tipo_MaterialID");
                });

            modelBuilder.Entity("RTM.Models.Metricas_Eficiencias", b =>
                {
                    b.HasOne("RTM.Models.Control_Ubicacion_Piezas", "Control_Ubicacion_Piezas")
                        .WithMany("Metricas_Eficiencias")
                        .HasForeignKey("Control_Ubicacion_PiezasControl_Ubicacion_PiezaID");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes", b =>
                {
                    b.HasOne("RTM.Models.Cliente", "Cliente")
                        .WithMany("Ordenes_Clientes")
                        .HasForeignKey("ClienteID");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles", b =>
                {
                    b.HasOne("RTM.Models.Marca", "Marca")
                        .WithMany("Ordenes_Clientes_Detalles")
                        .HasForeignKey("MarcaID");

                    b.HasOne("RTM.Models.Ordenes_Clientes", "Ordenes_Clientes")
                        .WithMany("Ordenes_Clientes_Detalles")
                        .HasForeignKey("Ordenes_ClientesOrden_ClienteID");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Colores", b =>
                {
                    b.HasOne("RTM.Models.Colore", "Colore")
                        .WithMany("Ordenes_Clientes_Detalles_Colores")
                        .HasForeignKey("ColoreColorID");

                    b.HasOne("RTM.Models.Ordenes_Clientes_Detalles", "Ordenes_Clientes_Detalles")
                        .WithMany("Ordenes_Clientes_Detalles_Colores")
                        .HasForeignKey("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Dimensiones", b =>
                {
                    b.HasOne("RTM.Models.Dimensione", "Dimensione")
                        .WithMany("Ordenes_Clientes_Detalles_Dimensiones")
                        .HasForeignKey("DimensioneDimensionID");

                    b.HasOne("RTM.Models.Ordenes_Clientes_Detalles", "Ordenes_Clientes_Detalles")
                        .WithMany("Ordenes_Clientes_Detalles_Dimensiones")
                        .HasForeignKey("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Modelos", b =>
                {
                    b.HasOne("RTM.Models.Modelo", "Modelo")
                        .WithMany("Ordenes_Clientes_Detalles_Modelos")
                        .HasForeignKey("ModeloID");

                    b.HasOne("RTM.Models.Ordenes_Clientes_Detalles", "Ordenes_Clientes_Detalles")
                        .WithMany("Ordenes_Clientes_Detalles_Modelos")
                        .HasForeignKey("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");
                });

            modelBuilder.Entity("RTM.Models.Ordenes_Clientes_Detalles_Tipos_Calzados", b =>
                {
                    b.HasOne("RTM.Models.Ordenes_Clientes_Detalles", "Ordenes_Clientes_Detalles")
                        .WithMany("Ordenes_Clientes_Detalles_Tipos_Calzados")
                        .HasForeignKey("Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

                    b.HasOne("RTM.Models.Tipo_Calzados", "Tipo_Calzados")
                        .WithMany("Ordenes_Clientes_Detalles_Tipos_Calzados")
                        .HasForeignKey("Tipo_CalzadosTipo_CalzadoID");
                });

            modelBuilder.Entity("RTM.Models.Suplidor_Materia_Prima", b =>
                {
                    b.HasOne("RTM.Models.Almacen", "Almacen")
                        .WithMany("Suplidor_Materia_Prima")
                        .HasForeignKey("AlmacenID");

                    b.HasOne("RTM.Models.Materias_Primas", "Materias_Primas")
                        .WithMany("Suplidor_Materia_Prima")
                        .HasForeignKey("Materias_PrimasMateria_PrimaID");

                    b.HasOne("RTM.Models.Suplidore", "Suplidore")
                        .WithMany("Suplidor_Materia_Prima")
                        .HasForeignKey("SuplidoreSuplidorID");
                });

            modelBuilder.Entity("RTM.Models.Usuario", b =>
                {
                    b.HasOne("RTM.Models.AreaProduccion", "AreaProduccion")
                        .WithMany()
                        .HasForeignKey("AreaProduccionID");

                    b.HasOne("RTM.Models.Empleado", "Empleado")
                        .WithMany()
                        .HasForeignKey("EmpleadoID");

                    b.HasOne("RTM.Models.Role", "Role")
                        .WithMany("Usuarios")
                        .HasForeignKey("RolID");
                });

            modelBuilder.Entity("RTM.Models.Usuarios_Almacen", b =>
                {
                    b.HasOne("RTM.Models.Almacen", "Almacen")
                        .WithMany("Usuarios_Almacen")
                        .HasForeignKey("AlmacenID");

                    b.HasOne("RTM.Models.Estados_Usuarios_Almacen", "Estados_Usuarios_Almacen")
                        .WithMany("Usuarios_Almacen")
                        .HasForeignKey("Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID");

                    b.HasOne("RTM.Models.Usuario", "Usuario")
                        .WithMany("Usuarios_Almacen")
                        .HasForeignKey("UsuarioID");
                });
#pragma warning restore 612, 618
        }
    }
}
