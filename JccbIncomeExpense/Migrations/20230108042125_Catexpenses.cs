using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JccbIncomeExpense.Migrations
{
    public partial class Catexpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catexpenses",
                columns: table => new
                {
                    CatexpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Excategory = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catexpenses", x => x.CatexpenseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catexpenses");
        }
    }
}
