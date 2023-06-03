using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Shared.Tournaments;

namespace Tournament.API.Domain.Tournaments.Exceptions
{
    public class MaximumNumberOfJumpsException: Exception
    {
        public MaximumNumberOfJumpsException(int maxNumberOfJumps)
            : base($"Maximun number of jumps could not be greater than {maxNumberOfJumps}")
        {

        }
    }
}
