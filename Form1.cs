

using System.ComponentModel;

namespace Taschenrechner
{
    public partial class Form1 : Form
    {
        public List<double> zahlen = new List<double>();
        public int zahlIndex = 0;

        private List<string> operatoren = new List<string>();

        private string gleichung = "";

        private bool KommaGewählt = false;
        private double exponent = -1;

        private bool ersteZahl = true;

        public List<double> speicher = new List<double>();
        private bool nochNichtGespeichert = true;

        private Color applicationColor;
        private bool FarbeGesetzt = false;

        private bool windowMaximized = false;

        private void ZahlVerarbeiten(double einserkomponent)
        {
            if (ersteZahl)
            {
                zahlen.Add(einserkomponent);

                ersteZahl = false;
            }
           else if (!KommaGewählt)
            {
                zahlen[zahlIndex] = zahlen[zahlIndex] * 10 + einserkomponent;
            }
            else
            {
                zahlen[zahlIndex] += einserkomponent * Math.Pow(10, exponent);

                exponent--;
            }

            gleichung += einserkomponent.ToString();
        }

        private void KommaUndExponentZurücksetzen()
        {
            KommaGewählt = false;
            exponent = -1;
        }

        private void OperatorenHinzufügen(string zeichen)
        {
            zahlIndex++;
            zahlen.Add(0);

            operatoren.Add(zeichen);

            gleichung += " " + zeichen + " ";

            // Natürlich, müssen die Variablen KommaGewählt und exponent zurückgesetzt werden

            KommaUndExponentZurücksetzen();
        }

        private void GleichungAusleeren(double result = 0)
        {
            gleichung = result.ToString();

            operatoren.Clear();
            zahlen.Clear();
            zahlen.Add(result);
            zahlIndex = 0;

            KommaUndExponentZurücksetzen();
        }

        private void Berechnen()
        {
            // 1. Berechne * und /

            List<double> zwischenErgebnisse = new List<double>();

            int i = 0;

            while (i < zahlen.Count)
            {
                // Mit dieser Verzweigung wird
                // sowohl der Fehler "index out of range" bei der der Liste von Operatoren ab
                // als auch die letzte Zahl hinzugefügt unter unten definierten Bedingungen

                if (i >= operatoren.Count)
                {
                    switch (operatoren[i - 1])
                    {
                        case "+":
                            zwischenErgebnisse.Add(zahlen[i]);
                            break;

                        case "-":
                            zwischenErgebnisse.Add(zahlen[i]);
                            break;

                        case "*":
                            zwischenErgebnisse[zwischenErgebnisse.Count - 1] *= zahlen[i];
                            break;

                        case "/":
                            zwischenErgebnisse[zwischenErgebnisse.Count - 1] /= zahlen[i];
                            break;
                    }

                    i++;
                    continue;
                }

                // Zahlen, die vor unten aufgeführten Zeichen stehen, werden
                // in die Zwischenergebnisse gespeichert.

                if (operatoren[i] == "+" || operatoren[i] == "-")
                {
                    zwischenErgebnisse.Add(zahlen[i]);
                    i++;
                    continue;
                }

                // Bei Punktrechenarten werden die Zahlen zuerst berechnet
                // und dann in die Zwischenergebnisse gespeichert. 

                double zahl1 = zahlen[i], zahl2 = zahlen[i + 1];
                
                if (operatoren[i] == "*")
                {
                    zwischenErgebnisse.Add(zahl1 * zahl2);
                }
                else if (operatoren[i] == "/")
                {
                    zwischenErgebnisse.Add(zahl1 / zahl2);
                }

                i += 2;
            }

            // 2. lösche * und /

            while (operatoren.Contains("/") || operatoren.Contains("*"))
            {
                operatoren.Remove("*");
                operatoren.Remove("/");
            }

            // 3. addiere alle Zwischenergebnisse zusammen bzw. subtrahiere sie voneinander

            double result = zwischenErgebnisse[0];

            for (int j = 1; j < zwischenErgebnisse.Count; j++)
            {
                // diese Verzweigung fängt den Fehler "index out of range" bei einer Liste
                // von Operatoren ab

                if (j > operatoren.Count)
                {
                    continue;
                }
                
                if (operatoren[j - 1] == "+")
                {
                    result += zwischenErgebnisse[j];
                }
                else if (operatoren[j - 1] == "-")
                {
                    result -= zwischenErgebnisse[j];
                }
            }

            // Sie setzt den String gleichung

            GleichungAusleeren(result);
        }

        private void StringGleichungUmformen()
        {
            gleichung = "";

            for (int i = 0; i < zahlen.Count; i++)
            {
                if (i >= operatoren.Count)
                {
                    gleichung += zahlen[i].ToString();
                }
                else
                {
                    gleichung += zahlen[i].ToString() + " " + operatoren[i] + " ";
                }
            }
        }

        // Keine Sorge, du musst keine Integrale oder Satz des Pidargoras verwenden;
        // sie quadriert oder zieht die quadratische Wurzel
        private void BerechnenHöhereMathematik(string zeichen)
        {
            // Phasen:
            //  1. letzte Zahl quadrieren oder die quadratische Wurzel davon ziehen
            //  2. den String gleichung umformen

            // 1. letzte Zahl quadrieren oder die quadratische Wurzel davon ziehen

            if (zeichen == "potenz")
            {
                zahlen[zahlIndex] *= zahlen[zahlIndex];
            }
            else if (zeichen == "wurzel")
            {
                zahlen[zahlIndex] = Math.Sqrt(zahlen[zahlIndex]);
            }

            // 2. den String gleichung umformen

           StringGleichungUmformen();
        }
       
        private void Umkehren(string art)
        {
            if (art == "addition")
            {
                zahlen[zahlIndex] = - zahlen[zahlIndex];
            }
            else if (art == "multiplikation")
            {
                zahlen[zahlIndex] = 1 / zahlen[zahlIndex];
            }

            StringGleichungUmformen();
        }
        private void Anzeigen()
        {
            label1.Text = gleichung;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn1_Click(object sender, EventArgs e)
        {

            ZahlVerarbeiten(1);

            Anzeigen();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(2);

            Anzeigen();
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(3);

            Anzeigen();
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(4);

            Anzeigen();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(5);

            Anzeigen();
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(6);

            Anzeigen();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(7);

            Anzeigen();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(8);

            Anzeigen();
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(9);

            Anzeigen();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            ZahlVerarbeiten(0);
            
            Anzeigen();
        }

        private void btnKomma_Click(object sender, EventArgs e)
        {
            KommaGewählt = true;
            gleichung += ",";

            Anzeigen();
        }

        private void btnplus_Click(object sender, EventArgs e)
        {
            OperatorenHinzufügen("+");

            Anzeigen();
        }

        private void btnmal_Click(object sender, EventArgs e)
        {
            OperatorenHinzufügen("*");

            Anzeigen();
        }

        private void btnGleich_Click(object sender, EventArgs e)
        {
            if (zahlen.Count > 1)
            {
                Berechnen();
            }

            Anzeigen();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            OperatorenHinzufügen("-");

            Anzeigen();
        }

        private void btnTeilen_Click(object sender, EventArgs e)
        {
            OperatorenHinzufügen("/");

            Anzeigen();
        }

        private void FarbenZurücksetzen()
        {
            btnMAll.ForeColor = applicationColor;
            btnMC.ForeColor = applicationColor;
            btnMR.ForeColor = applicationColor;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            speicher.Clear();
            nochNichtGespeichert = true;

            FarbenZurücksetzen();
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            speicher.RemoveAt(speicher.Count - 1);
            
            if (speicher.Count == 0)
            {
                nochNichtGespeichert = true;

                FarbenZurücksetzen();
            }
        }

        private void Zahlspeichern()
        {
            speicher.Add(zahlen[zahlIndex]);

            Color color = btnM.ForeColor;
            applicationColor = !FarbeGesetzt ? btnMAll.ForeColor : applicationColor;
            FarbeGesetzt = true;

            btnMAll.ForeColor = color;
            btnMC.ForeColor = color;
            btnMR.ForeColor = color;

            nochNichtGespeichert = false;
        }

        private void GespeicherteZahlVerarbeiten(int prefix)
        {
            if (!gleichung.EndsWith(","))
            {
               if (nochNichtGespeichert)
                {
                    Zahlspeichern();

                    nochNichtGespeichert = false;  
                }
               else
                {
                    speicher[speicher.Count - 1] += prefix * zahlen[zahlIndex];
                }
            }
        }

        private void btnMplus_Click(object sender, EventArgs e)
        {
            GespeicherteZahlVerarbeiten(1);
        }

        private void btnMminus_Click(object sender, EventArgs e)
        {
            GespeicherteZahlVerarbeiten(-1);
        }

        private void btnM_Click(object sender, EventArgs e)
        {
            Zahlspeichern();
        }

        private void btnMAll_Click(object sender, EventArgs e)
        {
            if (!nochNichtGespeichert)
            {
                Form2 speicherForm = new Form2();
                CheckedListBox kopie = speicherForm.speicherListe;
                speicherForm.instance = this;

                foreach (double zahl in speicher)
                {
                    kopie.Items.Add(zahl.ToString());
                }

                speicherForm.Show();
            }
        }

        private void btnPow_Click(object sender, EventArgs e)
        {
            BerechnenHöhereMathematik("potenz");

            Anzeigen();
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            BerechnenHöhereMathematik("wurzel");

            Anzeigen();
        }

        private void btnKehrwert_Click(object sender, EventArgs e)
        {
            Umkehren("multiplikation");

            Anzeigen();
        }

        private void btnZeichenwechsel_Click(object sender, EventArgs e)
        {
            Umkehren("addition");

            Anzeigen();
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            zahlen[zahlIndex] /= 100;

            StringGleichungUmformen();

            Anzeigen();
        }

        private void OperatorLöschen()
        {
            operatoren.RemoveAt(operatoren.Count - 1);

            zahlen.RemoveAt(zahlIndex);
            zahlIndex--;

            KommaUndExponentZurücksetzen();
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (!gleichung.EndsWith(" "))
            {
                zahlen[zahlIndex] = 0;

                KommaUndExponentZurücksetzen();
            }
            
            StringGleichungUmformen();

            Anzeigen();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            // Sie setzt den String gleichung
            
            GleichungAusleeren();

            Anzeigen();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (gleichung.EndsWith(" "))
            {
                gleichung = gleichung.Substring(0, gleichung.Length - 3);

                OperatorLöschen();
            }
            else
            {
               string copy = zahlen[zahlIndex].ToString();
               string[] zifferBereiche = copy.Split(",");

               if (zifferBereiche.Length == 2)
               {
                    string nachkommastellen = zifferBereiche[1];

                    zifferBereiche[1] = nachkommastellen.Substring(0, nachkommastellen.Length - 1);

                    if (zifferBereiche[1].Length <= 0)
                    {
                        KommaUndExponentZurücksetzen();
                    }
                    else
                    {
                        exponent = -1 * zifferBereiche[1].Length;
                    }
               }
               else if (zifferBereiche.Length == 1)
               {
                    string ziffern = zifferBereiche[0];

                    zifferBereiche[0] = ziffern.Substring(0, ziffern.Length - 1);
               }

                copy = zifferBereiche.Length == 2 && !zifferBereiche[1].Equals("") ? String.Join(",", zifferBereiche) : zifferBereiche[0];

                if (copy.Equals(""))
                {
                    zahlen.RemoveAt(zahlIndex);
                    zahlIndex--;
                    ersteZahl = true;
                }
                else
                {
                    zahlen[zahlIndex] = Convert.ToDouble(copy);
                }
            }

            ersteZahl = zahlen.Count == 0 ? true : false;
            zahlIndex = zahlIndex < 0 ? 0 : zahlIndex;

            StringGleichungUmformen();
            Anzeigen();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            windowMaximized = !windowMaximized;

            if (windowMaximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
    }
}