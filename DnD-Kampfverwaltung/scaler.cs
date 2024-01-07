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
                    float currentSize = initialFontSizes[control];
                    control.Font = new Font(control.Font.FontFamily, currentSize * Math.Min(scaleX, scaleY));
                }
                catch { }
            }
        }

        public void quadraticButtons(Button[] buttons)
        {
            //Nimmt Buttons in der übergebenen Liste und skaliert sie quadratisch
            foreach (Button button in buttons)
            {
                try
                {
                    button.Location = new Point(button.Left + (button.Width - button.Height), button.Top);
                    button.Size = new Size(button.Height, button.Height);
                }
                catch { }
            }
        }

        public void quadraticButtonsStatus(List<fighter> fighters, Dictionary<string, Button> checkBoxes)
        {
            //Buttons quadratisch formatieren (die automatisch generiert wurden (Statusverwaltung Form4))
            fighter f = new fighter("", false);
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

        public void resolutionAdept(Form formA)
        {
            //Verhältnis zwischen der aktuellen Bildschirmauflösung und der Standardauflösung berechnen
            float scaleX = (float)Screen.PrimaryScreen.Bounds.Width / 1920;
            float scaleY = (float)Screen.PrimaryScreen.Bounds.Height / 1080;

            //Skalierungsfaktor bestimmen (Minimum, um das Seitenverhältnis zu erhalten)
            float scale = Math.Min(scaleX, scaleY);

            //Formulargröße und Position anpassen
            formA.Width = (int)(formA.Width * scale);
            formA.Height = (int)(formA.Height * scale);

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