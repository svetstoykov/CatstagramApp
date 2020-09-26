using Microsoft.EntityFrameworkCore.Migrations;

namespace Catstagram.Server.Data.Migrations
{
    public partial class AddProfileDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile_Biography",
                table: "AspNetUsers",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Profile_Gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Profile_IsPrivateProfile",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Name",
                table: "AspNetUsers",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_ProfilePhotoUrl",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profile_Website",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile_Biography",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_IsPrivateProfile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_ProfilePhotoUrl",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Profile_Website",
                table: "AspNetUsers");
        }
    }
}
