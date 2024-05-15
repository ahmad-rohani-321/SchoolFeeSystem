using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFeeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class FeesChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentExtraIncome");

            migrationBuilder.DropTable(
                name: "StudentExtraIncomeCollection");

            migrationBuilder.DropColumn(
                name: "FessType",
                table: "FeesCollection");

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "FeesCollection",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActivityFeesCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentClassId = table.Column<int>(type: "int", nullable: false),
                    ActivityFeesAmount = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityFeesCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityFeesCollection_ClassStudents_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "ClassStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeesCollectionPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesCollectionPeriod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransportFeesCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentClassId = table.Column<int>(type: "int", nullable: false),
                    TransportFeesAmount = table.Column<int>(type: "int", nullable: false),
                    TransportFeesDiscount = table.Column<int>(type: "int", nullable: false),
                    TransportFeesRemaining = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportFeesCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportFeesCollection_ClassStudents_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "ClassStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportFeesCollection_FeesCollectionPeriod_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "FeesCollectionPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeesCollection_PeriodId",
                table: "FeesCollection",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityFeesCollection_StudentClassId",
                table: "ActivityFeesCollection",
                column: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportFeesCollection_PeriodId",
                table: "TransportFeesCollection",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportFeesCollection_StudentClassId",
                table: "TransportFeesCollection",
                column: "StudentClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeesCollection_FeesCollectionPeriod_PeriodId",
                table: "FeesCollection",
                column: "PeriodId",
                principalTable: "FeesCollectionPeriod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeesCollection_FeesCollectionPeriod_PeriodId",
                table: "FeesCollection");

            migrationBuilder.DropTable(
                name: "ActivityFeesCollection");

            migrationBuilder.DropTable(
                name: "TransportFeesCollection");

            migrationBuilder.DropTable(
                name: "FeesCollectionPeriod");

            migrationBuilder.DropIndex(
                name: "IX_FeesCollection_PeriodId",
                table: "FeesCollection");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "FeesCollection");

            migrationBuilder.AddColumn<bool>(
                name: "FessType",
                table: "FeesCollection",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StudentExtraIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExtraIncome", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentExtraIncomeCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyProperty = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExtraIncomeCollection", x => x.Id);
                });
        }
    }
}
