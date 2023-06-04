using Microsoft.AspNetCore.Mvc;
using Tournament.API.Application.Contract.Participants;
using Tournament.API.Application.Contract.Participants.Dtos.Request;
using Tournament.API.Application.Contract.Participants.Dtos.Response;

namespace Tournament.API.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService _participantService;
        public ParticipantController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpPost]
        public async Task<string> CreateAsync(ParticipantCreateInput input)
        {
            await _participantService.CreateAsync(input);
            return Task.FromResult("Created").ToString();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<string> UpdateAsync(int id, ParticipantUpdateInput input)
        {
            await _participantService.UpdateAsync(id, input);
            return Task.FromResult("Updated").ToString();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            await _participantService.DeleteAsync(id);
            return Task.FromResult("Deleted").ToString();
        }

        [HttpGet]
        public async Task<List<ParticipantDto>> GetListAsync([FromQuery]  ParticipantListInput input)
        {
            
            return await _participantService.GetListAsync(input);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ParticipantDto> GetByIdAsync(int id)
        {
            return await _participantService.GetByIdAsync(id);
        }

    }
}
