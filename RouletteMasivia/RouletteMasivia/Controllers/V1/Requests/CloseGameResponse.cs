using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Controllers.V1.Requests
{
    public class CloseGameResponse
    {
        public Guid Id { get; set; }
        public float Earn { get; set; }
    }
}
