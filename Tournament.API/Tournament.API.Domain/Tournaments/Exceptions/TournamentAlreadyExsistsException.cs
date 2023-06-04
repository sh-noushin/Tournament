using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Exceptions
{
    public class TournamentAlreadyExsistsException : Exception
    {
        public TournamentAlreadyExsistsException(string name)
            : base($"Tournament with name: {name} already exists.")
        {

        }
    }
}
