using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Domain
{
    public class Roulette
    {
        public Guid Id { get; set; }
        public DateTime StarTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public List<Player> Players { get; set; }
        public Roulette()
        {
            Id = Guid.NewGuid();
            Status = "Open";
            StarTime = DateTime.Now;
        }
    }
}
