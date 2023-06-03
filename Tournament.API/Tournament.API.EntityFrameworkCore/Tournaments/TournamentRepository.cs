using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
