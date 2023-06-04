using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Application.Contract.Tournaments.Dtos.Request
{
    public class TournamentAddAttemptInput
    {
        public int TournametId { get; set; }
        public int ParticipantId { get; set; }
        public int Distance { get; set; }

    }
}
