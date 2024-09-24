using RockPaperScissors.GameLogic;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Interfaces
{
    internal interface IUserInterface
    {
        public MainMenuOption MainMenu();
        public Move PlayerTurn(HumanPlayer player, List<Move> hand);
        public void DisplayMoves(string player1Name, string player1Move, string player2Name, string player2Move);
        public void DeclareDraw();
        public void DisplayGameStats(int turnCount, List<Move> mostCommonMoves, int movesCount);
        public void DeclareWinner(IPlayer player);
    }
}
