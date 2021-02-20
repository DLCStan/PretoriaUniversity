using Microsoft.EntityFrameworkCore.Migrations;

namespace PretoriaUniversity.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "GendacProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GendacProducts",
                table: "GendacProducts",
                column: "Id");

            migrationBuilder.InsertData(
                table: "GendacProducts",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[] { 1, "CategoryA", "Stove", 10.00m });

            migrationBuilder.InsertData(
                table: "GendacProducts",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[] { 2, "CategoryB", "Fridge", 19.99m });

            migrationBuilder.InsertData(
                table: "GendacProducts",
                columns: new[] { "Id", "Category", "Name", "Price" },
                values: new object[] { 3, "CategoryA", "Stove", 29.99m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GendacProducts",
                table: "GendacProducts");

            migrationBuilder.DeleteData(
                table: "GendacProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GendacProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GendacProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "GendacProducts",
                newName: "Products");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");
        }
    }
}
