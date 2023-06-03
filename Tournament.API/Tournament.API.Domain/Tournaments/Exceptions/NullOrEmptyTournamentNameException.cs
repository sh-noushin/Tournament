using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Exceptions
{
    public class NullOrEmptyTournamentNameException:Exception
    {
        public NullOrEmptyTournamentNameException()
            :base("Name of Tournament could not be null or empty.")
        {

        }
    }
}
