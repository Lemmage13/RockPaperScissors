using RockPaperScissors.GameLogic.RuleSets;
using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using RockPaperScissors.UI;
using RockPaperScissors.UI.UIModels;

namespace RockPaperScissors.GameLogic
{
    public enum MainMenuOption
    {
        SinglePlayer,
        MultiPlayer,
        Exit
    }
    public enum GameModeOption
    {
        Classic,
        LizardSpock
    }
    internal class GameManager
    {
        //manager class to ensure game flows logically
        //functions produce a main menu to allow the player to play or quit and subsequent game menus to choose options and play the game
        public GameManager()
        {
            _ui = new ConsoleInterface();
            _player1 = new HumanPlayer("Player 1", _ui);
            _playing = true;
        }

        private BaseRuleSet _ruleSet;
        private IUserInterface _ui;
        private IPlayer _player1;
        private IPlayer _player2;
        private bool _playing;

        public void MainMenu()
        {
            //main menu handles logic before the game starts giving the option to play multi or single player (or quit)
            //then options to use the classic or lizard spock rule sets
            while (_playing)
            {
                List<MenuOption<MainMenuOption>> mainMenuOptions = new List<MenuOption<MainMenuOption>>
                {
                    new MenuOption<MainMenuOption>("Single Player", MainMenuOption.SinglePlayer),
                    new MenuOption<MainMenuOption>("Multi Player", MainMenuOption.MultiPlayer),
                    new MenuOption<MainMenuOption>("Exit", MainMenuOption.Exit)
                };

                switch (_ui.MainMenu(mainMenuOptions))
                {
                    case MainMenuOption.SinglePlayer:
                        _player2 = new ComputerPlayer("Computer");
                        break;
                    case MainMenuOption.MultiPlayer:
                        _player2 = new HumanPlayer("Player 2", _ui);
                        break;
                    case MainMenuOption.Exit:
                        _playing = false;
                        break;
                }

                //do not continue if the player quits!
                if (_playing)
                {
                    List<MenuOption<GameModeOption>> gameModeOptions = new List<MenuOption<GameModeOption>>
                    {
                        new MenuOption<GameModeOption>("Classic", GameModeOption.Classic),
                        new MenuOption<GameModeOption>("Rock Paper Scissors Lizard Spock", GameModeOption.LizardSpock)
                    };

                    switch (_ui.SelectGameMode(gameModeOptions))
                    {
                        case GameModeOption.Classic:
                            _ruleSet = new RuleSetClassic();
                            break;
                        case GameModeOption.LizardSpock:
                            _ruleSet = new RuleSetLizardSpock();
                            break;
                    }
                    PlayGame();
                }
            }
        }

        public void PlayGame()
        {
            //handles logic and data collection while the game is played
            //makes each player take their turn, then determines the winner, or a draw
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


            //prepare stats for game once game is won
            List<Move> mostCommonMoves = MostCommonMoves(movesTaken);

            //the count of the most common moves is the count of any one of them in the movesTaken list
            int mostCommonMoveCount = movesTaken.Where(m => m == mostCommonMoves[0]).Count();

            //display stats
            _ui.DisplayGameStats(turn, mostCommonMoves, mostCommonMoveCount);
        }

        private List<Move> MostCommonMoves(List<Move> moves)
        {
            //not uncommon to have multiple most common moves in a single game, so each move must be counted and however many that are the maximum should be displayed

            //add moves to dictionary and calculate counts
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

            //collect list of moves used the most based on the dictionary
            int maximum = 0;
            List<Move> mostCommon = new List<Move>();
            foreach (KeyValuePair<Move, int> count in counts)
            {
                //switch not useable as requires constant values
                if (count.Value > maximum)
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
            //determine winner or draw and return whether to keep playing
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
