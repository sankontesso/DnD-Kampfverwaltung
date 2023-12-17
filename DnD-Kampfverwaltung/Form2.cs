using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DnD_Kampfverwaltung
{
    public partial class Form2 : Form
    {
        //Variablen für Verwaltung
        private int counter; //Aktuelle Rundenzeit
        private int counterMax; //Standardrundenzeit
        private int blockTime; //Zeit, die "Next" nach Betätigung geblockt wird (in Timer-Funktion festgelegt)
        private int activeFighter; //Aktuelle Kämpfernummer
        Label[] fighterLabels = new Label[5]; //Labels für die Ausgabe der Reihenfolge
        private int round = 1; //Rundenzähler

        //Liste der Kämpfer
        List<fighter> fighters = new List<fighter>();

        //Variablen für das Resizing
        private Dictionary<Control, Rectangle> initialFormSize = new Dictionary<Control, Rectangle>();
        private Dictionary<Control, float> initialFontSizes = new Dictionary<Control, float>();
        private int standardSizeX;
        private int standardSizeY;

        public Form2(List<fighter> fighters, int timePerRound)
        {
            InitializeComponent();
            //Wenn Rundenzeit angegeben, passe Werte an
            counterMax = 10 * timePerRound;
            this.fighters = fighters;
            this.Text = "W2.0 Kampf";

            //Labels dem Array hinzufügen
            fighterLabels[0] = activeLabel;
            fighterLabels[1] = secondLabel;
            fighterLabels[2] = thirdLabel;
            fighterLabels[3] = fourthLabel;
            fighterLabels[4] = fifthLabel;

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

            //Starte den Kampf
            startBattle();
        }

        private void startBattle()
        {
            //Einmalige Ausführung zum Starten des Kampfes
            activeLabel.Text = fighters[0].name;
            counter = counterMax;
            //Prüfung und ggf. Verdoppelung von Zugzeiten
            if (fighters[activeFighter].doubleTime) counter = counter * 2;
            //Eintragung der Zugzeit und Start des Timers
            timeLabel.Text = seconds_to_minutes(counter);
            timer1.Start();
            //Reihenfolge anzeigen
            showOrder();
        }

        private void showOrder()
        {
            //Liste durchgehen und aktive Kämpfer in Reihenfolge anzeigen
            int fighterCount = fighters.Count();
            for (int i = 0; i < fighterLabels.Count(); i++)
            {
                fighterLabels[i].Text = "";
                if (i < fighters.Count()) fighterLabels[i].Text = fighters[(i + activeFighter) % fighterCount].name;
            }

            //Aktuelle Statusveränderungen dem Anzeigetext hinzufügen
            string statusList = "";
            foreach (var st in fighters[activeFighter].statuses)
            {
                if (st.Value.Item2)
                {
                    if (statusList != "") statusList += ", ";
                    statusList += st.Value.Item1;
                }
            }

            //Erschöpfung dem Text hinzufügen
            if (fighters[activeFighter].exhaustion > 0)
            {
                if (statusList != "") statusList += ", ";
                statusList += "Erschöpfung Stufe " + fighters[activeFighter].exhaustion;
            }

            //Statustext an das Label übergeben
            statusLabel.Text = statusList;
        }

        private void nextFighter()
        {
            //Nur Next-Funktion ausführen, wenn Blocktime 0 oder darunter ist
            if (blockTime <= 0)
            {
                //Nächster Kampfteilnehmer
                activeFighter++;

                //Rundenzähler aktualisieren
                if (activeFighter >= fighters.Count)
                {
                    activeFighter = 0;
                    round++;
                    roundsLabel.Text = "Runde: " + round + ", Kampfdauer: " + (round - 1) * 6 + "s";
                }

                //Timer zurücksetzen und Reihenfolge passend anzeigen
                timer1.Stop();
                showOrder();
                counter = counterMax;

                //Blocktime zurücksetzen (x * 100ms)
                blockTime = 5;

                //Ggf. Zugzeit verdoppeln
                if (fighters[activeFighter].doubleTime) counter = counter * 2;
                timeLabel.Text = seconds_to_minutes(counter);
                timer1.Start();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            nextFighter();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (fighters.Count() > 1) //Wenn mehr als 1 Kämpfer aktiv, entferne Kämpfer
            {
                fighters.RemoveAt(activeFighter);
            }
            else //Sonst schließe das Kampfsystem
            {
                this.Close();
            }
            showOrder();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Zugzeit runterzählen
            counter--;
            timeLabel.Text = seconds_to_minutes(counter);
            //Geblockte Zeit runterzählen
            blockTime--;
        }

        public string seconds_to_minutes(int seconds)
        {
            string minutes = "";
            //Umrechnen, weil Timerintervall 100ms sind
            seconds = seconds / 10;

            //Wenn negative Zeit, das "-" vor die Ausgabe setzen
            if (seconds < 0)
            {
                minutes = "-";
                seconds = -seconds;
            }

            //Formatierung der restlichen Ausgabe
            minutes += "" + seconds / 60 + ":";

            //Bei einstelliger Sekundenausgabe eine Null vorstellen
            if (seconds % 60 < 10) minutes += "0";
            minutes += seconds % 60;
            return minutes;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Bei Tastaturanschlag, nächster Kämpfer, bei ESC Kampf beenden
            if (keyData == Keys.Escape) this.Close();
            nextFighter();
            return true;
        }

        private void newFighterButton_Click(object sender, EventArgs e)
        {
            //Dialog generieren
            Form3 dialog = new Form3();
            dialog.addButton.DialogResult = DialogResult.OK;
            DialogResult dialogResult = dialog.ShowDialog();

            //Wenn Textfeld nicht leer und Dialog bestätigt
            if (dialogResult == DialogResult.OK && dialog.newFighter.Text != "" && dialog.newFighter.Text != " ")
            {
                //Kämpfer der Liste hinzufügen
                fighters.Insert(activeFighter + 1, new fighter(dialog.newFighter.Text, dialog.checkBox1.Checked));
                showOrder(); //Neue Reihenfolge anzeigen
            }
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
                control.Font = new Font(control.Font.FontFamily, currentSize * Math.Min(scaleX, scaleY), control.Font.Style);
            }

            //Label Inhalte anpassen
            //foreach(Label l in fighterLabels) fitLabelToContent(l);
        }

        /*private void fitLabelToContent(Label l)
        {
            int maxSize = l.Size.Width;

            if (TextRenderer.MeasureText(l.Text, l.Font).Width <= maxSize) return;

            string labelText = l.Text;
            string textNumber = "..." + Regex.Replace(l.Text, "[^0-9]", "");
            labelText = Regex.Replace(l.Text, "[0-9]", "");

            for (int i = 0; i < labelText.Length; i++) {
                if(TextRenderer.MeasureText(labelText.Substring(i + 1) + textNumber, l.Font).Width >= maxSize)
                {
                    l.Text = labelText.Substring(i) + textNumber;
                    return;
                }
            }       
        }*/

        private void Form2_Resize(object sender, EventArgs e)
        {
            resize();
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            //Dialog generieren
            Form4 dialog = new Form4(fighters, activeFighter);
            dialog.acceptButton.DialogResult = DialogResult.OK;
            DialogResult dialogResult = dialog.ShowDialog();

            //Zeige die aktualisierten Werte an
            showOrder();
        }
    }
}