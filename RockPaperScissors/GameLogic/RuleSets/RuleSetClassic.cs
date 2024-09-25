using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using RockPaperScissors.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GameLogic.RuleSets
{
    internal class RuleSetClassic : BaseRuleSet
    {
        //representation of the classic ruleset of rock paper scissors
        //assigns the 3 moves, and the moves that they each defeat
        public RuleSetClassic()
        {
            Moves = InitialiseMoves();
        }
        private List<Move> InitialiseMoves()
        {
            //makes and assigns defeats for each possible move
            List<Move> moves = new List<Move>();

            Move rock = new Move("Rock");
            Move paper = new Move("Paper");
            Move scissors = new Move("Scissors");

            moves.Add(rock);
            moves.Add(paper);
            moves.Add(scissors);

            rock.AddDefeats(new List<Move> { scissors });
            paper.AddDefeats(new List<Move> { rock });
            scissors.AddDefeats(new List<Move> { paper });

            return moves;
        }
    }
}
