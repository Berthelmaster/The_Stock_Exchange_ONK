using Microsoft.EntityFrameworkCore.Migrations;

namespace TobinTaxControl.Migrations
{
    public partial class tobintaxmig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Stock");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Balance",
                table: "Stock",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
