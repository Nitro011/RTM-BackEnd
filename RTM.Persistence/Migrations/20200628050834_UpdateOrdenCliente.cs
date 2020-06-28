using Microsoft.EntityFrameworkCore.Migrations;

namespace RTM.Persistence.Migrations
{
    public partial class UpdateOrdenCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Ordenes_Clientes_Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metricas_Eficiencias_Control_Ubicacion_Piezas_Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Ordenes_Clientes_Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Colores_ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensioneDimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_Calzados_Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_DimensioneDimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles");

            migrationBuilder.DropIndex(
                name: "IX_Metricas_Eficiencias_Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias");

            migrationBuilder.DropIndex(
                name: "IX_Control_Ubicacion_Piezas_Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropColumn(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropColumn(
                name: "Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropColumn(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos");

            migrationBuilder.DropColumn(
                name: "DimensioneDimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropColumn(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropColumn(
                name: "ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropColumn(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropColumn(
                name: "Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles");

            migrationBuilder.DropColumn(
                name: "Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias");

            migrationBuilder.DropColumn(
                name: "Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Orden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Tipo_CalzadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Modelos_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos",
                column: "Orden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "DimensionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "Orden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_ColorID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "ColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "Orden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Orden_ClienteID",
                table: "Ordenes_Clientes_Detalles",
                column: "Orden_ClienteID",
                unique: true,
                filter: "[Orden_ClienteID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Metricas_Eficiencias_Control_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias",
                column: "Control_Ubicacion_PiezaID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_Orden_ClienteID",
                table: "Control_Ubicacion_Piezas",
                column: "Orden_ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Ordenes_Clientes_Orden_ClienteID",
                table: "Control_Ubicacion_Piezas",
                column: "Orden_ClienteID",
                principalTable: "Ordenes_Clientes",
                principalColumn: "Orden_ClienteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Metricas_Eficiencias_Control_Ubicacion_Piezas_Control_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias",
                column: "Control_Ubicacion_PiezaID",
                principalTable: "Control_Ubicacion_Piezas",
                principalColumn: "Control_Ubicacion_PiezaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Ordenes_Clientes_Orden_ClienteID",
                table: "Ordenes_Clientes_Detalles",
                column: "Orden_ClienteID",
                principalTable: "Ordenes_Clientes",
                principalColumn: "Orden_ClienteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Colores_ColorID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "ColorID",
                principalTable: "Colores",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "Orden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "DimensionID",
                principalTable: "Dimensiones",
                principalColumn: "DimensionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "Orden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos",
                column: "Orden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Orden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_Calzados_Tipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Tipo_CalzadoID",
                principalTable: "Tipo_Calzados",
                principalColumn: "Tipo_CalzadoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Ordenes_Clientes_Orden_ClienteID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.DropForeignKey(
                name: "FK_Metricas_Eficiencias_Control_Ubicacion_Piezas_Control_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Ordenes_Clientes_Orden_ClienteID",
                table: "Ordenes_Clientes_Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Colores_ColorID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_Detalles_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_Calzados_Tipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Modelos_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_DimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Dimensiones_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_ColorID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_Orden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores");

            migrationBuilder.DropIndex(
                name: "IX_Ordenes_Clientes_Detalles_Orden_ClienteID",
                table: "Ordenes_Clientes_Detalles");

            migrationBuilder.DropIndex(
                name: "IX_Metricas_Eficiencias_Control_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias");

            migrationBuilder.DropIndex(
                name: "IX_Control_Ubicacion_Piezas_Orden_ClienteID",
                table: "Control_Ubicacion_Piezas");

            migrationBuilder.AddColumn<int>(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DimensioneDimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Tipo_CalzadosTipo_CalzadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos",
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
                name: "IX_Ordenes_Clientes_Detalles_Colores_ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "ColoreColorID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_Clientes_Detalles_Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles",
                column: "Ordenes_ClientesOrden_ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Metricas_Eficiencias_Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias",
                column: "Control_Ubicacion_PiezasControl_Ubicacion_PiezaID");

            migrationBuilder.CreateIndex(
                name: "IX_Control_Ubicacion_Piezas_Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas",
                column: "Ordenes_ClientesOrden_ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Control_Ubicacion_Piezas_Ordenes_Clientes_Ordenes_ClientesOrden_ClienteID",
                table: "Control_Ubicacion_Piezas",
                column: "Ordenes_ClientesOrden_ClienteID",
                principalTable: "Ordenes_Clientes",
                principalColumn: "Orden_ClienteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Metricas_Eficiencias_Control_Ubicacion_Piezas_Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                table: "Metricas_Eficiencias",
                column: "Control_Ubicacion_PiezasControl_Ubicacion_PiezaID",
                principalTable: "Control_Ubicacion_Piezas",
                principalColumn: "Control_Ubicacion_PiezaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Ordenes_Clientes_Ordenes_ClientesOrden_ClienteID",
                table: "Ordenes_Clientes_Detalles",
                column: "Ordenes_ClientesOrden_ClienteID",
                principalTable: "Ordenes_Clientes",
                principalColumn: "Orden_ClienteID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Colores_ColoreColorID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "ColoreColorID",
                principalTable: "Colores",
                principalColumn: "ColorID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Colores_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Colores",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Dimensiones_DimensioneDimensionID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "DimensioneDimensionID",
                principalTable: "Dimensiones",
                principalColumn: "DimensionID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Dimensiones_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Dimensiones",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Modelos_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Modelos",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Ordenes_Clientes_Detalles_Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Ordenes_Clientes_DetallesOrden_Cliente_DetalleID",
                principalTable: "Ordenes_Clientes_Detalles",
                principalColumn: "Orden_Cliente_DetalleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ordenes_Clientes_Detalles_Tipos_Calzados_Tipo_Calzados_Tipo_CalzadosTipo_CalzadoID",
                table: "Ordenes_Clientes_Detalles_Tipos_Calzados",
                column: "Tipo_CalzadosTipo_CalzadoID",
                principalTable: "Tipo_Calzados",
                principalColumn: "Tipo_CalzadoID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
