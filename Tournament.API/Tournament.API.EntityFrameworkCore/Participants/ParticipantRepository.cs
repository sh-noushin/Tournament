using Tournament.API.Domain.Participants;
using Tournament.API.EntityFrameworkCore.Core;

namespace Tournament.API.EntityFrameworkCore.Participants
{
    public class ParticipantRepository : BaseRepository<TournamentAPIDbContext, Participant, int> , IParticipantRepository
    {
        public ParticipantRepository(TournamentAPIDbContext db)
            :base(db) 
        {

        }
    }
}
