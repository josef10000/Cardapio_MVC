using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardapioMVC.Migrations
{
    /// <inheritdoc />
    public partial class novocorreto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pratos_Prato_ModelId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Produtos_ProdutoId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_Prato_ModelId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ProdutoId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Prato_ModelId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "PratoId");

            migrationBuilder.AddColumn<double>(
                name: "ValorTotal",
                table: "Pratos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "PratoId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ProdutoNome",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "QuantidadeGramas",
                table: "Items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                columns: new[] { "ProdutoId", "PratoId" });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pratos_PratoId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PratoId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pratos");

            migrationBuilder.DropColumn(
                name: "ProdutoNome",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "QuantidadeGramas",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "PratoId",
                table: "Items",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Prato_ModelId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Prato_ModelId",
                table: "Items",
                column: "Prato_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ProdutoId",
                table: "Items",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Pratos_Prato_ModelId",
                table: "Items",
                column: "Prato_ModelId",
                principalTable: "Pratos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Produtos_ProdutoId",
                table: "Items",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
