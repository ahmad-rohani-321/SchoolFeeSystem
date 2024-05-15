using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFeeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class SomeNamesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransportFeesRemaining",
                table: "TransportFeesCollection",
                newName: "Taken");

            migrationBuilder.RenameColumn(
                name: "TransportFeesDiscount",
                table: "TransportFeesCollection",
                newName: "Remaining");

            migrationBuilder.RenameColumn(
                name: "TransportFeesAmount",
                table: "TransportFeesCollection",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "FeesRemaining",
                table: "FeesCollection",
                newName: "Taken");

            migrationBuilder.RenameColumn(
                name: "FeesDiscount",
                table: "FeesCollection",
                newName: "Remaining");

            migrationBuilder.RenameColumn(
                name: "FeesAmount",
                table: "FeesCollection",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "ActivityFeesAmount",
                table: "ActivityFeesCollection",
                newName: "Amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Taken",
                table: "TransportFeesCollection",
                newName: "TransportFeesRemaining");

            migrationBuilder.RenameColumn(
                name: "Remaining",
                table: "TransportFeesCollection",
                newName: "TransportFeesDiscount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "TransportFeesCollection",
                newName: "TransportFeesAmount");

            migrationBuilder.RenameColumn(
                name: "Taken",
                table: "FeesCollection",
                newName: "FeesRemaining");

            migrationBuilder.RenameColumn(
                name: "Remaining",
                table: "FeesCollection",
                newName: "FeesDiscount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "FeesCollection",
                newName: "FeesAmount");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "ActivityFeesCollection",
                newName: "ActivityFeesAmount");
        }
    }
}
