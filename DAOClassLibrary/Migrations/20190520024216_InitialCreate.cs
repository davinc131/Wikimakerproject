using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAOClassLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GetUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NomeUsuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GetDocumentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    CorpoDocumento = table.Column<string>(nullable: true),
                    Temporario = table.Column<short>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DocumentoId = table.Column<int>(nullable: true),
                    Aprovado = table.Column<int>(nullable: true),
                    IdDocOrigem = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetDocumentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetDocumentos_GetDocumentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "GetDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GetDocumentos_GetUsuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "GetUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataDocumento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    GetDate = table.Column<DateTime>(nullable: false),
                    DocumentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataDocumento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataDocumento_GetDocumentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "GetDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GetImagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NomeImagem = table.Column<string>(nullable: true),
                    CaminhoImagem = table.Column<string>(nullable: true),
                    ArrayByte = table.Column<byte[]>(nullable: true),
                    DocumentoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetImagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetImagens_GetDocumentos_DocumentoId",
                        column: x => x.DocumentoId,
                        principalTable: "GetDocumentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataDocumento_DocumentoId",
                table: "DataDocumento",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GetDocumentos_DocumentoId",
                table: "GetDocumentos",
                column: "DocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_GetDocumentos_UsuarioId",
                table: "GetDocumentos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_GetImagens_DocumentoId",
                table: "GetImagens",
                column: "DocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataDocumento");

            migrationBuilder.DropTable(
                name: "GetImagens");

            migrationBuilder.DropTable(
                name: "GetDocumentos");

            migrationBuilder.DropTable(
                name: "GetUsuarios");
        }
    }
}
