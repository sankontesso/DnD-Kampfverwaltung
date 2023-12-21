using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnD_Kampfverwaltung
{
    public class fighter
    {
        public string name;
        public bool doubleTime;
        public Dictionary<string, (string, bool, string)> statuses = new Dictionary<string, (string, bool, string)>();
        public int exhaustion = 0;

        public fighter(string name, bool doubleTime){
            this.name = name;
            this.doubleTime = doubleTime;

            statuses.Add("blinded", ("Geblendet", false, "B"));
            statuses.Add("charmed", ("Bezaubert", false, "C"));
            statuses.Add("deafend", ("Taub", false, "T"));
            statuses.Add("frightened", ("Verängstigt", false, "A"));
            statuses.Add("grappled", ("Gepackt", false, "P"));
            statuses.Add("incapacitated", ("Kampfunfähig", false, "K"));
            statuses.Add("invisible", ("Unsichtbar", false, "U"));
            statuses.Add("paralyzed", ("Gelähmt", false, "Y"));
            statuses.Add("petrified", ("Versteinert", false, "S"));
            statuses.Add("poisened", ("Vergiftet", false, "G"));
            statuses.Add("prone", ("Liegend", false, "L"));
            statuses.Add("restrained", ("Festgesetzt", false, "F"));
            statuses.Add("stunned", ("Betäubt", false, "X"));
            statuses.Add("unconscious", ("Bewusstlos", false, "O"));
        }
    }
}
