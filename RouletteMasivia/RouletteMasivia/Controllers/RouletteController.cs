using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RouletteMasivia.Domain;
using RouletteMasivia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.Responses;
using RouletteMasivia.Controllers.Requests;

namespace RouletteMasivia.Controllers
{
    public class RouletteController : Controller
    {
        private readonly IRouletteService _rouletteServices;

        [HttpGet("/roulette/newgame")]
        public IActionResult NewGame()
        {
            var roulette = _rouletteServices.NewGame();
            var response = new { Id = roulette.Id };
            return Ok(response);
        }

        [HttpGet("/roulette/getstatusgame/{rouletteId}")]
        public IActionResult GetStatusGame([FromRoute]Guid rouletteId)
        {
            var roulette = _rouletteServices.GetStatusRoulette(rouletteId);

            if (roulette == null)
                return NotFound(); //Corregir

            var response = new StatusGameResponse { Status = roulette.Status };

            return Ok(response);
        }

        [HttpGet("/roulette/newbet/{rouletteId}")]
        public IActionResult NewBet([FromRoute]Guid rouletteId, [FromBody]CreateRouletteBet bet)
        {
            var rouletteBet = _rouletteServices.NewBet(rouletteId, bet);

            return Ok(rouletteBet);
        }

        [HttpGet("/roulette/closegame/{rouletteId}")]
        public IActionResult CloseGame([FromRoute]Guid rouletteId)
        {
            var winners = _rouletteServices.CloseGame(rouletteId);

            return Ok(winners);
        }

        [HttpGet("/roulette/getallgames")]
        public IActionResult GetAllGames()
        {
            return Ok(_rouletteServices.GetRoulettes());
        }
    }
}
