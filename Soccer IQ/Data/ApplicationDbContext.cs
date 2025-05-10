namespace Soccer_IQ.Data
{
    using Microsoft.EntityFrameworkCore;
    using Soccer_IQ.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PLayerStat> PlayerStats { get; set; }
        public DbSet<LeagueStanding> Standings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .HasMany(c => c.Players)
                .WithOne(p => p.Club)
                .HasForeignKey(p => p.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Player>()
                .HasMany(p => p.PlayerStats)
                .WithOne(ps => ps.Player)
                .HasForeignKey(ps => ps.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LeagueStanding>()
                .HasOne(ls => ls.Club)
                .WithMany() // لو مش هتضيف List<LeagueStanding> جوه Club
                .HasForeignKey(ls => ls.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
