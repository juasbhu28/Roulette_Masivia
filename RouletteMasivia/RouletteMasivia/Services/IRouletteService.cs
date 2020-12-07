using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.Requests;

namespace RouletteMasivia.Services
{
    public interface IRouletteService
    {
        Roulette NewGame();
        Roulette GetStatusRoulette(Guid rouletteId);
        Bet NewBet(Guid rouletteId, CreateRouletteBet Bet);
        List<Roulette> GetRoulettes();
        List<string> CloseGame(Guid rouletteId);
    }
}
