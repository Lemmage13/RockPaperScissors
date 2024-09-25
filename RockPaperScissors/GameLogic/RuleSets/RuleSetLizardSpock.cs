using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GameLogic.RuleSets
{
    internal class RuleSetLizardSpock: BaseRuleSet
    {
        //representation of the expanded rules of rock paper scissors lizard spock
        //assigns the 5 moves, and the moves that they each defeat
        public RuleSetLizardSpock()
        {
            Moves = InitialiseMoves();
        }
        public List<Move> InitialiseMoves()
        {
            //makes and assigns defeats for each possible move
            List<Move> moves = new List<Move>();

            Move rock = new Move("Rock");
            Move paper = new Move("Paper");
            Move scissors = new Move("Scissors");
            Move lizard = new Move("Lizard");
            Move spock = new Move("Spock");

            moves.Add(rock);
            moves.Add(paper);
            moves.Add(scissors);
            moves.Add(lizard);
            moves.Add(spock);

            rock.AddDefeats(new List<Move> { scissors, lizard });
            paper.AddDefeats(new List<Move> { rock, spock });
            scissors.AddDefeats(new List<Move> { paper, lizard });
            lizard.AddDefeats(new List<Move> { spock, paper });
            spock.AddDefeats(new List<Move> { scissors, rock });

            return moves;
        }
    }
}
