using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioMVC.Migrations
{
    /// <inheritdoc />
    public partial class Conserto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Quantidade",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produtos");
        }
    }
}
