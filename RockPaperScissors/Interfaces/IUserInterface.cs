using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interfaces
{
    internal interface IUserInterface
    {
        public Move PlayerTurn(HumanPlayer player, List<Move> hand);
        public void DeclareWinner(IPlayer player);
    }
}
