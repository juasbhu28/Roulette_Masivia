using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RouletteMasivia.Domain;
using RouletteMasivia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.V1.Responses;
using RouletteMasivia.Controllers.V1.Requests;
using RouletteMasivia.Contracts;
using RouletteMasivia.Contracts.V1;

namespace RouletteMasivia.V1.Controllers
{
    public class RouletteController : Controller
    {
        private readonly IRouletteService _rouletteServices;
        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteServices = rouletteService;
        }

        [HttpGet(ApiRoutes.Roulette.NewGame)]
        public IActionResult NewGame()
        {
            var roulette = _rouletteServices.NewGame();
            var response = new { Id = roulette.Id };
            return Ok(response);
        }

        [HttpGet(ApiRoutes.Roulette.GetStatusGame)]
        public IActionResult GetStatusGame([FromRoute]Guid rouletteId)
        {
            var roulette = _rouletteServices.GetStatusRoulette(rouletteId);

            if (roulette == null)
                return NotFound(); //Corregir

            var response = new StatusGameResponse { Status = roulette.Status };

            return Ok(response);
        }

        [HttpGet(ApiRoutes.Roulette.NewBet)]
        public IActionResult NewBet([FromRoute]Guid rouletteId, [FromBody]CreateRouletteBet bet)
        {
            var rouletteBet = _rouletteServices.NewBet(rouletteId, bet);

            return Ok(rouletteBet);
        }

        [HttpGet(ApiRoutes.Roulette.CloseGame)]
        public IActionResult CloseGame([FromRoute]Guid rouletteId)
        {
            var winners = _rouletteServices.CloseGame(rouletteId);

            return Ok(winners);
        }

        [HttpGet(ApiRoutes.Roulette.GetAllGames)]
        public IActionResult GetAllGames()
        {
            return Ok(_rouletteServices.GetRoulettes());
        }
    }
}
