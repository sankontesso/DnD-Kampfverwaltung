using Microsoft.VisualBasic;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;

namespace DnD_Kampfverwaltung
{
    public partial class Form1 : Form
    {
        //Liste mit den Kämpfern und ihren Werten
        public List<fighter> fighters = new List<fighter>();

        private TextBox[] textBoxes = new TextBox[20];
        private Button[] checkBoxes = new Button[20];
        public int counter = 0;

        //Variablen für das Resizing
        private Dictionary<Control, Rectangle> initialFormSize = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> initialFontSizes = new Dictionary<Control, float>();
        private int standardSizeX;
        private int standardSizeY;

        public Form1()
        {
            InitializeComponent();
            this.Text = "W2.0 Kampfverwaltung";

            setControls();

            //Fenstergröße & Positionen + Größen der Controls für den Resize-Befehl speichern
            foreach (Control control in this.Controls)
            {
                initialFormSize[control] = control.Bounds;
                initialFontSizes[control] = control.Font.Size;
            }
            standardSizeX = this.Width;
            standardSizeY = this.Height;

            //Fenster maximieren
            this.WindowState = FormWindowState.Maximized;
        }

        private void fightButton_Click(object sender, EventArgs e)
        {
            //Leere die Listen
            fighters.Clear();
            counter = 0;

            //Füge Kämpfer in die Liste
            for (int i = 0; i < textBoxes.Length; i++)
            {
                //Ignoriere Einträge, die nur aus " " bestehen (versehentliche Eintragunen)
                if (textBoxes[i].Text != "" && textBoxes[i].Text != " " && textBoxes[i].Text != "  ")
                {
                    //Übernehme Kämpfername und ggf. doppelte Zugzeit
                    addFighter(textBoxes[i].Text, checkBoxes[i].Text == "X");
                }
            }

            //Check ob Kampf gestartet wird, nur wenn min. 2 Kämpfer eingetragen sind und Zugzeit leer oder Zahl ist
            if (fighters.Count >= 2 && (int.TryParse(timePerRound.Text, out int time) || timePerRound.Text == ""))
            {
                if (timePerRound.Text == "") //Wenn keine Rundenzeit angegeben, wähle Standardwert (120s)
                {
                    Form2 scene = new Form2(fighters, 120);
                    scene.Show();
                }
                else //Sonst angegebene Zugzeit wählen
                {
                    Form2 scene = new Form2(fighters, time);
                    scene.Show();
                }
            }
        }

        public void addFighter(string fighter, bool doubleTime)
        {
            //Neuen Kämpfer (inklusive Angabe der Zeitverlängerung) hinzufügen
            fighters.Add(new fighter(fighter, doubleTime));
            counter++;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Textfelder zurücksetzen
            foreach (TextBox a in textBoxes) a.Text = "";
            foreach (Button a in checkBoxes) a.Text = "";
            timePerRound.Text = "";
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Wenn ESC gedrückt wird, Fenster schließen, bei ENTER Kampf starten
            if (keyData == Keys.Escape) this.Close();
            if (keyData == Keys.Enter)
            {
                fightButton.PerformClick();
                return true;
            }
            return false;
        }

        private void resize()
        {
            //Skalierungsfaktor bestimmen
            float scaleX = (float)this.Size.Width / (float)standardSizeX;
            float scaleY = (float)this.Size.Height / (float)standardSizeY;

            //Alle Positionen, Größen und Schriftgrößen anpassen
            foreach (Control control in this.Controls)
            {
                control.Left = (int)(initialFormSize[control].Left * scaleX);
                control.Top = (int)(initialFormSize[control].Top * scaleY);
                control.Width = (int)(initialFormSize[control].Width * scaleX);
                control.Height = (int)(initialFormSize[control].Height * scaleY);

                float currentSize = initialFontSizes[control];
                control.Font = new Font(control.Font.FontFamily, currentSize * Math.Min(scaleX, scaleY));
            }

            //Buttons quadratisch formatieren
            for(int i = 0; i < checkBoxes.Length; i++)
            {
                checkBoxes[i].Location = new Point(checkBoxes[i].Left + (checkBoxes[i].Width - checkBoxes[i].Height), checkBoxes[i].Top);
                checkBoxes[i].Size = new Size(checkBoxes[i].Height, checkBoxes[i].Height);
            }
        }

        private void setControls()
        {
            //Namen-Textboxes
            textBoxes[0] = textBox1;
            textBoxes[1] = textBox2;
            textBoxes[2] = textBox3;
            textBoxes[3] = textBox4;
            textBoxes[4] = textBox5;
            textBoxes[5] = textBox6;
            textBoxes[6] = textBox7;
            textBoxes[7] = textBox8;
            textBoxes[8] = textBox9;
            textBoxes[9] = textBox10;
            textBoxes[10] = textBox11;
            textBoxes[11] = textBox12;
            textBoxes[12] = textBox13;
            textBoxes[13] = textBox14;
            textBoxes[14] = textBox15;
            textBoxes[15] = textBox16;
            textBoxes[16] = textBox17;
            textBoxes[17] = textBox18;
            textBoxes[18] = textBox19;
            textBoxes[19] = textBox20;

            //Zugzeiten-Checkboxes
            checkBoxes[0] = button1;
            checkBoxes[1] = button2;
            checkBoxes[2] = button3;
            checkBoxes[3] = button4;
            checkBoxes[4] = button5;
            checkBoxes[5] = button6;
            checkBoxes[6] = button7;
            checkBoxes[7] = button8;
            checkBoxes[8] = button9;
            checkBoxes[9] = button10;
            checkBoxes[10] = button11;
            checkBoxes[11] = button12;
            checkBoxes[12] = button13;
            checkBoxes[13] = button14;
            checkBoxes[14] = button15;
            checkBoxes[15] = button16;
            checkBoxes[16] = button17;
            checkBoxes[17] = button18;
            checkBoxes[18] = button19;
            checkBoxes[19] = button20;

            //Den Button (Checkboxen), das click-Event hinzufügen
            foreach(Button a in checkBoxes)
            {
                a.Click += buttonPressed;
            }
        }

        private void buttonPressed(object sender, EventArgs e)
        {
            Button clickButton = (Button)sender;
            if (clickButton.Text == "")
            {
                clickButton.Text = "X";
            }
            else
            {
                clickButton.Text = "";
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resize();
        }
    }
}