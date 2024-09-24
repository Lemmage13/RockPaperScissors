using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    public class Move
    {
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
