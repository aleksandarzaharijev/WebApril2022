using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_Brend_BrendID",
                table: "Spoj");

            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_Tip_TipID",
                table: "Spoj");

            migrationBuilder.DropIndex(
                name: "IX_Spoj_BrendID",
                table: "Spoj");

            migrationBuilder.DropIndex(
                name: "IX_Spoj_TipID",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "BrendID",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "TipID",
                table: "Spoj");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrendID",
                table: "Spoj",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipID",
                table: "Spoj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_BrendID",
                table: "Spoj",
                column: "BrendID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_TipID",
                table: "Spoj",
                column: "TipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_Brend_BrendID",
                table: "Spoj",
                column: "BrendID",
                principalTable: "Brend",
                principalColumn: "BrendID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_Tip_TipID",
                table: "Spoj",
                column: "TipID",
                principalTable: "Tip",
                principalColumn: "TipID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
