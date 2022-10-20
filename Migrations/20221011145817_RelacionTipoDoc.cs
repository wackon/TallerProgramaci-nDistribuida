using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller.Migrations
{
    public partial class RelacionTipoDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoDocumentos_IdTipoDoc",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdTipoDoc",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdTipoDoc",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "IdUserId",
                table: "TipoDocumentos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDocumentos_IdUserId",
                table: "TipoDocumentos",
                column: "IdUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDocumentos_AspNetUsers_IdUserId",
                table: "TipoDocumentos",
                column: "IdUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDocumentos_AspNetUsers_IdUserId",
                table: "TipoDocumentos");

            migrationBuilder.DropIndex(
                name: "IX_TipoDocumentos_IdUserId",
                table: "TipoDocumentos");

            migrationBuilder.DropColumn(
                name: "IdUserId",
                table: "TipoDocumentos");

            migrationBuilder.AddColumn<int>(
                name: "IdTipoDoc",
                table: "AspNetUsers",
                type: "int",
                maxLength: 6,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdTipoDoc",
                table: "AspNetUsers",
                column: "IdTipoDoc");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoDocumentos_IdTipoDoc",
                table: "AspNetUsers",
                column: "IdTipoDoc",
                principalTable: "TipoDocumentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
