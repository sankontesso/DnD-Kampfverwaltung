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
        public Dictionary<string, (string, bool)> statuses = new Dictionary<string, (string, bool)>();
        public int exhaustion = 0;

        public fighter(string name, bool doubleTime){
            this.name = name;
            this.doubleTime = doubleTime;

            statuses.Add("blinded", ("Geblendet", false));
            statuses.Add("charmed", ("Bezaubert", false));
            statuses.Add("deafend", ("Taub", false));
            statuses.Add("frightened", ("Verängstigt", false));
            statuses.Add("grappled", ("Gepackt", false));
            statuses.Add("incapacitated", ("Kampfunfähig", false));
            statuses.Add("invisible", ("Unsichtbar", false));
            statuses.Add("paralyzed", ("Gelähmt", false));
            statuses.Add("petrified", ("Versteinert", false));
            statuses.Add("poisened", ("Vergiftet", false));
            statuses.Add("prone", ("Liegend", false));
            statuses.Add("restrained", ("Festgesetzt", false));
            statuses.Add("stunned", ("Betäubt", false));
            statuses.Add("unconscious", ("Bewusstlos", false));
        }
    }
}
