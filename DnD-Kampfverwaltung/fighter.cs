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
        public Dictionary<string, bool> statuses = new Dictionary<string, bool>();

        public fighter(string name, bool doubleTime){
            this.name = name;
            this.doubleTime = doubleTime;

            statuses.Add("Blinded", false);
            statuses.Add("Charmed", true);
            statuses.Add("Deafened", false);
            statuses.Add("Frightened", false);
            statuses.Add("Grappled", false);
            statuses.Add("Incapacitated", false);
            statuses.Add("Invisible", false);
            statuses.Add("Paralyzed", false);
            statuses.Add("Petrified", false);
            statuses.Add("Poisened", false);
            statuses.Add("Prone", false);
            statuses.Add("Restrained", false);
            statuses.Add("Stunned", false);
            statuses.Add("Unconscious", false);
            statuses.Add("Exhaustion Lvl 2", false);
            statuses.Add("Exhaustion Lvl 3", false);
            statuses.Add("Exhaustion Lvl 4", false);
            statuses.Add("Exhaustion Lvl 5", false);
        }
    }
}
