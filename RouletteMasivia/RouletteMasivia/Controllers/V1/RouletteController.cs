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

        [HttpPost(ApiRoutes.Roulette.NewGame)]
        public IActionResult NewGame()
        {
            var roulette = _rouletteServices.NewGame();

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var localtionUri =  baseUrl + "/" + ApiRoutes.Roulette.GetStatusGame.Replace("{rouletteId}", roulette.Id.ToString() );
                
            var response = new { Id = roulette.Id };

            return Created(localtionUri, response);
  
        }

        [HttpGet(ApiRoutes.Roulette.GetStatusGame)]
        public IActionResult GetStatusGame([FromRoute]Guid rouletteId)
        {
            if (rouletteId == Guid.Empty)  return NotFound();
            Roulette roulette = _rouletteServices.GetStatusRoulette(rouletteId);
            if (roulette == null)  return NotFound();
            var response = new StatusGameResponse { Status_Roulette = roulette.Status };

            return Ok(response);
        }

        [HttpPut(ApiRoutes.Roulette.NewBet)]
        public IActionResult NewBet([FromHeader]string user_id, [FromBody]CreateRouletteBet bet)
        {
            if (bet.roueletteId == Guid.Empty) return NotFound();

            var rouletteBet = _rouletteServices.NewBet(bet);   
            
            return Ok(new { result = (rouletteBet ? "Succes" : "Failed") } );
        }

        [HttpGet(ApiRoutes.Roulette.CloseGame)]
        public IActionResult CloseGame([FromRoute]Guid rouletteId)
        {
            if (rouletteId == Guid.Empty) return NotFound();
            //Ya esta cerrado
            //Nobody wins
            var winners = _rouletteServices.CloseGame(rouletteId);

            return Ok(winners);
        }

        [HttpGet(ApiRoutes.Roulette.GetAllGames)]
        public IActionResult GetAllGames()
        {
            if (_rouletteServices.GetRoulettes()?.Any() == false)
                return NotFound();
            return Ok(_rouletteServices.GetRoulettes());
        }
    }
}
