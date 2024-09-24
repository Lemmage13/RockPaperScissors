using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interfaces
{
    internal interface IRuleSet
    {
        public string Name { get; }
        public List<Move> Moves { get; }
        public void InitialiseMoves();
    }
}
