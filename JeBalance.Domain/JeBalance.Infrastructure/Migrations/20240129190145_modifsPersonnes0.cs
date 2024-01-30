using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class modifsPersonnes0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "adresse",
                schema: "app",
                table: "PERSONNES",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "estCalomniateur",
                schema: "app",
                table: "PERSONNES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "estVIP",
                schema: "app",
                table: "PERSONNES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "role",
                schema: "app",
                table: "PERSONNES",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estCalomniateur",
                schema: "app",
                table: "PERSONNES");

            migrationBuilder.DropColumn(
                name: "estVIP",
                schema: "app",
                table: "PERSONNES");

            migrationBuilder.DropColumn(
                name: "role",
                schema: "app",
                table: "PERSONNES");

            migrationBuilder.AlterColumn<string>(
                name: "adresse",
                schema: "app",
                table: "PERSONNES",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);
        }
    }
}
