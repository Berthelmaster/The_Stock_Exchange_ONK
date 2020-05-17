using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockShareRequester.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Seller = table.Column<string>(nullable: true),
                    Buyer = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "something@gmail.com", "Florent", "123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "thom@gmail.com", "Thomas", "123456" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 3, "ras@gmail.com", "Rasmus", "123456" });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Buyer", "Name", "Price", "Quantity", "Seller", "TimeStamp", "UserId" },
                values: new object[,]
                {
                    { 1, "flow", "Vestas", 1, 3, "ras", new DateTime(2020, 5, 17, 21, 29, 20, 697, DateTimeKind.Local).AddTicks(9584), 1 },
                    { 2, "flow", "Novo", 11, 5, "thom", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7292), 1 },
                    { 3, "flow", "Maersk", 111, 10, "ras", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7457), 1 },
                    { 4, "ras", "Marcus", 1, 7, "flow", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7466), 2 },
                    { 5, "ras", "Aarhus University", 11, 12, "thom", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7470), 2 },
                    { 6, "ras", "Shit", 111, 10, "thom", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7474), 2 },
                    { 7, "thom", "LOL", 1, 10, "flow", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7477), 3 },
                    { 8, "thom", "Testing", 11, 20, "ras", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7481), 3 },
                    { 9, "thom", "Systematic", 111, 25, "ras", new DateTime(2020, 5, 17, 21, 29, 20, 702, DateTimeKind.Local).AddTicks(7485), 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UserId",
                table: "Stocks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
