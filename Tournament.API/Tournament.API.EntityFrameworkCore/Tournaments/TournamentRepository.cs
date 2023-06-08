using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using Tournament.API.Domain.Core.Extentions;
using Tournament.API.Domain.Participants;
using Tournament.API.Domain.Tournaments;
using Tournament.API.Domain.Tournaments.Views;
using Tournament.API.EntityFrameworkCore.Core;

namespace Tournament.API.EntityFrameworkCore.Tournaments
{
    public class TournamentRepository : BaseRepository<TournamentAPIDbContext, Domain.Tournaments.Tournament, int>, ITournamentRepository
    {
        public TournamentRepository(TournamentAPIDbContext db)
            : base(db)
        {
        }


        public async Task<long> GetCountAsync(string filter)
        {
            var query = Db.Tournaments.AsQueryable();

            query = ApplyFilter(query, filter);

            return await query.CountAsync();
        }

        public async Task<List<TournamentWithAttemptsView>> GetFilteredListAsync(string filterText, string sorting, int skipCount = 0, int maxResultCount = 10)
        {
            var query = Db.Tournaments.Include(x => x.Attempts).AsQueryable()
                .Select(x => new TournamentWithAttemptsView
                {
                    Id = x.Id,
                    Name = x.Name,

                    Attempts = (from jumpAttempt in Db.Set<JumpAttempt>()
                                where jumpAttempt.TournamentId == x.Id
                                select new JumpAttemptView
                                {
                                    TournamentId = jumpAttempt.TournamentId,
                                    ParticipantId = jumpAttempt.ParticipantId,
                                    Distance = jumpAttempt.Distance
                                }).ToList()
                });

            query = ApplyFilterWithAttempts(query, filterText)
               .OrderBy(!string.IsNullOrEmpty(sorting) ? sorting : "Id asc")
               .PageBy(skipCount, maxResultCount);

            return await query.ToListAsync();
        }

        public async Task<List<JumpAttemptsWithDetailView>> GetTopTenAttemptsListAsync(string filterText)
        {
            var query = Db.JumpAttempts.AsQueryable()
                 .Join(Db.Participants, ja => ja.ParticipantId, part => part.Id,
                 (ja, part) => new { JumpAttempt = ja, Participant = part, Tournament = ja.Tournament })
                 .WhereIf(!string.IsNullOrEmpty(filterText), x => x.Tournament.Name.Contains(filterText));
            return (await query.ToListAsync()).GroupBy(x => new { Tid = x.Tournament.Id, PId = x.Participant.Id })
                            .Select(x => new JumpAttemptsWithDetailView
                            {
                                ParticipantName = x.ElementAt(0).Participant.Name,
                                ParticipantLastName = x.ElementAt(0).Participant.LastName,
                                TournamentName = x.ElementAt(0).Tournament.Name,
                                Distance = x.Max(i => i.JumpAttempt.Distance)
                            }).Take(10).OrderByDescending(d => d.Distance).ToList();

           
    }

    protected IQueryable<Domain.Tournaments.Tournament> ApplyFilter(IQueryable<Domain.Tournaments.Tournament> query, string filtertext)
    {
        return query.WhereIf(!string.IsNullOrEmpty(filtertext), x => x.Name.Contains(filtertext));

    }

    protected IQueryable<TournamentWithAttemptsView> ApplyFilterWithAttempts(IQueryable<TournamentWithAttemptsView> query, string filtertext)
    {
        return query.WhereIf(!string.IsNullOrEmpty(filtertext), x => x.Name.Contains(filtertext));

    }
            


}
}
