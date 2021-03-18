using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RecipesAPI.Data;
using RecipesAPI.Data.Repositories;
using RecipesAPI.Data.Repositories.Interfaces;
using RecipesAPI.Mapping;
using RecipesAPI.Services;
using RecipesAPI.Services.Interfaces;

namespace RecipesAPI
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RecipesAPI", Version = "v1" });
            });

            services.AddAutoMapper(typeof(ModelToResourceProfile), typeof(ResourceToModelProfile));

            // repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();

            // services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRecipesService, RecipesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RecipesAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
