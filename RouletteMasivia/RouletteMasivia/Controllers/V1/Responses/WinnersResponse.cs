using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Controllers.V1.Responses
{
    public class WinnersResponse
    {
        public Guid roulette_id { get; set; }
        public string message { get; set; }
        public BetResult bet_result { get; set; }        
        public IEnumerable<PlayerResult> winners_by_color { get; set; }
        public IEnumerable<PlayerResult> winners_by_number { get; set; }
    }
}

