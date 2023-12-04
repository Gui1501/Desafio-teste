using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mttechne.Backend.Junior.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Nome", "Valor" },
                values: new object[,]
                {
                    { 1, "Placa de Vídeo", 1000 },
                    { 2, "Placa de Vídeo", 1500 },
                    { 3, "Placa de Vídeo", 1350 },
                    { 4, "Processador", 2000 },
                    { 5, "Processador", 2100 },
                    { 6, "Memória", 300 },
                    { 7, "Memória", 350 },
                    { 8, "Placa mãe", 1100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "ProdutoId",
                keyValue: 8);
        }
    }
}
