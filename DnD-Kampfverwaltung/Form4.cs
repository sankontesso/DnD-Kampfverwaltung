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
        List<String> fighters;
        public Form4(List<String> fighters)
        {
            InitializeComponent();
            this.fighters = fighters;
            fillPlayerComboBox();
        }

        private void fillPlayerComboBox()
        {
            foreach(String fighter in fighters)
            {
                playerComboBox.Items.Add(fighter);
            }
        }
    }
}
