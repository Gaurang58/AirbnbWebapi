using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Airbnb.Migrations
{
    /// <inheritdoc />
    public partial class IdentityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderConfirmation_Vehicles_RoomModelId",
                table: "OrderConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_Vehicles_RoomModelId",
                table: "Pricings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "RoomModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomModels",
                table: "RoomModels",
                column: "RoomModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderConfirmation_RoomModels_RoomModelId",
                table: "OrderConfirmation",
                column: "RoomModelId",
                principalTable: "RoomModels",
                principalColumn: "RoomModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_RoomModels_RoomModelId",
                table: "Pricings",
                column: "RoomModelId",
                principalTable: "RoomModels",
                principalColumn: "RoomModelId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderConfirmation_RoomModels_RoomModelId",
                table: "OrderConfirmation");

            migrationBuilder.DropForeignKey(
                name: "FK_Pricings_RoomModels_RoomModelId",
                table: "Pricings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomModels",
                table: "RoomModels");

            migrationBuilder.RenameTable(
                name: "RoomModels",
                newName: "Vehicles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "RoomModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderConfirmation_Vehicles_RoomModelId",
                table: "OrderConfirmation",
                column: "RoomModelId",
                principalTable: "Vehicles",
                principalColumn: "RoomModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pricings_Vehicles_RoomModelId",
                table: "Pricings",
                column: "RoomModelId",
                principalTable: "Vehicles",
                principalColumn: "RoomModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
