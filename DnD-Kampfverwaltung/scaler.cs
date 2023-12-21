using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
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
                control.Left = (int)(initialFormSize[control].Left * scaleX);
                control.Top = (int)(initialFormSize[control].Top * scaleY);
                control.Width = (int)(initialFormSize[control].Width * scaleX);
                control.Height = (int)(initialFormSize[control].Height * scaleY);

                float currentSize = initialFontSizes[control];
                control.Font = new Font(control.Font.FontFamily, currentSize * Math.Min(scaleX, scaleY));
            }
        }

        public void quadraticButtons(Button[] buttons)
        {
            //Nimmt Buttons in der übergebenen Liste und skaliert sie quadratisch
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Location = new Point(buttons[i].Left + (buttons[i].Width - buttons[i].Height), buttons[i].Top);
                buttons[i].Size = new Size(buttons[i].Height, buttons[i].Height);
            }
        }

        public void resolutionAdept(int standardSizeX, int standardSizeY, Form formA)
        {
            // Verhältnis zwischen der aktuellen Bildschirmauflösung und der Standardauflösung berechnen
            float scaleX = (float)Screen.PrimaryScreen.Bounds.Width / standardSizeX;
            float scaleY = (float)Screen.PrimaryScreen.Bounds.Height / standardSizeY;

            // Skalierungsfaktor bestimmen (Minimum, um das Seitenverhältnis zu erhalten)
            float scale = Math.Min(scaleX, scaleY);

            // Formulargröße und Position anpassen
            formA.Width = (int)(standardSizeX * scale);
            formA.Height = (int)(standardSizeY * scale);
            formA.Location = new Point((Screen.PrimaryScreen.Bounds.Width - formA.Width) / 2,
                                       (Screen.PrimaryScreen.Bounds.Height - formA.Height) / 2);

            // Alle Steuerelemente und Schriftarten skalieren
            foreach (Control control in formA.Controls)
            {
                control.Left = (int)(control.Left * scale);
                control.Top = (int)(control.Top * scale);
                control.Width = (int)(control.Width * scale);
                control.Height = (int)(control.Height * scale);
                control.Font = new Font(control.Font.FontFamily, control.Font.Size * scale);
            }

            formA.Size = formA.MaximumSize;
        }
    }
}