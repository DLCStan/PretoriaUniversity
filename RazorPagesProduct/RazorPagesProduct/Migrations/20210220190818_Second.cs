using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesProduct.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Category", "Name" },
                values: new object[,]
                {
                    { 1, "CategoryA", "Stove" },
                    { 2, "CategoryB", "Fridge" },
                    { 3, "CategoryC", "TV" },
                    { 4, "CategoryA", "Sofa" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
