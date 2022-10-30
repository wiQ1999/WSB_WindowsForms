using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Notatnik : Form
    {
        public Notatnik()
        {
            InitializeComponent();
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> tekst = new List<string>();
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string nazwaPliku = openFileDialog1.FileName;
                    using (StreamReader sr = new StreamReader(nazwaPliku))
                    {
                        string wiersz;
                        while ((wiersz = sr.ReadLine()) != null)
                            tekst.Add(wiersz);
                    }
                }
                textBox1.Lines = tekst.ToArray();
            }
            catch (Exception info)
            {
                MessageBox.Show("Błąd odczytu pliku " + info.Message);
            }
        }

        private void zapiszJakoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                ZapiszDoPlikuTekstowego(saveFileDialog1.FileName, textBox1.Lines);
        }

        public static void ZapiszDoPlikuTekstowego(string nazwaPliku, string[] tekst)
        {
            using (StreamWriter sw = new StreamWriter(nazwaPliku))
                foreach (string wiersz in tekst)
                    sw.WriteLine(wiersz);
        }
    }
}
