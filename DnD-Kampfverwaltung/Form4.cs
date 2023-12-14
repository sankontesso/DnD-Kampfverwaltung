using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Kampfverwaltung
{
    public partial class Form4 : Form
    {
        List<fighter> fighters = new List<fighter>();
        Dictionary<string, CheckBox> checkBoxes = new Dictionary<string, CheckBox>();
        fighter activeFighter;

        //Variablen für das Resizing
        private Dictionary<Control, Rectangle> initialFormSize = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> initialFontSizes = new Dictionary<Control, float>();
        private int standardSizeX;
        private int standardSizeY;

        public Form4(List<fighter> fighters, int f)
        {
            InitializeComponent();
            this.Text = "Statusverwaltung";
            this.fighters = fighters;

            //Comboboxmöglichkeiten hinzufügen
            foreach (fighter a in fighters)
            {
                comboBox1.Items.Add(a.name);
            }
            comboBox1.SelectedIndex = f;
            activeFighter = fighters[0];

            //Checkboxes anhand der Statusmöglichkeiten in fighter.cs generieren
            addCheckBoxes();

            //Fenstergröße & Positionen + Größen der Controls für den Resize-Befehl speichern
            foreach (Control control in this.Controls)
            {
                initialFormSize[control] = control.Bounds;
                initialFontSizes[control] = control.Font.Size;
            }
            standardSizeX = this.Width;
            standardSizeY = this.Height;

            //namen des aktiven Kämpfer anwählen
            activeFighter = fighters[0];
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Auswahl des Kämpfers in der Combobox
            checkboxesToFighter();
            foreach(fighter f in fighters)
            {
                if (f.name == comboBox1.Text) activeFighter = f;
            }
            fighterToCheckboxes();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Erschöpfung anhand der Combobox aktualisieren
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    activeFighter.exhaustion = 0;
                    break;
                case 1:
                    activeFighter.exhaustion = 1;
                    break;
                case 2:
                    activeFighter.exhaustion = 2;
                    break;
                case 3:
                    activeFighter.exhaustion = 3;
                    break;
                case 4:
                    activeFighter.exhaustion = 4;
                    break;
                case 5:
                    activeFighter.exhaustion = 5;
                    break;
            }
        }

        private void fighterToCheckboxes()
        {
            //Alle Checkboxen durchlaufen und an die Werte vom ausgewählten Kämpfer
            foreach (var cb in checkBoxes)
            {
                cb.Value.Checked = activeFighter.statuses[cb.Key].Item2;
            }

            //Combobox anhand der Erschöpfung aktualisieren
            switch (activeFighter.exhaustion)
            {
                case 0:
                    comboBox2.SelectedIndex = 0;
                    break;
                case 1:
                    comboBox2.SelectedIndex = 1;
                    break;
                case 2:
                    comboBox2.SelectedIndex = 2;
                    break;
                case 3:
                    comboBox2.SelectedIndex = 3;
                    break;
                case 4:
                    comboBox2.SelectedIndex = 4;
                    break;
                case 5:
                    comboBox2.SelectedIndex = 5;
                    break;
            }
        }

        public void checkboxesToFighter()
        {
            //Speichert die Werte der Checkboxen in den aktiven Kämpfer
            foreach (var cb in checkBoxes)
            {
                activeFighter.statuses[cb.Key] = (activeFighter.statuses[cb.Key].Item1, cb.Value.Checked);
            }
        }

        private void addCheckBoxes()
        {
            //Checkboxes anhand der Statusmöglichkeiten in fighter.cs generieren
            fighter a = fighters[0];
            int i = 0;
            foreach (var status in a.statuses)
            {
                checkBoxes.Add(status.Key, new CheckBox());
                checkBoxes[status.Key].Checked = status.Value.Item2;
                checkBoxes[status.Key].Text = status.Value.Item1;
                checkBoxes[status.Key].Size = new Size(140, 20);
                checkBoxes[status.Key].Location = new Point(150 * (i % 3) + 20, 20 * (i / 3) + 40);
                Controls.Add(checkBoxes[status.Key]);
                i++;
            }
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            resize();
        }
    }
}