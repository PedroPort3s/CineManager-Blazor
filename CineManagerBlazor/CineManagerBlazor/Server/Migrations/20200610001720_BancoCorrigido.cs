using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CineManagerBlazor.Server.Migrations
{
    public partial class BancoCorrigido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGeneros_Filme_FilmeId",
                table: "FilmeGeneros");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGeneros_Generos_GeneroId",
                table: "FilmeGeneros");

            migrationBuilder.DropTable(
                name: "FilmeTiposFilme");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGeneros",
                table: "FilmeGeneros");

            migrationBuilder.DropIndex(
                name: "IX_FilmeGeneros_FilmeId",
                table: "FilmeGeneros");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FilmeGeneros");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "FilmeGeneros",
                newName: "generoId");

            migrationBuilder.RenameColumn(
                name: "FilmeId",
                table: "FilmeGeneros",
                newName: "filmeId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeGeneros_GeneroId",
                table: "FilmeGeneros",
                newName: "IX_FilmeGeneros_generoId");

            migrationBuilder.AlterColumn<int>(
                name: "generoId",
                table: "FilmeGeneros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "filmeId",
                table: "FilmeGeneros",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGeneros",
                table: "FilmeGeneros",
                columns: new[] { "filmeId", "generoId" });

            migrationBuilder.CreateTable(
                name: "FilmesTipo",
                columns: table => new
                {
                    filmeId = table.Column<int>(nullable: false),
                    tipoFilmeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmesTipo", x => new { x.filmeId, x.tipoFilmeId });
                    table.ForeignKey(
                        name: "FK_FilmesTipo_Filme_filmeId",
                        column: x => x.filmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmesTipo_TipoFilmes_tipoFilmeId",
                        column: x => x.tipoFilmeId,
                        principalTable: "TipoFilmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmesTipo_tipoFilmeId",
                table: "FilmesTipo",
                column: "tipoFilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGeneros_Filme_filmeId",
                table: "FilmeGeneros",
                column: "filmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGeneros_Generos_generoId",
                table: "FilmeGeneros",
                column: "generoId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGeneros_Filme_filmeId",
                table: "FilmeGeneros");

            migrationBuilder.DropForeignKey(
                name: "FK_FilmeGeneros_Generos_generoId",
                table: "FilmeGeneros");

            migrationBuilder.DropTable(
                name: "FilmesTipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FilmeGeneros",
                table: "FilmeGeneros");

            migrationBuilder.RenameColumn(
                name: "generoId",
                table: "FilmeGeneros",
                newName: "GeneroId");

            migrationBuilder.RenameColumn(
                name: "filmeId",
                table: "FilmeGeneros",
                newName: "FilmeId");

            migrationBuilder.RenameIndex(
                name: "IX_FilmeGeneros_generoId",
                table: "FilmeGeneros",
                newName: "IX_FilmeGeneros_GeneroId");

            migrationBuilder.AlterColumn<int>(
                name: "GeneroId",
                table: "FilmeGeneros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "FilmeId",
                table: "FilmeGeneros",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FilmeGeneros",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FilmeGeneros",
                table: "FilmeGeneros",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FilmeTiposFilme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FilmeId = table.Column<int>(type: "int", nullable: true),
                    TipoFilmeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmeTiposFilme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmeTiposFilme_Filme_FilmeId",
                        column: x => x.FilmeId,
                        principalTable: "Filme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FilmeTiposFilme_TipoFilmes_TipoFilmeId",
                        column: x => x.TipoFilmeId,
                        principalTable: "TipoFilmes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmeGeneros_FilmeId",
                table: "FilmeGeneros",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeTiposFilme_FilmeId",
                table: "FilmeTiposFilme",
                column: "FilmeId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmeTiposFilme_TipoFilmeId",
                table: "FilmeTiposFilme",
                column: "TipoFilmeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGeneros_Filme_FilmeId",
                table: "FilmeGeneros",
                column: "FilmeId",
                principalTable: "Filme",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FilmeGeneros_Generos_GeneroId",
                table: "FilmeGeneros",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
