using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taller.Migrations
{
    public partial class tipoDoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoDocumentos_AspNetUsers_IdUsuarioId",
                table: "TipoDocumentos");

            migrationBuilder.RenameColumn(
                name: "IdUsuarioId",
                table: "TipoDocumentos",
                newName: "IdUserId");

            migrationBuilder.RenameIndex(
                name: "IX_TipoDocumentos_IdUsuarioId",
                table: "TipoDocumentos",
                newName: "IX_TipoDocumentos_IdUserId");

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

            migrationBuilder.RenameColumn(
                name: "IdUserId",
                table: "TipoDocumentos",
                newName: "IdUsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_TipoDocumentos_IdUserId",
                table: "TipoDocumentos",
                newName: "IX_TipoDocumentos_IdUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipoDocumentos_AspNetUsers_IdUsuarioId",
                table: "TipoDocumentos",
                column: "IdUsuarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
