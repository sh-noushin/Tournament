using Tournament.API.Domain.Participants;
using Tournament.API.Domain.Tournaments.Exceptions;

namespace Tournament.API.Domain.Tournaments
{
    public class TournamentManager : ITournamentManager
    {
        private readonly ITournamentRepository _repository;
        private readonly IParticipantRepository _participantRepository;

        public TournamentManager(ITournamentRepository repository, IParticipantRepository participantRepository)
        {
            _repository = repository;
            _participantRepository = participantRepository;
        }

        public async Task<Tournament> AddAttemtAsync(int tournamnetId, int participantId, int distance)
        {
           
            if(! await _participantRepository.AnyAsync(x => x.Id == participantId))
            {
                // TODO
                throw new Exception();
            }
            var tournament = await _repository.FindAsync(x => x.Id == tournamnetId);
            if (tournament == null)
            {
                // TODO
                throw new Exception();
            }

            tournament.AddAttempt(participantId, distance);
            await _repository.UpdateAsync(tournament);
            return tournament;
        }

        public async Task<Tournament> CreateAsync(string name)
        {
            
            if(await _repository.AnyAsync(x => x.Name == name))
            {
                // TODO: exception
                throw new Exception();
            }
            var tournament = new Tournament(name);
            await _repository.CreateAsync(tournament);
            return tournament;
        }

        public async Task<int> DeleteAsync(int id)
        {
           return await _repository.DeleteAsync(id);  
        }

        public async Task<Tournament> RemoveAttemtAsync(int tournamentId, int participantId, int distance)
        {
            var tournament = await _repository.FindAsync(tournamentId);
            if(tournament == null)
            {
                throw new TournamentNotExistsException(tournamentId);
            }

            tournament.RemoveAttempt(participantId, distance);
            await _repository.UpdateAsync(tournament);
            return tournament;
        }

        public async Task<Tournament> UpdateAsync(int id, string name)
        {
            var tournamnet = await _repository.GetAsync(id);
            if (tournamnet == null)
            {
                throw new TournamentNotExistsException(id);    
            }

            tournamnet.SetName(name);
            await _repository.UpdateAsync(tournamnet);
            return tournamnet;
        }

        
    }
}
