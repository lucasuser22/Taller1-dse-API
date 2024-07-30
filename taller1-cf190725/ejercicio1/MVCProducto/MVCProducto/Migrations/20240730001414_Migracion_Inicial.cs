using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCProducto.Migrations
{
    /// <inheritdoc />
    public partial class Migracion_Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CodigoCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_CodigoCategoria",
                        column: x => x.CodigoCategoria,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Electronica" },
                    { 2, "Ropa" },
                    { 3, "Alimentos" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ID", "CodigoCategoria", "NombreProducto", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Smartphone", 299.99m, 50 },
                    { 2, 2, "Camisa", 19.99m, 200 },
                    { 3, 3, "Pan", 1.99m, 100 },
                    { 5, 1, "Laptop", 799.99m, 30 },
                    { 6, 2, "Zapatos", 49.99m, 150 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_CodigoCategoria",
                table: "Producto",
                column: "CodigoCategoria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
