using Microsoft.EntityFrameworkCore;
using Tournament.API.Domain.Tournaments;
using Tournament.API.Domain.Participants;

namespace Tournament.API.EntityFrameworkCore
{
    public class TournamentAPIDbContext: DbContext
    {
        public DbSet<Domain.Tournaments.Tournament> Tournaments { get; set; }
        public DbSet<Participant> Participants { get; set; }

        public TournamentAPIDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }
}
