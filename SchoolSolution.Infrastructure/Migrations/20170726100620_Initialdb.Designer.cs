using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SchoolSolution.Infrastructure.Data;

namespace SchoolSolution.Infrastructure.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20170726100620_Initialdb")]
    partial class Initialdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.ClassAssignement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<int>("TeacherId");

                    b.HasKey("Id");

                    b.ToTable("ClassAssignement");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentID")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID")
                        .HasName("IX_DepartmentID");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartmentID")
                        .HasColumnName("DepartmentID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("TotalAverage");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID")
                        .HasName("IX_DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.CourseAssignement", b =>
                {
                    b.Property<int>("TeaherId");

                    b.Property<int>("CourseId");

                    b.HasKey("TeaherId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseAssignement");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Enrollement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassID");

                    b.Property<DateTime>("EnrollementDate");

                    b.Property<int>("StudentID");

                    b.HasKey("Id");

                    b.ToTable("Enrollement");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.PaiementFor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Month")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PaiementFor");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.PaiementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PaimentType");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Paiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("MonthId");

                    b.Property<DateTime>("PaidOn");

                    b.Property<int>("StudentID");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("MonthId");

                    b.HasIndex("StudentID");

                    b.HasIndex("Type");

                    b.ToTable("Paiment");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasDiscriminator<string>("Discriminator").HasValue("People");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Percentage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("PeriodID");

                    b.Property<int>("StudentID");

                    b.HasKey("Id");

                    b.HasIndex("PeriodID");

                    b.HasIndex("StudentID");

                    b.ToTable("Percentage");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Period", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Period");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("PeriodID");

                    b.Property<double>("Point");

                    b.Property<int>("StudentID");

                    b.HasKey("Id");

                    b.HasIndex("CourseID");

                    b.HasIndex("PeriodID");

                    b.HasIndex("StudentID");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Student", b =>
                {
                    b.HasBaseType("SchoolSolution.Infrastructure.Entities.People");

                    b.Property<DateTime>("DateofBirth")
                        .HasColumnType("date");

                    b.Property<bool>("IsEnrolled");

                    b.Property<byte[]>("Photo");

                    b.Property<string>("StudentNumber")
                        .HasColumnType("varchar(100)");

                    b.HasIndex("StudentNumber")
                        .HasName("IX_StudentNum");

                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Teacher", b =>
                {
                    b.HasBaseType("SchoolSolution.Infrastructure.Entities.People");

                    b.Property<string>("Email");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("PhoneNumber");

                    b.Property<decimal>("Salary");

                    b.ToTable("Teacher");

                    b.HasDiscriminator().HasValue("Teacher");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Classe", b =>
                {
                    b.HasOne("SchoolSolution.Infrastructure.Entities.Department", "department")
                        .WithMany("Classes")
                        .HasForeignKey("DepartmentID")
                        .HasConstraintName("FK_Classe_Department_DepartmentID");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Course", b =>
                {
                    b.HasOne("SchoolSolution.Infrastructure.Entities.Department", "department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .HasConstraintName("FK_Course_Department_DepartmentID");
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.CourseAssignement", b =>
                {
                    b.HasOne("SchoolSolution.Infrastructure.Entities.Course", "Course")
                        .WithMany("CourseAssigned")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSolution.Infrastructure.Entities.Teacher", "Teacher")
                        .WithMany("CourseAssigned")
                        .HasForeignKey("TeaherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Paiment", b =>
                {
                    b.HasOne("SchoolSolution.Infrastructure.Entities.PaiementFor", "Month")
                        .WithMany("Paiements")
                        .HasForeignKey("MonthId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSolution.Infrastructure.Entities.Student", "Student")
                        .WithMany("Paiements")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSolution.Infrastructure.Entities.PaiementType", "PType")
                        .WithMany("Paiements")
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Percentage", b =>
                {
                    b.HasOne("SchoolSolution.Infrastructure.Entities.Period", "Period")
                        .WithMany("Percentages")
                        .HasForeignKey("PeriodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSolution.Infrastructure.Entities.Student", "Student")
                        .WithMany("Percentages")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SchoolSolution.Infrastructure.Entities.Score", b =>
                {
                    b.HasOne("SchoolSolution.Infrastructure.Entities.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSolution.Infrastructure.Entities.Period", "Period")
                        .WithMany("Scores")
                        .HasForeignKey("PeriodID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SchoolSolution.Infrastructure.Entities.Student", "Student")
                        .WithMany("Scores")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
