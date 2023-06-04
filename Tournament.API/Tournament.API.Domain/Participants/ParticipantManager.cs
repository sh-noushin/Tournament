using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Participants.Exceptions;

namespace Tournament.API.Domain.Participants
{
    public class ParticipantManager : IParticipantManager
    {
        private readonly IParticipantRepository _repository;

        public ParticipantManager(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Participant> CreateAsync(string name, string lastName)
        {
            var participant = new Participant(name, lastName);
            await _repository.CreateAsync(participant); 
            return participant;
        }

        public async Task<int> DeleteAsync(int id)
        {
           if(!await _repository.AnyAsync(x => x.Id == id))
            {
                throw new ParticipantNotExistsException(id);
            }

           return await _repository.DeleteAsync(id);  

        }

        public async Task<Participant> UpdateAsync(int id, string name, string lastName)
        {
            var participant = await _repository.GetAsync(id);
            if(participant == null)
            {
                throw new ParticipantNotExistsException(id);
            }
            participant.SetName(name);
            participant.SetLastName(lastName);
            await _repository.UpdateAsync(participant); 
            return participant; 

        }
    }
}
