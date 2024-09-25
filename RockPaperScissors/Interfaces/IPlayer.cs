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
        //implementing this interface allows the same method to be called for the human/computer player's turn
        //could allow different computer player "profiles" with different weightings for different moves
        public string Name { get; }
        public Move TakeTurn(List<Move> hand);
    }
}
