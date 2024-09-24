using RockPaperScissors.GameLogic;
using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.UI
{
    internal class ConsoleInterface: IUserInterface
    {
        public MainMenuOption MainMenu()
        {
            //display options to play multi player or against computer
            List<MainMenuOption> options = new List<MainMenuOption>(  (MainMenuOption[])Enum.GetValues(typeof(MainMenuOption))  ); //uses list constructor that takes an array, which must be cast to the appropriate type: MainMenuOption[]
            Dictionary<string, MainMenuOption> menuOptions = GenerateOptions(options);

            Console.WriteLine("MAIN MENU");
            Console.WriteLine("Select game mode: \n");
            foreach (KeyValuePair<string, MainMenuOption> option in menuOptions)
            {
                Console.WriteLine($"{option.Key}. {option.Value}\n");
            }
            string response = "";
            while (!menuOptions.Keys.Contains(response))
            {
                Console.WriteLine("Enter the number associated with your choice.");
                response = Console.ReadLine();
            }
            Console.Clear();
            return menuOptions[response];
        }

        public Move PlayerTurn(HumanPlayer player, List<Move> hand)
        {
            //display options in hand
            //handle incorrect response from player

            Dictionary<string, Move> moveOptions = GenerateOptions(hand);

            Console.WriteLine($"{player.Name} select your move!");
            foreach(KeyValuePair<string, Move> move in moveOptions)
            {
                Console.WriteLine($"{move.Key}. {move.Value.Name}\n");
            }
            string response = "";
            while (!moveOptions.Keys.Contains(response))
            {
                Console.WriteLine("Enter the number associated with your choice.");
                response = Console.ReadLine();
            }
            Console.Clear();
            return moveOptions[response];
        }

        public void DisplayMoves(string player1Name, string player1Move, string player2Name, string player2Move)
        {
            Console.WriteLine($"{player1Name} has chosen: {player1Move}");
            Console.WriteLine($"{player2Name} has chosen: {player2Move}");
        }

        public void DeclareDraw()
        {
            Console.WriteLine("It's a draw! Press any key to play again!");
            Console.ReadKey();
            Console.Clear();
        }

        public void DisplayGameStats(int turnCount, List<Move> mostCommonMoves, int movesCount)
        {
            Console.WriteLine($"That game took {turnCount} turns.");
            if (mostCommonMoves.Count == 1)
            {
                Console.WriteLine($"The most common move was: {mostCommonMoves[0].Name}, which was used {movesCount} times.");
            }
            else
            {
                string movesString = CommonMovesStringBuilder(mostCommonMoves);
                string finalS = "";
                if (movesCount > 1)
                {
                    finalS = "s";
                }
                Console.WriteLine($"The most common moves were: {movesString}, which were used {movesCount} time{finalS}.");
            }
            Console.ReadLine();
        }

        private string CommonMovesStringBuilder(List<Move> moves)
        {
            string movesString = moves[0].Name;
            for (int i = 1; i < moves.Count; i++)
            {
                movesString += $" and {moves[i].Name}";
            }
            return movesString;
        }

        public void DeclareWinner(IPlayer player)
        {
            Console.WriteLine("The winner is...");
            Console.WriteLine($"{player.Name}!!!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        private Dictionary<string, T> GenerateOptions<T>(List<T> options)
        {
            //generates a dictionary associating a list of objects of some type to string numbers
            //dictionary allows user input to be passed directly to select the option
            //taking a generic type allows this method to be used for arbitrary options

            Dictionary<string, T> optionDictionary = new Dictionary<string, T>();
            for (int i = 0; i < options.Count; i++)
            {
                optionDictionary.Add((i + 1).ToString(), options[i]);
            }
            return optionDictionary;
        }

    }
}
