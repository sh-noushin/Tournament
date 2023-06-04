using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.API.Application.Contract.Participants.Dtos.Response;
using Tournament.API.Domain.Participants;

namespace Tournament.API.Application.Participants
{
    public class ParticipantsMappingProfile: Profile
    {
        public ParticipantsMappingProfile()
        {
            CreateMap<Participant, ParticipantDto>();
        }
    }
}
