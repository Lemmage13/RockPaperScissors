using RockPaperScissors.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.UI.UIModels
{
    internal class MenuOption<T>
    {
        //Menu option class to associate type values with names for displaying in any ui
        //in ConsoleInterface this allows for reuse of code to display an arbitrary list of options in a highly reusable way

        public MenuOption(string name, T value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public T Value { get; }

    }
}
