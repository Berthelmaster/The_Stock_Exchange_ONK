using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserStocksBroker.Migrations
{
    public partial class seeddata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    FullPrice = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Seller = table.Column<string>(nullable: true),
                    Buyer = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Buyer", "FullPrice", "Name", "Price", "Quantity", "Seller", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 125, DateTimeKind.Local).AddTicks(2366), 1 },
                    { 2, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6732), 1 },
                    { 3, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6840), 1 },
                    { 4, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6848), 2 },
                    { 5, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6851), 2 },
                    { 6, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6855), 2 },
                    { 7, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6858), 3 },
                    { 8, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6861), 3 },
                    { 9, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 21, 3, 13, 127, DateTimeKind.Local).AddTicks(6864), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
