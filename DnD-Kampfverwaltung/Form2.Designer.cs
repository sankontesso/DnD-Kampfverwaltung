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
            statusButton = new Button();
            statusLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            SuspendLayout();
            // 
            // activeLabel
            // 
            activeLabel.Font = new Font("Segoe UI", 100F, FontStyle.Regular, GraphicsUnit.Point);
            activeLabel.Location = new Point(-15, 121);
            activeLabel.Name = "activeLabel";
            activeLabel.Size = new Size(868, 162);
            activeLabel.TabIndex = 0;
            activeLabel.Text = "label1";
            // 
            // nextButton
            // 
            nextButton.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point);
            nextButton.Location = new Point(676, 472);
            nextButton.Name = "nextButton";
            nextButton.Size = new Size(177, 95);
            nextButton.TabIndex = 1;
            nextButton.Text = "Next";
            nextButton.UseVisualStyleBackColor = true;
            nextButton.Click += nextButton_Click;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.Font = new Font("Segoe UI", 45F, FontStyle.Regular, GraphicsUnit.Point);
            timeLabel.Location = new Point(700, 9);
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
            secondLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            secondLabel.Location = new Point(12, 392);
            secondLabel.Name = "secondLabel";
            secondLabel.Size = new Size(475, 45);
            secondLabel.TabIndex = 3;
            secondLabel.Text = "second";
            // 
            // thirdLabel
            // 
            thirdLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            thirdLabel.Location = new Point(12, 437);
            thirdLabel.Name = "thirdLabel";
            thirdLabel.Size = new Size(475, 45);
            thirdLabel.TabIndex = 4;
            thirdLabel.Text = "third";
            // 
            // fourthLabel
            // 
            fourthLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            fourthLabel.Location = new Point(12, 482);
            fourthLabel.Name = "fourthLabel";
            fourthLabel.Size = new Size(475, 45);
            fourthLabel.TabIndex = 5;
            fourthLabel.Text = "fourth";
            // 
            // fifthLabel
            // 
            fifthLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            fifthLabel.Location = new Point(12, 527);
            fifthLabel.Name = "fifthLabel";
            fifthLabel.Size = new Size(475, 45);
            fifthLabel.TabIndex = 6;
            fifthLabel.Text = "fifth";
            // 
            // deleteButton
            // 
            deleteButton.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            deleteButton.Location = new Point(676, 367);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(177, 95);
            deleteButton.TabIndex = 7;
            deleteButton.Text = "Entferne Kämpfer [DEL]";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // roundsLabel
            // 
            roundsLabel.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            roundsLabel.Location = new Point(143, 34);
            roundsLabel.Name = "roundsLabel";
            roundsLabel.Size = new Size(551, 66);
            roundsLabel.TabIndex = 8;
            roundsLabel.Text = "Runde: 1";
            // 
            // folgendLabel
            // 
            folgendLabel.AutoSize = true;
            folgendLabel.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            folgendLabel.Location = new Point(12, 347);
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
            logoBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoBox.TabIndex = 25;
            logoBox.TabStop = false;
            // 
            // newFighterButton
            // 
            newFighterButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            newFighterButton.Location = new Point(493, 472);
            newFighterButton.Name = "newFighterButton";
            newFighterButton.Size = new Size(177, 95);
            newFighterButton.TabIndex = 26;
            newFighterButton.Text = "Weiterer Kämpfer [W/+]";
            newFighterButton.UseVisualStyleBackColor = true;
            newFighterButton.Click += newFighterButton_Click;
            // 
            // statusButton
            // 
            statusButton.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            statusButton.Location = new Point(493, 367);
            statusButton.Name = "statusButton";
            statusButton.Size = new Size(177, 95);
            statusButton.TabIndex = 27;
            statusButton.Text = "Status [S]";
            statusButton.UseVisualStyleBackColor = true;
            statusButton.Click += statusButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            statusLabel.Location = new Point(12, 298);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(841, 30);
            statusLabel.TabIndex = 28;
            statusLabel.Text = "STATUSVERÄNDERUNGEN";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(871, 581);
            Controls.Add(statusButton);
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
            Controls.Add(logoBox);
            Controls.Add(activeLabel);
            Controls.Add(statusLabel);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(887, 620);
            Name = "Form2";
            Text = "Form2";
            Resize += Form2_Resize;
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
        private Button statusButton;
        private Label statusLabel;
    }
}