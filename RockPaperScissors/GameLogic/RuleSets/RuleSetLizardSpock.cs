using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GameLogic.RuleSets
{
    internal class RuleSetLizardSpock: IRuleSet
    {
        //representation of the expanded rules of rock paper scissors lizard spock
        //assigns the 5 moves, and the moves that they each defeat
        public RuleSetLizardSpock()
        {
            InitialiseMoves();
        }
        public List<Move> Moves { get; } = new List<Move>();
        public void InitialiseMoves()
        {
            Move rock = new Move("Rock");
            Move paper = new Move("Paper");
            Move scissors = new Move("Scissors");
            Move lizard = new Move("Lizard");
            Move spock = new Move("Spock");

            Moves.Add(rock);
            Moves.Add(paper);
            Moves.Add(scissors);
            Moves.Add(lizard);
            Moves.Add(spock);

            rock.AddDefeats(new List<Move> { scissors, lizard });
            paper.AddDefeats(new List<Move> { rock, spock });
            scissors.AddDefeats(new List<Move> { paper, lizard });
            lizard.AddDefeats(new List<Move> { spock, paper });
            spock.AddDefeats(new List<Move> { scissors, rock });
        }
    }
}
