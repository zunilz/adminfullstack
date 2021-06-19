using Microsoft.EntityFrameworkCore.Migrations;

namespace Admin.Core.Library.Migrations
{
    public partial class AddedMappingETY3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductKeywords_KeywordTags_KeywordTagsKeywordId",
                table: "ProductKeywords");

            migrationBuilder.DropIndex(
                name: "IX_ProductKeywords_KeywordTagsKeywordId",
                table: "ProductKeywords");

            migrationBuilder.DropColumn(
                name: "KeywordTagsKeywordId",
                table: "ProductKeywords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KeywordTagsKeywordId",
                table: "ProductKeywords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductKeywords_KeywordTagsKeywordId",
                table: "ProductKeywords",
                column: "KeywordTagsKeywordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductKeywords_KeywordTags_KeywordTagsKeywordId",
                table: "ProductKeywords",
                column: "KeywordTagsKeywordId",
                principalTable: "KeywordTags",
                principalColumn: "KeywordId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
