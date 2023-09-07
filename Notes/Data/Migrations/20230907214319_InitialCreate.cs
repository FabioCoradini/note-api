using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NotesApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "DateCreation" },
                values: new object[] { "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", new DateTime(2023, 9, 7, 21, 43, 19, 473, DateTimeKind.Utc).AddTicks(190) });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "Body", "DateCreation", "Title" },
                values: new object[,]
                {
                    { 2, "LoremLorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque dignissim vehicula iaculis. Sed mattis dui eros, in accumsan tellus efficitur lacinia. Nulla mollis consequat orci quis consectetur.", new DateTime(2023, 9, 7, 21, 43, 19, 473, DateTimeKind.Utc).AddTicks(240), "My first note" },
                    { 3, "Sed vitae magna consequat, sollicitudin enim et, vehicula dui. Integer porta lectus nec facilisis eleifend. Cras fermentum tellus vel neque fermentum, quis pellentesque felis pretium. Donec erat turpis, euismod eu massa non, ornare eleifend justo. Cras et mauris eros. Duis dapibus sem ut ornare hendrerit. Duis ornare tempus massa sed aliquet.", new DateTime(2023, 9, 7, 21, 43, 19, 473, DateTimeKind.Utc).AddTicks(240), "My first note" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Body", "DateCreation" },
                values: new object[] { "My description...", new DateTime(2023, 9, 4, 21, 51, 46, 791, DateTimeKind.Utc).AddTicks(4030) });
        }
    }
}
