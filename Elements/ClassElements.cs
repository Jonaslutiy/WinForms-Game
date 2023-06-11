using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Elements
    {
        public char Character { get; set; }
        public ConsoleColor Color { get; set; }

        public Elements(char character = ' ')
        {
            Character = character;
            Color = ConsoleColor.Cyan;
        }

        public virtual void Print()
        {
            Console.ForegroundColor = Color;
            Console.Write(Character);
            Console.ResetColor();
        }

        public virtual void PrintEmpty()
        {
            Console.Write(" ");
        }

    }

    internal class Wall : Elements
    {
        public Wall() : base('#')
        {
            Color = ConsoleColor.White;
        }
    }

    internal class Mine : Elements
    {
        public Mine() : base('*')
        {
            Color = ConsoleColor.Red;
        }
    }

    internal class Dollar : Elements
    {
        public Dollar() : base('$')
        {
            Color = ConsoleColor.Yellow;
        }
    }
}
