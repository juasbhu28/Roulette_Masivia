using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.V1.Requests;

namespace RouletteMasivia.Services
{
    public interface IRouletteService
    {
        Roulette NewGame();
        Roulette GetStatusRoulette(Guid rouletteId);
        bool NewBet(Guid rouletteId, CreateRouletteBet Bet);
        List<Roulette> GetRoulettes();
        List<string> CloseGame(Guid rouletteId);
    }
}
