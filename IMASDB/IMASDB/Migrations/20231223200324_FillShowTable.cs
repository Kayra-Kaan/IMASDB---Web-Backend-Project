using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMASDB.Migrations
{
    /// <inheritdoc />
    public partial class FillShowTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shows",
                columns: new[] { "ShowId", "EpisodeCount", "SeasonCount", "ShowName" },
                values: new object[,]
                {
                    { 1, 80, 4, "High School Life" },
                    { 2, 12, 3, "Depression" },
                    { 3, 8, 1, "Opposites" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shows",
                keyColumn: "ShowId",
                keyValue: 3);
        }
    }
}
