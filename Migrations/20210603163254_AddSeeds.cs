using Microsoft.EntityFrameworkCore.Migrations;

namespace eudaci.Migrations
{
    public partial class AddSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pandemic_Country_CountryId",
                table: "Pandemic");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Country_CountryId",
                table: "Vaccination");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Vaccination",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Pandemic",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "GeographicLocation", "Name", "Population" },
                values: new object[] { 1, "Southwest", "Portugal", 10169411 });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "GeographicLocation", "Name", "Population" },
                values: new object[] { 2, "Southwest", "Spain", 46754778 });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "GeographicLocation", "Name", "Population" },
                values: new object[] { 3, "Center", "Germany", 84030279 });

            migrationBuilder.AddForeignKey(
                name: "FK_Pandemic_Country_CountryId",
                table: "Pandemic",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccination_Country_CountryId",
                table: "Vaccination",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pandemic_Country_CountryId",
                table: "Pandemic");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccination_Country_CountryId",
                table: "Vaccination");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Vaccination",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Pandemic",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
