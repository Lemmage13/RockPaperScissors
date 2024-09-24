using RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Models
{
    internal class HumanPlayer: IPlayer
    {
        private IUserInterface _ui;
        public HumanPlayer(string name, IUserInterface ui)
        {
            Name = name;
            _ui = ui;
        }

        public string Name { get; }


        public Move TakeTurn(List<Move> hand)
        {
            return _ui.PlayerTurn(this, hand);
        }
    }
}
