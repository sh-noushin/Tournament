using Microsoft.EntityFrameworkCore;
using Tournament.API.Domain.Participants;
using Tournament.API.Domain.Tournaments;
using Domain = Tournament.API.Domain;

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
            modelBuilder.Entity<JumpAttempt>()

                 .HasKey(x => new { x.TournamentId, x.ParticipantId, x.Distance });
         

            modelBuilder.Entity<Tournament.API.Domain.Tournaments.Tournament>()

                .HasMany(x => x.Attempts)
                .WithOne()
                .HasForeignKey(x => x.TournamentId).IsRequired();

            modelBuilder.Entity<Participant>()

               .HasMany<JumpAttempt>()
               .WithOne()
               .HasForeignKey(x => x.ParticipantId).IsRequired();

        }
    }
}
