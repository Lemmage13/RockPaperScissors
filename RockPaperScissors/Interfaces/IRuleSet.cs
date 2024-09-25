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
        //Rule set interface allows any custom rule set to be designed and added to the game
        public List<Move> Moves { get; }
        public void InitialiseMoves();
    }
}
