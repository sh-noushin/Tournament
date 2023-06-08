using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Views
{
    public class JumpAttemptsWithDetailView
    {
        public int TournamentId { get; set; }
        public int ParticipantId { get; set; }
        public string TournamentName { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantLastName { get; set; }
        public int Distance { get; set; }
    }
}
