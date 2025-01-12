using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo.API.Database.Migrations
{
    /// <inheritdoc />
    public partial class Migraties10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WriterId",
                table: "Writers");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WriterId",
                table: "Writers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "Genre",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BookId",
                table: "Books",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
