
using Microsoft.EntityFrameworkCore;
using Soccer_IQ.Data;
using Soccer_IQ.Models;
using Soccer_IQ.Repository.IRepository;

namespace Soccer_IQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IRepository<Player>, PlayerRepository>();
            builder.Services.AddScoped<IRepository<Club>, ClubRepository>();
            builder.Services.AddScoped<IRepository<PLayerStat>, PlayerStatRepository>();
            builder.Services.AddScoped<IRepository<LeagueStanding>, LeagueStandingRepository>();
            builder.Services.AddHttpClient();
            builder.Services.AddScoped<StandingsSyncService>();
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
