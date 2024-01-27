using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class initialDenonciation11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_InformateurId",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.DropForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_SuspectId",
                schema: "app",
                table: "DENONCIATIONS");

            migrationBuilder.RenameColumn(
                name: "SuspectId",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "fk_suspect");

            migrationBuilder.RenameColumn(
                name: "InformateurId",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "fk_informateur");

            migrationBuilder.RenameIndex(
                name: "IX_DENONCIATIONS_SuspectId",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "IX_DENONCIATIONS_fk_suspect");

            migrationBuilder.RenameIndex(
                name: "IX_DENONCIATIONS_InformateurId",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "IX_DENONCIATIONS_fk_informateur");

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

            migrationBuilder.RenameColumn(
                name: "fk_suspect",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "SuspectId");

            migrationBuilder.RenameColumn(
                name: "fk_informateur",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "InformateurId");

            migrationBuilder.RenameIndex(
                name: "IX_DENONCIATIONS_fk_suspect",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "IX_DENONCIATIONS_SuspectId");

            migrationBuilder.RenameIndex(
                name: "IX_DENONCIATIONS_fk_informateur",
                schema: "app",
                table: "DENONCIATIONS",
                newName: "IX_DENONCIATIONS_InformateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_InformateurId",
                schema: "app",
                table: "DENONCIATIONS",
                column: "InformateurId",
                principalSchema: "app",
                principalTable: "PERSONNES",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DENONCIATIONS_PERSONNES_SuspectId",
                schema: "app",
                table: "DENONCIATIONS",
                column: "SuspectId",
                principalSchema: "app",
                principalTable: "PERSONNES",
                principalColumn: "id");
        }
    }
}
