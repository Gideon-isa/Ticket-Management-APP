using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GlobalTicket.TicketManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderTotal = table.Column<int>(type: "int", nullable: false),
                    OrderPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPaid = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("25381df8-c432-4593-bfa8-c567e8434913"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Musicals" },
                    { new Guid("73d07064-d7fa-42a0-a118-29934d368ec4"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Plays" },
                    { new Guid("9299ede7-7918-42d3-80bd-c7c9c9d677a3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Concerts" },
                    { new Guid("eb45ad73-5854-4976-b310-bd4e865afef2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Conferences" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "OrderPaid", "OrderPlaced", "OrderTotal", "UserId" },
                values: new object[,]
                {
                    { new Guid("2447f156-f484-48e1-a5aa-f35f457345ff"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4262), 85, new Guid("c070d80c-eb47-4748-8a34-b89a2320554a") },
                    { new Guid("288d0da0-b1d0-422e-a205-de110989c893"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4355), 40, new Guid("326564e5-efa8-4824-aba4-f600cba4ae4c") },
                    { new Guid("4901a19c-c9cd-4cf5-ba00-2f99113f1b69"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4234), 135, new Guid("af8d4964-cda6-4ffd-9259-fdc4a41fb279") },
                    { new Guid("4e7d040c-bbfd-475c-bae5-5bb10d4d8feb"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4200), 400, new Guid("a72c71fd-f736-49cc-997f-a9f55a09edf9") },
                    { new Guid("c6448885-4618-499b-970a-144a3d04039d"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4292), 245, new Guid("7532362f-2f22-49e9-8919-22a210dd4c09") },
                    { new Guid("e24e71c6-2f23-4840-ba95-9a7da54443aa"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4322), 142, new Guid("858811aa-dbe8-40f8-ba31-2724b0093147") },
                    { new Guid("f44cc385-d7ea-4071-ac21-bf8c4f13eb52"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, true, new DateTime(2024, 1, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4801), 116, new Guid("a6f12d87-bc5c-4fb0-906b-4c5b99415aa1") }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "CreatedBy", "CreatedDate", "Date", "Description", "ImageUrl", "LastModifiedBy", "LastModifiedDate", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("0ff6e70d-7518-476c-9394-6d63fdef4491"), "Many", new Guid("eb45ad73-5854-4976-b310-bd4e865afef2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 11, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4120), "The best tech conference in the world", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg", null, null, "Techorama 2021", 400 },
                    { new Guid("467172f5-25aa-44ad-a0cf-c496e11a8f5c"), "Michael Johnson", new Guid("9299ede7-7918-42d3-80bd-c7c9c9d677a3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4028), "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg", null, null, "The State of Affairs: Michael Live!", 85 },
                    { new Guid("75149ce3-20bf-4045-9ee6-96b86e285906"), "DJ 'The Mike'", new Guid("9299ede7-7918-42d3-80bd-c7c9c9d677a3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4058), "DJs from all over the world will compete in this epic battle for eternal fame.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg", null, null, "Clash of the DJs", 85 },
                    { new Guid("7f3711a8-b788-437f-84a8-7f827dc30f03"), "John Egbert", new Guid("9299ede7-7918-42d3-80bd-c7c9c9d677a3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(3969), "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", null, null, "John Egbert Live", 65 },
                    { new Guid("a34ee542-e804-40bd-aabd-e52e9459c861"), "Manuel Santinonisi", new Guid("9299ede7-7918-42d3-80bd-c7c9c9d677a3"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 5, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4087), "Get on the hype of Spanish Guitar concerts with Manuel.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg", null, null, "Spanish guitar hits with Manuel", 25 },
                    { new Guid("c8599a5d-8d5c-447c-aed0-a3cf037c2201"), "Nick Sailor", new Guid("25381df8-c432-4593-bfa8-c567e8434913"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 9, 20, 11, 28, 21, 972, DateTimeKind.Local).AddTicks(4154), "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg", null, null, "To the Moon and Back", 135 }
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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
