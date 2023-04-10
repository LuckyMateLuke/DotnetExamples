using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuckyMateLuke.Examples.EfCore.Migrations
{
    /// <inheritdoc />
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
#pragma warning disable SA1300 // Element should begin with upper-case letter
    public partial class init : Migration
#pragma warning restore SA1300 // Element should begin with upper-case letter
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    MetaDataCreatedBy = table.Column<int>(name: "MetaData_CreatedBy", type: "int", nullable: true),
                    MetaDataCreatedOnUtc = table.Column<long>(name: "MetaData_CreatedOnUtc", type: "bigint", nullable: true),
                    MetaDataLastUpdatedBy = table.Column<int>(name: "MetaData_LastUpdatedBy", type: "int", nullable: true),
                    MetaDataLastUpdatedOnUtc = table.Column<long>(name: "MetaData_LastUpdatedOnUtc", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    MetaDataCreatedBy = table.Column<int>(name: "MetaData_CreatedBy", type: "int", nullable: true),
                    MetaDataCreatedOnUtc = table.Column<long>(name: "MetaData_CreatedOnUtc", type: "bigint", nullable: true),
                    MetaDataLastUpdatedBy = table.Column<int>(name: "MetaData_LastUpdatedBy", type: "int", nullable: true),
                    MetaDataLastUpdatedOnUtc = table.Column<long>(name: "MetaData_LastUpdatedOnUtc", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    City = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    MetaDataCreatedBy = table.Column<int>(name: "MetaData_CreatedBy", type: "int", nullable: true),
                    MetaDataCreatedOnUtc = table.Column<long>(name: "MetaData_CreatedOnUtc", type: "bigint", nullable: true),
                    MetaDataLastUpdatedBy = table.Column<int>(name: "MetaData_LastUpdatedBy", type: "int", nullable: true),
                    MetaDataLastUpdatedOnUtc = table.Column<long>(name: "MetaData_LastUpdatedOnUtc", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    SchoolId1 = table.Column<int>(type: "int", nullable: true),
                    MetaDataCreatedBy = table.Column<int>(name: "MetaData_CreatedBy", type: "int", nullable: true),
                    MetaDataCreatedOnUtc = table.Column<long>(name: "MetaData_CreatedOnUtc", type: "bigint", nullable: true),
                    MetaDataLastUpdatedBy = table.Column<int>(name: "MetaData_LastUpdatedBy", type: "int", nullable: true),
                    MetaDataLastUpdatedOnUtc = table.Column<long>(name: "MetaData_LastUpdatedOnUtc", type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Group_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Group_School_SchoolId1",
                        column: x => x.SchoolId1,
                        principalTable: "School",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    Grades = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    MetaDataCreatedBy = table.Column<int>(name: "MetaData_CreatedBy", type: "int", nullable: true),
                    MetaDataCreatedOnUtc = table.Column<long>(name: "MetaData_CreatedOnUtc", type: "bigint", nullable: true),
                    MetaDataLastUpdatedBy = table.Column<int>(name: "MetaData_LastUpdatedBy", type: "int", nullable: true),
                    MetaDataLastUpdatedOnUtc = table.Column<long>(name: "MetaData_LastUpdatedOnUtc", type: "bigint", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_School_StudentId",
                        column: x => x.StudentId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupProjectStudent",
                columns: table => new
                {
                    GroupProjectsId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProjectStudent", x => new { x.GroupProjectsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_GroupProjectStudent_GroupProject_GroupProjectsId",
                        column: x => x.GroupProjectsId,
                        principalTable: "GroupProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupProjectStudent_Student_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParentStudent",
                columns: table => new
                {
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentStudent", x => new { x.StudentId, x.ParentId });
                    table.ForeignKey(
                        name: "FK_ParentStudent_Parent_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentStudent_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_SchoolId",
                table: "Group",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Group_SchoolId1",
                table: "Group",
                column: "SchoolId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProjectStudent_StudentsId",
                table: "GroupProjectStudent",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentStudent_ParentId",
                table: "ParentStudent",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupId",
                table: "Student",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentId",
                table: "Student",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupProjectStudent");

            migrationBuilder.DropTable(
                name: "ParentStudent");

            migrationBuilder.DropTable(
                name: "GroupProject");

            migrationBuilder.DropTable(
                name: "Parent");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
