using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioMVC.Migrations
{
    /// <inheritdoc />
    public partial class atulizarmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pratos");

            migrationBuilder.AddColumn<int>(
                name: "Prato_ModelId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Prato_ModelId",
                table: "Produtos",
                column: "Prato_ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos",
                column: "Prato_ModelId",
                principalTable: "Pratos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_Prato_ModelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Prato_ModelId",
                table: "Produtos");

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Pratos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
