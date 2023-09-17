using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI_timetable.Migrations
{
    /// <inheritdoc />
    public partial class updateCourseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "LevelDepartmentId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId",
                principalTable: "LevelDepartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "LevelDepartmentId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId",
                principalTable: "LevelDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
