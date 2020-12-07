using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouletteMasivia.Domain;

namespace RouletteMasivia.Controllers.V1.Requests
{
    public class CreateRouletteBet
    {
        public TypeBet TypeBet { get; set; }
        public string Value { get; set; }
        public float Price { get; set; }
    }
}
