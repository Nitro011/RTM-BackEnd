using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class InitialDBRTM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    AlmacenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Almacen = table.Column<string>(nullable: true),
                    Existencia = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.AlmacenID);
                });

            migrationBuilder.CreateTable(
                name: "Area_Produccion",
                columns: table => new
                {
                    Area_ProduccionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(nullable: true),
                    Nombre_Area_Produccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area_Produccion", x => x.Area_ProduccionID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Cliente = table.Column<string>(nullable: true),
                    Correo_Electronico = table.Column<string>(nullable: true),
                    No_Telefono = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.ColorID);
                });

            migrationBuilder.CreateTable(
                name: "Dimensiones",
                columns: table => new
                {
                    DimensionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitud = table.Column<int>(nullable: true),
                    Anchura = table.Column<int>(nullable: true),
                    Altura = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensiones", x => x.DimensionID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Sexo = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Fecha_Nacimiento = table.Column<DateTime>(nullable: true),
                    Edad = table.Column<int>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    EstadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoID);
                });

            migrationBuilder.CreateTable(
                name: "Estados_Usuarios_Almacen",
                columns: table => new
                {
                    Estado_Usuario_AlmacenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados_Usuarios_Almacen", x => x.Estado_Usuario_AlmacenID);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaID);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    ModeloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.ModeloID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolID);
                });

            migrationBuilder.CreateTable(
                name: "Suplidores",
                columns: table => new
                {
                    SuplidorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Suplidor = table.Column<string>(nullable: true),
                    No_Telefono = table.Column<string>(nullable: true),
                    Correo_Electronico = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplidores", x => x.SuplidorID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Calzados",
                columns: table => new
                {
                    Tipo_CalzadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Calzado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Calzados", x => x.Tipo_CalzadoID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Material",
                columns: table => new
                {
                    Tipo_MaterialID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Material = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Material", x => x.Tipo_MaterialID);
                });

            migrationBuilder.CreateTable(
                name: "Area_Produccion_Control_Piezas",
                columns: table => new
                {
                    Area_Produccion_Control_PiezasID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area_ProduccionID = table.Column<int>(nullable: true),
                    Control_Ubicacion_PiezaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area_Produccion_Control_Piezas", x => x.Area_Produccion_Control_PiezasID);
                    table.ForeignKey(
                        name: "FK_Area_Produccion_Control_Piezas_Area_Produccion_Area_ProduccionID",
                        column: x => x.Area_ProduccionID,
                        principalTable: "Area_Produccion",
                        principalColumn: "Area_ProduccionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes_Clientes",
                columns: table => new
                {
                    Orden_ClienteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteID = table.Column<int>(nullable: true),
                    CodigoQR = table.Column<string>(nullable: true),
                    Cantidad_Calzado_Realizar = table.Column<int>(nullable: true),
                    Fecha_Inicio = table.Column<DateTime>(nullable: false),
                    Fecha_Entrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes_Clientes", x => x.Orden_ClienteID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    RolID = table.Column<int>(nullable: true),
                    EmpleadoID = table.Column<int>(nullable: true),
                    RoleRolID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empleados_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RoleRolID",
                        column: x => x.RoleRolID,
                        principalTable: "Roles",
                        principalColumn: "RolID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materias_Primas",
                columns: table => new
                {
                    Materia_PrimaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_MaterialID = table.Column<int>(nullable: true),
                    Nombre_Materia_Prima = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias_Primas", x => x.Materia_PrimaID);
                    table.ForeignKey(
                        name: "FK_Materias_Primas_Tipo_Material_Tipo_MaterialID",
                        column: x => x.Tipo_MaterialID,
                        principalTable: "Tipo_Material",
                        principalColumn: "Tipo_MaterialID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Control_Ubicacion_Piezas",
                columns: table => new
                {
                    Control_Ubicacion_PiezaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_ClienteID = table.Column<int>(nullable: true),
                    Area_ProduccionID = table.Column<int>(nullable: true),
                    EstadoID = table.Column<int>(nullable: true),
                    Tiempo_Inicio = table.Column<DateTime>(nullable: true),
                    Tiempo_Finalizacion = table.Column<DateTime>(nullable: true),
                    Cantidad_Piezas_Realizadas = table.Column<int>(nullable: true),
                    Ordenes_ClientesOrden_ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Control_Ubicacion_Piezas", x => x.Control_Ubicacion_PiezaID);
                    table.ForeignKey(
                        name: "FK_Control_Ubicacion_Piezas_Area_Produccion_Area_ProduccionID",
                        column: x => x.Area_ProduccionID,
                        principalTable: "Area_Produccion",
                        principalColumn: "Area_ProduccionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Control_Ubicacion_Piezas_Estados_EstadoID",
                        column: x => x.EstadoID,
                        principalTable: "Estados",
                        principalColumn: "EstadoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Control_Ubicacion_Piezas_Ordenes_Clientes_Ordenes_ClientesOrden_ClienteID",
                        column: x => x.Ordenes_ClientesOrden_ClienteID,
                        principalTable: "Ordenes_Clientes",
                        principalColumn: "Orden_ClienteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes_Clientes_Detalles",
                columns: table => new
                {
                    Orden_Cliente_DetalleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_ClienteID = table.Column<int>(nullable: true),
                    MarcaID = table.Column<int>(nullable: true),
                    Ordenes_ClientesOrden_ClienteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes_Clientes_Detalles", x => x.Orden_Cliente_DetalleID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Marcas_MarcaID",
                        column: x => x.MarcaID,
                        principalTable: "Marcas",
                        principalColumn: "MarcaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Ordenes_Clientes_Ordenes_ClientesOrden_ClienteID",
                        column: x => x.Ordenes_ClientesOrden_ClienteID,
                        principalTable: "Ordenes_Clientes",
                        principalColumn: "Orden_ClienteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios_Almacen",
                columns: table => new
                {
                    Usuario_AlmacenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioID = table.Column<int>(nullable: true),
                    AlmacenID = table.Column<int>(nullable: true),
                    Estado_Usuario_AlmacenID = table.Column<int>(nullable: true),
                    Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios_Almacen", x => x.Usuario_AlmacenID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Almacen_Almacen_AlmacenID",
                        column: x => x.AlmacenID,
                        principalTable: "Almacen",
                        principalColumn: "AlmacenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Almacen_Estados_Usuarios_Almacen_Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID",
                        column: x => x.Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID,
                        principalTable: "Estados_Usuarios_Almacen",
                        principalColumn: "Estado_Usuario_AlmacenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Almacen_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Area_Produccion_Materias_Primas",
                columns: table => new
                {
                    Area_Produccion_Materia_PrimaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area_ProduccionID = table.Column<int>(nullable: true),
                    Materia_PrimaID = table.Column<int>(nullable: true),
                    CantidadSaliente = table.Column<int>(nullable: true),
                    FechaDeSalida = table.Column<DateTime>(nullable: true),
                    Materias_PrimasMateria_PrimaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area_Produccion_Materias_Primas", x => x.Area_Produccion_Materia_PrimaID);
                    table.ForeignKey(
                        name: "FK_Area_Produccion_Materias_Primas_Area_Produccion_Area_ProduccionID",
                        column: x => x.Area_ProduccionID,
                        principalTable: "Area_Produccion",
                        principalColumn: "Area_ProduccionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Produccion_Materias_Primas_Materias_Primas_Materias_PrimasMateria_PrimaID",
                        column: x => x.Materias_PrimasMateria_PrimaID,
                        principalTable: "Materias_Primas",
                        principalColumn: "Materia_PrimaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "suplidor_Materia_Prima",
                columns: table => new
                {
                    Suplidor_Materia_PrimaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuplidorID = table.Column<int>(nullable: true),
                    AlmacenID = table.Column<int>(nullable: true),
                    Materia_PrimaID = table.Column<int>(nullable: true),
                    Cantidad = table.Column<int>(nullable: true),
                    Fecha_Entrega = table.Column<DateTime>(nullable: true),
                    Materias_PrimasMateria_PrimaID = table.Column<int>(nullable: true),
                    SuplidoreSuplidorID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suplidor_Materia_Prima", x => x.Suplidor_Materia_PrimaID);
                    table.ForeignKey(
                        name: "FK_suplidor_Materia_Prima_Almacen_AlmacenID",
                        column: x => x.AlmacenID,
                        principalTable: "Almacen",
                        principalColumn: "AlmacenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suplidor_Materia_Prima_Materias_Primas_Materias_PrimasMateria_PrimaID",
                        column: x => x.Materias_PrimasMateria_PrimaID,
                        principalTable: "Materias_Primas",
                        principalColumn: "Materia_PrimaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_suplidor_Materia_Prima_Suplidores_SuplidoreSuplidorID",
                        column: x => x.SuplidoreSuplidorID,
                        principalTable: "Suplidores",
                        principalColumn: "SuplidorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Metricas_Eficiencias",
                columns: table => new
                {
                    Metrica_EficienciaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Control_Ubicacion_PiezaID = table.Column<int>(nullable: true),
                    Resultado_Metricas_Eficiencia = table.Column<int>(nullable: true),
                    Control_Ubicacion_PiezasControl_Ubicacion_PiezaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metricas_Eficiencias", x => x.Metrica_EficienciaID);
                    table.ForeignKey(
                        name: "FK_Metricas_Eficiencias_Control_Ubicacion_Piezas_Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                        column: x => x.Control_Ubicacion_PiezasControl_Ubicacion_PiezaID,
                        principalTable: "Control_Ubicacion_Piezas",
                        principalColumn: "Control_Ubicacion_PiezaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes_Clientes_Detalles_Colores",
                columns: table => new
                {
                    Orden_Cliente_Detalle_ColorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_Cliente_DetalleID = table.Column<int>(nullable: true),
                    ColorID = table.Column<int>(nullable: true),
                    ColoreColorID = table.Column<int>(nullable: true),
                    Ordenes_Clientes_DetallesOrden_Cliente_DetalleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes_Clientes_Detalles_Colores", x => x.Orden_Cliente_Detalle_ColorID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Colores_Colores_ColoreColorID",
                        column: x => x.ColoreColorID,
                        principalTable: "Colores",
                        principalColumn: "ColorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                        column: x => x.Ordenes_Clientes_DetallesOrden_Cliente_DetalleID,
                        principalTable: "Ordenes_Clientes_Detalles",
                        principalColumn: "Orden_Cliente_DetalleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes_Clientes_Detalles_Dimensiones",
                columns: table => new
                {
                    Orden_Cliente_Detalle_DimensionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_Cliente_DetalleID = table.Column<int>(nullable: true),
                    DimensionID = table.Column<int>(nullable: true),
                    DimensioneDimensionID = table.Column<int>(nullable: true),
                    Ordenes_Clientes_DetallesOrden_Cliente_DetalleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes_Clientes_Detalles_Dimensiones", x => x.Orden_Cliente_Detalle_DimensionID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensioneDimensionID",
                        column: x => x.DimensioneDimensionID,
                        principalTable: "Dimensiones",
                        principalColumn: "DimensionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                        column: x => x.Ordenes_Clientes_DetallesOrden_Cliente_DetalleID,
                        principalTable: "Ordenes_Clientes_Detalles",
                        principalColumn: "Orden_Cliente_DetalleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes_Clientes_Detalles_Modelos",
                columns: table => new
                {
                    Orden_Cliente_Detalle_ModeloID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_Cliente_DetalleID = table.Column<int>(nullable: true),
                    ModeloID = table.Column<int>(nullable: true),
                    Ordenes_Clientes_DetallesOrden_Cliente_DetalleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes_Clientes_Detalles_Modelos", x => x.Orden_Cliente_Detalle_ModeloID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Modelos_Modelos_ModeloID",
                        column: x => x.ModeloID,
                        principalTable: "Modelos",
                        principalColumn: "ModeloID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                        column: x => x.Ordenes_Clientes_DetallesOrden_Cliente_DetalleID,
                        principalTable: "Ordenes_Clientes_Detalles",
                        principalColumn: "Orden_Cliente_DetalleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                columns: table => new
                {
                    Orden_Cliente_Detalle_Tipo_CalzadoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Orden_Cliente_DetalleID = table.Column<int>(nullable: true),
                    Tipo_CalzadoID = table.Column<int>(nullable: true),
                    Ordenes_Clientes_DetallesOrden_Cliente_DetalleID = table.Column<int>(nullable: true),
                    Tipo_CalzadosTipo_CalzadoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes_Clientes_Detalles_Tipos_Calzados", x => x.Orden_Cliente_Detalle_Tipo_CalzadoID);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                        column: x => x.Ordenes_Clientes_DetallesOrden_Cliente_DetalleID,
                        principalTable: "Ordenes_Clientes_Detalles",
                        principalColumn: "Orden_Cliente_DetalleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_Calzados_Tipo_CalzadosTipo_CalzadoID",
                        column: x => x.Tipo_CalzadosTipo_CalzadoID,
                        principalTable: "Tipo_Calzados",
                        principalColumn: "Tipo_CalzadoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Control_Piezas_Area_ProduccionID",
                table: "Area_Produccion_Control_Piezas",
                column: "Area_ProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_Area_ProduccionID",
                table: "Area_Produccion_Materias_Primas",
                column: "Area_ProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_Produccion_Materias_Primas_Materias_PrimasMateria_PrimaID",
                table: "Area_Produccion_Materias_Primas",
                column: "Materias_PrimasMateria_PrimaID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_Area_ProduccionID",
                table: "Control_Ubicacion_Piezas",
                column: "Area_ProduccionID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_EstadoID",
                table: "Control_Ubicacion_Piezas",
                column: "EstadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas",
                column: "Ordenes_ClientesOrden_ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Materias_Primas_Tipo_MaterialID",
                table: "Materias_Primas",
                column: "Tipo_MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Metricas_Eficiencias_Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias",
                column: "Control_Ubicacion_PiezasControl_Ubicacion_PiezaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_ClienteID",
                table: "Ordenes_Clientes",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_MarcaID",
                table: "Ordenes_Clientes_Detalles",
                column: "MarcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles",
                column: "Ordenes_ClientesOrden_ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "ColoreColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_DimensioneDimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "DimensioneDimensionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Modelos_ModeloID",
                table: "Ordenes_Clientes_Detalles_Modelos",
                column: "ModeloID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Tipo_CalzadosTipo_CalzadoID");

            migrationBuilder.CreateIndex(
                name: "IX_suplidor_Materia_Prima_AlmacenID",
                table: "suplidor_Materia_Prima",
                column: "AlmacenID");

            migrationBuilder.CreateIndex(
                name: "IX_suplidor_Materia_Prima_Materias_PrimasMateria_PrimaID",
                table: "suplidor_Materia_Prima",
                column: "Materias_PrimasMateria_PrimaID");

            migrationBuilder.CreateIndex(
                name: "IX_suplidor_Materia_Prima_SuplidoreSuplidorID",
                table: "suplidor_Materia_Prima",
                column: "SuplidoreSuplidorID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpleadoID",
                table: "Usuarios",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RoleRolID",
                table: "Usuarios",
                column: "RoleRolID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Almacen_AlmacenID",
                table: "Usuarios_Almacen",
                column: "AlmacenID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Almacen_Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID",
                table: "Usuarios_Almacen",
                column: "Estados_Usuarios_AlmacenEstado_Usuario_AlmacenID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Almacen_UsuarioID",
                table: "Usuarios_Almacen",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area_Produccion_Control_Piezas");

            migrationBuilder.DropTable(
                name: "Area_Produccion_Materias_Primas");

            migrationBuilder.DropTable(
                name: "Metricas_Eficiencias");

            migrationBuilder.DropTable(
                name: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropTable(
                name: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropTable(
                name: "Ordenes_Clientes_Detalles_Modelos");

            migrationBuilder.DropTable(
                name: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropTable(
                name: "suplidor_Materia_Prima");

            migrationBuilder.DropTable(
                name: "Usuarios_Almacen");

            migrationBuilder.DropTable(
                name: "Control_Ubicacion_Piezas");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropTable(
                name: "Dimensiones");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Ordenes_Clientes_Detalles");

            migrationBuilder.DropTable(
                name: "Tipo_Calzados");

            migrationBuilder.DropTable(
                name: "Materias_Primas");

            migrationBuilder.DropTable(
                name: "Suplidores");

            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "Estados_Usuarios_Almacen");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Area_Produccion");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Ordenes_Clientes");

            migrationBuilder.DropTable(
                name: "Tipo_Material");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
