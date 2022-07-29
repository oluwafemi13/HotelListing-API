using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing_API.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Hotels",
                newName: "HotelRating");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hotels",
                newName: "HotelName");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Hotels",
                newName: "HotelAddress");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Countries",
                newName: "CountryShortName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Countries",
                newName: "CountryName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelRating",
                table: "Hotels",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "HotelName",
                table: "Hotels",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "HotelAddress",
                table: "Hotels",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "CountryShortName",
                table: "Countries",
                newName: "ShortName");

            migrationBuilder.RenameColumn(
                name: "CountryName",
                table: "Countries",
                newName: "Name");
        }
    }
}
