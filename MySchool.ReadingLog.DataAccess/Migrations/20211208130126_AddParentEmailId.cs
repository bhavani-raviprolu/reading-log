using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.ReadingLog.DataAccess.Migrations
{
    public partial class AddParentEmailId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentEmailId",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentEmailId",
                table: "Students");
        }
    }
}
