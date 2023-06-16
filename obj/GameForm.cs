using ConsoleGame;
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
        }

        private void AdjustWindowSize()
        {
            int windowWidth = map.Width * squareSize + 200; // Adjust the padding as needed
            int windowHeight = map.Height * squareSize + 80; // Adjust the padding as needed
            this.ClientSize = new Size(windowWidth, windowHeight);
        }
        private void DrawMap()
        {
            mapPictureBox.Controls.Clear();

            // Calculate the size of the mapPictureBox based on the map dimensions
            int pictureBoxWidth = (map.Width + 2) * squareSize;
            int pictureBoxHeight = (map.Height + 2) * squareSize;

            // Set the size of the mapPictureBox
            mapPictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);

            // Calculate the actual size of the image within each PictureBox
            int imageWidth = squareSize - 2;  // Subtract 2 for the border thickness
            int imageHeight = squareSize - 2; // Subtract 2 for the border thickness

            // Iterate over each element in the map
            for (int y = 0; y < map.Height + 2; y++)
            {
                for (int x = 0; x < map.Width + 2; x++)
                {
                    // Create a new PictureBox for each element
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Size = new Size(squareSize, squareSize);
                    pictureBox.Location = new Point(x * squareSize, y * squareSize);

                    // Set the image or color based on the element type
                    Elements element = map.GetElement(y, x);

                    // Check if the element represents the player's position
                    if (player.PositionX == x && player.PositionY == y)
                    {
                        // Set the player image or color
                        pictureBox.BackgroundImage = Properties.Resources.PlayerImage; // For example, set player color to red
                    }
                    // Set the background image based on the map element
                    else if (element is Wall)
                    {
                        pictureBox.BackgroundImage = Properties.Resources.WallImage;
                    }
                    else if (element is Mine)
                    {
                        pictureBox.BackgroundImage = Properties.Resources.MineImage;
                    }
                    else if (element is Dollar)
                    {
                        pictureBox.BackgroundImage = Properties.Resources.DollarImage;
                    }
                    else
                    {
                        pictureBox.BackColor = Color.White;
                    }

                    // Adjust the background image size to fit the PictureBox
                    if (pictureBox.BackgroundImage != null)
                    {
                        pictureBox.BackgroundImageLayout = ImageLayout.Stretch;
                        pictureBox.BackgroundImage = ResizeImage(pictureBox.BackgroundImage, imageWidth, imageHeight);
                    }

                    // Add the PictureBox control to the form and the mapPictureBoxes array
                    mapPictureBox.Controls.Add(pictureBox);
                    mapPictureBoxes[y, x] = pictureBox;
                }
            }
        }




        private Image ResizeImage(Image image, int width, int height)
        {
            // Create a new Bitmap with the desired size
            Bitmap resizedImage = new Bitmap(width, height);

            // Draw the original image onto the resized bitmap
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, width, height);
            }

            // Return the resized image
            return resizedImage;
        }



        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Check which key was pressed
            switch (e.KeyCode)
            {
                case Keys.Left:
                    MovePlayer(-1, 0); // Move left
                    break;
                case Keys.Right:
                    MovePlayer(1, 0); // Move right
                    break;
                case Keys.Up:
                    MovePlayer(0, -1); // Move up
                    break;
                case Keys.Down:
                    MovePlayer(0, 1); // Move down
                    break;
            }
        }

        private void MovePlayer(int deltaX, int deltaY)
        {
            int nextPlayerX = player.PositionX + deltaX;
            int nextPlayerY = player.PositionY + deltaY;

            // Check if the next position is valid (not out of bounds and not a wall)
            if (nextPlayerX >= 0 && nextPlayerX < map.Width && nextPlayerY >= 0 && nextPlayerY < map.Height)
            {
                Elements nextCell = map.GetElement(nextPlayerY, nextPlayerX);

                // Check the result of moving to the next cell
                Player.ResultEnum result = player.CheckCellResult(nextCell, nextPlayerX, nextPlayerY);

                // Handle game result
                if (result == Player.ResultEnum.GameOver)
                {
                    MessageBox.Show("Game Over");
                    // Close the game or show game over screen
                }
                else if (result == Player.ResultEnum.Win)
                {
                    MessageBox.Show("You Win!");
                    // Close the game or show win screen
                }
                else if (result == Player.ResultEnum.Continue)
                {
                    // Move the player to the next position
                    player.UpdatePlayerPosition(nextPlayerX, nextPlayerY);

                    // Redraw the map
                    DrawMap();
                }
            }
        }

    }
}
