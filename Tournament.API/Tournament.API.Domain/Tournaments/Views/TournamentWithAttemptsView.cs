using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.API.Domain.Tournaments.Views
{
    public class TournamentWithAttemptsView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<JumpAttemptView> Attempts { get; set; }
    }
}
