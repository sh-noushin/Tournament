﻿using Microsoft.AspNetCore.Mvc;
using Tournament.API.Application.Contract.Core.Dtos.Requests;
using Tournament.API.Application.Contract.Core.Dtos.Responses;
using Tournament.API.Application.Contract.Participants.Dtos.Request;
using Tournament.API.Application.Contract.Participants.Dtos.Response;
using Tournament.API.Application.Contract.Tournaments;
using Tournament.API.Application.Contract.Tournaments.Dtos.Request;
using Tournament.API.Application.Contract.Tournaments.Dtos.Response;
using Tournament.API.Application.Tournaments;

namespace Tournament.API.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;

        public TournamentController(ITournamentService tournamentService)
        {
            _tournamentService = tournamentService;
        }

        [HttpPost]
        public async Task<string> CreateAsync(TournamentCreateInput input)
        {
            await _tournamentService.CreateAsync(input);
            return Task.FromResult("Created").ToString();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<string> UpdateAsync(int id, TournamentUpdateInput input)
        {
            await _tournamentService.UpdateAsync(id, input);
            return Task.FromResult("Updated").ToString();

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<string> DeleteAsync(int id)
        {
            await _tournamentService.DeleteAsync(id);
            return Task.FromResult("Deleted").ToString();
        }


        [HttpGet]
        public async Task<PagedResultResponse<TournamentWithAttemptsDto>> GetListAsync()
        {

            return await _tournamentService.GetFilteredListAsync(new TournamentListInput());

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<TournamentDto> GetByIdAsync(int id)
        {
            return await _tournamentService.GetByIdAsync(id);
        }

        [HttpPost]
        [Route("AddAttempts")]
        public async Task<string> AddAttemptsAsync(TournamentAddAttemptInput input)
        {
            await _tournamentService.AddAttemptsAsync(input);
            return Task.FromResult("Attempt is added").ToString();
        }

        [HttpPost]
        [Route("RemoveAttempts")]
        public async Task<string> RemoveAttemptsAsync(TournamentRemoveAttemptInput input)
        {
            await _tournamentService.RemoveAttemptsAsync(input);
            return Task.FromResult("Attempt is removed").ToString();
        }
    }
}
