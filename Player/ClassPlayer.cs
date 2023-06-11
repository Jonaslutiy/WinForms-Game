using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    internal class Player : Elements
    {
        public Player() : base('@')
        {
            Color = ConsoleColor.Red;
        }


        private readonly Map map;
        public int PositionX;
        public int PositionY;

        internal Player(Map map)
        {
            this.map = map;
            SetPlayerPosition(ref PositionX, ref PositionY);
        }

        internal void SetPlayerPosition(ref int PositionX, ref int PositionY)
        {
            PositionX = (map.Width + 2) / 2;
            PositionY = map.Height + 1;

            map.SetElement(PositionY, PositionX, '@');
        }

        internal int DisplayNearbyStars()
        {
            int numMines = 0;
            if (map.GetElement(PositionY - 1, PositionX) is Mine) // Check above
            {
                numMines++;
            }
            if (map.GetElement(PositionY + 1, PositionX) is Mine) // Check below
            {
                numMines++;
            }
            if (map.GetElement(PositionY, PositionX - 1) is Mine) // Check left
            {
                numMines++;
            }
            if (map.GetElement(PositionY, PositionX + 1) is Mine) // Check right
            {
                numMines++;
            }
            return numMines;
        }


        internal ResultEnum PlayerMovement(ConsoleKeyInfo pressedKey)
        {
            int[] direction = GetDirection(pressedKey);
            int nextPlayerPositionY = PositionY + direction[1];
            int nextPlayerPositionX = PositionX + direction[0];
            Elements nextCell = map.GetElement(nextPlayerPositionY, nextPlayerPositionX);
            Elements thisCell = map.GetElement(PositionY, PositionX);
            ResultEnum result = ResultEnum.Continue;

            if (!(nextCell is Wall))
            {


                result = CheckCellResult(nextCell, nextPlayerPositionX, nextPlayerPositionY);

                if (result == ResultEnum.Continue)
                {
                    map.SetElement(PositionY, PositionX, ' ');
                    UpdatePlayerPosition(nextPlayerPositionX, nextPlayerPositionY);

                    DisplayNearbyStars();
                }
            }

            return result;
        }


        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };
            switch (pressedKey.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    direction[1] = -1;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    direction[1] = 1;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    direction[0] = -1;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    direction[0] = 1;
                    break;
            }
            return direction;
        }

        internal ResultEnum CheckCellResult(Elements nextCell, int nextPlayerPositionX, int nextPlayerPositionY)
        {
            if (nextCell is Mine)
            {

                return ResultEnum.GameOver;
            }
            else if (nextCell is Dollar)
            {
                UpdatePlayerPosition(nextPlayerPositionX, nextPlayerPositionY);

                return ResultEnum.Win;
            }

            return ResultEnum.Continue;
        }

        public enum ResultEnum
        {
            Continue,
            GameOver,
            Win
        }

        private void UpdatePlayerPosition(int nextPlayerPositionX, int nextPlayerPositionY)
        {
            map.SetElement(PositionY, PositionX, ' ');
            PositionX = nextPlayerPositionX;
            PositionY = nextPlayerPositionY;
            map.SetElement(PositionY, PositionX, '@');
        }



    }
}
