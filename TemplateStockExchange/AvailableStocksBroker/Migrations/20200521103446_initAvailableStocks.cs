using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AvailableStocksBroker.Migrations
{
    public partial class initAvailableStocks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableStocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    FullPrice = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableStocks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableStocks");
        }
    }
}
