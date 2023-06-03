using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Ecxeptions
{
    public class InvalidJumpDistanceException: Exception
    {
        public InvalidJumpDistanceException(int maxDistance)
            :base($"Jump distance must be between 0 and {maxDistance}") 
        {

        }
    }
}
