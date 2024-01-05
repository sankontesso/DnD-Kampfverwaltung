using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD_Kampfverwaltung
{
    internal class scaler
    {
        public scaler()
        {
        }

        public void scale(int standardSizeX, int standardSizeY, Form formA,
            Dictionary<Control, Rectangle> initialFormSize, Dictionary<Control, float> initialFontSizes)
        {
            //Skalierungsfaktor bestimmen
            float scaleX = (float)formA.Size.Width / (float)standardSizeX;
            float scaleY = (float)formA.Size.Height / (float)standardSizeY;

            //Alle Positionen, Größen und Schriftgrößen anpassen
            foreach (Control control in formA.Controls)
            {
                try
                {
                    control.Bounds = new Rectangle(
                        (int)(initialFormSize[control].Left * scaleX),
                         (int)(initialFormSize[control].Top * scaleY),
                          (int)(initialFormSize[control].Width * scaleX),
                           (int)(initialFormSize[control].Height * scaleY)
                           );

                    /*control.Left = (int)(initialFormSize[control].Left * scaleX);
                    control.Top = (int)(initialFormSize[control].Top * scaleY);
                    control.Width = (int)(initialFormSize[control].Width * scaleX);
                    control.Height = (int)(initialFormSize[control].Height * scaleY);*/

                    float currentSize = initialFontSizes[control];
                    control.Font = new Font(control.Font.FontFamily, currentSize * Math.Min(scaleX, scaleY));
                }
                catch { }
            }
        }

        public void quadraticButtons(Button[] buttons)
        {
            //Nimmt Buttons in der übergebenen Liste und skaliert sie quadratisch
            for (int i = 0; i < buttons.Length; i++)
            {
                try
                {
                    buttons[i].Location = new Point(buttons[i].Left + (buttons[i].Width - buttons[i].Height), buttons[i].Top);
                    buttons[i].Size = new Size(buttons[i].Height, buttons[i].Height);
                }
                catch { }
            }
        }

        public void resolutionAdept(int standardSizeX, int standardSizeY, Form formA)
        {
            //Verhältnis zwischen der aktuellen Bildschirmauflösung und der Standardauflösung berechnen
            float scaleX = (float)Screen.PrimaryScreen.Bounds.Width / standardSizeX;
            float scaleY = (float)Screen.PrimaryScreen.Bounds.Height / standardSizeY;

            //Skalierungsfaktor bestimmen (Minimum, um das Seitenverhältnis zu erhalten)
            float scale = Math.Min(scaleX, scaleY);

            //Formulargröße und Position anpassen
            formA.Width = (int)(standardSizeX * scale);
            formA.Height = (int)(standardSizeY * scale);
            formA.Location = new Point((Screen.PrimaryScreen.Bounds.Width - formA.Width) / 2,
                                       (Screen.PrimaryScreen.Bounds.Height - formA.Height) / 2);

            //Alle Steuerelemente und Schriftarten skalieren
            foreach (Control control in formA.Controls)
            {
                try
                {
                    control.Bounds = new Rectangle((int)(control.Left * scale),
                        (int)(control.Top * scale),
                        (int)(control.Width * scale),
                        (int)(control.Height * scale)
                        );
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * scale);

                    /*control.Left = (int)(control.Left * scale);
                    control.Top = (int)(control.Top * scale);
                    control.Width = (int)(control.Width * scale);
                    control.Height = (int)(control.Height * scale);
                    control.Font = new Font(control.Font.FontFamily, control.Font.Size * scale);*/
                }catch { }
            }

            formA.Size = formA.MaximumSize;
        }

        public void quadraticButtonsStatus(List<fighter> fighters, Dictionary<string, Button> checkBoxes)
        {
            //Buttons quadratisch formatieren (nicht per scaler, da funktional hinzugefügt wurde)
            fighter f = fighters[0];
            foreach (var status in f.statuses)
            {
                try
                {
                    Button a = checkBoxes[status.Key];
                    a.Location = new Point(a.Left + (a.Width - a.Height), a.Top);
                    a.Size = new Size(a.Height, a.Height);
                }
                catch { }
            }

        }

        public void fitLabelToContent(Label l)
        {
            int maxSize = l.Size.Width;

            if (TextRenderer.MeasureText(l.Text, l.Font).Width <= maxSize) return;

            string labelText = l.Text;
            string textNumber = "..." + Regex.Replace(l.Text, "[^0-9]", "");
            labelText = Regex.Replace(l.Text, "[0-9]", "");

            for (int i = 0; i < labelText.Length; i++)
            {
                if (TextRenderer.MeasureText(labelText.Substring(i + 1) + textNumber, l.Font).Width >= maxSize)
                {
                    l.Text = labelText.Substring(i) + textNumber;
                    return;
                }
            }
        }

    }
}