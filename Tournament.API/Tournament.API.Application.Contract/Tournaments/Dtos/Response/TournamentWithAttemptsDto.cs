using Tournament.API.Domain.Tournaments.Views;

namespace Tournament.API.Application.Contract.Tournaments.Dtos.Response
{
    public class TournamentWithAttemptsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JumpAttemptView> Attempts { get; set; }
    }
}
