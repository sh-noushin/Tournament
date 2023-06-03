using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;

namespace Tournament.API.Domain.Participants
{
    public interface IParticipantRepository : IBaseRepository<Participant, int>  
    {

    }
}
