using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientService.Migrations
{
    public partial class ClientSystemUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditorRequestId",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Comments",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ClientRequests");

            migrationBuilder.RenameColumn(
                name: "AuditorPortfolioId",
                table: "ClientRequests",
                newName: "AuditorPortfolioID");

            migrationBuilder.RenameColumn(
                name: "AuditorId",
                table: "ClientRequests",
                newName: "AuditorID");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "ClientRequests",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "AuditorPortfolioID",
                table: "ClientRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AuditorID",
                table: "ClientRequests",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "AuditRequestID",
                table: "ClientRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_Timestamp",
                table: "ClientRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Request",
                table: "ClientRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Request_Comment",
                table: "ClientRequests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Response_Comment",
                table: "ClientRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuditRequestID",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Created_Timestamp",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Request",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Request_Comment",
                table: "ClientRequests");

            migrationBuilder.DropColumn(
                name: "Response_Comment",
                table: "ClientRequests");

            migrationBuilder.RenameColumn(
                name: "AuditorPortfolioID",
                table: "ClientRequests",
                newName: "AuditorPortfolioId");

            migrationBuilder.RenameColumn(
                name: "AuditorID",
                table: "ClientRequests",
                newName: "AuditorId");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ClientRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AuditorPortfolioId",
                table: "ClientRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuditorId",
                table: "ClientRequests",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuditorRequestId",
                table: "ClientRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Comments",
                table: "ClientRequests",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ClientRequests",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ClientRequests",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
