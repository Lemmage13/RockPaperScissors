using RockPaperScissors.Interfaces;
using RockPaperScissors.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    internal class Move
    {
        //Move class holds the values that a given move defeats, allowing the game manager to determine a winner (or draw)
        public Move(string name)
        {
            Name = name;
        }
        public string Name { get; }
        public List<Move> Defeats { get; } = new List<Move>();

        public void AddDefeats(List<Move> moves)
        {
            Defeats.AddRange(moves);
        }
    }
}
