using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JccbIncomeExpense.Migrations
{
    public partial class myexpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "myexpenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Expname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpAmount = table.Column<float>(type: "real", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Excategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datedexp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myexpenses", x => x.ExpenseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "myexpenses");
        }
    }
}
