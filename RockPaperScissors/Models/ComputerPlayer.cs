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
        public ComputerPlayer(string name)
        {
            _random = new Random();
            Name = name;
        }
        private Random _random;

        public string Name { get; }

        public Move TakeTurn(List<Move> hand)
        {
            //Computer player turn returns an unweighted random move
            return hand[_random.Next(hand.Count)];
        }
    }
}
