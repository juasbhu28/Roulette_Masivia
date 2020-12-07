
using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Controllers.V1.Requests;

namespace RouletteMasivia.Services
{
    public class RouletteService : IRouletteService
    {
        private readonly List<Roulette> _roulettes;

        public RouletteService()
        {
            _roulettes = new List<Roulette>();
        }
        public List<string> CloseGame(Guid rouletteId)
        {
            var roulette = _roulettes.SingleOrDefault((r) => r.Id == rouletteId);

            var numberWin = new Random().Next(0, 36);            
            var colorWin = new Random().Next(0, 1);

            var winColorList = roulette.Players.FindAll(p => p.Bet.TypeBet == TypeBet.Color && p.Bet.Value == (colorWin == 0 ? "Black" : "Red"));
            var winNumberList = roulette.Players.FindAll(p => p.Bet.TypeBet == TypeBet.Number && p.Bet.Value == numberWin.ToString());

            List<string> listResult = new List<string>();//winColorList.Concat(winNumberList.ToList()).ToList();

            return listResult;
        }

        public List<Roulette> GetRoulettes()
        {
            return _roulettes;
        }

        public Roulette GetStatusRoulette(Guid rouletteId)
        {
            return _roulettes.SingleOrDefault(r => r.Id == rouletteId);
        }

        public Bet NewBet(Guid rouletteId, CreateRouletteBet bet)
        {
            var roulette = _roulettes.SingleOrDefault((r) => r.Id == rouletteId);
            var newBet = new Bet { TypeBet = bet.TypeBet, Value = bet.Value, Price = bet.Price };
            
            roulette.Players.Add( new Player { Bet = newBet });

            //Actualizar una lista
            return newBet;            
        }

        public Roulette NewGame() 
        {
            var newRoulette = new Roulette();
            _roulettes.Add(newRoulette);
            return newRoulette;
        }
    }
}
