using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do_List_Backend.Migrations
{
    public partial class Todo_Add_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Todo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Todo");
        }
    }
}
