using RockPaperScissors.GameLogic;
using RockPaperScissors.Models;
using RockPaperScissors.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interfaces
{
    internal interface IUserInterface
    {
        //this interface allows the game manager to be naive to the actual interface in use
        //this simplifies the addition of a different type of ui later
        public MainMenuOption MainMenu(List<MenuOption<MainMenuOption>> options);
        public GameModeOption SelectGameMode(List<MenuOption<GameModeOption>> options);
        public Move PlayerTurn(HumanPlayer player, List<MenuOption<Move>> hand);
        public void DisplayMoves(string player1Name, string player1Move, string player2Name, string player2Move);
        public void DeclareDraw();
        public void DisplayGameStats(int turnCount, List<Move> mostCommonMoves, int movesCount);
        public void DeclareWinner(IPlayer player);
    }
}
