using Microsoft.EntityFrameworkCore.Migrations;

namespace RASCH_FLOTILLAS.Migrations
{
    public partial class AddTableTypeMaintenancesIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeMaintenances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMaintenances", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeMaintenances_Description",
                table: "TypeMaintenances",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeMaintenances");
        }
    }
}
