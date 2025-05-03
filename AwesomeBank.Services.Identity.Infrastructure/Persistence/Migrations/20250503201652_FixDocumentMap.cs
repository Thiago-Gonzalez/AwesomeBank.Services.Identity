using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeBank.Services.Identity.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixDocumentMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Users",
                newName: "Document");

            migrationBuilder.RenameIndex(
                name: "IX_Users_DocumentNumber",
                table: "Users",
                newName: "IX_Users_Document");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Users",
                newName: "DocumentNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Document",
                table: "Users",
                newName: "IX_Users_DocumentNumber");
        }
    }
}
