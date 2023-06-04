using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Application.Contract.Participants.Dtos.Request
{
    public class ParticipantUpdateInput
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
