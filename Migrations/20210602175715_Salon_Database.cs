using Microsoft.EntityFrameworkCore.Migrations;

namespace Tema2_NoLogin.Migrations
{
    public partial class Salon_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_appintment_AppointmentId",
                table: "service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appintment",
                table: "appintment");

            migrationBuilder.RenameTable(
                name: "appintment",
                newName: "appointment");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_appointment",
                table: "appointment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_appointment_AppointmentId",
                table: "service",
                column: "AppointmentId",
                principalTable: "appointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_service_appointment_AppointmentId",
                table: "service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_appointment",
                table: "appointment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "user");

            migrationBuilder.RenameTable(
                name: "appointment",
                newName: "appintment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_appintment",
                table: "appintment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_service_appintment_AppointmentId",
                table: "service",
                column: "AppointmentId",
                principalTable: "appintment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
