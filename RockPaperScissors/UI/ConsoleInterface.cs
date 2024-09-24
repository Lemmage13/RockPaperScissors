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
        public Move PlayerTurn(HumanPlayer player, List<Move> hand)
        {
            // display options in hand, or give up
            //handle incorrect response from player

            Dictionary<string, Move> moveOptions = GenerateMoveOptions(hand);

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

            return moveOptions[response];
        }

        private Dictionary<string, Move> GenerateMoveOptions(List<Move> moves)
        {
            Dictionary<string, Move> options = new Dictionary<string, Move>();
            for (int i = 0; i < moves.Count; i++)
            {
                options.Add((i + 1).ToString(), moves[i]);
            }
            return options;
        }

        public void DeclareWinner(IPlayer player)
        {
            Console.WriteLine("The winner is...");
            Console.WriteLine($"{player.Name}!!!");
            string response = "";
            while (response == "")
            {
                response = Console.ReadLine();
            }
        }
    }
}
