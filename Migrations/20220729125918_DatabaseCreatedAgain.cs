using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing_API.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreatedAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CountryShortName",
                table: "Countries",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Countries",
                newName: "CountryShortName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");
        }
    }
}
