using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JccbIncomeExpense.Migrations
{
    public partial class Incomecat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "incomecats",
                columns: table => new
                {
                    CIncomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icategory = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incomecats", x => x.CIncomeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incomecats");
        }
    }
}
