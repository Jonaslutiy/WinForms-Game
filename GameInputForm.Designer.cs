namespace WinFormsGame
{
    partial class GameInputForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.percentFilledLabel = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.percentFilledTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // heightLabel
            // 
            this.heightLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.heightLabel.Location = new System.Drawing.Point(79, 85);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(100, 23);
            this.heightLabel.TabIndex = 0;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.widthLabel.Location = new System.Drawing.Point(79, 139);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(100, 23);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "Width:";
            // 
            // percentFilledLabel
            // 
            this.percentFilledLabel.AutoSize = true;
            this.percentFilledLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.percentFilledLabel.Location = new System.Drawing.Point(12, 189);
            this.percentFilledLabel.Name = "percentFilledLabel";
            this.percentFilledLabel.Size = new System.Drawing.Size(223, 26);
            this.percentFilledLabel.TabIndex = 2;
            this.percentFilledLabel.Text = "Percent Filled (0 - 100):";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(261, 139);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.Size = new System.Drawing.Size(121, 23);
            this.widthTextBox.TabIndex = 4;
            widthTextBox.KeyDown += TextBox_KeyDown; // Add event handler
            // 
            // percentFilledTextBox
            // 
            this.percentFilledTextBox.Location = new System.Drawing.Point(261, 194);
            this.percentFilledTextBox.Name = "percentFilledTextBox";
            this.percentFilledTextBox.Size = new System.Drawing.Size(121, 23);
            this.percentFilledTextBox.TabIndex = 5;
            percentFilledTextBox.KeyDown += TextBox_KeyDown; // Add event handler

            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.AliceBlue;
            this.createButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.createButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createButton.Location = new System.Drawing.Point(162, 260);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(119, 35);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Створити";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(261, 85);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.Size = new System.Drawing.Size(121, 23);
            this.heightTextBox.TabIndex = 3;
            heightTextBox.KeyDown += TextBox_KeyDown; // Add event handler
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.Title);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 61);
            this.panel1.TabIndex = 8;
            // 
            // Title
            // 
            this.Title.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.Location = new System.Drawing.Point(137, 11);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(176, 35);
            this.Title.TabIndex = 0;
            this.Title.Text = "Mined - Out";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameInputForm
            // 
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(443, 333);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.Controls.Add(this.percentFilledLabel);
            this.Controls.Add(this.heightTextBox);
            this.Controls.Add(this.widthTextBox);
            this.Controls.Add(this.percentFilledTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GameInputForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mined-Out - Game Settings";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label heightLabel;
        private Label widthLabel;
        private Label percentFilledLabel;
        private TextBox heightTextBox;
        private TextBox widthTextBox;
        private TextBox percentFilledTextBox;
        private Button createButton;
        private Panel panel1;
        private Label Title;
    }
}