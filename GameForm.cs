﻿using ConsoleGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsGame
{

    public partial class GameForm : Form
    {
        private Map map;
        private PictureBox[,] mapPictureBoxes;
        private Player player;
        private int squareSize = 23;



       public GameForm(int height, int width, int percentFilled)
        {
            InitializeComponent();

            map = new Map(height, width, percentFilled);
            mapPictureBoxes = new PictureBox[map.Height + 2, map.Width + 2];

            player = new Player(map);
            AdjustWindowSize();
            DrawMap();
            UpdateMinesCount();

            //  Розміщення minesCountLabel поруч з mapPictureBox
            minesCountLabel.Location = new Point(mapPictureBox.Right + 10, mapPictureBox.Top + mapPictureBox.Height / 2 - minesCountLabel.Height / 2);
        }

        private void AdjustWindowSize()
        {
            int windowWidth = (map.Width + 2) * squareSize + 200; // Змініть відступи за потреби
            int windowHeight = (map.Height + 2) * squareSize + 80; // Змініть відступи за потреби
            this.ClientSize = new Size(windowWidth, windowHeight);

            // // Зміна позицію мітки minesCountLabel
            int labelX = mapPictureBox.Location.X + mapPictureBox.Width + 10;
            int labelY = mapPictureBox.Location.Y + mapPictureBox.Height / 2 - minesCountLabel.Height / 2;
            minesCountLabel.Location = new Point(labelX, labelY);
        }


        private void UpdateMinesCount()
        {
            int numMines = player.DisplayNearbyStars();
            minesCountLabel.Text = $"Mines: {numMines}";
        }


        private void DrawMap()
        {
            mapPictureBox.SuspendLayout();
            this.SuspendLayout();

            mapPictureBox.Controls.Clear();
            mapPictureBoxes = new PictureBox[map.Height + 2, map.Width + 2];

            // Розрахунок розміру mapPictureBox на основі розмірів карти
            int pictureBoxWidth = (map.Width + 2) * squareSize;
            int pictureBoxHeight = (map.Height + 2) * squareSize;

            // Встановлення розміру mapPictureBox
            mapPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);

            // Розрахунок фактичного розміру зображення в кожному PictureBox
            int imageWidth = squareSize - 2;  // Відніміть 2 для товщини межі
            int imageHeight = squareSize - 2; // Відніміть 2 для товщини межі

            // Призупинити оновлення макету для уникнення непотрібних обчислень та оновлень
            mapPictureBox.SuspendLayout();

            // Перебір кожного елементу на карті
            for (int y = 0; y < map.Height + 2; y++)
            {
                for (int x = 0; x < map.Width + 2; x++)
                {
                    // Створення нового PictureBox для кожного елементу
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(squareSize, squareSize);
                    pictureBox.Location = new Point(x * squareSize, y * squareSize);

                    
                    Elements element = map.GetElement(y, x);

                    // Перевірка, чи елемент представляє позицію гравця
                    if (x == player.PositionX && y == player.PositionY)
                    {
                        // Встановлення зображення гравця
                        pictureBox.BackgroundImage = Properties.Resources.PlayerImage;
                    }
                    // Встановлення фонового зображення на основі елемента карти
                    else if (element is Wall)
                    {
                        pictureBox.BackgroundImage = Properties.Resources.WallImage;
                    }
                    /*else if (element is Mine)
                    {
                        pictureBox.BackgroundImage = Properties.Resources.WallImage;
                    }*/

                    else if (element is Dollar)
                    {
                        pictureBox.BackgroundImage = Properties.Resources.DollarImage;
                    }
                    else
                    {
                        pictureBox.BackColor = Color.White;
                    }

                    // Налаштування розміру фонового зображення для впису у PictureBox
                    if (pictureBox.BackgroundImage != null)
                    {
                        pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                        pictureBox.BackgroundImage = ResizeImage(pictureBox.BackgroundImage, imageWidth, imageHeight);
                    }

                    // Додавання елемента керування PictureBox до форми та масиву mapPictureBoxes
                    mapPictureBox.Controls.Add(pictureBox);
                    mapPictureBoxes[y, x] = pictureBox;
                }
            }

            // Відновлення макету та виконання оновлення макету
            mapPictureBox.ResumeLayout();
            this.ResumeLayout();

            // Оновлення mapPictureBox для відображення змін
            mapPictureBox.Refresh();
        }



        private Image ResizeImage(Image image, int width, int height)
        {
            // Створення нового Bitmap із заданим розміром
            Bitmap resizedImage = new Bitmap(width, height);

            // Намалювати оригінальне зображення на зменшеному бітмапі
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            // Повернути зменшене зображення
            return resizedImage;
        }



        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Перевірка, яку клавішу натиснуто
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.A:
                    MovePlayer(-1, 0); // Рух вліво
                    break;
                case Keys.Right:
                case Keys.D:
                    MovePlayer(1, 0); // Рух вправо
                    break;
                case Keys.Up:
                case Keys.W:
                    MovePlayer(0, -1); // Рух вгору
                    break;
                case Keys.Down:
                case Keys.S:
                    MovePlayer(0, 1); // Рух вниз
                    break;
            }
        }


        private void UpdatePlayerPosition(int prevX, int prevY, int newX, int newY)
        {
            // Оновити PictureBox, що відображає попередню позицію гравця
            mapPictureBoxes[prevY, prevX].BackgroundImage = null;
            mapPictureBoxes[prevY, prevX].BackColor = Color.White;

            // Оновити PictureBox, що відображає поточну позицію гравця
            mapPictureBoxes[newY, newX].BackgroundImage = Properties.Resources.PlayerImage;
            mapPictureBoxes[newY, newX].BackgroundImageLayout = ImageLayout.Stretch;
            mapPictureBoxes[newY, newX].BackgroundImage = ResizeImage(mapPictureBoxes[newY, newX].BackgroundImage, squareSize - 2, squareSize - 2);
        }

        private void MovePlayer(int deltaX, int deltaY)
        {
            // Розрахувати наступну позицію гравця
            int nextPlayerPositionX = player.PositionX + deltaX;
            int nextPlayerPositionY = player.PositionY + deltaY;

            // Перетворити код клавіші на ConsoleKey
            ConsoleKey consoleKey = ConvertToConsoleKey(deltaX, deltaY);

            // Створити новий ConsoleKeyInfo, використовуючи перетворений ConsoleKey
            ConsoleKeyInfo consoleKeyInfo = new ConsoleKeyInfo((char)0, consoleKey, false, false, false);


            // Викликати метод PlayerMovement класу Player для обробки руху
            Player.ResultEnum result = player.PlayerMovement(consoleKeyInfo);

            // Обробка результату гри
            HandleGameResult(result, deltaX, deltaY);

            // Оновити лічильник мін
            UpdateMinesCount();

            // Оновити позицію гравця
            UpdatePlayerPosition(player.PositionX - deltaX, player.PositionY - deltaY, player.PositionX, player.PositionY);
        }

        private void HandleGameResult(Player.ResultEnum result, int deltaX, int deltaY)
        {
            if (result == Player.ResultEnum.GameOver)
            {

                MessageBox.Show("Game Over");
                RestartGame(); // Викликати вікно рестарту гри
            }
            else if (result == Player.ResultEnum.Win)
            {
                UpdatePlayerPosition(player.PositionX - deltaX, player.PositionY - deltaY, player.PositionX, player.PositionY);
                MessageBox.Show("You Win!");
                RestartGame(); // Викликати вікно рестарту гри
            }
        }

        private void RestartGame()
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to restart the game?", "Restart Game", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Закрити поточну форму гри
                this.Hide();
                this.Dispose();

                // Показати форму введення для початку нової гри
                GameInputForm inputForm = new GameInputForm();
                inputForm.ShowDialog();
                Close(); // Закрити форму введення
            }
            else
            {
                Close(); // Завершити гру
            }
        }



        private ConsoleKey ConvertToConsoleKey(int deltaX, int deltaY)
        {
            // Перетворити код клавіші на ConsoleKey
            if (deltaX == -1 && deltaY == 0)
            {
                return ConsoleKey.LeftArrow;
            }
            else if (deltaX == 1 && deltaY == 0)
            {
                return ConsoleKey.RightArrow;
            }
            else if (deltaX == 0 && deltaY == -1)
            {
                return ConsoleKey.UpArrow;
            }
            else if (deltaX == 0 && deltaY == 1)
            {
                return ConsoleKey.DownArrow;
            }
            else
            {
                return ConsoleKey.Spacebar; // Випадок за замовчуванням, може бути змінений, за потреби
            }
        }

    }
} 