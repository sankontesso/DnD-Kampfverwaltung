namespace DnD_Kampfverwaltung
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            comboBox1 = new ComboBox();
            acceptButton = new Button();
            exhaustionBox = new ComboBox();
            resetButton = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(345, 23);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // acceptButton
            // 
            acceptButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            acceptButton.Location = new Point(12, 141);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(211, 48);
            acceptButton.TabIndex = 2;
            acceptButton.Text = "Akzeptieren [ENTER]";
            acceptButton.UseVisualStyleBackColor = true;
            acceptButton.Click += acceptButton_Click;
            // 
            // exhaustionBox
            // 
            exhaustionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            exhaustionBox.FormattingEnabled = true;
            exhaustionBox.Items.AddRange(new object[] { "Ersch. 0", "Ersch. 1", "Ersch. 2", "Ersch. 3", "Ersch. 4", "Ersch. 5" });
            exhaustionBox.Location = new Point(363, 12);
            exhaustionBox.Name = "exhaustionBox";
            exhaustionBox.Size = new Size(78, 23);
            exhaustionBox.TabIndex = 3;
            // 
            // resetButton
            // 
            resetButton.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            resetButton.Location = new Point(276, 141);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(165, 48);
            resetButton.TabIndex = 4;
            resetButton.Text = "Reset Status [R]";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 196);
            Controls.Add(resetButton);
            Controls.Add(exhaustionBox);
            Controls.Add(acceptButton);
            Controls.Add(comboBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(469, 235);
            Name = "Form4";
            Text = "Form4";
            Resize += Form4_Resize;
            ResumeLayout(false);
        }

        #endregion
        public ComboBox comboBox1;
        public Button acceptButton;
        public ComboBox exhaustionBox;
        public Button resetButton;
    }
}