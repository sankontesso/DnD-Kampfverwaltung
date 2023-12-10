namespace DnD_Kampfverwaltung
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            activeLabel = new Label();
            nextButton = new Button();
            timeLabel = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            secondLabel = new Label();
            thirdLabel = new Label();
            fourthLabel = new Label();
            fifthLabel = new Label();
            deleteButton = new Button();
            roundsLabel = new Label();
            folgendLabel = new Label();
            logoBox = new PictureBox();
            newFighterButton = new Button();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // activeLabel
            // 
            activeLabel.AutoSize = true;
            activeLabel.Font = new Font("Segoe UI", 100F, FontStyle.Regular, GraphicsUnit.Point);
            activeLabel.Location = new Point(-14, 121);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new Size(428, 177);
            activeLabel.TabIndex = 0;
            activeLabel.Text = "label1";
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            nextButton.Location = new Point(711, 437);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(144, 95);
            nextButton.TabIndex = 1;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 45F, FontStyle.Regular, GraphicsUnit.Point);
            timeLabel.Location = new Point(706, 9);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(153, 81);
            timeLabel.TabIndex = 2;
            timeLabel.Text = "time";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // secondLabel
            // 
            secondLabel.AutoSize = true;
            secondLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            secondLabel.Location = new Point(14, 357);
            secondLabel.Name = "secondLabel";
            secondLabel.Size = new Size(122, 45);
            secondLabel.TabIndex = 3;
            secondLabel.Text = "second";
            // 
            // thirdLabel
            // 
            thirdLabel.AutoSize = true;
            thirdLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            thirdLabel.Location = new Point(14, 402);
            thirdLabel.Name = "thirdLabel";
            thirdLabel.Size = new Size(87, 45);
            thirdLabel.TabIndex = 4;
            thirdLabel.Text = "third";
            // 
            // fourthLabel
            // 
            fourthLabel.AutoSize = true;
            fourthLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            fourthLabel.Location = new Point(14, 447);
            fourthLabel.Name = "fourthLabel";
            fourthLabel.Size = new Size(107, 45);
            fourthLabel.TabIndex = 5;
            fourthLabel.Text = "fourth";
            // 
            // fifthLabel
            // 
            fifthLabel.AutoSize = true;
            fifthLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            fifthLabel.Location = new Point(14, 492);
            fifthLabel.Name = "fifthLabel";
            fifthLabel.Size = new Size(77, 45);
            fifthLabel.TabIndex = 6;
            fifthLabel.Text = "fifth";
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(711, 336);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(144, 95);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Entferne Kämpfer";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // roundsLabel
            // 
            roundsLabel.AutoSize = true;
            roundsLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            roundsLabel.Location = new Point(143, 34);
            roundsLabel.Name = "roundsLabel";
            roundsLabel.Size = new Size(165, 50);
            roundsLabel.TabIndex = 8;
            roundsLabel.Text = "Runde: 1";
            // 
            // folgendLabel
            // 
            folgendLabel.AutoSize = true;
            folgendLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            folgendLabel.Location = new Point(14, 312);
            folgendLabel.Name = "folgendLabel";
            folgendLabel.Size = new Size(295, 45);
            folgendLabel.TabIndex = 9;
            folgendLabel.Text = "Folgende Kämpfer:";
            // 
            // logoBox
            // 
            logoBox.BackColor = SystemColors.Control;
            logoBox.BackgroundImageLayout = ImageLayout.None;
            logoBox.Image = Properties.Resources.Logo_Scale;
            logoBox.Location = new Point(3, -6);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(134, 124);
            logoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoBox.TabIndex = 25;
            logoBox.TabStop = false;
            // 
            // newFighterButton
            // 
            newFighterButton.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point);
            newFighterButton.Location = new Point(561, 437);
            newFighterButton.Name = "newFighterButton";
            newFighterButton.Size = new Size(144, 95);
            newFighterButton.TabIndex = 26;
            newFighterButton.Text = "Weiterer Kämpfer";
            newFighterButton.UseVisualStyleBackColor = true;
            newFighterButton.Click += newFighterButton_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 543);
            Controls.Add(newFighterButton);
            Controls.Add(folgendLabel);
            Controls.Add(roundsLabel);
            Controls.Add(deleteButton);
            Controls.Add(fifthLabel);
            Controls.Add(fourthLabel);
            Controls.Add(thirdLabel);
            Controls.Add(secondLabel);
            Controls.Add(timeLabel);
            Controls.Add(nextButton);
            Controls.Add(activeLabel);
            Controls.Add(logoBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label activeLabel;
        private Button nextButton;
        private Label timeLabel;
        private System.Windows.Forms.Timer timer1;
        private Label secondLabel;
        private Label thirdLabel;
        private Label fourthLabel;
        private Label fifthLabel;
        private Button deleteButton;
        private Label roundsLabel;
        private Label folgendLabel;
        private PictureBox logoBox;
        private Button newFighterButton;
    }
}