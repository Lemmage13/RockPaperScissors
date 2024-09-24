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
    public enum MainMenuOption
    {
        SinglePlayer,
        MultiPlayer
    }
    internal class GameManager
    {
        public GameManager()
        {
            _ruleSet = new RuleSetClassic();
            _ui = new ConsoleInterface();
            _player1 = new HumanPlayer("Player 1", _ui);
        }

        private IRuleSet _ruleSet;
        private IUserInterface _ui;
        private IPlayer _player1;
        private IPlayer _player2;

        public void MainMenu()
        {
            MainMenuOption response = _ui.MainMenu();
            switch (response)
            {
                case MainMenuOption.SinglePlayer:
                    _player2 = new ComputerPlayer("Computer");
                    break;
                case MainMenuOption.MultiPlayer:
                    _player2 = new HumanPlayer("Player 2", _ui);
                    break;
            }
            PlayGame();
        }

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

                //display selected moves
                _ui.DisplayMoves(_player1.Name, p1Move.Name, _player2.Name, p2Move.Name);

                //find result of game and whether to keep playing
                playing = DetermineResult(p1Move, p2Move);
            }
            //display stats for game
            List<Move> mostCommonMoves = MostCommonMoves(movesTaken);
            int mostCommonMoveCount = movesTaken.Where(m => m == mostCommonMoves[0]).Count();
            _ui.DisplayGameStats(turn, mostCommonMoves, mostCommonMoveCount);
        }

        private List<Move> MostCommonMoves(List<Move> moves)
        {
            Dictionary<Move, int> counts = new Dictionary<Move, int>();

            foreach (Move move in moves)
            {
                if (counts.ContainsKey(move))
                {
                    counts[move] += 1;
                }
                else
                {
                    counts.Add(move, 1);
                }
            }

            int maximum = 0;
            List<Move> mostCommon = new List<Move>();
            foreach(KeyValuePair<Move, int> count in counts)
            {
                //switch not useable as requires constant values
                if(count.Value > maximum)
                {
                    mostCommon = new List<Move>();
                    mostCommon.Add(count.Key);

                    maximum = count.Value;
                }
                else
                {
                    if (count.Value == maximum)
                    {
                        mostCommon.Add(count.Key);
                    }
                }
            }
            return mostCommon;
        }

        private bool DetermineResult(Move p1Move, Move p2Move)
        {
            //determine winner or draw
            if (p1Move.Defeats.Contains(p2Move))
            {
                _ui.DeclareWinner(_player1);
                return false;
            }
            if (p2Move.Defeats.Contains(p1Move))
            {
                _ui.DeclareWinner(_player2);
                return false;
            }
            else
            {
                _ui.DeclareDraw();
                return true;
            }
        }
    }
}
