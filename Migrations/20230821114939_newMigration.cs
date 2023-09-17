using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI_timetable.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Departments_DepartmentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Departments_DepartmentId1",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_DepartmentId1",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentId1",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "LevelDepartmentId",
                table: "Course",
                newName: "LevelDepartmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Course_LevelDepartmentId",
                table: "Course",
                newName: "IX_Course_LevelDepartmentId1");

            migrationBuilder.CreateTable(
                name: "LevelCourses",
                columns: table => new
                {
                    CoursesId = table.Column<int>(type: "int", nullable: false),
                    LevelDepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelCourses", x => new { x.LevelDepartmentId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_LevelCourses_Course_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LevelCourses_LevelDepartments_LevelDepartmentId",
                        column: x => x.LevelDepartmentId,
                        principalTable: "LevelDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LevelCourses_CoursesId",
                table: "LevelCourses",
                column: "CoursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId1",
                table: "Course",
                column: "LevelDepartmentId1",
                principalTable: "LevelDepartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId1",
                table: "Course");

            migrationBuilder.DropTable(
                name: "LevelCourses");

            migrationBuilder.RenameColumn(
                name: "LevelDepartmentId1",
                table: "Course",
                newName: "LevelDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_LevelDepartmentId1",
                table: "Course",
                newName: "IX_Course_LevelDepartmentId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId1",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId1",
                table: "Course",
                column: "DepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Departments_DepartmentId",
                table: "Course",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Departments_DepartmentId1",
                table: "Course",
                column: "DepartmentId1",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId",
                principalTable: "LevelDepartments",
                principalColumn: "Id");
        }
    }
}
