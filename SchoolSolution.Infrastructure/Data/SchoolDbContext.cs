using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolSolution.Infrastructure.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
        {

        }
       
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        
        public virtual DbSet<Classe> Classe { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Enrollement> Enrollement { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PaiementType> PaimentType { get; set; }
        public virtual DbSet<Paiment> Paiment { get; set; }
        public virtual DbSet<PaiementFor> PaiementFor { get; set; }
        public virtual DbSet<Period> Period { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<Percentage> Percentage { get; set; }
        public virtual DbSet<CourseAssignement> CourseAssignement { get; set; }
        public virtual DbSet<ClassAssignement> ClassAssignement { get; set; }
        public virtual DbSet<ClassesCourses> ClassesCourses { get; set; }


<<<<<<< Updated upstream
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=SchoolContext.db;Integrated Security=True");
        //}
=======
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename = ./bin/school.db");
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Context.db;Integrated Security=True");
        }
>>>>>>> Stashed changes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Classe>(entity =>
            {
               
                entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
                

                entity.HasOne(d => d.department)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Classe_Department_DepartmentID");
                entity.HasMany(e => e.CoursesByClasse)
                 .WithOne(e => e.Classe)
                 .HasForeignKey(e => e.ClassId);
                entity.HasMany(e => e.Scores)
                 .WithOne(e => e.Classe)
                 .HasForeignKey(e => e.ClassId);



            });

            modelBuilder.Entity<Course>(entity =>
            {
               

                entity.Property(e => e.DepartmentID).HasColumnName("DepartmentID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.department)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.DepartmentID)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Course_Department_DepartmentID");
                entity.HasMany(e => e.CourseAssigned)
                 .WithOne(e => e.Course)
                 .HasForeignKey(e => e.CourseId);
                entity.HasMany(e => e.CoursesInClass)
                 .WithOne(e => e.Course)
                 .HasForeignKey(e => e.CourseId);
                entity.Ignore(e => e.CheckboxAnswer);
            });
        

            modelBuilder.Entity<CourseAssignement>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.CourseId });
                entity.HasOne(e => e.Course).WithMany(e => e.CourseAssigned)
                .HasForeignKey(e => e.CourseId);
                entity.HasOne(e => e.Teacher).WithMany(e => e.CourseAssigned)
               .HasForeignKey(e => e.TeacherId);

            });
            modelBuilder.Entity<ClassesCourses>(entity =>
           {
               entity.HasKey(e => new { e.ClassId, e.CourseId });
               entity.HasOne(e => e.Course).WithMany(e => e.CoursesInClass)
               .HasForeignKey(e => e.CourseId);
               entity.HasOne(e => e.Classe).WithMany(e => e.CoursesByClasse)
              .HasForeignKey(e => e.ClassId);

           });



            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("date");
                entity.Property(e => e.ModifiedDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });
            modelBuilder.Entity<People>(entity =>
           {
               entity.Property(e => e.Firstname)
               .IsRequired()
               .HasColumnType("varchar(100)");
               entity.Property(e => e.Lastname)
               .IsRequired()
               .HasColumnType("varchar(100)");
               entity.Property(e => e.Address)
               .IsRequired()
               .HasColumnType("varchar(200)");
               entity.Property(e => e.Gender)
               .IsRequired()
               .HasColumnType("char(1)");
               entity.Property(e => e.CreatedDate).HasColumnType("date");


           });
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentNumber)
               .HasColumnType("varchar(100)");
                entity.Property(e => e.DateofBirth).HasColumnType("date");
               

                entity.HasMany(e => e.Paiements)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentID);
                entity.HasMany(e => e.Scores)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentID);
                entity.HasMany(e => e.Percentages)
               .WithOne(e => e.Student)
               .HasForeignKey(e => e.StudentID);

            });
            modelBuilder.Entity<Teacher>(entity =>
            {

                entity.HasMany(e => e.CourseAssigned)
                 .WithOne(e => e.Teacher)
                 .HasForeignKey(e => e.TeacherId);

            });
           


            modelBuilder.Entity<PaiementType>(entity =>
            {
                entity.HasMany(e => e.Paiements)
                .WithOne(e => e.PType)
                .HasForeignKey(e => e.Type);

                entity.Property(e => e.Description)
                .HasColumnType("varchar(100)");


            });
            modelBuilder.Entity<PaiementFor>(entity =>
            {
                entity.HasMany(e => e.Paiements)
                .WithOne(e => e.Month)
                .HasForeignKey(e => e.MonthId);

                entity.Property(e => e.Month)
                .HasColumnType("varchar(30)");


            });
            modelBuilder.Entity<Period>(entity =>
            {
                entity.HasMany(e => e.Scores)
                .WithOne(e => e.Period)
                .HasForeignKey(e => e.PeriodID);

                entity.HasMany(e => e.Percentages)
               .WithOne(e => e.Period)
               .HasForeignKey(e => e.PeriodID);



                entity.Property(e => e.Name)
                .HasColumnType("varchar(30)");


            });
        }
    }
}
