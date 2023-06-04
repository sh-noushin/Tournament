using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Participants;

namespace Tournament.API.Domain.Tournaments
{
    public interface ITournamentManager
    {
        public Task<Tournament> CreateAsync(string name);
        public Task<Tournament> UpdateAsync(int id, string name);
        public Task<int> DeleteAsync(int id);
        public Task<Tournament> AddAttemtAsync(int tournamnetId, int participantId, int distance);
        public Task<Tournament> RemoveAttemtAsync(int tournamentId, int participantId, int distance);
    }
}
