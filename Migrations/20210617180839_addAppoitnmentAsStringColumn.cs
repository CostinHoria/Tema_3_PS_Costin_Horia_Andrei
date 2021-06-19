using Microsoft.EntityFrameworkCore.Migrations;

namespace Tema2_NoLogin.Migrations
{
    public partial class addAppoitnmentAsStringColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentAsString",
                table: "appointment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentAsString",
                table: "appointment");
        }
    }
}
