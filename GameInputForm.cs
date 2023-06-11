namespace WinFormsGame
{
    public partial class GameInputForm : Form
    {

        public GameInputForm()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Сповіщення звуком про помилку
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(heightTextBox.Text, out int height) &&
                int.TryParse(widthTextBox.Text, out int width) &&
                int.TryParse(percentFilledTextBox.Text, out int percentFilled))
            {
                if (height > 0 && width > 0 && percentFilled >= 0 && percentFilled <= 100)
                {
                    Hide();
                    GameForm gameForm = new GameForm(height, width, percentFilled);
                    gameForm.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid input. Please enter the correct values (0 - 100).");
                }
            }
            else
            {
                MessageBox.Show("Incorrect input. Please enter natural numbers.");
            }
        }

    }
}