using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioMVC.Migrations
{
    /// <inheritdoc />
    public partial class colunaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pratos_PratoId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_Prato_ModelId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Items_PratoId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Prato_ModelId",
                table: "Produtos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAlteracaoPreco",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAlteracaoPreco",
                table: "Produtos");

            migrationBuilder.AddColumn<int>(
                name: "Prato_ModelId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustoTotal = table.Column<double>(type: "float", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorcentagemLucro = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pratos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Prato_ModelId",
                table: "Produtos",
                column: "Prato_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PratoId",
                table: "Items",
                column: "PratoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Pratos_PratoId",
                table: "Items",
                column: "PratoId",
                principalTable: "Pratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Pratos_Prato_ModelId",
                table: "Produtos",
                column: "Prato_ModelId",
                principalTable: "Pratos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
