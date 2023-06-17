using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class qwertyu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectsOfTeachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectsOfTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectsOfTeachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectsOfTeachers_Users_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SublectsOfStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectsOfTeachersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SublectsOfStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SublectsOfStudents_SubjectsOfTeachers_SubjectsOfTeachersId",
                        column: x => x.SubjectsOfTeachersId,
                        principalTable: "SubjectsOfTeachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SublectsOfStudents_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RefreshToken", "RefreshTokenExpireDate", "Role", "Salt" },
                values: new object[] { new Guid("583f9a8a-6bbb-4a47-3a04-08db37684f69"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "muxammadyor@gmail.com", "Admin", "Admin", "U3wZq33dK4rvlNqhJ0zTQlQ4jfvA5brrTfmdid+yDtk=", "+998942142336", null, null, 0, "15d9bb01-0aa2-4b35-b25b-362287751b03" });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOfTeachers_SubjectId",
                table: "SubjectsOfTeachers",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectsOfTeachers_TeacherId",
                table: "SubjectsOfTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_SublectsOfStudents_StudentId",
                table: "SublectsOfStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SublectsOfStudents_SubjectsOfTeachersId",
                table: "SublectsOfStudents",
                column: "SubjectsOfTeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SublectsOfStudents");

            migrationBuilder.DropTable(
                name: "SubjectsOfTeachers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
