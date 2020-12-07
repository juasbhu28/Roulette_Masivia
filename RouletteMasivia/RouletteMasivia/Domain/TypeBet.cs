using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteMasivia.Domain
{
    public enum TypeBet
    {
        [Display(Name = "Numeric Bet")]
        Number,

        [Display(Name = "Color Bet")]
        Color
    }
}
