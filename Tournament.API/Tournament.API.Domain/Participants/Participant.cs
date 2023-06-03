using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;

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
                //TODO: Exception
                throw new ArgumentNullException("name"); 
            }    

            Name = name;
        }
        internal void SetLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                //TODO: Exception
                throw new ArgumentNullException("lastName");
            }

            LastName = lastName;
        }
    }
}
