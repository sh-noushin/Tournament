using Tournament.API.Domain.Participants;

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
            return tournament;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);  
        }

        public async Task<Tournament> RemoveAttemtAsync(int tournamentId, int participantId, int distance)
        {
            var tournament = await _repository.FindAsync(tournamentId);
            if(tournament == null)
            {
                // TODO
                throw new Exception();
            }

            tournament.RemoveAttempt(participantId, distance);
            return tournament;
        }

        public async Task<Tournament> UpdateAsync(int id, string name)
        {
            var tournamnet = await _repository.GetAsync(id);
            if (tournamnet == null)
            {
                // TODO
                throw new NotImplementedException();    
            }

            tournamnet.SetName(name);
            return tournamnet;
        }

        
    }
}
