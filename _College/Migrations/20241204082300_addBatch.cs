using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _College.Migrations
{
    /// <inheritdoc />
    public partial class addBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Students",
                newName: "BatchId");

            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Exam_Date",
                table: "Courses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Exam_Duration",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Batchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batchs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_BatchId",
                table: "Students",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_BatchId",
                table: "Courses",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Batchs_BatchId",
                table: "Courses",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Batchs_BatchId",
                table: "Students",
                column: "BatchId",
                principalTable: "Batchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Batchs_BatchId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Batchs_BatchId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Batchs");

            migrationBuilder.DropIndex(
                name: "IX_Students_BatchId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Courses_BatchId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Exam_Date",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "Exam_Duration",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "BatchId",
                table: "Students",
                newName: "Year");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Exam_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Exam_Duration = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
