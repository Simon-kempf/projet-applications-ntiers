using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class initialDenonciation6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_informateur",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_suspect",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_informateur",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_informateur",
                principalSchema: "app",
                principalTable: "PERSONNES",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_suspect",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_suspect",
                principalSchema: "app",
                principalTable: "PERSONNES",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_informateur",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_suspect",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_informateur",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_informateur",
                principalSchema: "app",
                principalTable: "PERSONNES",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_fk_suspect",
                schema: "app",
                table: "DENONCIATIONS",
                column: "fk_suspect",
                principalSchema: "app",
                principalTable: "PERSONNES",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
