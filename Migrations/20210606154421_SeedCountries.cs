using Microsoft.EntityFrameworkCore.Migrations;

namespace eudaci.Migrations
{
    public partial class SeedCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "Population",
                value: 10196709);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "Population",
                value: 84031009);

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "GeographicLocation", "Name", "Population" },
                values: new object[,]
                {
                    { 27, "North", "Sweden", 10099265 },
                    { 26, "Center", "Slovenia", 2079202 },
                    { 25, "Center", "Slovakia", 5462090 },
                    { 24, "Southeast", "Romania", 19237691 },
                    { 23, "Center", "Poland", 37846611 },
                    { 22, "Northwest", "Netherlands", 17169846 },
                    { 21, "South", "Malta", 441543 },
                    { 20, "Northwest", "Luxembourg", 625978 },
                    { 19, "East", "Lithuania", 2722289 },
                    { 18, "Northwest", "Latvia", 1886198 },
                    { 17, "South", "Italy", 60379497 },
                    { 16, "Northwest", "Ireland", 4937786 },
                    { 14, "Southeast", "Greece", 10423054 },
                    { 13, "West", "France", 65406747 },
                    { 12, "North", "Finland", 5548661 },
                    { 11, "Northeast", "Estonia", 1326535 },
                    { 10, "North", "Denmark", 5792202 },
                    { 9, "Center", "Czechia", 10727309 },
                    { 8, "East", "Cyprus", 1215480 },
                    { 7, "Northwest", "Croatia", 4105267 },
                    { 6, "Southeast", "Bulgaria", 6948445 },
                    { 5, "West", "Belgium", 11589623 },
                    { 15, "Center", "Hungary", 9637630 },
                    { 4, "Center", "Austria", 9053899 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 1,
                column: "Population",
                value: 10169411);

            migrationBuilder.UpdateData(
                table: "Country",
                keyColumn: "Id",
                keyValue: 3,
                column: "Population",
                value: 84030279);
        }
    }
}
