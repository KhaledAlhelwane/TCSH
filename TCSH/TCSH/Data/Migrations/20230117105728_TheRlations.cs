using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCSH.Data.Migrations
{
    public partial class TheRlations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgeType",
                columns: table => new
                {
                    AgeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyProperty = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeType", x => x.AgeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfClothe",
                columns: table => new
                {
                    TypeOfClotheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfClothe", x => x.TypeOfClotheId);
                });

            migrationBuilder.CreateTable(
                name: "Clothe",
                columns: table => new
                {
                    ClotheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Market = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SaleRate = table.Column<float>(type: "real", nullable: false),
                    MostPopular = table.Column<bool>(type: "bit", nullable: false),
                    CareInstruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatrialComposition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditonalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productImage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AgeTypeId = table.Column<int>(type: "int", nullable: false),
                    TypeOfClotheId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothe", x => x.ClotheId);
                    table.ForeignKey(
                        name: "FK_Clothe_AgeType_AgeTypeId",
                        column: x => x.AgeTypeId,
                        principalTable: "AgeType",
                        principalColumn: "AgeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothe_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clothe_TypeOfClothe_TypeOfClotheId",
                        column: x => x.TypeOfClotheId,
                        principalTable: "TypeOfClothe",
                        principalColumn: "TypeOfClotheId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddtionalPicture",
                columns: table => new
                {
                    AddtionalPictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ClotheId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddtionalPicture", x => x.AddtionalPictureId);
                    table.ForeignKey(
                        name: "FK_AddtionalPicture_Clothe_ClotheId",
                        column: x => x.ClotheId,
                        principalTable: "Clothe",
                        principalColumn: "ClotheId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddtionalPicture_ClotheId",
                table: "AddtionalPicture",
                column: "ClotheId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_AgeTypeId",
                table: "Clothe",
                column: "AgeTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_ApplicationUserId",
                table: "Clothe",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Clothe_TypeOfClotheId",
                table: "Clothe",
                column: "TypeOfClotheId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddtionalPicture");

            migrationBuilder.DropTable(
                name: "Clothe");

            migrationBuilder.DropTable(
                name: "AgeType");

            migrationBuilder.DropTable(
                name: "TypeOfClothe");
        }
    }
}
