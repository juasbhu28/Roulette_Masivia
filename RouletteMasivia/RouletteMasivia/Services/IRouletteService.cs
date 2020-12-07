using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.V1.Requests;
using RouletteMasivia.Controllers.V1.Responses;

namespace RouletteMasivia.Services
{
    public interface IRouletteService
    {
        Roulette NewGame();
        Roulette GetStatusRoulette(Guid rouletteId);
        bool NewBet(CreateRouletteBet Bet);
        IEnumerable<GetRoulettesResponse> GetRoulettes();
        WinnersResponse CloseGame(Guid rouletteId);
    }
}
