using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCSH.Data.Migrations
{
    public partial class NewImageStoringSys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productImage",
                table: "Clothe");

            migrationBuilder.AddColumn<string>(
                name: "ProductImageURL",
                table: "Clothe",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImageURL",
                table: "Clothe");

            migrationBuilder.AddColumn<byte[]>(
                name: "productImage",
                table: "Clothe",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
