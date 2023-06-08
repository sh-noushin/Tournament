using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Core.Dtos.Responses;
using Tournament.API.Application.Contract.Tournaments;
using Tournament.API.Application.Contract.Tournaments.Dtos.Request;
using Tournament.API.Application.Contract.Tournaments.Dtos.Response;
using Tournament.API.Application.Core;
using Tournament.API.Domain.Tournaments;
using Tournament.API.Domain.Tournaments.Views;

namespace Tournament.API.Application.Tournaments
{
    public class TournamentService : BaseService, ITournamentService
    {
        private readonly ITournamentManager _tournamentManager;
        private readonly ITournamentRepository _tournamentRepository;   

        public TournamentService(ITournamentManager tournamentManager,
            ITournamentRepository tournamentRepository, IMapper mapper)

            :base(mapper)
        {
            _tournamentManager = tournamentManager;
            _tournamentRepository = tournamentRepository;
        }

        public async Task<TournamentDto> AddAttemptsAsync(TournamentAddAttemptInput input)
        {
           return Mapper.Map<TournamentDto>( await _tournamentManager.AddAttemtAsync(input.TournametId, input.ParticipantId, input.Distance));
        }

        public async Task<TournamentDto> CreateAsync(TournamentCreateInput input)
        {
            return Mapper.Map<TournamentDto>(await _tournamentManager.CreateAsync(input.Name));
           
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _tournamentRepository.DeleteAsync(id);
        }

        public async Task<TournamentDto> GetByIdAsync(int id)
        {
            return Mapper.Map<TournamentDto>(await _tournamentRepository.GetAsync(id));
        }

        public async Task<PagedResultResponse<TournamentWithAttemptsDto>> GetFilteredListAsync(TournamentListInput filter)
        {
            long totalCount = await _tournamentRepository.GetCountAsync(filter.Name);
            var items = await _tournamentRepository.GetFilteredListAsync(filter.Name, filter.Sorting, filter.SkipCount, filter.MaxResultCount);

            return new PagedResultResponse<TournamentWithAttemptsDto>()
            {
                TotalCount = totalCount,
                Items = Mapper.Map<List<TournamentWithAttemptsView>, List<TournamentWithAttemptsDto>>(items)
            };
        }

        public async Task<List<TournamentWithAttemptsDto>> GetListAsync(TournamentListInput input)
        {
            
            return Mapper.Map<List<TournamentWithAttemptsDto>>(await _tournamentRepository.GetListAsync(x => true));
        }

        public async Task<PagedResultResponse<TopAttemptsDto>> GetTopTenAttemptsListAsync(TopAttemptsListInput filter)
        {
            var items = await _tournamentRepository.GetTopTenAttemptsListAsync(filter.TournamentName);
            return new PagedResultResponse<TopAttemptsDto>()
            {
                TotalCount = items.Count(),
                Items = Mapper.Map<List<JumpAttemptsWithDetailView>, List<TopAttemptsDto>>(items)
            };

        }

        public async Task<TournamentDto> RemoveAttemptsAsync(TournamentRemoveAttemptInput input)
        {
            return Mapper.Map<TournamentDto>(await _tournamentManager.RemoveAttemtAsync(input.TournametId, input.ParticipantId, input.Distance));
        }

        public async Task<TournamentDto> UpdateAsync(int id, TournamentUpdateInput input)
        {
          return  Mapper.Map<TournamentDto>(await _tournamentManager.UpdateAsync(id, input.Name));   
        }
    }
}
