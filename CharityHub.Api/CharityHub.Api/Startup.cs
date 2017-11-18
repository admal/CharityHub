using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using CharityHub.Services.Interfaces;
using CharityHub.Services;
using CharityHub.Domain;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CharityHub.Services.CharityService;
using CharityHub.Services.EventNotificationService;

namespace CharityHub.Api
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
            services.AddCors();

            services.AddDbContext<CharityHubContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });


            // Add application services.
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICryptographyService, CryptographyService>();
            services.AddTransient<ICharityService, CharityService>();
            services.AddTransient<ICharityEventService, CharityEventService>();
            services.AddTransient<IEmailNotificationService, EmailNotificationService>();
            services.AddTransient<IEventNotificationQueryService, EventNotificationQueryService>();

            services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile(provider.GetService<ICryptographyService>()));
            }).CreateMapper());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(builder => builder
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseMvc();
        }
    }
}
