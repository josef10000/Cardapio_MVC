using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioMVC.Migrations
{
    /// <inheritdoc />
    public partial class corrigindo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "Prato_ModelId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos",
                column: "Prato_ModelId",
                principalTable: "Pratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos");

            migrationBuilder.AlterColumn<int>(
                name: "Prato_ModelId",
                table: "Produtos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos",
                column: "Prato_ModelId",
                principalTable: "Pratos",
                principalColumn: "Id");
        }
    }
}
