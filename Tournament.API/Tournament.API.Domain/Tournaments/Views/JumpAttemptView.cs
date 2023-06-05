using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Views
{
    public class JumpAttemptView
    {
        public int TournamentId { get;  set; }
        public int ParticipantId { get;  set; }
        public int Distance { get;  set; }
    }
}
