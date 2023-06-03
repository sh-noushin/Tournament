using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;
using Tournament.API.Domain.Participants.Exceptions;

namespace Tournament.API.Domain.Participants
{
    public class Participant: BaseEntity<int>
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        internal Participant(string name, string lastName)
        {
            SetLastName(name);
            SetLastName(lastName);  
        }

        internal void SetName(string name)
        { 
            if(string.IsNullOrEmpty(name))
            { 
                
                throw new NullOrEmptyParticipantNameOrLastNameException(); 
            }    

            Name = name;
        }
        internal void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                
                throw new NullOrEmptyParticipantNameOrLastNameException();
            }

            LastName = lastName;
        }
    }
}
