using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Controllers.V1.Responses
{
    public class GetRoulettesResponse
    {
        public Guid Id{ get; set; }
        public string Status { get; set; }
        public int Bets { get; set; }


    }
}
