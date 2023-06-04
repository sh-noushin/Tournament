using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Core;
using Tournament.API.Application.Contract.Participants.Dtos.Request;
using Tournament.API.Application.Contract.Tournaments.Dtos.Request;
using Tournament.API.Application.Contract.Tournaments.Dtos.Response;
using Tournament.API.Domain.Tournaments;

namespace Tournament.API.Application.Contract.Tournaments
{
    public interface ITournamentService : IBaseService
    {
        public Task<TournamentDto> GetByIdAsync(int id);
        public Task<List<TournamentDto>> GetListAsync(TournamentListInput input);
        public Task<TournamentDto> CreateAsync(TournamentCreateInput input);
        public Task<int> DeleteAsync(int id);
        public Task<TournamentDto> UpdateAsync(int id, TournamentUpdateInput input);
        public Task<TournamentDto> AddAttemptsAsync(TournamentAddAttemptInput input);
        public Task<TournamentDto> RemoveAttemptsAsync(TournamentRemoveAttemptInput input);
       
    }
}
