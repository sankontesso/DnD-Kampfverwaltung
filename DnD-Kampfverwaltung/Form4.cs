using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Kampfverwaltung
{
    public partial class Form4 : Form
    {
        List<fighter> fighters = new List<fighter>();
        Dictionary<string, Button> checkBoxes = new Dictionary<string, Button>();
        fighter activeFighter;

        //Variablen für das Resizing
        private Dictionary<Control, Rectangle> initialFormSize = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> initialFontSizes = new Dictionary<Control, float>();
        private int standardSizeX;
        private int standardSizeY;
        scaler scaler = new scaler();

        public Form4(List<fighter> fighters, int fighterNumber)
        {
            InitializeComponent();
            this.Text = "Statusverwaltung";
            this.fighters = fighters;

            //Comboboxmöglichkeiten hinzufügen
            foreach (fighter a in fighters)
            {
                comboBox1.Items.Add(a.name);
            }

            //Aktuellen Kämpfer auswählen
            comboBox1.SelectedIndex = fighterNumber;
            activeFighter = fighters[fighterNumber];

            //Checkboxes anhand der Statusmöglichkeiten in fighter.cs generieren
            addCheckBoxes();

            //Daten des aktuellen Kämpfers anzeigen
            fighterToCheckboxes();

            //Fenstergröße & Positionen + Größen der Controls für den Resize-Befehl speichern
            foreach (Control control in this.Controls)
            {
                initialFormSize[control] = control.Bounds;
                initialFontSizes[control] = control.Font.Size;
            }
            standardSizeX = this.Width;
            standardSizeY = this.Height;

            //Skalierung an die Bildschirmauflösung
            scaler.resolutionAdept(standardSizeX, standardSizeY, this);

            //Fenster maximieren
            this.WindowState = FormWindowState.Maximized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Auswahl des Kämpfers in der Combobox
            checkboxesToFighter();
            setActiveFighter();
            fighterToCheckboxes();
        }

        private void setActiveFighter()
        {
            foreach (fighter f in fighters)
            {
                if (f.name == comboBox1.SelectedItem.ToString()) activeFighter = f;
            }
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
                if (activeFighter.statuses[cb.Key].Item2)
                {
                    cb.Value.Text = "X";
                }
                else
                {
                    cb.Value.Text = "";
                }
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
                activeFighter.statuses[cb.Key] = (activeFighter.statuses[cb.Key].Item1, cb.Value.Text == "X", activeFighter.statuses[cb.Key].Item3);
            }
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            checkboxesToFighter();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //Alle Checkboxen zurücksetzen
            foreach (var cb in checkBoxes)
            {
                cb.Value.Text = "";
            }
            //Kämpferdaten an Checkboxen anpassen und Erschöpfung entfernen
            checkboxesToFighter();
        }

        private void addCheckBoxes()
        {
            //Checkboxes anhand der Statusmöglichkeiten in fighter.cs generieren
            fighter a = fighters[0];
            int i = 0;
            foreach (var status in a.statuses)
            {
                //Button als Checkboxen einfügen, für die Skalierbarkeit
                checkBoxes.Add(status.Key, new Button());
                if(status.Value.Item2) checkBoxes[status.Key].Text = "X";
                checkBoxes[status.Key].Text = status.Value.Item1;
                checkBoxes[status.Key].Size = new Size(18, 18);
                checkBoxes[status.Key].Location = new Point(150 * (i % 3) + 20, 20 * (i / 3) + 40);
                checkBoxes[status.Key].Click += buttonPressed;

                //Beschriftungen für die Zustände einfügen
                Label statusLabel = new Label();
                statusLabel.Text = status.Value.Item1 + " [" + status.Value.Item3 + "]";
                statusLabel.Size = new Size(120, 20);
                statusLabel.Location = new Point(150 * (i % 3) + 40, 20 * (i / 3) + 40);
                
                //Hinzufügen zum Formular
                Controls.Add(statusLabel);
                Controls.Add(checkBoxes[status.Key]);
                i++;
            }
            //Anpassung der Buttonhöhe anhand der Anzahl der Checkboxen
            acceptButton.Location = new Point(acceptButton.Left, 20 * (i / 3) + 60);
            resetButton.Location = new Point(resetButton.Left, 20 * (i / 3) + 60);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Wenn ESC gedrückt wird, Fenster schließen, bei ENTER Kampf starten
            switch (keyData)
            {
                case Keys.Escape:
                    this.Close();
                    return true;
                case Keys.Enter:
                    acceptButton.PerformClick();
                    return true;
                case Keys.R:
                    resetButton.PerformClick();
                    return true;
                default:
                    //Generierte Buchstaben der Statuse
                    foreach(var status in activeFighter.statuses)
                    {
                        if (status.Value.Item3.Equals(keyData.ToString()))
                        {
                            checkBoxes[status.Key].PerformClick();
                        }
                    }

                    return false;
            }
        }

        private void Form4_Resize(object sender, EventArgs e)
        {
            scaler.scale(standardSizeX, standardSizeY, this, initialFormSize, initialFontSizes);

            //Buttons quadratisch formatieren
            fighter f = fighters[0];
            foreach (var status in f.statuses)
            {
                Button a = checkBoxes[status.Key];
                a.Location = new Point(a.Left + (a.Width - a.Height), a.Top);
                a.Size = new Size(a.Height, a.Height);
            }
        }
    }
}