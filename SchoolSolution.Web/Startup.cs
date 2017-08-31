<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSolution.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Interfaces;
using SchoolSolution.Infrastructure.Repositories;

namespace SchoolSolution.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SchoolDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SchoolSolution")));
            //Add All my services
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IClass, ClassRepository>();
            services.AddScoped<IStudent, StudentRepository>();
            services.AddScoped<ITeacher, TeacherRepository>();
            services.AddScoped<IScore, ScoreRepository>();
            services.AddScoped<IPeriod, PeriodRepository>();
            services.AddScoped<IPaymentType, PaiementTypeRepository>();
            services.AddScoped<IPayment, PaiementRepository>();
            services.AddScoped<IPaymentFor, PaiementForRepository>();
            services.AddScoped<IMatrix, MatrixRepository>();
            services.AddScoped<IEnrollement, EnrollementRepository>();
            services.AddScoped<ICourseAssignement, CourseAssignRepository>();
            services.AddScoped<IClasseCourse, ClasseCourseRepository>();
            services.AddScoped<IClassAssign, ClassAssignRepository>();
            services.AddScoped<ICourse, CourseRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSolution.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SchoolSolution.Infrastructure.Interfaces;
using SchoolSolution.Infrastructure.Repositories;

namespace SchoolSolution.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<SchoolDbContext>(option =>
            option.UseSqlite("Filename = ./bin/schoolContext.db"));
            //services.AddDbContext<SchoolDbContext>(options=>
                //options.UseSqlServer(Configuration.GetConnectionString("SchoolSolution")));
            //Add All my services
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IClass, ClassRepository>();
            services.AddScoped<IStudent, StudentRepository>();
            services.AddScoped<ITeacher, TeacherRepository>();
            services.AddScoped<IScore, ScoreRepository>();
            services.AddScoped<IPeriod, PeriodRepository>();
            services.AddScoped<IPaymentType, PaiementTypeRepository>();
            services.AddScoped<IPayment, PaiementRepository>();
            services.AddScoped<IPaymentFor, PaiementForRepository>();
            services.AddScoped<IMatrix, MatrixRepository>();
            services.AddScoped<IEnrollement, EnrollementRepository>();
            services.AddScoped<ICourseAssignement, CourseAssignRepository>();
            services.AddScoped<IClasseCourse, ClasseCourseRepository>();
            services.AddScoped<IClassAssign, ClassAssignRepository>();
            services.AddScoped<ICourse, CourseRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            /*app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });*/



            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
>>>>>>> Stashed changes
