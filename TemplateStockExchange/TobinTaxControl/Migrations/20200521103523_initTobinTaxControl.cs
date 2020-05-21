using Microsoft.EntityFrameworkCore.Migrations;

namespace TobinTaxControl.Migrations
{
    public partial class initTobinTaxControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(nullable: true),
                    StockId = table.Column<int>(nullable: false),
                    CurrentStockPrice = table.Column<double>(nullable: false),
                    AmountSubtracted = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
