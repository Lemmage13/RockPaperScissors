using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GameLogic.RuleSets
{
    internal class RuleSetClassic : IRuleSet
    {
        //representation of the classic ruleset of rock paper scissors
        //assigns the 3 moves, and the moves that they each defeat
        public RuleSetClassic()
        {
            InitialiseMoves();
        }
        public List<Move> Moves { get; } = new List<Move>();
        public void InitialiseMoves()
        {
            Move rock = new Move("Rock");
            Move paper = new Move("Paper");
            Move scissors = new Move("Scissors");

            Moves.Add(rock);
            Moves.Add(paper);
            Moves.Add(scissors);

            rock.AddDefeats(new List<Move> { scissors });
            paper.AddDefeats(new List<Move> { rock });
            scissors.AddDefeats(new List<Move> { paper });
        }
    }
}
