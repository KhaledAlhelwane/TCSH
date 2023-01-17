using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCSH.Data.Migrations
{
    public partial class InvokePrvilige : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [Locstion], [ProfilePicture], [SecoundName]) VALUES (N'748194b1-2eda-44c5-b826-34b86c4db06b', N'Admin@admin.com', N'ADMIN@ADMIN.COM', N'Admin@admin.com', N'ADMIN@ADMIN.COM', 1, N'AQAAAAEAACcQAAAAEB88edDhwznSmy6s5yDeMYhKuU/veAWzIqGUErhjr24UI9qPs3swmUBUwKwTBe55HA==', N'JYIMTZEXQKZY744IWHTFPJM3A7HWYA4M', N'acacdeb1-5ab6-466f-b840-dbd451bbbf4e', NULL, 0, 0, NULL, 1, 0, NULL, NULL, Null, NULL)\r\n");
            migrationBuilder.Sql("Insert INTO [dbo].[AspNetUserRoles](UserId,RoleId) SELECT '748194b1-2eda-44c5-b826-34b86c4db06b',Id FROM [dbo].[AspNetRoles] ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
