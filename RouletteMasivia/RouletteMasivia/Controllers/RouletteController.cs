using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RouletteMasivia.Domain;
using RouletteMasivia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            return Ok(roulette);
        }

        [HttpGet("/roulette/newbet/{rouletteId}")]
        public IActionResult NewBet([FromRoute]Guid rouletteId, [FromBody]Bet bet)
        {
            var rouletteBet = _rouletteServices.NewBet(rouletteId, bet);
            return Ok(new { working = "I'm working" });
        }

        [HttpGet("/roulette/closegame/{rouletteId}")]
        public IActionResult CloseGame([FromRoute]Guid rouletteId)
        {
            return Ok(new { working = "I'm working" + rouletteId });
        }

        [HttpGet("/roulette/getallgames")]
        public IActionResult GetAllGames()
        {
            return Ok(_rouletteServices.GetRoulettes());
        }
    }
}
