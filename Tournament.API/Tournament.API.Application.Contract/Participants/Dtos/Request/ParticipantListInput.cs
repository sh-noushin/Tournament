using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Core.Dtos.Requests;

namespace Tournament.API.Application.Contract.Participants.Dtos.Request
{
    public class ParticipantListInput: PagedAndSorted
    {
        public string AnyFilter { get; set; } = "";
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";

    }
}
