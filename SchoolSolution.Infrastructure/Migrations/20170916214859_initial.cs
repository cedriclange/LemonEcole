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
                name: "tbl_classassignement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_classassignement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_departement",
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
                    table.PrimaryKey("PK_tbl_departement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_enrollement",
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
                    table.PrimaryKey("PK_tbl_enrollement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_paymentreason",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Month = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_paymentreason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_paymentype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_paymentype", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_people",
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
                    table.PrimaryKey("PK_tbl_people", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_yearperiod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_yearperiod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_classe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_classe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classe_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "tbl_departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamAverage = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    PeriodAverage = table.Column<double>(type: "REAL", nullable: false),
                    TotalAverage = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "tbl_departement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_payement",
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
                    table.PrimaryKey("PK_tbl_payement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_payement_tbl_paymentreason_MonthId",
                        column: x => x.MonthId,
                        principalTable: "tbl_paymentreason",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_payement_tbl_people_StudentID",
                        column: x => x.StudentID,
                        principalTable: "tbl_people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_payement_tbl_paymentype_Type",
                        column: x => x.Type,
                        principalTable: "tbl_paymentype",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_percentage",
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
                    table.PrimaryKey("PK_tbl_percentage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_percentage_tbl_yearperiod_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "tbl_yearperiod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_percentage_tbl_people_StudentID",
                        column: x => x.StudentID,
                        principalTable: "tbl_people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_classecourses",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_classecourses", x => new { x.ClassId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_tbl_classecourses_tbl_classe_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tbl_classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_classecourses_tbl_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_courseassignement",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_courseassignement", x => new { x.TeacherId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_tbl_courseassignement_tbl_course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "tbl_course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_courseassignement_tbl_people_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "tbl_people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_score",
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
                    table.PrimaryKey("PK_tbl_score", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_score_tbl_classe_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tbl_classe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_score_tbl_course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "tbl_course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_score_tbl_yearperiod_PeriodID",
                        column: x => x.PeriodID,
                        principalTable: "tbl_yearperiod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_score_tbl_people_StudentID",
                        column: x => x.StudentID,
                        principalTable: "tbl_people",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_classe_DepartmentID",
                table: "tbl_classe",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_classecourses_CourseId",
                table: "tbl_classecourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_course_DepartmentID",
                table: "tbl_course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_courseassignement_CourseId",
                table: "tbl_courseassignement",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_payement_MonthId",
                table: "tbl_payement",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_payement_StudentID",
                table: "tbl_payement",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_payement_Type",
                table: "tbl_payement",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_percentage_PeriodID",
                table: "tbl_percentage",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_percentage_StudentID",
                table: "tbl_percentage",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_score_ClassId",
                table: "tbl_score",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_score_CourseID",
                table: "tbl_score",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_score_PeriodID",
                table: "tbl_score",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_score_StudentID",
                table: "tbl_score",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_classassignement");

            migrationBuilder.DropTable(
                name: "tbl_classecourses");

            migrationBuilder.DropTable(
                name: "tbl_courseassignement");

            migrationBuilder.DropTable(
                name: "tbl_enrollement");

            migrationBuilder.DropTable(
                name: "tbl_payement");

            migrationBuilder.DropTable(
                name: "tbl_percentage");

            migrationBuilder.DropTable(
                name: "tbl_score");

            migrationBuilder.DropTable(
                name: "tbl_paymentreason");

            migrationBuilder.DropTable(
                name: "tbl_paymentype");

            migrationBuilder.DropTable(
                name: "tbl_classe");

            migrationBuilder.DropTable(
                name: "tbl_course");

            migrationBuilder.DropTable(
                name: "tbl_yearperiod");

            migrationBuilder.DropTable(
                name: "tbl_people");

            migrationBuilder.DropTable(
                name: "tbl_departement");
        }
    }
}
