using ConsoleGame;

namespace WinFormsGame
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.minesCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.mapPictureBox.Location = new System.Drawing.Point(12, 12);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(400, 400);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            // 
            // minesCountLabel
            // 
            this.minesCountLabel.AutoSize = true;
            
            this.minesCountLabel.Name = "minesCountLabel";
            this.minesCountLabel.Size = new System.Drawing.Size(38, 15);
            this.minesCountLabel.TabIndex = 1;
            this.minesCountLabel.Text = "Mines: 0";
            this.minesCountLabel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.minesCountLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            // 
            // GameForm
            // 
            this.ClientSize = new System.Drawing.Size(564, 424);
            this.Controls.Add(this.minesCountLabel);
            this.Controls.Add(this.mapPictureBox);
            this.Name = "GameForm";
            this.Text = "Mined-Out - Game field";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private PictureBox mapPictureBox;
        private Label minesCountLabel;
    }
}