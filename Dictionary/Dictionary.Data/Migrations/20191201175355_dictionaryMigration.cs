using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dictionary.Data.Migrations
{
    public partial class dictionaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Explanations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Meaning = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Explanations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageOrigins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Origin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageOrigins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UkranianIdioms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UkranianEquivalent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UkranianIdioms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsageType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnglishIdioms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Phrase = table.Column<string>(nullable: true),
                    LanguageOriginId = table.Column<int>(nullable: true),
                    UkranianIdiomId = table.Column<int>(nullable: true),
                    UsageId = table.Column<int>(nullable: true),
                    ExplanationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishIdioms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnglishIdioms_Explanations_ExplanationId",
                        column: x => x.ExplanationId,
                        principalTable: "Explanations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnglishIdioms_LanguageOrigins_LanguageOriginId",
                        column: x => x.LanguageOriginId,
                        principalTable: "LanguageOrigins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnglishIdioms_UkranianIdioms_UkranianIdiomId",
                        column: x => x.UkranianIdiomId,
                        principalTable: "UkranianIdioms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnglishIdioms_Usages_UsageId",
                        column: x => x.UsageId,
                        principalTable: "Usages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnglishIdioms_ExplanationId",
                table: "EnglishIdioms",
                column: "ExplanationId");

            migrationBuilder.CreateIndex(
                name: "IX_EnglishIdioms_LanguageOriginId",
                table: "EnglishIdioms",
                column: "LanguageOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_EnglishIdioms_UkranianIdiomId",
                table: "EnglishIdioms",
                column: "UkranianIdiomId");

            migrationBuilder.CreateIndex(
                name: "IX_EnglishIdioms_UsageId",
                table: "EnglishIdioms",
                column: "UsageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnglishIdioms");

            migrationBuilder.DropTable(
                name: "Explanations");

            migrationBuilder.DropTable(
                name: "LanguageOrigins");

            migrationBuilder.DropTable(
                name: "UkranianIdioms");

            migrationBuilder.DropTable(
                name: "Usages");
        }
    }
}
