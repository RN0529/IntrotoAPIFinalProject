using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using AnimeCardAPI.Models;

namespace AnimeCardAPI.Models
{
    public class AnimeAPIContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AnimeAPIContext(DbContextOptions<AnimeAPIContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("AnimeCardAPI");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        public DbSet<BoosterBox> BoosterBox { get; set; } = null!;
        public DbSet<Card> Card { get; set; } = null!;
    }
}
