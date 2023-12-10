using System.Windows.Forms;

namespace DnD_Kampfverwaltung
{
    public partial class Form1 : Form
    {
        List<string> fighters = new List<string>();
        List<bool> doubleTimes = new List<bool>();
        TextBox[] textBoxes = new TextBox[20];
        CheckBox[] checkBoxes = new CheckBox[20];
        public int counter = 0;

        public Form1()
        {
            InitializeComponent();
            this.Text = "W2.0 Kampfverwaltung";
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
            autoScale();
        }

        private void fightButton_Click(object sender, EventArgs e)
        {
            //Leere die Listen
            fighters.Clear();
            doubleTimes.Clear();
            counter = 0;

            //Füge Kämpfer in die Liste
            for (int i = 0; i < textBoxes.Length; i++)
            {
                //Ignoriere Einträge, die nur aus " " bestehen (versehentliche Eintragunen)
                if (textBoxes[i].Text != "" && textBoxes[i].Text != " " && textBoxes[i].Text != "  ")
                {
                    //Übernehme Kämpfername und ggf. doppelte Zugzeit
                    addFighter(textBoxes[i].Text, checkBoxes[i].Checked);
                }
            }

            //Check ob Kampf gestartet wird, nur wenn min. 2 Kämpfer eingetragen sind und Zugzeit leer oder Zahl ist
            if (fighters.Count >= 2 && (int.TryParse(timePerRound.Text, out int number2) || timePerRound.Text == ""))
            {
                if (timePerRound.Text == "") //Wenn keine Rundenzeit angegeben, wähle Standardwert (120s)
                {
                    Form2 scene = new Form2(fighters, doubleTimes, "120");
                    scene.Show();
                }
                else //Sonst angegebene Zugzeit wählen
                {
                    Form2 scene = new Form2(fighters, doubleTimes, timePerRound.Text);
                    scene.Show();
                }
            }
        }

        public void addFighter(string fighter, bool doubleTime)
        {
            fighters.Add(fighter);
            doubleTimes.Add(doubleTime);
            counter++;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Textfelder zurücksetzen
            foreach (TextBox a in textBoxes) a.Text = "";
            foreach (CheckBox a in checkBoxes) a.Checked = false;
            timePerRound.Text = "";
        }

        private void autoScale()
        {
            Control[] c = Controls.OfType<Control>().Cast<Control>().ToArray();
            foreach(Control controlItem in c)
            {
                
            }
            int i = 3;
            i++;
        }

    }
}