using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Core.Dtos.Requests;

namespace Tournament.API.Application.Contract.Tournaments.Dtos.Request
{
    public class TopAttemptsListInput 
    {
        public string TournamentName { get; set; } = "";
    }
}
