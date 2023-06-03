using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Participants
{
    public class ParticipantManager : IParticipantManager
    {
        private readonly IParticipantRepository _repository;

        public ParticipantManager(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public Task<Participant> CreateAsync(string name, string lastName)
        {
            var participant = new Participant(name, lastName);
            return Task.FromResult(participant);
        }

        public async Task DeleteAsync(int id)
        {
            // TODO: check for existence
            await _repository.DeleteAsync(id);  
        }

        public async Task<Participant> UpdateAsync(int id, string name, string lastName)
        {
            var participant = await _repository.GetAsync(id);
            // TODO: Check for null
            participant.SetName(name);
            participant.SetLastName(lastName);
            return participant; 

        }
    }
}
