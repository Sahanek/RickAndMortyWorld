using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class DeleteBeh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserCharacters_Characters_CharacterId",
                table: "AppUserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserCharacters_Characters_CharacterId",
                table: "AppUserCharacters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserCharacters_Characters_CharacterId",
                table: "AppUserCharacters");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserCharacters_Characters_CharacterId",
                table: "AppUserCharacters",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
