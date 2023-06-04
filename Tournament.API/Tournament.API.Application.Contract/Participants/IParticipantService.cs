using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Core;
using Tournament.API.Application.Contract.Core.Dtos.Responses;
using Tournament.API.Application.Contract.Participants.Dtos.Request;
using Tournament.API.Application.Contract.Participants.Dtos.Response;
using Tournament.API.Application.Contract.Tournaments.Dtos.Request;
using Tournament.API.Application.Contract.Tournaments.Dtos.Response;

namespace Tournament.API.Application.Contract.Participants
{
    public interface IParticipantService: IBaseService
    {
        public Task<ParticipantDto> GetByIdAsync(int id);
        public Task<List<ParticipantDto>> GetListAsync(ParticipantListInput input);
        public Task<ParticipantDto> CreateAsync(ParticipantCreateInput input);
        public Task<int> DeleteAsync(int id);
        public Task<ParticipantDto> UpdateAsync(int id, ParticipantUpdateInput input);
        Task<PagedResultResponse<ParticipantDto>> GetFilteredListAsync(ParticipantListInput filter);

    }
}
