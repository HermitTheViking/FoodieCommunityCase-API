using FirebaseAdmin;
using FoodieCommunityCase.Domain.CommandHandlers;
using FoodieCommunityCase.Domain.Commands;
using FoodieCommunityCase.Domain.Entities;
using FoodieCommunityCase.Domain.Entities.Food;
using FoodieCommunityCase.Domain.Events;
using FoodieCommunityCase.Domain.Events.Food;
using FoodieCommunityCase.Domain.Events.Foodrepo;
using FoodieCommunityCase.Domain.Mappers;
using FoodieCommunityCase.Domain.Messaging;
using FoodieCommunityCase.Domain.Models;
using FoodieCommunityCase.Domain.Repository;
using FoodieCommunityCase.Domain.Repository.Implementations;
using FoodieCommunityCase.Domain.Time;
using FoodieCommunityCase.WebApi.Mappers;
using FoodieCommunityCase.WebApi.Models;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;

namespace FoodieCommunityCase
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
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", Configuration.GetSection("GOOGLE_APPLICATION_CREDENTIALS").Value);

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS") ?? "GOOGLE_APPLICATION_CREDENTIALS")
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://securetoken.google.com/{Configuration.GetSection("ProjectId").Value}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://securetoken.google.com/{Configuration.GetSection("ProjectId").Value}",
                    ValidateAudience = true,
                    ValidAudience = $"{Configuration.GetSection("ProjectId").Value}",
                    ValidateLifetime = true
                };
            });

            services.AddScoped<FoodrepoEventFactory>();
            services.AddScoped<FoodEventFactory>();

            services.AddScoped<IMessageBus, FakeBus>();
            services.AddScoped<ITimeService, TimeService>();
            services.AddScoped<IEventStore, EventStore>();

            services.AddScoped<IMapper<RecipModel, Recip>, RecipModelMapper>();
            services.AddScoped<IMapper<NutrientModel, Nutrient>, NutrientModelMapper>();
            services.AddScoped<IMapper<NutrientInfoModel, NutrientInfo>, NutrientInfoModelMapper>();

            services.AddScoped<IMapper<CreateRecipCommand, Recip>, CreateRecipCommandMapper>();
            services.AddScoped<IMapper<CreateNutrientCommand, Nutrient>, CreateNutrientCommandMapper>();
            services.AddScoped<IMapper<CreateNutrientInfoCommand, NutrientInfo>, CreateNutrientInfoCommandMapper>();

            services.AddScoped<IMapper<UpdateRecipCommand, Recip>, UpdateRecipCommandMapper>();
            services.AddScoped<IMapper<UpdateNutrientCommand, Nutrient>, UpdateNutrientCommandMapper>();
            services.AddScoped<IMapper<UpdateNutrientInfoCommand, NutrientInfo>, UpdateNutrientInfoCommandMapper>();

            services.AddScoped<IMapper<Recip, RecipDto>, RecipMapper>();
            services.AddScoped<IMapper<Nutrient, NutrientDto>, NutrientMapper>();
            services.AddScoped<IMapper<NutrientInfo, NutrientInfoDto>, NutrientInfoMapper>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IFoodrepoRepository, FoodrepoRepository>();

            services.AddScoped<ICommandHandler, FoodrepoCommandHandler>();
            services.AddScoped<ICommandHandler, FoodCommandHandler>();

            services.AddDbContext<FoodEntities>(options =>
#if DEBUG
                    options.EnableSensitiveDataLogging(true)
#else
                    options.EnableSensitiveDataLogging(false)
#endif
                    .UseSqlServer(Configuration.GetConnectionString("dbcontext"))
                    );

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyCorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseHttpsRedirection();

            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors("AllowAnyCorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
