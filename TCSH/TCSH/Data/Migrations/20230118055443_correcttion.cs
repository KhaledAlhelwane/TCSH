using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCSH.Data.Migrations
{
    public partial class correcttion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothe_AspNetUsers_ApplicationUserId",
                table: "Clothe");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "AgeType");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Clothe",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Type_Title",
                table: "AgeType",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothe_AspNetUsers_ApplicationUserId",
                table: "Clothe",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clothe_AspNetUsers_ApplicationUserId",
                table: "Clothe");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Clothe",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type_Title",
                table: "AgeType",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "AgeType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Clothe_AspNetUsers_ApplicationUserId",
                table: "Clothe",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
