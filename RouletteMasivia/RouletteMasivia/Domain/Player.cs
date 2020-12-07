using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Domain
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Bet Bet { get; set; }
    }
}
