using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCSH.Data.Migrations
{
    public partial class BSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 1,
                column: "Type_Title",
                value: "(11-12)");

            migrationBuilder.InsertData(
                table: "AgeType",
                columns: new[] { "AgeTypeId", "Type_Title" },
                values: new object[,]
                {
                    { 2, "(12-13)" },
                    { 3, "(13-14)" },
                    { 4, "(14-15)" },
                    { 5, "(15-16)" },
                    { 6, "(16-17)" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfClothe",
                columns: new[] { "TypeOfClotheId", "TypeOfTitle" },
                values: new object[,]
                {
                    { 1, "Scarf" },
                    { 2, "Jeans" },
                    { 3, "Pants" },
                    { 4, "Tishirt" },
                    { 5, "Socks" },
                    { 6, "Sweater" },
                    { 7, "Twins" },
                    { 8, "Hat" },
                    { 9, "Jacket" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TypeOfClothe",
                keyColumn: "TypeOfClotheId",
                keyValue: 9);

            migrationBuilder.UpdateData(
                table: "AgeType",
                keyColumn: "AgeTypeId",
                keyValue: 1,
                column: "Type_Title",
                value: "Jeans");
        }
    }
}
