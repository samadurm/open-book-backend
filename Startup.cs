using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OpenBook.Models;
using OpenBook.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OpenBook
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<PersonContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
    
            services.AddDbContext<CourseContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            
            services.AddDbContext<LessonContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddDbContext<StudentCoursesContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddDbContext<CourseLessonsContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddControllers();

            services.AddSingleton(x => new BlobServiceClient(Configuration.GetConnectionString("AzureBlobStorageConnectionString")));
            services.AddSingleton<IBlobService, BlobService>();

            services.AddCors(options => 
            {
                options.AddDefaultPolicy(
                    builder => 
                    {
                        builder.WithOrigins("https://web.engr.oregonstate.edu/~mayma/openbook/");
                    }
                );
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = "https://openbook.us.auth0.com/";
                options.Audience = "https://localhost:5001/api";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
