using Microsoft.EntityFrameworkCore.Migrations;

namespace eudaci.Migrations
{
    public partial class UpdateRelantionships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pandemic_Country_countryId",
                table: "Pandemic");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Country_countryId",
                table: "Vaccination");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Vaccination",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccination_countryId",
                table: "Vaccination",
                newName: "IX_Vaccination_CountryId");

            migrationBuilder.RenameColumn(
                name: "countryId",
                table: "Pandemic",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pandemic_countryId",
                table: "Pandemic",
                newName: "IX_Pandemic_CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pandemic_Country_CountryId",
                table: "Pandemic",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccination_Country_CountryId",
                table: "Vaccination",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pandemic_Country_CountryId",
                table: "Pandemic");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Country_CountryId",
                table: "Vaccination");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Vaccination",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccination_CountryId",
                table: "Vaccination",
                newName: "IX_Vaccination_countryId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Pandemic",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pandemic_CountryId",
                table: "Pandemic",
                newName: "IX_Pandemic_countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pandemic_Country_countryId",
                table: "Pandemic",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccination_Country_countryId",
                table: "Vaccination",
                column: "countryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
