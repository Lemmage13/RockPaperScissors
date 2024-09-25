using RockPaperScissors.Models;
using RockPaperScissors.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GameLogic.RuleSets
{
    internal class BaseRuleSet
    {
        //Base rule set class to allow children access to the below method without repeating code unneccessarily
        public List<Move> Moves { get; protected set; }
        public List<MenuOption<Move>> GetMoveMenuOptions()
        {
            //returns list of MenuOptions representing moves that can be used in the UI
            List<MenuOption<Move>> moveOptions = new List<MenuOption<Move>>();

            foreach (Move move in Moves)
            {
                moveOptions.Add(new MenuOption<Move>(move.Name, move));
            }

            return moveOptions;
        }
    }
}
