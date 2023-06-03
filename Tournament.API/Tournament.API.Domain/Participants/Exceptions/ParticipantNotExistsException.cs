using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Participants.Exceptions
{
    public class ParticipantNotExistsException: Exception
    {
        public ParticipantNotExistsException(int id)
            :base($"Participant with id {id} does not exist.")
        {

        }
    }
}
