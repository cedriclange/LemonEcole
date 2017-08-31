using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolSolution.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassAssignement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassAssignement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassID = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollementDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaiementFor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaiementFor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaimentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaimentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(type: "varchar(200)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "date", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Firstname = table.Column<string>(type: "varchar(100)", nullable: false),
                    Gender = table.Column<string>(type: "char(1)", nullable: false),
                    Lastname = table.Column<string>(type: "varchar(100)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "date", nullable: true),
                    IsEnrolled = table.Column<bool>(type: "INTEGER", nullable: true),
                    Photo = table.Column<byte[]>(type: "BLOB", nullable: true),
                    StudentNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classe_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    TotalAverage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paiment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    MonthId = table.Column<int>(type: "INTEGER", nullable: false),
                    PaidOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paiment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paiment_PaiementFor_MonthId",
                        column: x => x.MonthId,
                        principalTable: "PaiementFor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paiment_People_StudentID",
                        column: x => x.StudentID,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paiment_PaimentType_Type",
                        column: x => x.Type,
                        principalTable: "PaimentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Percentage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Percent = table.Column<double>(type: "REAL", nullable: false),
                    PeriodID = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Percentage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Percentage_Period_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Percentage_People_StudentID",
                        column: x => x.StudentID,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClassesCourses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesCourses", x => new { x.ClassId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_ClassesCourses_Classe_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassesCourses_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignement",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignement", x => new { x.TeacherId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_CourseAssignement_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssignement_People_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Score",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseID = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PeriodID = table.Column<int>(type: "INTEGER", nullable: false),
                    Point = table.Column<double>(type: "REAL", nullable: false),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Score_Classe_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_Period_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Score_People_StudentID",
                        column: x => x.StudentID,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classe_DepartmentID",
                table: "Classe",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ClassesCourses_CourseId",
                table: "ClassesCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignement_CourseId",
                table: "CourseAssignement",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiment_MonthId",
                table: "Paiment",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Paiment_StudentID",
                table: "Paiment",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Paiment_Type",
                table: "Paiment",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Percentage_PeriodID",
                table: "Percentage",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Percentage_StudentID",
                table: "Percentage",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Score_ClassId",
                table: "Score",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Score_CourseID",
                table: "Score",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Score_PeriodID",
                table: "Score",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_Score_StudentID",
                table: "Score",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassAssignement");

            migrationBuilder.DropTable(
                name: "ClassesCourses");

            migrationBuilder.DropTable(
                name: "CourseAssignement");

            migrationBuilder.DropTable(
                name: "Enrollement");

            migrationBuilder.DropTable(
                name: "Paiment");

            migrationBuilder.DropTable(
                name: "Percentage");

            migrationBuilder.DropTable(
                name: "Score");

            migrationBuilder.DropTable(
                name: "PaiementFor");

            migrationBuilder.DropTable(
                name: "PaimentType");

            migrationBuilder.DropTable(
                name: "Classe");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Period");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
