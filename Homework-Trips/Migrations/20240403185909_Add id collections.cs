using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework_Trips.Migrations
{
    /// <inheritdoc />
    public partial class Addidcollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsOfIntrest_Photos_PhotoId",
                table: "PointsOfIntrest");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_TripId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Reservations",
                newName: "TripId1");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservations",
                newName: "CustomerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TripId",
                table: "Reservations",
                newName: "IX_Reservations_TripId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId1");

            migrationBuilder.AddColumn<int[]>(
                name: "PointsOfIntrestIds",
                table: "Trips",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddColumn<int[]>(
                name: "ReservationsIds",
                table: "Trips",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "PointsOfIntrest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_PointsOfIntrest_Photos_PhotoId",
                table: "PointsOfIntrest",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId1",
                table: "Reservations",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_TripId1",
                table: "Reservations",
                column: "TripId1",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PointsOfIntrest_Photos_PhotoId",
                table: "PointsOfIntrest");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId1",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Trips_TripId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PointsOfIntrestIds",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ReservationsIds",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripId1",
                table: "Reservations",
                newName: "TripId");

            migrationBuilder.RenameColumn(
                name: "CustomerId1",
                table: "Reservations",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TripId1",
                table: "Reservations",
                newName: "IX_Reservations_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId1",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "PhotoId",
                table: "PointsOfIntrest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PointsOfIntrest_Photos_PhotoId",
                table: "PointsOfIntrest",
                column: "PhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Trips_TripId",
                table: "Reservations",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
