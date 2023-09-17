using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI_timetable.Migrations
{
    /// <inheritdoc />
    public partial class levelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId1",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_slots_coursesId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelDepartments_Departments_deptId",
                table: "LevelDepartments");

            migrationBuilder.DropIndex(
                name: "IX_LevelDepartments_deptId",
                table: "LevelDepartments");

            migrationBuilder.DropIndex(
                name: "IX_Course_coursesId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_LevelDepartmentId1",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LevelDepartmentId1",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "deptId",
                table: "LevelDepartments",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "TotalNoOfNonDepartmentalCources",
                table: "LevelDepartments",
                newName: "TotalNoOfNonDepartmentalCourses");

            migrationBuilder.RenameColumn(
                name: "coursesId",
                table: "Course",
                newName: "no_of_dept_offering");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "LevelDepartments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevelDepartmentId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SLOTId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "level",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LevelDepartments_DepartmentId",
                table: "LevelDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SLOTId",
                table: "Course",
                column: "SLOTId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId",
                principalTable: "LevelDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_slots_SLOTId",
                table: "Course",
                column: "SLOTId",
                principalTable: "slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelDepartments_Departments_DepartmentId",
                table: "LevelDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_slots_SLOTId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_LevelDepartments_Departments_DepartmentId",
                table: "LevelDepartments");

            migrationBuilder.DropIndex(
                name: "IX_LevelDepartments_DepartmentId",
                table: "LevelDepartments");

            migrationBuilder.DropIndex(
                name: "IX_Course_LevelDepartmentId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_SLOTId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "LevelDepartments");

            migrationBuilder.DropColumn(
                name: "LevelDepartmentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "SLOTId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "level",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "LevelDepartments",
                newName: "deptId");

            migrationBuilder.RenameColumn(
                name: "TotalNoOfNonDepartmentalCourses",
                table: "LevelDepartments",
                newName: "TotalNoOfNonDepartmentalCources");

            migrationBuilder.RenameColumn(
                name: "no_of_dept_offering",
                table: "Course",
                newName: "coursesId");

            migrationBuilder.AddColumn<int>(
                name: "LevelDepartmentId1",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LevelDepartments_deptId",
                table: "LevelDepartments",
                column: "deptId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_coursesId",
                table: "Course",
                column: "coursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelDepartmentId1",
                table: "Course",
                column: "LevelDepartmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId1",
                table: "Course",
                column: "LevelDepartmentId1",
                principalTable: "LevelDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_slots_coursesId",
                table: "Course",
                column: "coursesId",
                principalTable: "slots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LevelDepartments_Departments_deptId",
                table: "LevelDepartments",
                column: "deptId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
