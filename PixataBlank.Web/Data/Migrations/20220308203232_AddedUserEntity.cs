using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixataBlank.Web.Data.Migrations {
  public partial class AddedUserEntity : Migration {
    protected override void Up(MigrationBuilder migrationBuilder) {
      migrationBuilder.AddColumn<string>(
        name: "FirstName",
        table: "AspNetUsers",
        type: "nvarchar(max)",
        nullable: false,
        defaultValue: "");

      migrationBuilder.AddColumn<string>(
        name: "Surname",
        table: "AspNetUsers",
        type: "nvarchar(max)",
        nullable: false,
        defaultValue: "");
    }

    protected override void Down(MigrationBuilder migrationBuilder) {
      migrationBuilder.DropColumn(
        name: "FirstName",
        table: "AspNetUsers");

      migrationBuilder.DropColumn(
        name: "Surname",
        table: "AspNetUsers");
    }
  }
}