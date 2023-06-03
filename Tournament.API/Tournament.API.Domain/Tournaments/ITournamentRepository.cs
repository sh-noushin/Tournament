using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Domain.Core;

namespace Tournament.API.Domain.Tournaments
{
    public interface ITournamentRepository : IBaseRepository<Tournament, int>
    {
    }
}
