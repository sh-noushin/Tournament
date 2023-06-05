using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Tournaments.Dtos.Response;
using Tournament.API.Domain.Tournaments.Views;

namespace Tournament.API.Application.Tournaments
{
    public class TournamentsMappingProfile: Profile
    {
        public TournamentsMappingProfile()
        {
            CreateMap<Domain.Tournaments.Tournament, TournamentDto>();
            CreateMap<TournamentWithAttemptsView, TournamentWithAttemptsDto>();
        }
    }
}
