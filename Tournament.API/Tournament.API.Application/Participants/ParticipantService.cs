using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Core.Dtos.Responses;
using Tournament.API.Application.Contract.Participants;
using Tournament.API.Application.Contract.Participants.Dtos.Request;
using Tournament.API.Application.Contract.Participants.Dtos.Response;
using Tournament.API.Application.Contract.Tournaments.Dtos.Response;
using Tournament.API.Application.Core;
using Tournament.API.Domain.Participants;

namespace Tournament.API.Application.Participants
{
    public class ParticipantService :BaseService,  IParticipantService
    {
        private readonly IParticipantManager _participantManager;
        private readonly IParticipantRepository _participantRepository;        

        public ParticipantService(IParticipantManager participantManager, 
            IParticipantRepository participantRepository, IMapper mapper)

            : base(mapper)  
            
        {
            _participantManager = participantManager;
            _participantRepository = participantRepository;
        }

        public async Task<ParticipantDto> CreateAsync(ParticipantCreateInput input)
        {
           return Mapper.Map<ParticipantDto>(await _participantManager.CreateAsync(input.Name, input.LastName));
        }

        public async Task<int> DeleteAsync(int id)
        {
           return await _participantManager.DeleteAsync(id);
        }

        public async Task<ParticipantDto> GetByIdAsync(int id)
        {
            return Mapper.Map<ParticipantDto>(await _participantRepository.GetAsync(id));
        }

        public async Task<PagedResultResponse<ParticipantDto>> GetFilteredListAsync(ParticipantListInput filter)
        {
            long totalCount = await _participantRepository.GetCountAsync(filter.AnyFilter, filter.Name, filter.LastName);
            var items = await _participantRepository.GetFilteredListAsync(filter.AnyFilter, filter.Name, filter.LastName, filter.Sorting, filter.SkipCount, filter.MaxResultCount);

            return new PagedResultResponse<ParticipantDto>()
            {
                TotalCount = totalCount,
                Items = Mapper.Map<List<Participant>, List<ParticipantDto>>(items)
            };
        }

        public async Task<List<ParticipantDto>> GetListAsync(ParticipantListInput input)
        {
            
            return Mapper.Map<List<ParticipantDto>>(await _participantRepository.GetListAsync(x => true));
        }

        public async Task<ParticipantDto> UpdateAsync(int id, ParticipantUpdateInput input)
        {
            return Mapper.Map<ParticipantDto>(await _participantManager.UpdateAsync(id, input.Name, input.LastName));
            
        }
    }
}
