using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing_API.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "33a2f85e-a059-4662-9244-742b0b972112", "074cb81d-7a4b-4a7a-8325-d00ff16cd7b1", "user", "USER" },
                    { "8ac2c0b1-9866-4ad1-92c7-4d3ae2e33329", "0930ee1d-4187-4319-b478-8316740d5e3c", "Admin", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CountryShortName" },
                values: new object[,]
                {
                    { 4, "Netherlands", "ND" },
                    { 5, "Gabon", "GB" },
                    { 6, "Guinea", "GE" },
                    { 7, "England", "EN" },
                    { 8, "Ivory Coast", "IV" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "CountryId", "HotelAddress", "HotelName", "HotelRating" },
                values: new object[,]
                {
                    { 5, 1, " Lagis Island", "Eko Hotel", 4.5 },
                    { 6, 1, " Abuja", "Oriental Hotel", 1.5 },
                    { 7, 1, " Lagis Island", "Eko Hotel", 4.5 },
                    { 4, 8, " Abidjan", "Manshak Hotels", 4.5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "33a2f85e-a059-4662-9244-742b0b972112");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ac2c0b1-9866-4ad1-92c7-4d3ae2e33329");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
