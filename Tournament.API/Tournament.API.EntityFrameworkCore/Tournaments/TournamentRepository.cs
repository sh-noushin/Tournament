using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.X509Certificates;
using Tournament.API.Domain.Core.Extentions;
using Tournament.API.Domain.Tournaments;
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

        public async Task<List<Domain.Tournaments.Tournament>> GetFilteredListAsync(string filterText, string sorting, int skipCount = 0, int maxResultCount = 10)
        {
            var query = Db.Tournaments.AsQueryable();

            query = ApplyFilter(query, filterText)
               .OrderBy(!string.IsNullOrEmpty(sorting) ? sorting : "Id asc")
               .PageBy(skipCount, maxResultCount);
            return await query.ToListAsync();
        }

        protected IQueryable<Domain.Tournaments.Tournament> ApplyFilter(IQueryable<Domain.Tournaments.Tournament> query, string filtertext)
        {
            return query.WhereIf(!string.IsNullOrEmpty(filtertext), x => x.Name.Contains(filtertext));

        }


    }
}
