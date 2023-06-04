using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;
using Tournament.API.Domain.Shared.Tournaments;
using Tournament.API.Domain.Tournaments.Ecxeptions;

namespace Tournament.API.Domain.Tournaments
{
    public class JumpAttempt 
    {
        public int TournamentId { get; private set; }

        public int ParticipantId { get; private set; }
        public int Distance { get; private set; }
        public Tournament Tournament { get; set; }
        public JumpAttempt(int tournamentId, int participantId)
        {
            TournamentId = tournamentId;
            ParticipantId = participantId;
        }

        internal void SetDistance(int distance)
        {
            if (distance < 0 || distance > TournamentConsts.JumpDistanceMaxValue)
            {
                throw new InvalidJumpDistanceException(TournamentConsts.JumpDistanceMaxValue);
            }
            Distance= distance;
        }

    }
}
