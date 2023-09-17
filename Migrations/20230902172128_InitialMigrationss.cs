using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI_timetable.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_slots_LevelDepartments_LevelDepartmentId1",
                table: "slots");

            migrationBuilder.DropIndex(
                name: "IX_slots_LevelDepartmentId1",
                table: "slots");

            migrationBuilder.DropIndex(
                name: "IX_Course_LevelDepartmentId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LevelDepartmentId1",
                table: "slots");

            migrationBuilder.DropColumn(
                name: "LevelDepartmentId",
                table: "Course");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelDepartmentId1",
                table: "slots",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LevelDepartmentId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_slots_LevelDepartmentId1",
                table: "slots",
                column: "LevelDepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_LevelDepartments_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId",
                principalTable: "LevelDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_slots_LevelDepartments_LevelDepartmentId1",
                table: "slots",
                column: "LevelDepartmentId1",
                principalTable: "LevelDepartments",
                principalColumn: "Id");
        }
    }
}
