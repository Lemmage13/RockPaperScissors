using RockPaperScissors.GameLogic.RuleSets;
using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using RockPaperScissors.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.GameLogic
{
    internal class GameManager
    {
        public GameManager()
        {
            _ruleSet = new RuleSetClassic();
            _ui = new ConsoleInterface();
            _player1 = new HumanPlayer("Player 1", _ui);
            _player2 = new ComputerPlayer("Computer");
        }

        private IRuleSet _ruleSet;
        private IUserInterface _ui;
        private IPlayer _player1;
        private IPlayer _player2;

        public void PlayGame()
        {
            int turn = 0;
            List<Move> movesTaken = new List<Move>();
            bool playing = true;

            while (playing)
            {
                turn++;
                Move p1Move = _player1.TakeTurn(_ruleSet.Moves);
                Move p2Move = _player2.TakeTurn(_ruleSet.Moves);

                movesTaken.Add(p1Move);
                movesTaken.Add(p2Move);

                if(p1Move.Defeats.Contains(p2Move))
                {
                    _ui.DeclareWinner(_player1);
                    playing = false;
                }
                if (p2Move.Defeats.Contains(p1Move))
                {
                    _ui.DeclareWinner(_player2);
                    playing = false;
                }
                else
                {
                    //handle draw
                }
            }
        }

        //player 1 -> take turn (pass moves from ruleset)

        //player 2 -> take turn

        //winner or draw and start again!

        //return stats (winner, moves, turn number etc)
    }
}
