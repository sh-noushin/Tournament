using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Shared.Tournaments;

namespace Tournament.API.Domain.Tournaments.Ecxeptions
{
    public class TournamentNameLengthException : Exception
    {
        public TournamentNameLengthException()
             : base($"Tournament name length exceeds {TournamentConsts.NameMaxLength} charachters.")
        {

        }
    }
}
