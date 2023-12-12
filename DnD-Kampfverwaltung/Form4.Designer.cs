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
            playerComboBox = new ComboBox();
            SuspendLayout();
            // 
            // playerComboBox
            // 
            playerComboBox.FormattingEnabled = true;
            playerComboBox.Location = new Point(14, 16);
            playerComboBox.Margin = new Padding(3, 4, 3, 4);
            playerComboBox.Name = "playerComboBox";
            playerComboBox.Size = new Size(138, 28);
            playerComboBox.TabIndex = 0;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(playerComboBox);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form4";
            Text = "Form4";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox playerComboBox;
    }
}