using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Exceptions
{
    internal class TournamentNotExistsException: Exception
    {
        public TournamentNotExistsException(int id)
            :base($"Tournament with id {id} does not exist.")
        {

        }
    }
}
