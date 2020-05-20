using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserStocksBroker.Migrations
{
    public partial class seeddata1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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
                    table.ForeignKey(
                        name: "FK_Stock_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "User",
                column: "Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "User",
                column: "Id",
                value: 3);

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "Id", "Buyer", "FullPrice", "Name", "Price", "Quantity", "Seller", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 71, DateTimeKind.Local).AddTicks(3921), 1 },
                    { 2, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8513), 1 },
                    { 3, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8617), 1 },
                    { 4, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8623), 2 },
                    { 5, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8626), 2 },
                    { 6, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8629), 2 },
                    { 7, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8632), 3 },
                    { 8, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8635), 3 },
                    { 9, "buyer", 1.1000000000000001, "flow", 1.0, 1, "seller", new DateTime(2020, 5, 20, 22, 23, 14, 73, DateTimeKind.Local).AddTicks(8638), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_UserId",
                table: "Stock",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
