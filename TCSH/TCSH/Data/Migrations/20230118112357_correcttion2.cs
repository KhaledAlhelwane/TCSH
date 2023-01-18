using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCSH.Data.Migrations
{
    public partial class correcttion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clothe_AgeTypeId",
                table: "Clothe");

            migrationBuilder.DropIndex(
                name: "IX_Clothe_TypeOfClotheId",
                table: "Clothe");

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_AgeTypeId",
                table: "Clothe",
                column: "AgeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_TypeOfClotheId",
                table: "Clothe",
                column: "TypeOfClotheId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clothe_AgeTypeId",
                table: "Clothe");

            migrationBuilder.DropIndex(
                name: "IX_Clothe_TypeOfClotheId",
                table: "Clothe");

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_AgeTypeId",
                table: "Clothe",
                column: "AgeTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_TypeOfClotheId",
                table: "Clothe",
                column: "TypeOfClotheId",
                unique: true);
        }
    }
}
