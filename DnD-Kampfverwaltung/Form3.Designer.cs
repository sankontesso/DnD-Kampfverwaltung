﻿namespace DnD_Kampfverwaltung
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            addButton = new Button();
            newFighter = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(12, 72);
            addButton.Name = "addButton";
            addButton.Size = new Size(360, 101);
            addButton.TabIndex = 1;
            addButton.Text = "Hinzufügen [ENTER]";
            addButton.UseVisualStyleBackColor = true;
            // 
            // newFighter
            // 
            newFighter.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            newFighter.Location = new Point(75, 9);
            newFighter.Name = "newFighter";
            newFighter.PlaceholderText = "Neuer Kämpfer";
            newFighter.Size = new Size(274, 57);
            newFighter.TabIndex = 28;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(50, 50);
            button1.TabIndex = 46;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 181);
            Controls.Add(button1);
            Controls.Add(newFighter);
            Controls.Add(addButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(400, 220);
            MinimumSize = new Size(400, 220);
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button addButton;
        public TextBox newFighter;
        public Button button1;
    }
}