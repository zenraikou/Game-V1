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
                    { new Guid("4fc17fe1-a8e1-43d8-a830-9229e8bb5e2a"), "A bow crafted from the wing of a Pure Silver Dragon.", "Buriza", new DateTime(2023, 5, 2, 3, 40, 31, 722, DateTimeKind.Utc).AddTicks(8832) },
                    { new Guid("519ed1bf-4664-4680-aed5-0dea811198a7"), "A sword crafted from the talon of a Pure Silver Dragon.", "Yasha", new DateTime(2023, 5, 2, 3, 40, 31, 722, DateTimeKind.Utc).AddTicks(8826) },
                    { new Guid("a489374e-48ea-47f2-8fff-860f142f27b8"), "A dagger crafted from the tooth of a Pure Silver Dragon.", "Dagon", new DateTime(2023, 5, 2, 3, 40, 31, 722, DateTimeKind.Utc).AddTicks(8755) },
                    { new Guid("ea86c683-d09a-4142-a822-a122543d7b76"), "A shield crafted from the scales of a Pure Silver Dragon.", "Vanguard", new DateTime(2023, 5, 2, 3, 40, 31, 722, DateTimeKind.Utc).AddTicks(8836) }
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
