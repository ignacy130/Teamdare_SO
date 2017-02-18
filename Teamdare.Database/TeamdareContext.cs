using Microsoft.EntityFrameworkCore;
using Teamdare.Database.Entities;

namespace Teamdare.Database
{
    public class TeamdareContext : DbContext
    {
        public TeamdareContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Adventure> Adventures { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<GameMaster> GameMasters { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Reward> Rewards { get; set; }
    }
}