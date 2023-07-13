using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeEstoqueSqLite.Migrations
{
    public partial class Versao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IdProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estoque = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IdProduto);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categorias",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdCategoria",
                table: "Produtos",
                column: "IdCategoria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
