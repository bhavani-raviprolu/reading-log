using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySchool.ReadingLog.API.Mapping;
using MySchool.ReadingLog.DataAccess;
using MySchool.ReadingLog.DataAccess.Implementations;
using MySchool.ReadingLog.DataAccess.Interfaces;
using MySchool.ReadingLog.Services.Implementations;
using MySchool.ReadingLog.Services.Interfaces;
using Newtonsoft.Json.Converters;

namespace MySchool.ReadingLog.API
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
            services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.AccessDeniedPath = "/api/login/AccessDenied";
            })
            .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
            {
                var section = Configuration.GetSection("Authentication:Google");
                options.ClientId = section["ClientId"];
                options.ClientSecret = section["ClientSecret"];
                options.CallbackPath = "/api/login/signin-google";
            });

            services.AddHttpContextAccessor();
            services.AddDbContext<ReadingLogDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<IStudentService, StudentService>()
                    .AddScoped<IBooksService, BooksService>()
                    .AddScoped<IUserService, UserService>();

            services.AddScoped<IBookRepository, BookRepository>()
                    .AddScoped<IStudentRepository, StudentRepository>()
                    .AddScoped<IUserRepository, UserRepository>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Description = "Reading Log API",
                    Title = "Reading Log API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseAuthentication();
            
            app.UseRouting();
            app.UseAuthorization();

            
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}