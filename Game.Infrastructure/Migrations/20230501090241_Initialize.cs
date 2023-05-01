using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Game.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name", "Timestamp" },
                values: new object[,]
                {
                    { new Guid("147f7db0-6c56-46a6-b80f-80be5db39203"), "A shield crafted from the scales of a Pure Silver Dragon.", "Vanguard", new DateTime(2023, 5, 1, 9, 2, 41, 442, DateTimeKind.Utc).AddTicks(2558) },
                    { new Guid("14e84c6b-a08d-48f3-8103-84310ab675d3"), "A sword crafted from the talon of a Pure Silver Dragon.", "Yasha", new DateTime(2023, 5, 1, 9, 2, 41, 442, DateTimeKind.Utc).AddTicks(2550) },
                    { new Guid("2e63e1fc-99d3-464f-9dc7-30f665c7f3ff"), "A bow crafted from the wing of a Pure Silver Dragon.", "Buriza", new DateTime(2023, 5, 1, 9, 2, 41, 442, DateTimeKind.Utc).AddTicks(2555) },
                    { new Guid("b6dc2adc-168c-4425-a933-6985d3c64c6e"), "A dagger crafted from the tooth of a Pure Silver Dragon.", "Dagon", new DateTime(2023, 5, 1, 9, 2, 41, 442, DateTimeKind.Utc).AddTicks(2537) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
