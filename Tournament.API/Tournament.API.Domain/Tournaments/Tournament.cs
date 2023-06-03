using Tournament.API.Domain.Core;
using Tournament.API.Domain.Shared.Tournaments;
using Tournament.API.Domain.Tournaments.Ecxeptions;

namespace Tournament.API.Domain.Tournaments
{
    public class Tournament : BaseEntity<int>
    {
        public string? Name { get; private set; }
        public List<JumpAttempt> Attempts { get; set; }
        public Tournament()
        {

        }
        public Tournament(string name)
        {
            SetName(name);
        }

        private void SetName(string name)
        {
            if (name.Length > TournamentConsts.NameMaxLength)
            {

                throw new TournamentNameLengthException();
            }

            Name = name;
        }
    }
}
