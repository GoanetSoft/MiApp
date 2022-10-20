using Microsoft.EntityFrameworkCore.Migrations;

namespace MiAppMVC.Migrations
{
    public partial class SegundaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Producto",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "idMarca",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "imagen",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "modelo",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "proveedor",
                table: "Producto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "stock",
                table: "Producto",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "idMarca",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "imagen",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "modelo",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "proveedor",
                table: "Producto");

            migrationBuilder.DropColumn(
                name: "stock",
                table: "Producto");
        }
    }
}
