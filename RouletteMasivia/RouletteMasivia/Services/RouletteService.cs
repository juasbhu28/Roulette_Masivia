
using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.V1.Requests;
using RouletteMasivia.Controllers.V1.Responses;

namespace RouletteMasivia.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly List<Roulette> _roulettes;

        public RouletteService()
        {
            _roulettes = new List<Roulette>();
        }
        public WinnersResponse CloseGame(Guid rouletteId)
        {
            string message = "succes";
            List<string> listResult = new List<string>();
            var numberWin = new Random().Next(0, 36);
            var colorWin = new Random().Next(0, 1);
            BetResult betResult = new BetResult { Color = (colorWin == 0 ? "Black" : "Red"), Number = numberWin }; 
            Roulette roulette = _roulettes.SingleOrDefault((r) => r.Id == rouletteId);
            if (roulette == null) listResult.Add( message = "Not exist Id " + rouletteId);
            if (roulette.Status == "Closed") listResult.Add( message = $"Id roulette {rouletteId} its closed");
            roulette.Status = "Closed";
            roulette.EndTime = DateTime.Now;          
            List<Player> winColorList = roulette.Players.FindAll(p => p.Bet.TypeBet == TypeBet.Color && p.Bet.Value == (colorWin == 0 ? "Black" : "Red"));
            List<Player> winNumberList = roulette.Players.FindAll(p => p.Bet.TypeBet == TypeBet.Number && p.Bet.Value == numberWin.ToString());

            IEnumerable<PlayerResult> earningsPerColor  = from player in winColorList
                                                          select new PlayerResult(){ Id = player.Id, earn = (player.Bet.Price * 1.8f) };

            IEnumerable<PlayerResult> earningsPerNumber = from player in winNumberList
                                                          select new PlayerResult() { Id = player.Id, earn = (player.Bet.Price * 5f) };


            WinnersResponse result = new WinnersResponse() { roulette_id = roulette.Id, message = message, bet_result = betResult, winners_by_color = earningsPerColor, winners_by_number = earningsPerNumber };


                return result;
        }

        public IEnumerable<GetRoulettesResponse> GetRoulettes()
        {
            IEnumerable<GetRoulettesResponse> allGames = from r in _roulettes
                           select new GetRoulettesResponse (){ Id = r.Id, Status = r.Status, Bets = r.Players.Count() };

            return allGames; 
        }

        public Roulette GetStatusRoulette(Guid rouletteId)
        {
            return _roulettes.SingleOrDefault(r => r.Id == rouletteId);
        }

        public bool NewBet(CreateRouletteBet bet)
        {
            int value;

            switch (bet.TypeBet)
            {
                case TypeBet.Color:
                    if (bet.Value != "Black" && bet.Value != "Red")
                        return false;
                    break;
                case TypeBet.Number:
                    if (!int.TryParse(bet.Value, out value)) return false;
                    if (!Enumerable.Range(0, 36).Contains(value)) return false;
                    break;
                default:
                    return false;                 

            }       

            if (bet.Price < 0f && bet.Price > 10000f) return false;
            Roulette roulette = _roulettes.SingleOrDefault((r) => r.Id == bet.roueletteId);
            if (roulette == null) return false;
            if (roulette.Status == "Closed") return false;
            Bet newBet = new Bet() { TypeBet = bet.TypeBet, Value = bet.Value, Price = bet.Price };
            Player newPlayer = new Player() { Bet = newBet };
            roulette.Players.Add(newPlayer);

            return true;            
        }

        public Roulette NewGame() 
        {
            var newRoulette = new Roulette();
            _roulettes.Add(newRoulette);

            return newRoulette;
        }

    }
}
