using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientService.Migrations
{
    public partial class Columnrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ClientResponses");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "ClientResponses");

            migrationBuilder.DropColumn(
                name: "AuditorPortfolioID",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Request_Comment",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Response_Comment",
                table: "ClientRequests");

            migrationBuilder.AddColumn<string>(
                name: "Doc_Name",
                table: "ClientResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Doc_Path",
                table: "ClientResponses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditPortfolioID",
                table: "ClientRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doc_Name",
                table: "ClientResponses");

            migrationBuilder.DropColumn(
                name: "Doc_Path",
                table: "ClientResponses");

            migrationBuilder.DropColumn(
                name: "AuditPortfolioID",
                table: "ClientRequests");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ClientResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "ClientResponses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuditorPortfolioID",
                table: "ClientRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Request_Comment",
                table: "ClientRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response_Comment",
                table: "ClientRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
