using RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    internal class HumanPlayer: IPlayer
    {
        private IUserInterface _ui;
        public HumanPlayer(string name, List<Move> moves, IUserInterface ui)
        {
            Name = name;
            hand = moves;
            _ui = ui;
        }

        public string Name { get; }

        List<Move> hand;

        public Move TakeTurn()
        {
            return _ui.PlayerTurn(this, hand);
        }
    }
}
