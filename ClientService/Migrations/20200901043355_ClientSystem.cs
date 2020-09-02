using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientService.Migrations
{
    public partial class ClientSystem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditorId = table.Column<string>(maxLength: 50, nullable: false),
                    AuditorPortfolioId = table.Column<int>(nullable: false),
                    AuditorRequestId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    Comments = table.Column<string>(maxLength: 300, nullable: true),
                    ClientId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientResponses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuditRequestID = table.Column<string>(nullable: true),
                    AuditPortfolioID = table.Column<string>(nullable: true),
                    AuditorID = table.Column<string>(nullable: true),
                    ClientId = table.Column<int>(nullable: false),
                    Request = table.Column<string>(nullable: true),
                    Created_Timestamp = table.Column<DateTime>(nullable: false),
                    ImageName = table.Column<string>(maxLength: 50, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    UserRoleType = table.Column<string>(nullable: true),
                    Created_Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientRequests");

            migrationBuilder.DropTable(
                name: "ClientResponses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
