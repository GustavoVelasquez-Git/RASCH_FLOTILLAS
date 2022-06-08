﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace RASCH_FLOTILLAS.Migrations
{
    public partial class AddTableTypesVehiclesIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypesVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesVehicles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypesVehicles_Description",
                table: "TypesVehicles",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypesVehicles");
        }
    }
}
