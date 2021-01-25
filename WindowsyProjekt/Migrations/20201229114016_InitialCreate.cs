using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WindowsyProjekt.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetCordX = table.Column<string>(nullable: true),
                    StreetCordY = table.Column<string>(nullable: true),
                    Additional = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    PersonName = table.Column<string>(maxLength: 100, nullable: true),
                    Hash = table.Column<string>(maxLength: 36, nullable: false, defaultValue: ""),
                    DeleteAccountDate = table.Column<DateTime>(nullable: true),
                    CreateAccountDate = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 12, nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 6, nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    IsVerified = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Streets_Id",
                table: "Streets",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Hash",
                table: "Users",
                column: "Hash",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streets");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
