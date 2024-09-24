using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interfaces
{
    internal interface IPlayer
    {
        public string Name { get; }
        public Move TakeTurn(List<Move> hand);
    }
}
