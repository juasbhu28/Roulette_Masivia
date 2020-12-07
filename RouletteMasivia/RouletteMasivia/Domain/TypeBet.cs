using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Domain
{
    public enum TypeBet
    {
        [Display(Name = "Bet by Numeric")]
        Number,

        [Display(Name = "Bet by Color")]
        Color
    }
}
