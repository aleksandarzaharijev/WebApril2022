using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brend",
                columns: table => new
                {
                    BrendID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brend", x => x.BrendID);
                });

            migrationBuilder.CreateTable(
                name: "Komponenta",
                columns: table => new
                {
                    KomponentaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<int>(type: "int", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komponenta", x => x.KomponentaID);
                });

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

            migrationBuilder.CreateTable(
                name: "Prodavnica",
                columns: table => new
                {
                    ProdavnicaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnica", x => x.ProdavnicaID);
                });

            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    TipID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.TipID);
                });

            migrationBuilder.CreateTable(
                name: "Spoj",
                columns: table => new
                {
                    SpojID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    KomponentaID = table.Column<int>(type: "int", nullable: true),
                    ProdavnicaID = table.Column<int>(type: "int", nullable: true),
                    KonfiguracijaID = table.Column<int>(type: "int", nullable: true),
                    TipID = table.Column<int>(type: "int", nullable: true),
                    BrendID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spoj", x => x.SpojID);
                    table.ForeignKey(
                        name: "FK_Spoj_Brend_BrendID",
                        column: x => x.BrendID,
                        principalTable: "Brend",
                        principalColumn: "BrendID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spoj_Komponenta_KomponentaID",
                        column: x => x.KomponentaID,
                        principalTable: "Komponenta",
                        principalColumn: "KomponentaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spoj_Konfiguracija_KonfiguracijaID",
                        column: x => x.KonfiguracijaID,
                        principalTable: "Konfiguracija",
                        principalColumn: "KonfiguracijaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spoj_Prodavnica_ProdavnicaID",
                        column: x => x.ProdavnicaID,
                        principalTable: "Prodavnica",
                        principalColumn: "ProdavnicaID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spoj_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "TipID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_BrendID",
                table: "Spoj",
                column: "BrendID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_KomponentaID",
                table: "Spoj",
                column: "KomponentaID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_KonfiguracijaID",
                table: "Spoj",
                column: "KonfiguracijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_ProdavnicaID",
                table: "Spoj",
                column: "ProdavnicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_TipID",
                table: "Spoj",
                column: "TipID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spoj");

            migrationBuilder.DropTable(
                name: "Brend");

            migrationBuilder.DropTable(
                name: "Komponenta");

            migrationBuilder.DropTable(
                name: "Konfiguracija");

            migrationBuilder.DropTable(
                name: "Prodavnica");

            migrationBuilder.DropTable(
                name: "Tip");
        }
    }
}
