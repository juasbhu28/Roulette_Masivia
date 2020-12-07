using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = "/" + Version + "/roulette";

        public static class Roulette
        {
            public const string NewGame = Base + "/newgame";
            public const string GetStatusGame = Base + "/getstatusgame/{rouletteId}";
            public const string NewBet = Base + "/newbet/{rouletteId}";
            public const string CloseGame = Base + "/closegame/{rouletteId}";
            public const string GetAllGames = Base + "/getallgames";
        }
}
}
