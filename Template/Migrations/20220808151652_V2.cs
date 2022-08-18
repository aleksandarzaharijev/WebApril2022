using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_Konfiguracija_KonfiguracijaID",
                table: "Spoj");

            migrationBuilder.DropTable(
                name: "Konfiguracija");

            migrationBuilder.DropIndex(
                name: "IX_Spoj_KonfiguracijaID",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "KonfiguracijaID",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "Komponenta");

            migrationBuilder.AddColumn<int>(
                name: "Sifra",
                table: "Spoj",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BrendID",
                table: "Komponenta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipID",
                table: "Komponenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Komponenta_BrendID",
                table: "Komponenta",
                column: "BrendID");

            migrationBuilder.CreateIndex(
                name: "IX_Komponenta_TipID",
                table: "Komponenta",
                column: "TipID");

            migrationBuilder.AddForeignKey(
                name: "FK_Komponenta_Brend_BrendID",
                table: "Komponenta",
                column: "BrendID",
                principalTable: "Brend",
                principalColumn: "BrendID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Komponenta_Tip_TipID",
                table: "Komponenta",
                column: "TipID",
                principalTable: "Tip",
                principalColumn: "TipID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komponenta_Brend_BrendID",
                table: "Komponenta");

            migrationBuilder.DropForeignKey(
                name: "FK_Komponenta_Tip_TipID",
                table: "Komponenta");

            migrationBuilder.DropIndex(
                name: "IX_Komponenta_BrendID",
                table: "Komponenta");

            migrationBuilder.DropIndex(
                name: "IX_Komponenta_TipID",
                table: "Komponenta");

            migrationBuilder.DropColumn(
                name: "Sifra",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "BrendID",
                table: "Komponenta");

            migrationBuilder.DropColumn(
                name: "TipID",
                table: "Komponenta");

            migrationBuilder.AddColumn<int>(
                name: "KonfiguracijaID",
                table: "Spoj",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sifra",
                table: "Komponenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Konfiguracija",
                columns: table => new
                {
                    KonfiguracijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KolicinaKomponenti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konfiguracija", x => x.KonfiguracijaID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_KonfiguracijaID",
                table: "Spoj",
                column: "KonfiguracijaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_Konfiguracija_KonfiguracijaID",
                table: "Spoj",
                column: "KonfiguracijaID",
                principalTable: "Konfiguracija",
                principalColumn: "KonfiguracijaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
