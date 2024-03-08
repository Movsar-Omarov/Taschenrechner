using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner
{
    public partial class Form2 : Form
    {
        public Form1 instance;
        
        public bool buttonMinusGeklickt;
        public bool buttonPlusGeklickt;

        public CheckedListBox speicherListe;

        private Color standardFarbe;
        private Color gewählteFarbe = Color.Cyan;

        public Form2()
        {
            InitializeComponent();

            speicherListe = checkedListBox1;
            standardFarbe = btnMMinus.BackColor;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            buttonMinusGeklickt = true;
            buttonPlusGeklickt= false;

            btnMMinus.BackColor = gewählteFarbe;
            btnMPlus.BackColor = standardFarbe;
        }

        private void btnBerechnen_Click(object sender, EventArgs e)
        {
            double prefix = 0;
           
            if (buttonMinusGeklickt)
            {
                prefix = -1;
            }
            else if (buttonPlusGeklickt)
            {
                prefix = 1;
            }

            List<double> zahlen = instance.zahlen;
            int zahlIndex = instance.zahlIndex;
            
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                instance.speicher[i] += prefix * zahlen[zahlIndex];
            }

            this.Close();
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            buttonPlusGeklickt = true;
            buttonMinusGeklickt = false;

            btnMPlus.BackColor = gewählteFarbe;
            btnMMinus.BackColor = standardFarbe;
        }
    }
}
