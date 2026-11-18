using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nepremicnine_RGIS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uporabniki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UporabniskoIme = table.Column<string>(type: "TEXT", nullable: false),
                    GesloHash = table.Column<string>(type: "TEXT", nullable: false),
                    Vloga = table.Column<int>(type: "INTEGER", nullable: false),
                    Lokacija = table.Column<string>(type: "TEXT", nullable: true),
                    LahkoObjavlja = table.Column<bool>(type: "INTEGER", nullable: false),
                    DatumUstvarjanja = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabniki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlokiraniUporabniki",
                columns: table => new
                {
                    BlokerId = table.Column<int>(type: "INTEGER", nullable: false),
                    BlokiranId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlokiraniUporabniki", x => new { x.BlokerId, x.BlokiranId });
                    table.ForeignKey(
                        name: "FK_BlokiraniUporabniki_Uporabniki_BlokerId",
                        column: x => x.BlokerId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlokiraniUporabniki_Uporabniki_BlokiranId",
                        column: x => x.BlokiranId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Oglasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProdajalecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Naslov = table.Column<string>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: false),
                    Cena = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lokacija = table.Column<string>(type: "TEXT", nullable: false),
                    Kvadratura = table.Column<double>(type: "REAL", nullable: false),
                    StevilоSob = table.Column<int>(type: "INTEGER", nullable: false),
                    Tip = table.Column<int>(type: "INTEGER", nullable: false),
                    DatumVselitve = table.Column<DateTime>(type: "TEXT", nullable: true),
                    JeOddano = table.Column<bool>(type: "INTEGER", nullable: false),
                    SteviloOgledov = table.Column<int>(type: "INTEGER", nullable: false),
                    DatumObjave = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oglasi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oglasi_Uporabniki_ProdajalecId",
                        column: x => x.ProdajalecId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShranjenaIskanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UporabnikId = table.Column<int>(type: "INTEGER", nullable: false),
                    Iskalniniz = table.Column<string>(type: "TEXT", nullable: true),
                    MinCena = table.Column<decimal>(type: "TEXT", nullable: true),
                    MaxCena = table.Column<decimal>(type: "TEXT", nullable: true),
                    MinKvadratura = table.Column<double>(type: "REAL", nullable: true),
                    MaxKvadratura = table.Column<double>(type: "REAL", nullable: true),
                    StevilоSob = table.Column<int>(type: "INTEGER", nullable: true),
                    Tip = table.Column<int>(type: "INTEGER", nullable: true),
                    ObvestilaVklopljena = table.Column<bool>(type: "INTEGER", nullable: false),
                    DatumShranjevanja = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShranjenaIskanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShranjenaIskanja_Uporabniki_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ocene",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AvtorId = table.Column<int>(type: "INTEGER", nullable: false),
                    OglasId = table.Column<int>(type: "INTEGER", nullable: true),
                    OcenjeniUporabnikId = table.Column<int>(type: "INTEGER", nullable: true),
                    Zvezdice = table.Column<int>(type: "INTEGER", nullable: false),
                    DatumOcene = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocene", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ocene_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ocene_Uporabniki_AvtorId",
                        column: x => x.AvtorId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ocene_Uporabniki_OcenjeniUporabnikId",
                        column: x => x.OcenjeniUporabnikId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Povprasevanja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OglasId = table.Column<int>(type: "INTEGER", nullable: false),
                    KupecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Sporocilo = table.Column<string>(type: "TEXT", nullable: false),
                    Odgovor = table.Column<string>(type: "TEXT", nullable: true),
                    DatumOddaje = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Povprasevanja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Povprasevanja_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Povprasevanja_Uporabniki_KupecId",
                        column: x => x.KupecId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prijave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OglasId = table.Column<int>(type: "INTEGER", nullable: false),
                    PrijaviteljId = table.Column<int>(type: "INTEGER", nullable: false),
                    Razlog = table.Column<string>(type: "TEXT", nullable: false),
                    DatumPrijave = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijave", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prijave_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prijave_Uporabniki_PrijaviteljId",
                        column: x => x.PrijaviteljId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Priljubljeni",
                columns: table => new
                {
                    UporabnikId = table.Column<int>(type: "INTEGER", nullable: false),
                    OglasId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priljubljeni", x => new { x.UporabnikId, x.OglasId });
                    table.ForeignKey(
                        name: "FK_Priljubljeni_Oglasi_OglasId",
                        column: x => x.OglasId,
                        principalTable: "Oglasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Priljubljeni_Uporabniki_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlokiraniUporabniki_BlokiranId",
                table: "BlokiraniUporabniki",
                column: "BlokiranId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_AvtorId",
                table: "Ocene",
                column: "AvtorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_OcenjeniUporabnikId",
                table: "Ocene",
                column: "OcenjeniUporabnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocene_OglasId",
                table: "Ocene",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_Oglasi_ProdajalecId",
                table: "Oglasi",
                column: "ProdajalecId");

            migrationBuilder.CreateIndex(
                name: "IX_Povprasevanja_KupecId",
                table: "Povprasevanja",
                column: "KupecId");

            migrationBuilder.CreateIndex(
                name: "IX_Povprasevanja_OglasId",
                table: "Povprasevanja",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijave_OglasId",
                table: "Prijave",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_Prijave_PrijaviteljId",
                table: "Prijave",
                column: "PrijaviteljId");

            migrationBuilder.CreateIndex(
                name: "IX_Priljubljeni_OglasId",
                table: "Priljubljeni",
                column: "OglasId");

            migrationBuilder.CreateIndex(
                name: "IX_ShranjenaIskanja_UporabnikId",
                table: "ShranjenaIskanja",
                column: "UporabnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Uporabniki_UporabniskoIme",
                table: "Uporabniki",
                column: "UporabniskoIme",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlokiraniUporabniki");

            migrationBuilder.DropTable(
                name: "Ocene");

            migrationBuilder.DropTable(
                name: "Povprasevanja");

            migrationBuilder.DropTable(
                name: "Prijave");

            migrationBuilder.DropTable(
                name: "Priljubljeni");

            migrationBuilder.DropTable(
                name: "ShranjenaIskanja");

            migrationBuilder.DropTable(
                name: "Oglasi");

            migrationBuilder.DropTable(
                name: "Uporabniki");
        }
    }
}
