using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.Core.Library.Migrations
{
    public partial class AddedMappingETY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductKeywordsId",
                table: "KeywordTags",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductProductKeywords",
                columns: table => new
                {
                    ProductKeywordsId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductKeywords", x => new { x.ProductKeywordsId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_ProductProductKeywords_ProductKeywords_ProductKeywordsId",
                        column: x => x.ProductKeywordsId,
                        principalTable: "ProductKeywords",
                        principalColumn: "ProductKeywordsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductKeywords_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeywordTags_ProductKeywordsId",
                table: "KeywordTags",
                column: "ProductKeywordsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductKeywords_ProductsProductId",
                table: "ProductProductKeywords",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeywordTags_ProductKeywords_ProductKeywordsId",
                table: "KeywordTags",
                column: "ProductKeywordsId",
                principalTable: "ProductKeywords",
                principalColumn: "ProductKeywordsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeywordTags_ProductKeywords_ProductKeywordsId",
                table: "KeywordTags");

            migrationBuilder.DropTable(
                name: "ProductProductKeywords");

            migrationBuilder.DropIndex(
                name: "IX_KeywordTags_ProductKeywordsId",
                table: "KeywordTags");

            migrationBuilder.DropColumn(
                name: "ProductKeywordsId",
                table: "KeywordTags");
        }
    }
}
