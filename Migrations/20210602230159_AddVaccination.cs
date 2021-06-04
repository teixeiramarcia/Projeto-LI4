using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eudaci.Migrations
{
    public partial class AddVaccination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityFirstDose = table.Column<int>(type: "int", nullable: false),
                    QuantitySecondDose = table.Column<int>(type: "int", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccination_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccination_countryId",
                table: "Vaccination",
                column: "countryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaccination");
        }
    }
}
