using Microsoft.EntityFrameworkCore;
using Teamdare.Database.Entities;

namespace Teamdare.Database
{
    public class TeamdareContext : DbContext
    {
        private readonly string _connectionString;
        public TeamdareContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this._connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<GameMaster> GameMasters { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Reward> Rewards { get; set; }
    }
}