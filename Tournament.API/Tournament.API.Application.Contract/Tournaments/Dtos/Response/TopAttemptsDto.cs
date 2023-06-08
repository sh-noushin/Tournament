using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Application.Contract.Tournaments.Dtos.Response
{
    public class TopAttemptsDto
    {
        public string TournamentName { get; set; }
        public string ParticipantName { get; set; }
        public string ParticipantLastName { get; set; }
        public int Distance { get; set; }
    }
}
