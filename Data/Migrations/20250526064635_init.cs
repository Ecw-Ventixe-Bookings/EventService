using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TicketPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    TotalTickets = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("649d7a76-56a2-4342-a8bf-f3b95ef4c4f6"), "Art" },
                    { new Guid("902c34d2-5a4d-43be-82fd-98ce1cc927bb"), "Music" },
                    { new Guid("a5da6417-26f9-4b69-8365-010f0772f31f"), "Comedy" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "City", "Name", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("e1b5f8c0-0001-0000-0000-000000000001"), "Hötorget 8", "Stockholm", "Stockholm Konserthus", "111 57" },
                    { new Guid("e1b5f8c0-0002-0000-0000-000000000002"), "Christina Nilssons Gata", "Göteborg", "Göteborgs Operan", "411 04" },
                    { new Guid("e1b5f8c0-0003-0000-0000-000000000003"), "Vaksala torg 1", "Uppsala", "Uppsala Konsert & Kongress", "753 31" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "Description", "EndDateTime", "StartDateTime", "TicketPrice", "Title", "TotalTickets", "VenueId" },
                values: new object[,]
                {
                    { new Guid("11111111-0001-0000-0000-000000000001"), new Guid("902c34d2-5a4d-43be-82fd-98ce1cc927bb"), "En klassisk musikupplevelse med Stockholms filharmoniker.", new DateTime(2025, 10, 12, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), 350.00m, "Beethoven i Blå Hallen", 3500, new Guid("e1b5f8c0-0001-0000-0000-000000000001") },
                    { new Guid("11111111-0002-0000-0000-000000000002"), new Guid("649d7a76-56a2-4342-a8bf-f3b95ef4c4f6"), "Utforska samtida konst från lokala och internationella konstnärer.", new DateTime(2025, 9, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), 150.00m, "Göteborgs Modern Art Expo", 3500, new Guid("e1b5f8c0-0002-0000-0000-000000000002") },
                    { new Guid("11111111-0003-0000-0000-000000000003"), new Guid("a5da6417-26f9-4b69-8365-010f0772f31f"), "Standup-komedi av en av Sveriges roligaste röster.", new DateTime(2025, 11, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 220.00m, "Skrattfest med Anna Svensson", 3500, new Guid("e1b5f8c0-0003-0000-0000-000000000003") },
                    { new Guid("11111111-0004-0000-0000-000000000004"), new Guid("902c34d2-5a4d-43be-82fd-98ce1cc927bb"), "En intim kväll med svenska jazzlegender.", new DateTime(2025, 8, 22, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 22, 18, 30, 0, 0, DateTimeKind.Unspecified), 275.00m, "Jazzkväll i Uppsala", 3500, new Guid("e1b5f8c0-0003-0000-0000-000000000003") },
                    { new Guid("11111111-0005-0000-0000-000000000005"), new Guid("649d7a76-56a2-4342-a8bf-f3b95ef4c4f6"), "En utställning som fokuserar på AI och digital konst.", new DateTime(2025, 12, 3, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), 180.00m, "Digital Art Now", 3500, new Guid("e1b5f8c0-0001-0000-0000-000000000001") },
                    { new Guid("11111111-0006-0000-0000-000000000006"), new Guid("a5da6417-26f9-4b69-8365-010f0772f31f"), "Ett humoristiskt scenprogram med sketcher och improvisation.", new DateTime(2025, 9, 18, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 18, 19, 30, 0, 0, DateTimeKind.Unspecified), 200.00m, "Humorkväll med Jonas & Mia", 3500, new Guid("e1b5f8c0-0002-0000-0000-000000000002") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Venues");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
