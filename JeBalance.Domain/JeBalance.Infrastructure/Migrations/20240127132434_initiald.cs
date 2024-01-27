using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class initiald : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denonciations");

            migrationBuilder.DropTable(
                name: "Reponses");

            migrationBuilder.DropTable(
                name: "VIPs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Denonciations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    delit = table.Column<int>(type: "int", nullable: false),
                    horodatage = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idInformateur = table.Column<int>(type: "int", nullable: false),
                    idSuspect = table.Column<int>(type: "int", nullable: false),
                    statutInfo = table.Column<int>(type: "int", nullable: false),
                    statutSuspect = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denonciations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reponses",
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
                    table.PrimaryKey("PK_Reponses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VIPs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    statut = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPs", x => x.id);
                });
        }
    }
}
