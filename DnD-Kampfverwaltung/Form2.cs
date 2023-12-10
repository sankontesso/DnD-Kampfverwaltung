﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace DnD_Kampfverwaltung
{
    public partial class Form2 : Form
    {
        private int counter; //Aktuelle Rundenzeit
        private int counterMax; //Standardrundenzeit
        private int blockTime = 0; //Zeit, die "Next" nach Betätigung geblockt wird (in Timer-Funktion festgelegt)
        private int activeFighter = 0; //Aktuelle Kämpfernummer
        List<string> fighters; //Liste mit aktiven Kämpfern
        List<bool> doubleTimes; //Liste mit Angaben ob Kämpfer doppelte Zugzeit erhält
        Label[] fighterLabels = new Label[5]; //Labels für die Ausgabe der Reihenfolge
        private int round = 1; //Rundenzähler

        public Form2(List<string> fighters, List<bool> doubleTimes, string timePerRound)
        {
            InitializeComponent();
            //Wenn Rundenzeit angegeben, passe Werte an
            counterMax = 10 * int.Parse(timePerRound);
            this.fighters = fighters;
            this.doubleTimes = doubleTimes;
            //Labels dem Array hinzufügen
            fighterLabels[0] = activeLabel;
            fighterLabels[1] = secondLabel;
            fighterLabels[2] = thirdLabel;
            fighterLabels[3] = fourthLabel;
            fighterLabels[4] = fifthLabel;
            //Starte den Kampf
            startBattle();
        }

        private void startBattle()
        {
            this.Text = "W2.0 Kampf";
            //Einmalige Ausführung zum Starten des Kampfes
            activeLabel.Text = fighters[0];
            counter = counterMax;
            //Prüfung und ggf. Verdoppelung von Zugzeiten
            if (doubleTimes[(activeFighter) % doubleTimes.Count()]) counter = counter * 2;
            //Eintragung der Zugzeit und Start des Timers
            timeLabel.Text = seconds_to_minutes(counter);
            timer1.Start();
            //Reihenfolge anzeigen
            showOrder();
        }

        private void showOrder()
        {
            //Liste durchgehen und aktive Kämpfer in Reihenfolge anzeigen
            for (int i = 0; i < fighterLabels.Count(); i++)
            {
                fighterLabels[i].Text = "";
                if (i < fighters.Count())
                {
                    fighterLabels[i].Text = fighters[(i + activeFighter) % fighters.Count()];
                }
            }
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
                //Blocktime runterzählen
                blockTime = 5;
                //Ggf. Zugzeit verdoppeln
                if (doubleTimes[activeFighter % doubleTimes.Count()]) counter = counter * 2;
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
                fighters.RemoveAt(activeFighter % fighters.Count());
                doubleTimes.RemoveAt(activeFighter % doubleTimes.Count());
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
            if (seconds % 60 < 10) minutes += "0"; //Sonst einstellige Sekundenausgabe
            minutes += seconds % 60;
            return minutes;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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
                fighters.Insert(activeFighter + 1, dialog.newFighter.Text); //Kämpfer der Liste hinzufügen
                doubleTimes.Insert(activeFighter + 1, dialog.checkBox1.Checked); //Eintragung ob Zugzeit verdoppelt wird
                showOrder(); //Neue Reihenfolge anzeigen
            }
        }
    }
}