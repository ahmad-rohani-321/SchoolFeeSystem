using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolFeeSystem.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassTiming = table.Column<TimeOnly>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FeeAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitqueKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandFatherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    TazkiraNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentExtraIncome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncomeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    StudentFee = table.Column<int>(type: "int", nullable: false),
                    EntranceDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentIdCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerialNo = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ExpireDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentIdCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentIdCard_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentIdCard_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeesCollection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentClassId = table.Column<int>(type: "int", nullable: false),
                    FessType = table.Column<bool>(type: "bit", nullable: false),
                    FeesAmount = table.Column<int>(type: "int", nullable: false),
                    FeesDiscount = table.Column<int>(type: "int", nullable: false),
                    FeesRemaining = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeesCollection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeesCollection_ClassStudents_StudentClassId",
                        column: x => x.StudentClassId,
                        principalTable: "ClassStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FeesCollection_StudentClassId",
                table: "FeesCollection",
                column: "StudentClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UnitqueKey",
                table: "Student",
                column: "UnitqueKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdCard_ClassId",
                table: "StudentIdCard",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentIdCard_StudentId",
                table: "StudentIdCard",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeesCollection");

            migrationBuilder.DropTable(
                name: "StudentExtraIncome");

            migrationBuilder.DropTable(
                name: "StudentExtraIncomeCollection");

            migrationBuilder.DropTable(
                name: "StudentIdCard");

            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
