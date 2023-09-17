using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UNI_timetable.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LevelDepartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    deptId = table.Column<int>(type: "int", nullable: false),
                    TotalNoOfNonDepartmentalCources = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LevelDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LevelDepartments_Departments_deptId",
                        column: x => x.deptId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "slots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LevelDepartmentId = table.Column<int>(type: "int", nullable: true),
                    LevelDepartmentId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_slots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_slots_LevelDepartments_LevelDepartmentId",
                        column: x => x.LevelDepartmentId,
                        principalTable: "LevelDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_slots_LevelDepartments_LevelDepartmentId1",
                        column: x => x.LevelDepartmentId1,
                        principalTable: "LevelDepartments",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isItDepartmental = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    coursesId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId1 = table.Column<int>(type: "int", nullable: true),
                    LevelDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_Departments_DepartmentId1",
                        column: x => x.DepartmentId1,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_LevelDepartments_LevelDepartmentId",
                        column: x => x.LevelDepartmentId,
                        principalTable: "LevelDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Course_slots_coursesId",
                        column: x => x.coursesId,
                        principalTable: "slots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Course_coursesId",
                table: "Course",
                column: "coursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId",
                table: "Course",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentId1",
                table: "Course",
                column: "DepartmentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Course_LevelDepartmentId",
                table: "Course",
                column: "LevelDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LevelDepartments_deptId",
                table: "LevelDepartments",
                column: "deptId");

            migrationBuilder.CreateIndex(
                name: "IX_slots_LevelDepartmentId",
                table: "slots",
                column: "LevelDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_slots_LevelDepartmentId1",
                table: "slots",
                column: "LevelDepartmentId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "slots");

            migrationBuilder.DropTable(
                name: "LevelDepartments");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
