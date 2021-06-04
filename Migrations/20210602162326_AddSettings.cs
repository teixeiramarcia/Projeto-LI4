using Microsoft.EntityFrameworkCore.Migrations;

namespace eudaci.Migrations
{
    public partial class AddSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notifications = table.Column<bool>(type: "bit", nullable: false),
                    Sugestions = table.Column<bool>(type: "bit", nullable: false),
                    NotifyVaccination = table.Column<bool>(type: "bit", nullable: false),
                    NotifyPandemic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
