using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Services
{
    public interface IRouletteService
    {
        Roulette NewGame();
        Roulette GetStatusRoulette(Guid rouletteId);
        Bet NewBet(Guid rouletteId, Bet Bet);
        List<Roulette> GetRoulettes();
        string CloseGame(Guid rouletteId);
    }
}
