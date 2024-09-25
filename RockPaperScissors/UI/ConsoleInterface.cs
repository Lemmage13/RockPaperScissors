using RockPaperScissors.GameLogic;
using RockPaperScissors.Interfaces;
using RockPaperScissors.Models;
using RockPaperScissors.UI.UIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.UI
{
    internal class ConsoleInterface: IUserInterface
    {
        //Class to handle the display and collection of data from the console
        //Contains functionality to display any list of MenuOption items to return a specified type, making this class highly extendable

        public MainMenuOption MainMenu(List<MenuOption<MainMenuOption>> options)
        {
            //clear console to make way for the menu
            Console.Clear();
            //display options to play multi player, against computer, or to quit

            Console.WriteLine("MAIN MENU");
            Console.WriteLine("How would you like to play?: \n");

            return DisplayOptionsMenu<MainMenuOption>(options);
        }

        public GameModeOption SelectGameMode(List<MenuOption<GameModeOption>> options)
        {
            //display options to choose the rule set to use
            Console.WriteLine("Which rules would you like to play with?");

            return DisplayOptionsMenu<GameModeOption>(options);
        }

        public Move PlayerTurn(HumanPlayer player, List<MenuOption<Move>> hand)
        {
            //display options in hand and return appropriate value for player response

            //clear console to tidy up the menu or hide the previous player's turn
            Console.Clear();

            return DisplayOptionsMenu(hand);
        }

        public void DisplayMoves(string player1Name, string player1Move, string player2Name, string player2Move)
        {
            //displays the moves each player used to allow players to see that the game was won, drawn, or lost fairly
            Console.WriteLine($"{player1Name} has chosen: {player1Move}");
            Console.WriteLine($"{player2Name} has chosen: {player2Move}");
        }

        public void DeclareDraw()
        {
            //displays that the game was a draw and waits for input to allow players to wait before trying again
            Console.WriteLine("It's a draw! Press any key to play again!");
            Console.ReadKey();
        }

        public void DisplayGameStats(int turnCount, List<Move> mostCommonMoves, int movesCount)
        {
            //shows the collected statistics from the game, as specified in the design document
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
            //private function to correctly assemble the string to display the most common moves in the case that there are more than one
            string movesString = moves[0].Name;
            for (int i = 1; i < moves.Count; i++)
            {
                movesString += $" and {moves[i].Name}";
            }
            return movesString;
        }

        public void DeclareWinner(IPlayer player)
        {
            //displays the winner of the game, and waits for player input to allow the player to process this information
            Console.WriteLine("The winner is...");
            Console.WriteLine($"{player.Name}!!!");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        //Below methods provide functionality for displaying custom menus displaying options implementing the MenuOption class
        //this approach allows the ui to render any set of options and return the appropriate object upon the users selection
        private T DisplayOptionsMenu<T>(List<MenuOption<T>> options)
        {
            //displays the specified menu options and returns the user selected value

            //generates dictionary
            Dictionary<string, MenuOption<T>> optionsDictionary = GenerateOptionsDictionary(options);

            //uses original list to display selections as this guarantees order
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i].Name}");
            }
            string response = "";
            while (!optionsDictionary.Keys.Contains(response))
            {
                Console.WriteLine("Please enter the number, first letter(s) (as long as there are no duplicates!), or name associated with your choice!");
                response = Console.ReadLine().ToLower();
            }

            return optionsDictionary[response].Value;
        }
        private Dictionary<string, MenuOption<T>> GenerateOptionsDictionary<T>(List<MenuOption<T>> options)
        {
            //generates a dictionary mapping a list of menu options to generated aliases
            //dictionary allows user input to be passed directly to select the option

            Dictionary<string, MenuOption<T>> optionDictionary = new Dictionary<string, MenuOption<T>>();
            for (int i = 0; i < options.Count; i++)
            {
                //for each option, generate aliases
                List<string> aliases = GenerateAliases(options[i].Name, i+1);
                List<string> forbiddenAliases = new List<string>();
                foreach (string alias in aliases)
                {
                    //map aliases to corresponding option
                    //At present this means that if 2 or more options start with the same letter, that letter will not be permitted to select either option
                    if (!optionDictionary.ContainsKey(alias)){
                        if(!forbiddenAliases.Contains(alias)){
                            optionDictionary.Add(alias, options[i]);
                        }
                    }
                    else
                    {
                        forbiddenAliases.Add(alias);
                        optionDictionary.Remove(alias);
                    }
                }
            }
            return optionDictionary;
        }

        private List<string> GenerateAliases(string optionName, int number)
        {
            //Generates alias values for a menu option and its position in the menu
            //this allows any of the number, the name, or the first characters of each word in the name to be used to select your choice
            optionName = optionName.ToLower();
            string[] splitName = optionName.Split(' ');
            string firstletters = "";
            foreach (string word in splitName)
            {
                firstletters += word.Substring(0,1);
            }
            List<String> aliases = new List<string>
            {
                optionName,
                firstletters,
                number.ToString()
            };
            return aliases;
        }
    }
}
