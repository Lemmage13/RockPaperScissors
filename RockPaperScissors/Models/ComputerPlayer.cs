using RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    internal class ComputerPlayer: IPlayer
    {
        //ComputerPlayer implements IPlayer and returns a random move for its turn
        public ComputerPlayer(string name)
        {
            Name = name;
        }
        private static Random _random = new Random();

        public string Name { get; }

        public Move TakeTurn(List<Move> hand)
        {
            //Computer player turn returns an unweighted random move
            return hand[_random.Next(hand.Count)];
        }
    }
}
