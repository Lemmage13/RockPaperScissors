using RockPaperScissors.GameLogic.RuleSets;
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
        //take turn method calls the injected ui to let the player take their turn
        private IUserInterface _ui;
        public HumanPlayer(string name, IUserInterface ui)
        {
            Name = name;
            _ui = ui;
        }

        public string Name { get; }


        public Move TakeTurn(BaseRuleSet ruleSet)
        {
            //use injected rule set to pass correct options to ui
            return _ui.PlayerTurn(this, ruleSet.GetMoveMenuOptions());
        }
    }
}
