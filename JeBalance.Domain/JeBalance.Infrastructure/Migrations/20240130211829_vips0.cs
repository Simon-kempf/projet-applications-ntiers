using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class vips0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "DENONCIATIONS",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delit = table.Column<int>(type: "int", nullable: false),
                    statutInfo = table.Column<int>(type: "int", nullable: false),
                    statutSuspect = table.Column<int>(type: "int", nullable: false),
                    horodatage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paysEvasion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    informateur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    suspect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reponse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estTraitee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENONCIATIONS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PERSONNES",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    statut = table.Column<int>(type: "int", nullable: false),
                    estVIP = table.Column<int>(type: "int", nullable: false),
                    estCalomniateur = table.Column<int>(type: "int", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSONNES", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENONCIATIONS",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PERSONNES",
                schema: "app");
        }
    }
}
