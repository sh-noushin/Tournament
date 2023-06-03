using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;

namespace Tournament.API.Domain.Tournaments
{
    public class Jump : BaseEntity<int>
    {
        public int TournamentId { get; set; }
        public int ParticipantId { get; set; }
        public int Distance { get; set; }
    }
}
