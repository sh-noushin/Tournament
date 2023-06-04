using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;

namespace Tournament.API.Domain.Participants
{
   public interface IParticipantManager
    {
        public Task<Participant> CreateAsync(string name, string lastName);
        public Task<Participant> UpdateAsync(int id, string name, string lastName);
        public Task<int> DeleteAsync(int id);    
    }
}
