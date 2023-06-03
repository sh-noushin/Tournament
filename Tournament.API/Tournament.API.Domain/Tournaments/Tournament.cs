using Tournament.API.Domain.Core;
using Tournament.API.Domain.Shared.Tournaments;
using Tournament.API.Domain.Tournaments.Ecxeptions;

namespace Tournament.API.Domain.Tournaments
{
    public class Tournament : BaseEntity<int>
    {
        public string Name { get; private set; }
        public List<JumpAttempt> Attempts { get; private set; }
        private Tournament()
        {
            Attempts = new List<JumpAttempt>(); 
        }
             
        internal Tournament(string name)
        {
            SetName(name);
        }

        internal void SetName(string name)
        {
            if (name.Length > TournamentConsts.NameMaxLength)
            {

                throw new TournamentNameLengthException();
            }
            // TODO: Check for null

            Name = name;
        }

        internal void AddAttempt(int participantId, int distance)
        {
            
            if(Attempts.Count(x => x.ParticipantId == participantId) >= 3 ) 
            {
                // TODO: Exception
                throw new Exception();
            }
            var attempt = new JumpAttempt(Id, participantId);
            attempt.SetDistance(distance);
            Attempts.Add(attempt);  

        }

        internal void RemoveAttempt(int participantId, int distance)
        {
            var attempt = Attempts.FirstOrDefault(x => x.ParticipantId == participantId &&
            x.Distance == distance);
            if (attempt != null) 
            {
                Attempts.Remove(attempt);   
            }
        }

    }
}
