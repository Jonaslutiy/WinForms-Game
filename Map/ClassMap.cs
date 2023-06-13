using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Map
    {
        private Elements[,] elements;
        private Mine Mine = new Mine();
        public int Height { get; }
        public int Width { get; }


        internal Map(int height, int width, int percentFilled)
        {
            Height = height;
            Width = width;

            // Збільшіть розмір масиву елементів на 2 у кожному вимірі, щоб врахувати стіни
            elements = new Elements[Height + 2, Width + 2];

            AddWalls();
            AddMines(percentFilled);
            AddDollarSign(width);
        }

        private void AddWalls()
        {
            for (int y = 0; y < Height + 2; y++)
            {
                for (int x = 0; x < Width + 2; x++)
                {
                    if (y == 0 || y == Height + 1 || x == 0 || x == Width + 1)
                    {
                        elements[y, x] = new Wall();
                    }
                    else
                    {
                        elements[y, x] = new Elements();
                    }
                }
            }
        }

        private void AddMines(int percentFilled)
        {
            // Обчислити кількість символів '*', яку потрібно розмістити, виходячи з наданого відсотка
            int numStars = (int)((percentFilled / 100.0) * (Height * Width));

            //  Додавання символiв '*' до масиву
            Random rand = new Random();
            int starsPlaced = 0;
            for (int y = 1; y <= Height; y++)
            {
                for (int x = 1; x <= Width; x++)
                {
                    if (starsPlaced < numStars && rand.NextDouble() < (double)numStars / ((Height * Width) - starsPlaced))
                    {
                        bool isAdjacentOrTwoPixelsAway = IsAdjacentToTarget(y, x, '@') || IsAdjacentToTarget(y, x, '$');
                        bool isWithinBounds = y > 1 && y <= Height - 1 && x >= 1 && x <= Width;
                        if (isWithinBounds && !isAdjacentOrTwoPixelsAway)
                        {
                            elements[y, x] = new Mine();
                            starsPlaced++;
                        }
                    }
                    else
                    {
                        elements[y, x] = new Elements();
                    }
                }
            }
        }

        public void AddDollarSign(int width)
        {
            Dollar dollar = new Dollar();
            int x = width / 2 + 1;
            elements[0, x] = dollar; // Присвоїти новий екземпляр класу Dollar масиву елементів
        }

        private bool IsAdjacentToTarget(int y, int x, char target)
        {
            // Перевірка, чи цільовий об'єкт знаходиться поруч з поточним елементом
            bool isAdjacent = false;
            if (y > 0 && y < Height + 1 && x > 0 && x < Width + 1)
            {
                if (elements[y - 1, x - 1].ToString() == target.ToString()
                    || elements[y - 1, x].ToString() == target.ToString()
                    || elements[y - 1, x + 1].ToString() == target.ToString()
                    || elements[y, x - 1].ToString() == target.ToString()
                    || elements[y, x + 1].ToString() == target.ToString()
                    || elements[y + 1, x - 1].ToString() == target.ToString()
                    || elements[y + 1, x].ToString() == target.ToString()
                    || elements[y + 1, x + 1].ToString() == target.ToString())
                {
                    isAdjacent = true;
                }
            }

            return isAdjacent;
        }


        internal Elements GetElement(int y, int x)
        {
            if (y >= 0 && y < Height + 2 && x >= 0 && x < Width + 2)
            {
                return elements[y, x];
            }
            else
            {
                return new Elements(); // повернути об'єкт Elements за замовчуванням замість null
            }
        }

        internal void SetElement(int y, int x, char c)
        {
            elements[y, x] = new Elements(c);
        }

        public void PrintMap()
        {
            int mapLeft = (Console.WindowWidth - (Width + 2)) / 2;
            int mapTop = (Console.WindowHeight - (Height + 2)) / 2;


            for (int y = 0; y < Height + 2; y++)
            {
                Console.SetCursorPosition(mapLeft, mapTop + y);

                for (int x = 0; x < Width + 2; x++)
                {
                    Elements element = elements[y, x];
                    if (element.Character == Mine.Character)
                    {
                        element.PrintEmpty();
                    }
                    else
                    {
                        element.Print();
                    }
                }
                Console.WriteLine();
            }
        }


    }
}
