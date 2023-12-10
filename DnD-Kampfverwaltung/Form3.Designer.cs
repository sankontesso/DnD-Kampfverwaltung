namespace DnD_Kampfverwaltung
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
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(12, 41);
            addButton.Name = "addButton";
            addButton.Size = new Size(144, 48);
            addButton.TabIndex = 1;
            addButton.Text = "Hinzufügen ";
            addButton.UseVisualStyleBackColor = true;
            // 
            // newFighter
            // 
            newFighter.Location = new Point(33, 12);
            newFighter.Name = "newFighter";
            newFighter.PlaceholderText = "Neuer Kämpfer";
            newFighter.Size = new Size(123, 23);
            newFighter.TabIndex = 28;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 14);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 29;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(169, 98);
            Controls.Add(checkBox1);
            Controls.Add(newFighter);
            Controls.Add(addButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form3";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        public Button addButton;
        public TextBox newFighter;
        public CheckBox checkBox1;
    }
}