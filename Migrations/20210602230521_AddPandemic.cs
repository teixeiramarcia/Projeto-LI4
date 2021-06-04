using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eudaci.Migrations
{
    public partial class AddPandemic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pandemic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Infected = table.Column<int>(type: "int", nullable: false),
                    Recovered = table.Column<int>(type: "int", nullable: false),
                    Hospitalisations = table.Column<int>(type: "int", nullable: false),
                    countryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pandemic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pandemic_Country_countryId",
                        column: x => x.countryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pandemic_countryId",
                table: "Pandemic",
                column: "countryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pandemic");
        }
    }
}
