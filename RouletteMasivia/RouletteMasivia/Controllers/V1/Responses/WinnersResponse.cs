using RouletteMasivia.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Controllers.V1.Responses
{
    public class WinnersResponse
    {
        public Guid Id { get; set; }
        public List<Player> Players { get; set; }
    }
}
