using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioMVC.Migrations
{
    /// <inheritdoc />
    public partial class adiçao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "Produtos",
                newName: "Kilos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Kilos",
                table: "Produtos",
                newName: "Quantidade");
        }
    }
}
