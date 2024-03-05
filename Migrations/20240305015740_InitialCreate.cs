using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Postcode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    RoomModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoomSize = table.Column<string>(type: "TEXT", nullable: false),
                    RoomType = table.Column<string>(type: "TEXT", nullable: false),
                    RentalPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    AvailabilityStatus = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.RoomModelId);
                });

            migrationBuilder.CreateTable(
                name: "OrderConfirmation",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "TEXT", nullable: false),
                    RentalStartDate = table.Column<string>(type: "TEXT", nullable: false),
                    RentalEndDate = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderConfirmation", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_OrderConfirmation_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderConfirmation_Vehicles_RoomModelId",
                        column: x => x.RoomModelId,
                        principalTable: "Vehicles",
                        principalColumn: "RoomModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    PriceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RentalRatePerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    Discounts = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.PriceId);
                    table.ForeignKey(
                        name: "FK_Pricings_Vehicles_RoomModelId",
                        column: x => x.RoomModelId,
                        principalTable: "Vehicles",
                        principalColumn: "RoomModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderConfirmation_CustomerId",
                table: "OrderConfirmation",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderConfirmation_RoomModelId",
                table: "OrderConfirmation",
                column: "RoomModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Pricings_RoomModelId",
                table: "Pricings",
                column: "RoomModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "OrderConfirmation");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
