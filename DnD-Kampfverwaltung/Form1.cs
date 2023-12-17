using Microsoft.VisualBasic;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace DnD_Kampfverwaltung
{
    public partial class Form1 : Form
    {
        //Liste mit den K�mpfern und ihren Werten
        public List<fighter> fighters = new List<fighter>();

        private TextBox[] textBoxes = new TextBox[20];
        private CheckBox[] checkBoxes = new CheckBox[20];
        public int counter = 0;

        //Variablen f�r das Resizing
        private Dictionary<Control, Rectangle> initialFormSize = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> initialFontSizes = new Dictionary<Control, float>();
        private int standardSizeX;
        private int standardSizeY;

        public Form1()
        {
            InitializeComponent();
            this.Text = "W2.0 Kampfverwaltung";

            setControls();

            //Fenstergr��e & Positionen + Gr��en der Controls f�r den Resize-Befehl speichern
            foreach (Control control in this.Controls)
            {
                initialFormSize[control] = control.Bounds;
                initialFontSizes[control] = control.Font.Size;
            }
            standardSizeX = this.Width;
            standardSizeY = this.Height;
        }

        private void fightButton_Click(object sender, EventArgs e)
        {
            //Leere die Listen
            fighters.Clear();
            counter = 0;

            //F�ge K�mpfer in die Liste
            for (int i = 0; i < textBoxes.Length; i++)
            {
                //Ignoriere Eintr�ge, die nur aus " " bestehen (versehentliche Eintragunen)
                if (textBoxes[i].Text != "" && textBoxes[i].Text != " " && textBoxes[i].Text != "  ")
                {
                    //�bernehme K�mpfername und ggf. doppelte Zugzeit
                    addFighter(textBoxes[i].Text, checkBoxes[i].Checked);
                }
            }

            //Check ob Kampf gestartet wird, nur wenn min. 2 K�mpfer eingetragen sind und Zugzeit leer oder Zahl ist
            if (fighters.Count >= 2 && (int.TryParse(timePerRound.Text, out int time) || timePerRound.Text == ""))
            {
                if (timePerRound.Text == "") //Wenn keine Rundenzeit angegeben, w�hle Standardwert (120s)
                {
                    Form2 scene = new Form2(fighters, 120);
                    scene.Show();
                }
                else //Sonst angegebene Zugzeit w�hlen
                {
                    Form2 scene = new Form2(fighters, time);
                    scene.Show();
                }
            }
        }

        public void addFighter(string fighter, bool doubleTime)
        {
            //Neuen K�mpfer (inklusive Angabe der Zeitverl�ngerung) hinzuf�gen
            fighters.Add(new fighter(fighter, doubleTime));
            counter++;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Textfelder zur�cksetzen
            foreach (TextBox a in textBoxes) a.Text = "";
            foreach (CheckBox a in checkBoxes) a.Checked = false;
            timePerRound.Text = "";
        }

        private void resize()
        {
            //Skalierungsfaktor bestimmen
            float scaleX = (float)this.Size.Width / (float)standardSizeX;
            float scaleY = (float)this.Size.Height / (float)standardSizeY;

            //Alle Positionen, Gr��en und Schriftgr��en anpassen
            foreach (Control control in this.Controls)
            {
                control.Left = (int)(initialFormSize[control].Left * scaleX);
                control.Top = (int)(initialFormSize[control].Top * scaleY);
                control.Width = (int)(initialFormSize[control].Width * scaleX);
                control.Height = (int)(initialFormSize[control].Height * scaleY);

                float currentSize = initialFontSizes[control];
                control.Font = new Font(control.Font.FontFamily, currentSize * Math.Min(scaleX, scaleY));
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
            checkBoxes[0] = doubleTime1;
            checkBoxes[1] = doubleTime2;
            checkBoxes[2] = doubleTime3;
            checkBoxes[3] = doubleTime4;
            checkBoxes[4] = doubleTime5;
            checkBoxes[5] = doubleTime6;
            checkBoxes[6] = doubleTime7;
            checkBoxes[7] = doubleTime8;
            checkBoxes[8] = doubleTime9;
            checkBoxes[9] = doubleTime10;
            checkBoxes[10] = doubleTime11;
            checkBoxes[11] = doubleTime12;
            checkBoxes[12] = doubleTime13;
            checkBoxes[13] = doubleTime14;
            checkBoxes[14] = doubleTime15;
            checkBoxes[15] = doubleTime16;
            checkBoxes[16] = doubleTime17;
            checkBoxes[17] = doubleTime18;
            checkBoxes[18] = doubleTime19;
            checkBoxes[19] = doubleTime20;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            resize();
        }
    }
}