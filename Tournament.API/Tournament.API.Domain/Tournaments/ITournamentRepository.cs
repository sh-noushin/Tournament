using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;
using Tournament.API.Domain.Tournaments.Views;

namespace Tournament.API.Domain.Tournaments
{
    public interface ITournamentRepository : IBaseRepository<Tournament, int>
    {
        Task<long> GetCountAsync(string filter);
        Task<List<TournamentWithAttemptsView>> GetFilteredListAsync(string filterText, string sorting, int skipCount = 0, int maxResultCount = 10);
        Task<List<JumpAttemptsWithDetailView>> GetTopTenAttemptsListAsync(string filterText);
      
    }
}
