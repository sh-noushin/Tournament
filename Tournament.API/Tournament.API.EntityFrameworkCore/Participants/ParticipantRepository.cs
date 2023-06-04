using Microsoft.EntityFrameworkCore;
using Tournament.API.Domain.Core.Extentions;
using Tournament.API.Domain.Participants;
using Tournament.API.EntityFrameworkCore.Core;
using System.Linq.Dynamic.Core;


namespace Tournament.API.EntityFrameworkCore.Participants
{
    public class ParticipantRepository : BaseRepository<TournamentAPIDbContext, Participant, int> , IParticipantRepository
    {
        public ParticipantRepository(TournamentAPIDbContext db)
            :base(db) 
        {

        }

        public async Task<long> GetCountAsync(string filter, string name, string lastname)
        {
            var query = Db.Participants.AsQueryable();

            query = ApplyFilter(query, filter, name, lastname);

            return await query.CountAsync();
        }

        public async Task<List<Participant>> GetFilteredListAsync(string filterText, string name, string lastname, string sorting, int skipCount = 0, int maxResultCount = 10)
        {
            var query = Db.Participants.AsQueryable();

            query = ApplyFilter(query, filterText, name, lastname)
               .OrderBy(!string.IsNullOrEmpty(sorting) ? sorting : "Id asc")
               .PageBy(skipCount, maxResultCount);
            return await query.ToListAsync();
        }

        protected IQueryable<Participant> ApplyFilter(IQueryable<Participant> query, string filtertext, string name, string lastname)
        {
            return query.WhereIf(!string.IsNullOrWhiteSpace(filtertext), x =>
                x.Name.Contains(filtertext) ||
                x.LastName.Contains(filtertext))
                .WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name.Contains(name))
                .WhereIf(!string.IsNullOrWhiteSpace(lastname), x => x.LastName.Contains(lastname));

        }

    }
}
