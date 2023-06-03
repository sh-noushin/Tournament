using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Participants.Exceptions
{
    public class NullOrEmptyParticipantNameOrLastNameException : Exception
    {
        public NullOrEmptyParticipantNameOrLastNameException()
            : base("Name or last name of Participant could not be null or empty.")
        {

        }
    }
}
