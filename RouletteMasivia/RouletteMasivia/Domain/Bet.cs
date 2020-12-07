using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Domain
{
    public class Bet
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public TypeBet TypeBet { get; set; }
        public string Value { get; set; }
        public float Price { get; set; }
    }
}
