using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserStocksBroker.Migrations
{
    public partial class initUserStocksBroker : Migration
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
                columns: new[] { "Id", "FullPrice", "Name", "Price", "Quantity", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 606, DateTimeKind.Local).AddTicks(3638), 1 },
                    { 2, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 610, DateTimeKind.Local).AddTicks(9986), 1 },
                    { 3, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(106), 1 },
                    { 4, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(115), 2 },
                    { 5, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(119), 2 },
                    { 6, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(122), 2 },
                    { 7, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(127), 3 },
                    { 8, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(131), 3 },
                    { 9, 1.1000000000000001, "flow", 1.0, 1, new DateTime(2020, 5, 21, 12, 36, 20, 611, DateTimeKind.Local).AddTicks(191), 3 }
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
