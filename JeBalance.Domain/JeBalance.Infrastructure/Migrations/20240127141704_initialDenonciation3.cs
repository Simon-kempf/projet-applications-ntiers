using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class initialDenonciation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_ReponseSQLS_fk_reponse",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.DropTable(
                name: "ReponseSQLS");

            migrationBuilder.DropIndex(
                name: "IX_DENONCIATIONS_fk_reponse",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.DropColumn(
                name: "fk_reponse",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.AddColumn<string>(
                name: "reponse",
                schema: "app",
                table: "DENONCIATIONS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reponse",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.AddColumn<int>(
                name: "fk_reponse",
                schema: "app",
                table: "DENONCIATIONS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ReponseSQLS",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    horodatage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    retribution = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReponseSQLS", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_reponse",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_reponse");

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_ReponseSQLS_fk_reponse",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_reponse",
                principalTable: "ReponseSQLS",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
